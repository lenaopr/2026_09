
SELECT p.ORPoiId, p.PoiId, p.NameLang1, count(*) AS CompleteOrders_in_30days
FROM [Mars].[dbo].[TakeAwayOrder] tao with (NOLOCK)
inner join mars.dbo.Poi p with (NOLOCK) on (tao.ORPoiId = p.ORPoiId and tao.PoiId = p.PoiId)
WHERE tao.PaymentTime >= DATEADD(day, -30, CAST(GETDATE() AS date))
  AND tao.PaymentTime < CAST(GETDATE() AS date)
  AND tao.PaymentTime IS NOT NULL
  AND tao.Status IN (0, 4, 10)
  and p.Status in (10, 3)
GROUP BY p.ORPoiId, p.PoiId, p.NameLang1
ORDER BY p.ORPoiId, p.PoiId


/*
SELECT
    ORPoiId,
    PoiId,
    COUNT(*) AS poi_row_count
FROM mars.dbo.Poi WITH (NOLOCK)
WHERE Status = 10
GROUP BY ORPoiId, PoiId
HAVING COUNT(*) > 1
ORDER BY poi_row_count DESC, ORPoiId, PoiId;
*/