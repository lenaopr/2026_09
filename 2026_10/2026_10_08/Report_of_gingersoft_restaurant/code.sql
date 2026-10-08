SELECT DISTINCT
    bc.ContractId AS [Contract ID],
    mp.PoiId AS [BBO POIID],
    mp.ORPoiId AS [OR POIID],
    orp.NameLang1 AS [Restaurant Name Lang1],
    orp.Status AS [OR POI status],
    N'PayAtRestaurant' AS [Contract Type],
    bc.ContractStartTime AS [Contract Start Date],
    bc.ContractEndTime AS [Contract End Date]
FROM dbo.BizContract bc WITH (NOLOCK)
INNER JOIN dbo.BizService bs WITH (NOLOCK)
    ON bs.ContractId = bc.ContractId
   AND bs.ServiceTypeId = 6           -- PayAtRestaurant
INNER JOIN dbo.Poi mp WITH (NOLOCK)
    ON mp.PoiId = bs.PoiId
INNER JOIN openrice3.dbo.Poi orp WITH (NOLOCK)
    ON orp.PoiId = mp.ORPoiId
WHERE TRY_CONVERT(int, JSON_VALUE(bc.MetaData, '$.IntegratedSystem')) = 14    -- gingersoft
  AND orp.Status = 10                   -- poi status: Normal
ORDER BY bc.ContractId DESC, mp.PoiId;