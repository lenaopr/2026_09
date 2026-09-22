SELECT TOP (100)
    tao.TakeAwayOrderId,
    tao.ORPoiId,
    poi.NameLang1 AS poi_name,
    tao.CreateTime,
    tao.AcceptedTime,
    DATEDIFF(MINUTE, tao.CreateTime, tao.AcceptedTime) AS accept_order_time_minutes,
    JSON_VALUE(tao.MetaData, '$.AcceptedUser.Type') AS accepted_user_type,
    JSON_VALUE(tao.MetaData, '$.AcceptedUser.ActionTime') AS accepted_user_action_time,
    JSON_VALUE(tao.MetaData, '$.AcceptedUser.PaymentClientInfo.model') AS device_model,
    tao.ReadyPickupTime,
    tao.CompletedTime
FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
INNER JOIN openrice3.dbo.Poi poi WITH (NOLOCK)
    ON poi.PoiId = tao.ORPoiId
WHERE tao.CreateTime >= '2026-08-01'
  AND tao.CreateTime < '2026-09-01'
  AND tao.Status = 10
  AND tao.AcceptedTime >= tao.CreateTime
  AND DATEPART(HOUR, tao.CreateTime) BETWEEN 0 AND 5
  AND DATEDIFF(MINUTE, tao.CreateTime, tao.AcceptedTime) >= 100
  AND poi.DistrictId IN (1004, 1009, 1014, 1018, 1023)
ORDER BY accept_order_time_minutes DESC;