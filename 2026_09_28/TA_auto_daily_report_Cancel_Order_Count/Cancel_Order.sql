 DECLARE @report_date date = CAST(GETDATE() AS date);

    WITH paid_orders AS (                  -- takeawayorder
        SELECT
            tao.ORPoiId,
            tao.PoiId,
            CAST(tao.PaymentTime AS date) AS payment_date,
            tao.Status
        FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
        WHERE tao.PaymentTime >= DATEADD(day, -30, @report_date)
          AND tao.PaymentTime < @report_date
          AND tao.PaymentTime IS NOT NULL
          AND tao.Status IN (0, 4, 10)           --"AutoDeclined": "0",  "CancelledByUser": "4", "Completed": "10"
    ),
    order_counts AS (
        SELECT
            ORPoiId,        -- tao.ORPoiId
            PoiId,          -- tao.PoiId
            SUM(CASE WHEN payment_date = DATEADD(day, -1, @report_date) AND Status IN (0, 4) THEN 1 ELSE 0 END) AS day_1_cancel_order,
            SUM(CASE WHEN payment_date = DATEADD(day, -1, @report_date) AND Status = 10 THEN 1 ELSE 0 END) AS day_1_completed_order,
            SUM(CASE WHEN payment_date = DATEADD(day, -2, @report_date) AND Status IN (0, 4) THEN 1 ELSE 0 END) AS day_2_cancel_order,
            SUM(CASE WHEN payment_date = DATEADD(day, -2, @report_date) AND Status = 10 THEN 1 ELSE 0 END) AS day_2_completed_order,
            SUM(CASE WHEN payment_date = DATEADD(day, -3, @report_date) AND Status IN (0, 4) THEN 1 ELSE 0 END) AS day_3_cancel_order,
            SUM(CASE WHEN payment_date = DATEADD(day, -3, @report_date) AND Status = 10 THEN 1 ELSE 0 END) AS day_3_completed_order,
            SUM(CASE WHEN Status IN (0, 4) THEN 1 ELSE 0 END) AS past_30_days_cancel_order,
            SUM(CASE WHEN Status = 10 THEN 1 ELSE 0 END) AS past_30_days_completed_order
        FROM paid_orders
        GROUP BY ORPoiId, PoiId
    )
    SELECT                                   -- takeawayorder join mars.poi
        p.ORPoiId AS [OR POIID],
        p.PoiId AS [BBO POIID],               -- mars poiid
        p.NameLang1 AS [Restaurant Name(Lang 1)],
        CONCAT(oc.day_1_cancel_order, '/', oc.day_1_completed_order) AS [Day-1 (Canceled by System & Customer/Completed Order)],
        CONCAT(oc.day_2_cancel_order, '/', oc.day_2_completed_order) AS [Day-2 (Canceled by System & Customer/Completed Order)],
        CONCAT(oc.day_3_cancel_order, '/', oc.day_3_completed_order) AS [Day-3 (Canceled by System & Customer/Completed Order)],
        CONCAT(oc.past_30_days_cancel_order, '/', oc.past_30_days_completed_order) AS [Past 30 Days (Canceled by System & Customer/Completed Order)]
    FROM order_counts oc
    INNER JOIN mars.dbo.Poi p WITH (NOLOCK)
        ON (p.ORPoiId = oc.ORPoiId and p.PoiId = oc.PoiId)
    WHERE p.Status in (10, 3)         -- 10: normal, 3: renovate
    ORDER BY p.ORPoiId, p.PoiId;