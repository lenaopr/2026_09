DECLARE @landmarkId as int
DECLARE @START as nvarchar(20)
DECLARE @END as nvarchar(20)
DECLARE @LandmarkName as nvarchar(20)

SET @landmarkId = 42

SET @START = '2026-09-01'
SET @END = '2026-10-01'

SELECT @LandmarkName = Namelang1 FROM openrice3.dbo.Landmark WHERE LandmarkId = @LandmarkId;

---------

SELECT POIID INTO #BBO_POIID FROM mars.dbo.Poi MP WHERE MP.ORPoiId IN (
(SELECT L.Poiid FROM openrice3.dbo.[LandmarkPoi] L
INNER JOIN openrice3.dbo.POI P ON P.Poiid = L.POiid
WHERE LandmarkId = @landmarkId
AND P.[Status] in (3, 10)
)) AND RegionId = 0;

-- Booking
SELECT DISTINCT @LandmarkName AS 'BOOKING', P.NameLang1 FROM mars.dbo.Poi P 
INNER JOIN mars.dbo.BizService BS ON P.Poiid = BS.Poiid
WHERE P.Poiid IN (
SELECT DISTINCT POIID FROM mars.dbo.Booking WHERE
BookingTime > @START AND BookingTime < @END AND [Status] = 10
AND POIID IN (SELECT POIID FROM #BBO_POIID));

--Voucher
SELECT DISTINCT @LandmarkName AS 'Voucher', P.NameLang1 FROM mars.dbo.Poi P 
INNER JOIN mars.dbo.BizService BS ON P.Poiid = BS.Poiid
WHERE BS.ServiceStartTime < @END AND BS.ServiceEndTime >= @END
AND P.POIID IN (SELECT POIID FROM #BBO_POIID)
AND BS.ServiceTypeId IN (5);


--SELECT TAS--
DECLARE @MIN_TakeAwayOrderID AS int


SELECT DISTINCT @LandmarkName aS 'TAS', P.NameLang1 FROM mars.dbo.Poi P 
INNER JOIN mars.dbo.BizService BS ON P.Poiid = BS.Poiid
WHERE BS.ServiceStartTime < @END AND BS.ServiceEndTime >= @END
AND P.POIID IN (
SELECT DISTINCT POIID FROM mars.dbo.TakeAwayOrder (nolock)
WHERE TakeAwayOrderId >= @MIN_TakeAwayOrderID AND CreateTime < @END AND [Status] = 10
AND POIID IN (SELECT POIID FROM #BBO_POIID)

)
AND BS.ServiceTypeId IN (4);

--MEDIA

SELECT @LandmarkName, PP.NameLang1, SUM(HitCount) AS Views FROM openrice3.dbo.[Media] P
INNER JOIN openrice3.dbo.LandmarkPoi LP ON P.Poiid = LP.Poiid
INNER JOIN openrice3.dbo.POi PP ON PP.Poiid = P.PoiId
WHERE LP.LandmarkId = @landmarkId
AND PP.PoiTypeId = 10 
GROUP BY PP.NameLang1


DROP TABLE #BBO_POIID;
    