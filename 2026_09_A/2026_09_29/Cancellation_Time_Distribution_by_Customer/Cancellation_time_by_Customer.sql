/* analyze the distribution of the time between order placement and cancellation for all orders cancelled by customers. 
full monthly reports for June, July, and August
*/

DECLARE @start_date date = '2026-06-01';
DECLARE @end_date date = '2026-09-01';

SELECT
    tao.Status,
    tao.SSOuserId AS SSOuserID,
    CONVERT(char(10), tao.CreateTime, 103) + ' ' + CONVERT(char(5), tao.CreateTime, 108) AS CreateTime,
    CONVERT(char(10), tao.PickupTime, 103) + ' ' + CONVERT(char(5), tao.PickupTime, 108) AS PickupTime,
    CONVERT(char(10), tao.CancelledTime, 103) + ' ' + CONVERT(char(5), tao.CancelledTime, 108) AS Cancel_Order_Time,
    CONVERT(varchar(10), duration.CancelSeconds / 3600) + ':'
        + RIGHT('0' + CONVERT(varchar(2), (duration.CancelSeconds % 3600) / 60), 2) + ':'
        + RIGHT('0' + CONVERT(varchar(2), duration.CancelSeconds % 60), 2)
        AS CancelOrderTime_Minutes,
    CAST(duration.CancelSeconds / 60.0 AS decimal(10, 2)) AS Min,
    CASE
        WHEN duration.CancelSeconds < 5 * 60 THEN '0-5 min'
        WHEN duration.CancelSeconds < 10 * 60 THEN '5-10 min'
        WHEN duration.CancelSeconds < 15 * 60 THEN '10-15 min'
        WHEN duration.CancelSeconds < 20 * 60 THEN '15-20 min'
        WHEN duration.CancelSeconds < 25 * 60 THEN '20-25 min'
        WHEN duration.CancelSeconds < 30 * 60 THEN '25-30 min'
        WHEN duration.CancelSeconds < 35 * 60 THEN '30-35 min'
        WHEN duration.CancelSeconds < 40 * 60 THEN '35-40 min'
        WHEN duration.CancelSeconds < 45 * 60 THEN '40-45 min'
        WHEN duration.CancelSeconds < 50 * 60 THEN '45-50 min'
        WHEN duration.CancelSeconds < 55 * 60 THEN '50-55 min'
        WHEN duration.CancelSeconds < 60 * 60 THEN '55-60 min'
        ELSE '60+ min'
    END AS [Group]
FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
CROSS APPLY (VALUES (DATEDIFF(second, tao.CreateTime, tao.CancelledTime))) duration (CancelSeconds)
WHERE tao.Status = 4                            -- CancelledByUser
    AND tao.CancelledTime >= @start_date
    AND tao.CancelledTime < @end_date
    AND tao.CreateTime IS NOT NULL
    AND tao.CancelledTime IS NOT NULL
ORDER BY tao.CancelledTime;