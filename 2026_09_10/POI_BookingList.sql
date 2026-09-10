DECLARE @start_date DATE = '2026-06-01';
DECLARE @end_date DATE = '2026-09-01';

-- DistrictId: 1004 = North Point ; 1014 = Quarry Bay.

SELECT
	b.*,
	p.ORPoiId AS or_poiid,
	p.NameLang1 AS poi_name,
	p.AddressLang1 AS poi_address,
	d.NameLang1 AS district_name
FROM mars.dbo.Booking b WITH (NOLOCK)
INNER JOIN mars.dbo.Poi p WITH (NOLOCK)
	ON p.PoiId = b.PoiId
LEFT JOIN openrice3.dbo.District d WITH (NOLOCK)
	ON d.DistrictId = p.DistrictId
WHERE b.Status = 10
  AND b.BookingTime >= @start_date
  AND b.BookingTime < @end_date
  AND p.DistrictId IN (1004, 1014)
ORDER BY b.BookingTime, b.BookingId;
