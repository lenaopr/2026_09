/*
1345

Takeaway orders - last three months

Auto workflow exclusion is based on the event snapshot in MetaData:
	AcceptedUser.Type = 0 = auto accepted
	ReadyUser.Type    = 0 = auto ready

Cancellation source:
	CancelledUser.Type = 3 = customer
	CancelledUser.Type IN (1, 2, 4), or RejectedUser.Type IN (2, 4) = merchant/POS
	CancelledUser.Type = 0, or RejectedUser.Type = 0 = system
*/

DECLARE @start_date date = '2026-06-01';
DECLARE @end_date date = '2026-09-01';

WITH order_base AS (
		SELECT
				tao.TakeAwayOrderId,
				CASE
						WHEN JSON_VALUE(tao.MetaData, '$.AcceptedUser.Type') = '0'
							OR JSON_VALUE(tao.MetaData, '$.ReadyUser.Type') = '0'
						THEN 1 ELSE 0
				END AS is_auto_workflow,
				JSON_VALUE(tao.MetaData, '$.CancelledUser.Type') AS cancelled_user_type,
				JSON_VALUE(tao.MetaData, '$.RejectedUser.Type') AS rejected_user_type
		FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
		WHERE tao.CreateTime >= @start_date
			AND tao.CreateTime < @end_date
)
SELECT
		COUNT_BIG(*) AS total_transaction,
		SUM(CASE WHEN cancelled_user_type = '3' THEN 1 ELSE 0 END) AS customer_cancel_number,
		SUM(CASE WHEN cancelled_user_type IN ('1', '2', '4')
							 OR rejected_user_type IN ('2', '4') THEN 1 ELSE 0 END) AS merchant_cancel_number,
		SUM(CASE WHEN cancelled_user_type = '0'
							 OR rejected_user_type = '0' THEN 1 ELSE 0 END) AS system_cancel_number
FROM order_base
WHERE is_auto_workflow = 0;


/*
2 & 6

Acceptance time: CreateTime to AcceptedTime.
Ready time: AcceptedTime to ReadyPickupTime.
Manual operations: Event types other than 0.
Extreme long cases: durations over 24h.
6: remove automatic & keep manual 

*/

WITH base_orders AS (
    SELECT
        tao.TakeAwayOrderId,
        tao.CreateTime,
        tao.AcceptedTime,
        tao.ReadyPickupTime,
        JSON_VALUE(tao.MetaData, '$.AcceptedUser.Type') AS accepted_user_type,
        JSON_VALUE(tao.MetaData, '$.ReadyUser.Type') AS ready_user_type
    FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
    WHERE tao.CreateTime >= @start_date
        AND tao.CreateTime < @end_date
),
accept_time AS (
    SELECT
        DATEDIFF(SECOND, CreateTime, AcceptedTime) / 60.0 AS duration_minutes
    FROM base_orders
    WHERE AcceptedTime >= CreateTime
        AND ISNULL(accepted_user_type, '') <> '0'
        AND ISNULL(ready_user_type, '') <> '0'
),
manual_ready_time AS (
    SELECT
        DATEDIFF(SECOND, AcceptedTime, ReadyPickupTime) / 60.0 AS duration_minutes
    FROM base_orders
    WHERE AcceptedTime >= CreateTime
        AND ReadyPickupTime >= AcceptedTime
        AND accepted_user_type IS NOT NULL
        AND accepted_user_type <> '0'
        AND ready_user_type IS NOT NULL
        AND ready_user_type <> '0'
),
timing_base AS (
    SELECT 'merchant_order_accept_time' AS metric, duration_minutes
    FROM accept_time
    WHERE duration_minutes <= 1440

    UNION ALL

    SELECT 'merchant_ready_time', duration_minutes
    FROM manual_ready_time
    WHERE duration_minutes <= 1440
),
timing_percentiles AS (
    SELECT
        metric,
        duration_minutes,
        PERCENTILE_CONT(0.90) WITHIN GROUP (ORDER BY duration_minutes) OVER (PARTITION BY metric) AS p90,
        PERCENTILE_CONT(0.80) WITHIN GROUP (ORDER BY duration_minutes) OVER (PARTITION BY metric) AS p80,
        PERCENTILE_CONT(0.70) WITHIN GROUP (ORDER BY duration_minutes) OVER (PARTITION BY metric) AS p70,
        PERCENTILE_CONT(0.60) WITHIN GROUP (ORDER BY duration_minutes) OVER (PARTITION BY metric) AS p60,
        PERCENTILE_CONT(0.50) WITHIN GROUP (ORDER BY duration_minutes) OVER (PARTITION BY metric) AS p50
    FROM timing_base
)
SELECT
    metric,
    COUNT_BIG(*) AS order_count,
    CAST(MAX(p90) AS DECIMAL(10, 2)) AS p90,
    CAST(MAX(p80) AS DECIMAL(10, 2)) AS p80,
    CAST(MAX(p70) AS DECIMAL(10, 2)) AS p70,
    CAST(MAX(p60) AS DECIMAL(10, 2)) AS p60,
    CAST(MAX(p50) AS DECIMAL(10, 2)) AS p50,
    CAST(AVG(duration_minutes) AS DECIMAL(10, 2)) AS average
FROM timing_percentiles
GROUP BY metric
ORDER BY metric;