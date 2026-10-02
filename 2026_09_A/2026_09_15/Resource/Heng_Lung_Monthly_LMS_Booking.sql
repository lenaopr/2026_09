use openrice3;
-- SELECT * from openrice3.dbo.Landmark (NOLOCK) WHERE lower(namelang2) like N'%fashion walk%';
---21	淘大商場
---9313	Fashion Walk
DECLARE @start_date DATE = '2026-09-01',
@end_date DATE = '2026-09-30',
@regionid INT = 0,
@landmarkid INT = 9313;

---- -no. of bookmark (new & accumulate).
---- landmark level
SELECT 
    CASE 
        WHEN GROUPING(CONVERT(varchar(7), bp.CreateTime, 120)) = 1 THEN 'Total'
        ELSE CONVERT(varchar(7), bp.CreateTime, 120)
    END AS Month,
    COUNT(1) AS Count
FROM BookmarkLandmark bp WITH (NOLOCK)
LEFT JOIN landmark l (nolock) on bp.landmarkid=l.LandmarkId
WHERE --bp.source >= 30 AND
l.landmarkid = @landmarkid
AND l.RegionId=@regionid
	--AND bp.Createtime between @start_date and @end_date
GROUP BY 
    ROLLUP(CONVERT(varchar(7), bp.CreateTime, 120))
ORDER BY 
    Month;

/*
---- POI level Bookmark (NN)
SELECT 
    CASE 
        WHEN GROUPING(CONVERT(varchar(7), bp.CreateTime, 120)) = 1 THEN 'Total'
        ELSE CONVERT(varchar(7), bp.CreateTime, 120)
    END AS Month,
    COUNT(1) AS Count
FROM landmarkpoi lp WITH (NOLOCK)
INNER JOIN poi p WITH (NOLOCK) 
    ON lp.poiid = p.poiid
INNER JOIN BookmarkPoi bp WITH (NOLOCK) 
    ON p.poiid = bp.poiid
    --AND bp.source >= 30
WHERE 
    p.regionid = @regionid
    AND lp.landmarkid = @landmarkid
	AND bp.Createtime between @start_date and @end_date
GROUP BY 
    ROLLUP(CONVERT(varchar(7), bp.CreateTime, 120))
ORDER BY 
    Month;
*/

---- No. of Booking
use mars;

SELECT count(distinct bookingid) FROM Booking b(NOLOCK)
LEFT JOIN POI p (nolock) on b.poiid = p.poiid
LEFT JOIN openrice3.dbo.poi op (nolock) on op.poiid = p.orpoiid
LEFT JOIN openrice3.dbo.landmarkpoi lp (NOLOCK) on p.orpoiid = lp.poiid
WHERE p.regionid = @regionid AND 
lp.landmarkid = @landmarkid AND
b.BookingTime between @start_date and @end_date AND
b.Status in (3,4,5,10);


---- No. of Restaurants have services
SELECT COUNT(IIF(bs.ServiceTypeId in (1,101), p.poiid, null)) AS Booking,
COUNT(IIF(bs.ServiceTypeId in (5), p.poiid, null)) AS Voucher,
COUNT(IIF(bs.ServiceTypeId in (4), p.poiid, null)) AS TAS
FROM POI p (nolock)
LEFT JOIN openrice3.dbo.poi op (nolock) on op.poiid = p.orpoiid
LEFT JOIN openrice3.dbo.landmarkpoi lp (NOLOCK) on p.orpoiid = lp.poiid
INNER JOIN BizService bs (nolock) on p.poiid = bs.poiid
WHERE p.regionid = @regionid AND 
lp.landmarkid = @landmarkid AND 
bs.status =10 and bs.ServiceStartTime <@start_date and bs.ServiceEndTime>@end_date
AND op.status=10;

/*
---- No. of Transaction (NN)
SELECT COUNT(IIF(CommodityType in (1), pt.PaymentTransactionId, null)) as  Voucher ,
COUNT(IIF(CommodityType in (9,10), pt.PaymentTransactionId, null)) as  TAS 
from PaymentTransaction pt (nolock) 
LEFT JOIN poi p (NOLOCK) on pt.PoiId = p.PoiId
LEFT JOIN openrice3.dbo.poi op (nolock) on op.poiid = p.orpoiid
LEFT JOIN openrice3.dbo.landmarkpoi lp (NOLOCK) on p.orpoiid = lp.poiid
WHERE pt.status=10 
AND p.RegionId = @regionid
AND lp.landmarkid = @landmarkid
AND CONVERT(date,pt.CreateTime) between @start_date and @end_date;
*/

---- Retail Shops Video Views
SELECT SUM(m.HitCount) FROM openrice3.dbo.media m (nolock)
LEFT JOIN openrice3.dbo.poi op (nolock) on op.poiid = m.poiid
LEFT JOIN openrice3.dbo.landmarkpoi lp (NOLOCK) on m.poiid = lp.poiid
WHERE op.RegionId=@regionid AND
op.poitypeid=10 and op.status=10 AND lp.landmarkid = @landmarkid
and m.MediaUriType=2 and CONVERT(DATE, m.ApproveTime)<=@end_date;

----- Top N Booking
SELECT op.poiid, op.namelang1, count(distinct bookingid) FROM Booking b(NOLOCK)
LEFT JOIN POI p (nolock) on b.poiid = p.poiid
LEFT JOIN openrice3.dbo.poi op (nolock) on op.poiid = p.orpoiid
LEFT JOIN openrice3.dbo.landmarkpoi lp (NOLOCK) on p.orpoiid = lp.poiid
WHERE p.regionid = @regionid AND lp.landmarkid = @landmarkid AND
b.BookingTime between @start_date and @end_date AND
b.Status in (3,4,5,10)
GROUP BY op.poiid, op.namelang1
order by count(distinct bookingid) desc;

