USE Mars;

-- 從重複地址的 POI 中，提取 Normal (10) & Renovate (3) 
WITH SameAddress AS (
	SELECT
		AddressLang1
	FROM openrice3.dbo.Poi WITH (NOLOCK)
		WHERE RegionId = 0
			AND NULLIF(LTRIM(RTRIM(AddressLang1)), '') IS NOT NULL
	GROUP BY AddressLang1
		HAVING COUNT(*) > 1
)
SELECT
	orp.PoiId AS or_poiid,
	mp.PoiId AS mars_poiid,
	orp.Status AS poi_status,
	CASE orp.Status
		WHEN 10 THEN 'Normal'
		WHEN 3 THEN 'Renovate'
	END AS poi_status_name,
	orp.NameLang1 AS poi_name_1,
	orp.NameLang2 AS poi_name_2,
	orp.AddressLang1 AS address,
	d.NameLang1 AS district,
	orp.CreateTime,
	orp.ModifyTime
FROM SameAddress sa
INNER JOIN openrice3.dbo.Poi orp WITH (NOLOCK)
	ON orp.AddressLang1 = sa.AddressLang1
   AND orp.RegionId = 0
   AND orp.Status IN (3, 10)
LEFT JOIN mars.dbo.Poi mp WITH (NOLOCK)
	ON mp.OrPoiId = orp.PoiId
   AND mp.RegionId = 0
LEFT JOIN openrice3.dbo.District d WITH (NOLOCK)
	ON d.DistrictId = orp.DistrictId
ORDER BY
	orp.AddressLang1,
	CASE orp.Status WHEN 10 THEN 1 WHEN 3 THEN 2 END,
	orp.PoiId;
