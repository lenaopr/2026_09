USE Mars;
GO

-- Active POIs that have ever joined Voucher service (ServiceTypeId = 28).
SELECT
	mp.PoiId AS mars_poiid,
	mp.OrPoiId AS orpoiid,
	orp.NameLang1 AS poi_name,
	orp.AddressLang1 AS address,
	-- orp.Status AS openrice_poi_status,
 	MIN(bs.ServiceStartTime) AS first_voucher_service_start_time,
	MAX(bs.ServiceEndTime) AS last_voucher_service_end_time,
	COUNT(DISTINCT bs.BizServiceId) AS voucher_service_record_count
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
  AND bs.ServiceTypeId = 28
	AND bc.ContractEndTime >= CAST(GETDATE() AS date)
GROUP BY
	mp.PoiId,
	mp.OrPoiId,
	orp.NameLang1,
	orp.AddressLang1,
	orp.Status
ORDER BY
	first_voucher_service_start_time,
	mp.OrPoiId;
