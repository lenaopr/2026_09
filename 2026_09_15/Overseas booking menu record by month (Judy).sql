use mars;
SELECT CONCAT(YEAR(b.bookingtime), '-', MONTH(b.BookingTime)), c.CountryCode
, count(distinct bpt.bookingId), sum(bmo.Quantity)
from bookingmenuorder bmo (nolock)
left join bookingpaymenttransaction  bpt on bpt.bookingid=bmo.bookingid
left join booking b on bpt.bookingid = b.bookingid
left join poi p (nolock) on b.PoiId = p.PoiId
left join Region r (nolock) on p.RegionId = r.RegionId
left join Country c (nolock) on r.CountryId = c.CountryId
where bmo.status in (10,15) and p.status not in (2,6) and b.status in (5,10)
and bpt.PaymentStatus=10 and bpt.BookingPaymentTransactionType in (1,7)
and c.CountryCode in ('JP', 'TW')
group by CONCAT(YEAR(b.bookingtime), '-', MONTH(b.BookingTime)), c.CountryCode
order by 2, 1 desc


SELECT --distinct b.bookingid
CONCAT(YEAR(b.bookingtime), '-', MONTH(b.BookingTime)), c.CountryCode
, count(distinct b.BookingId), sum(bmo.Quantity)
from partnerbookingmenuorder bmo (nolock)
--left join bookingpaymenttransaction  bpt on bpt.bookingid=bmo.bookingid
left join booking b on bmo.bookingid = b.bookingid
left join poi p (nolock) on b.PoiId = p.PoiId
left join Region r (nolock) on p.RegionId = r.RegionId
left join Country c (nolock) on r.CountryId = c.CountryId
where bmo.status in (10,15) and p.status not in (2,6) 
and b.status in (5,10)
and c.CountryCode in ('TH')
group by CONCAT(YEAR(b.bookingtime), '-', MONTH(b.BookingTime)), c.CountryCode
order by 1 desc, 2

