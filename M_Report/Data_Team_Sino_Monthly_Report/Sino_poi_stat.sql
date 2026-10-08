DECLARE @landmarkId as int
DECLARE @START as nvarchar(20)
DECLARE @END as nvarchar(20)
DECLARE @LandmarkName as nvarchar(20)

SET @landmarkId = 37

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

--No. of POIs - Booking，No. of Booking

SELECT COUNT(DISTINCT POIID)AS 'BOOKING', COUNT(1) FROM mars.dbo.Booking WHERE
BookingTime > @START AND BookingTime < @END AND [Status] = 10
AND POIID IN (SELECT POIID FROM #BBO_POIID);

-- No. of POIs - Voucher，No. of Voucher Transaction

SELECT COUNT(DISTINCT P.NameLang1) FROM mars.dbo.Poi P 
INNER JOIN mars.dbo.BizService BS ON P.Poiid = BS.Poiid
WHERE BS.ServiceStartTime < @END AND BS.ServiceEndTime >= @END
AND P.POIID IN (SELECT POIID FROM #BBO_POIID)
AND BS.ServiceTypeId IN (5);

SELECT COUNT(DISTINCT POIID) AS 'VoucherRedeemed'
FROM mars.dbo.OfferWallet OW 
INNER JOIN mars.dbo.OfferPoi O ON O.OfferId = OW.OfferId
INNER JOIN mars.dbo.Offer OO ON OO.OfferId = O.OfferId
WHERE OW.CreateTime > @START AND OW.CreateTime < @END AND OW.[Status] =15
AND POIID IN (SELECT POIID FROM #BBO_POIID)
AND RedeemPoiId IN (SELECT POIID FROM #BBO_POIID)
AND OO.OfferType IN (7, 18, 22);


-- No. of POIs - Takeaway，No. of Takeaway Transaction
DECLARE @MIN_TakeAwayOrderID AS int

SELECT @MIN_TakeAwayOrderID = MAX(TakeAwayOrderID) FROM mars.dbo.TakeAwayOrder (nolock)
WHERE CreateTime < @Start;

SELECT COUNT(DISTINCT POIID) aS 'TAS', COUNT(1) FROM mars.dbo.TakeAwayOrder (nolock)
WHERE TakeAwayOrderId >= @MIN_TakeAwayOrderID AND CreateTime < @END AND [Status] = 10
AND POIID IN (SELECT POIID FROM #BBO_POIID);

-- Retail POIs Video Views

SELECT SUM(HitCount) AS Views, COUNT(1) AS DistinctPOIs FROM openrice3.dbo.[Media] P
INNER JOIN openrice3.dbo.LandmarkPoi LP ON P.Poiid = LP.Poiid
INNER JOIN openrice3.dbo.POi PP ON PP.Poiid = P.PoiId
WHERE LP.LandmarkId = @landmarkId
AND PP.PoiTypeId = 10;


DROP TABLE #BBO_POIID;
    