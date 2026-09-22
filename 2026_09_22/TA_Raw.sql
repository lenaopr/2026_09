/*
TakeAway raw data for the latest 30 days.
Order Accepted Time by Merchant excludes system auto-acceptance (AcceptedUser.Type = 0).
*/

DECLARE @start_date DATE = DATEADD(MONTH, -1, CAST(GETDATE() AS DATE));
DECLARE @end_date DATE = CAST(GETDATE() AS DATE);

SELECT
    tao.TakeAwayOrderId,
    tao.OrderRefId,
    tao.PoiId,
    tao.ORPoiId,
    tao.VendorPoiID,
    tao.Status,
    tao.SSOuserID,
    tao.CreateTime,
    tao.PickupTime,
    tao.CancelledTime AS [Cancel_Order_Time],
    CASE
        WHEN ISNULL(JSON_VALUE(tao.MetaData, '$.AcceptedUser.Type'), '') <> '0'
        THEN tao.AcceptedTime
    END AS [Accepted_Time_by_Merchant],
    tao.AcceptedTime AS [Accepted_Time_by_Merchant_and_AutoSystem]
FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
WHERE tao.CreateTime >= @start_date
  AND tao.CreateTime < @end_date
ORDER BY tao.CreateTime;