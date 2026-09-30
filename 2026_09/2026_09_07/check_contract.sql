USE Mars;
GO

WITH multi_service_poi AS (
    SELECT
        bs.PoiId,
        COUNT(DISTINCT bs.BizServiceId) AS service_record_count
    FROM dbo.BizService bs WITH (NOLOCK)
    INNER JOIN dbo.Poi mp WITH (NOLOCK)
        ON mp.PoiId = bs.PoiId
    INNER JOIN dbo.BizContract bc WITH (NOLOCK)
        ON bc.ContractId = bs.ContractId
    LEFT JOIN openrice3.dbo.Poi orp WITH (NOLOCK)
        ON orp.PoiId = mp.OrPoiId
    WHERE mp.RegionId = 0
        AND mp.Status <> 0
        AND orp.RegionId = 0
        AND orp.Status = 10
        AND bs.ServiceTypeId = 5
        AND bc.ContractEndTime >= CAST(GETDATE() AS date)
    GROUP BY bs.PoiId
    HAVING COUNT(DISTINCT bs.BizServiceId) > 1
)
SELECT
    mp.PoiId AS mars_poiid,
    mp.OrPoiId AS orpoiid,
    orp.NameLang1 AS poi_name,
    multi.service_record_count,
    bs.BizServiceId,
    bs.ContractId,
    bs.ServiceTypeId,
    bs.Status AS biz_service_status,
    bs.ServiceStartTime,
    bs.ServiceEndTime,
    bc.ContractEndTime
FROM multi_service_poi multi
INNER JOIN dbo.BizService bs WITH (NOLOCK)
    ON bs.PoiId = multi.PoiId
INNER JOIN dbo.Poi mp WITH (NOLOCK)
    ON mp.PoiId = bs.PoiId
INNER JOIN dbo.BizContract bc WITH (NOLOCK)
    ON bc.ContractId = bs.ContractId
LEFT JOIN openrice3.dbo.Poi orp WITH (NOLOCK)
    ON orp.PoiId = mp.OrPoiId
WHERE bs.ServiceTypeId = 5
ORDER BY
    mp.OrPoiId,
    bs.ServiceStartTime,
    bs.BizServiceId;