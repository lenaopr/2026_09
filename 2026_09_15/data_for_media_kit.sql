
DECLARE @start_date DATE = '2026-08-01';
DECLARE @end_date DATE = '2026-08-31';

 use mars

 ----1.  Total unique users ever booked 
Select COUNT(DISTINCT CAST(UserId AS nvarchar(20)) + CAST(DinerPhone_Hash AS nvarchar(30)))
FROM [Booking] (nolock) B
WHERE BookingTime < @end_date
 AND Source IN (1, 4, 5, 6, 7, 9, 11, 12, 13, 21, 25, 26, 27, 28, 29, 30) 


 ----2.  Average Daily Bookings 
SELECT count(bookingid)/datediff(day, @start_date, @end_date) from booking b (nolock)
left join poi p (nolock) on b.poiid = p.poiid
where p.status not in (2,6) 
and bookingtime>=@start_date and bookingtime<@end_date
and b.status =10
 AND Source IN (1, 4, 5, 6, 7, 9, 11, 12, 13, 21, 25, 26, 27, 28, 29, 30) 


use openrice3
----3. Asia Miles Bound Accounts 
SELECT COUNT(DISTINCT UserId) FROM UserIM WHERE 
IMTypeId IN (30, 31)
AND ModifyTime < @end_date


--- 4.       OpenRice Macau monthly page views (Aug 2026)  -->  Big query

--- 5.       Total Bookmark count for ONLY HK Active POIs
--- 6.       Total Bookmark count for ALL REGIONS Active POIs (including HK)
            --> http://172.17.2.220:8888/notebooks/KimmyLam/20250925_adhocData/oversea_bookmark_count.ipynb


--- 7. HK - MAU
SELECT count(distinct UserDeviceId) from UserDevice 
WHERE convert(Date, ModifyTime) between @start_date and @end_date

--- 8. bind card
use mars;
Select
count(distinct SSOuserID) as user_count
FROM UserCreditCard_BA
WHERE convert(date, CreateTime)<=@end_date and status=10