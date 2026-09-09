/*
Takeaway orders - last three calendar months through today.

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
