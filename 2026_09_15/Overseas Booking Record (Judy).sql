use mars;
--- Must be start of month and start of next month!
DECLARE @start_date DATE = '2026-07-01';
DECLARE @end_date DATE = '2026-08-01';

WITH PROMO_CODE as 
(SELECT b.bookingid, o.PromoCode
 FROM [Mars].[dbo].[Booking] (NOLOCK) b
LEFT JOIN [Mars].[dbo].[OfferWallet] (NOLOCK) ow  ON b.[BookingId] = ow.CommodityId
LEFT JOIN [Mars].[dbo].[Offer] (NOLOCK) o  ON ow.[OfferId] = o.[OfferId]
WHERE  o.[PromoCode] In ('JP30', 'TH30', 'TW30') and  ow.status in (10,15)
  AND BookingTime >= @start_date AND BookingTime < @end_date
),
BOOKING_PROMO_CODE as
(SELECT b.bookingid, o.PromoCode
 FROM [Mars].[dbo].[Booking] (NOLOCK) b
LEFT JOIN [Mars].[dbo].[OfferWallet] (NOLOCK) ow  ON b.[BookingId] = ow.[BookingId]
LEFT JOIN [Mars].[dbo].[Offer] (NOLOCK) o  ON ow.[OfferId] = o.[OfferId]
WHERE o.[PromoCode] In ('TRAVEL', 'TLC') and ow.status in (10,15)
  AND BookingTime >= @start_date AND BookingTime < @end_date
),
GATEWAY_OFFER AS
(SELECT b.bookingid, o.offerid
 FROM [Mars].[dbo].[Booking] (NOLOCK) b
LEFT JOIN [Mars].[dbo].[OfferWallet] (NOLOCK) ow  ON b.[BookingId] = ow.commodityid
LEFT JOIN [Mars].[dbo].[Offer] (NOLOCK) o  ON ow.[OfferId] = o.[OfferId]
WHERE o.OfferType = 17 and ow.status in (10,15)
  AND BookingTime >= @start_date AND BookingTime < @end_date
),
Partner_BookingMenu as (
SELECT bmo.bookingid, sum(Quantity) as MenuSold from partnerbookingmenuorder bmo (nolock)
where bmo.status in (10,15)
group by bmo.bookingid
),
OR_BookingMenu as (
SELECT bmo.bookingid, sum(Quantity) as MenuSold from bookingmenuorder bmo (nolock)
where bmo.status in (10,15)
group by bmo.bookingid
)


-- General Booking Query --
SELECT  IIF(R.regionId=1, 'MO', C.CountryCode), R.NameLang1, P.Poiid AS [BBO POIID], P.NameLang1, b.[BookingId], u.username, b.UserId AS [BBO UserId],--- ou.userid,
-- OU.Email, OU.Phone, 
convert(date,b.BookingTime), convert(time, t.TimeSlotTime), convert(date,SubmitTime), convert(time,SubmitTime), b.AmendedSeat,
IIF(obm.menusold>0, 'yes', IIF(pbm.menusold>0, 'yes', 'no')) as booking_menu,
COALESCE(obm.MenuSold, pbm.menusold) as menu_count,
 IIF(bpc.PromoCode is null, '', bpc.promocode) as booking_promo_code,
case when b.Source=1 then 'Web'
when b.Source=4 then 'WAP'
when b.source in (7,14,15,16,21,25,26) then 'MerchantSite'
when b.Source =12 then 'IPhone'
when b.source=13 then 'Android'
when b.source=41 then 'Google'
else CAST(b.source AS varchar) end as BookingChannel ,
IIF(b.userid!=0 and b.userid in 
		(SELECT userid FROM booking b (NOLOCK) 
		LEFT JOIN [Mars].[dbo].[Poi] p (NOLOCK) ON p.PoiId = b.PoiId 
		WHERE regionid!=0 and b.status=4 and BookingTime >= @start_date AND BookingTime < @end_date), 'Y', 'N') as any_noshow,
 IIF(pc.PromoCode is null, '', pc.promocode) as promo_code,
 IIF(g.offerid is null or g.offerid=0, '', g.offerid) as gateway_offer
  FROM [Mars].[dbo].[Booking] (NOLOCK) b
  LEFT JOIN [Mars].[dbo].[Timeslot] t (NOLOCK) on b.StartTimeSlotId = t.TimeSlotId
  LEFT JOIN [Mars].[dbo].[Poi] p (NOLOCK) ON p.PoiId = b.PoiId
  LEFT JOIN [Mars].[dbo].[Region] R (NOLOCK) ON R.RegionId = P.RegionId
  LEFT JOIN [Mars].[dbo].[Country] C (NOLOCK) ON C.CountryId = R.CountryId
  LEFT JOIN [Mars].[dbo].[User] U (NOLOCK) ON U.UserId = b.UserId
  LEFT JOIN [Openrice3].[dbo].[User] OU (NOLOCK) ON u.ssouserid = ou.ssouserid
  LEFT JOIN PROMO_CODE pc on b.bookingid = pc.BookingId
  LEFT JOIN BOOKING_PROMO_CODE bpc on b.bookingid = bpc.bookingid
  LEFT JOIN GATEWAY_OFFER g on b.bookingid = g.BookingId
  LEFT JOIN Partner_BookingMenu pbm on b.BookingId = pbm.BookingId --and c.CountryCode = 'TH'
  LEFT JOIN OR_BookingMenu obm on b.BookingId = obm.BookingId --and c.CountryCode in ('JP', 'HK', 'TW', 'SG')
  WHERE b.[Status] In (5,10)
  AND b.BookingTime >= @start_date AND b.BookingTime < @end_date
  AND p.RegionId!=0
  AND p.status not in (2,6)
  ORDER BY BOOKINGID

