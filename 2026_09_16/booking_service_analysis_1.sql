
Select  B.UserPhoneAreaCode_Hash, COUNT(1) AS booking_#     -- userphoneareacode = homeregion id, if unhashed
FROM dbo.Booking B (nolock)
INNER JOIN dbo.POI P ON P.Poiid = B.PoiId            -- if needed to investigation regional booking
WHERE BookingTime >= '2026-01-01'
AND B.[Status] IN (3, 4, 5, 10)
-- AND P.[RegionId] = 1       -- HK, if needed to investigation regional booking
GROUP BY B.UserPhoneAreaCode_Hash

Select top 100 * FROM dbo.HomeRegion


SELECT B.UserPhoneAreaCode_Hash, COUNT(1) AS booking_#
FROM dbo.Booking B (nolock)
WHERE BookingTime >= '2026-01-01'
AND B.[Status] IN (3, 4, 5, 10)     -- case submitted in (3, 4, 5, 10), attented = 10
GROUP BY B.UserPhoneAreaCode_Hash