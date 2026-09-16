
Select  H.NameLang1 AS Area, COUNT(*) As booking_count 
FROM Booking B (nolock)
INNER JOIN POI P ON P.Poiid = B.PoiId
INNER JOIN HomeRegion H ON HASHBYTES('MD5',cast(H.[HomeRegionId] as varbinary(16))) = DinerPhoneAreaCode_Hash
WHERE BookingTime >= '2026-01-01'
AND B.[Status] IN (3, 4, 5, 10)
AND P.[RegionId] = 0
GROUP BY H.NameLang1, DinerPhoneAreaCode_Hash
ORDER BY booking_count DESC