DECLARE @start_date date = '2026-08-01';
DECLARE @end_date date = '2026-09-01';

WITH promo_bookings AS (
	SELECT DISTINCT
		b.BookingId,
		b.PoiId AS RestaurantID,
		p.NameLang1 AS RestaurantName,
		b.BookingRefId,
		b.UserId AS mars_userid,
		b.SubmitTime,
		CONVERT(date, b.BookingTime) AS BookingDate,
		CONVERT(time(0), ts.TimeSlotTime) AS BookingTime,
		b.AmendedSeat,
		menu.bookmenu_spending,
		DATEADD(
			second,
			DATEPART(hour, ts.TimeSlotTime) * 3600
				+ DATEPART(minute, ts.TimeSlotTime) * 60
				+ DATEPART(second, ts.TimeSlotTime),
			CAST(CONVERT(date, b.BookingTime) AS datetime)
		) AS BookingDateTime
	FROM mars.dbo.OfferWallet ow WITH (NOLOCK)
	INNER JOIN mars.dbo.Booking b WITH (NOLOCK)
		ON b.BookingId = ow.BookingId
	INNER JOIN mars.dbo.Poi p WITH (NOLOCK)
		ON p.PoiId = b.PoiId
	LEFT JOIN mars.dbo.TimeSlot ts WITH (NOLOCK)
		ON ts.TimeSlotId = b.StartTimeSlotId
    OUTER APPLY (
        SELECT SUM(bpt.FinalPrice) AS bookmenu_spending
        FROM mars.dbo.BookingPaymentTransaction bpt WITH (NOLOCK)
        WHERE bpt.BookingId = b.BookingId
        AND bpt.PaymentStatus = 10      -- paid
        AND bpt.BookingPaymentTransactionType = 1  -- booking menu
        AND EXISTS (         -- ensure at least 1 booked & completed order
            SELECT 1
            FROM mars.dbo.BookingMenuOrder bmo WITH (NOLOCK)
            WHERE bmo.BookingId = b.BookingId
                AND bmo.Status = 15      --completed menu order
        )
    ) menu
	WHERE ow.OfferId IN (549787, 548057)
			AND ow.Status = 15      --redeemed
	  AND b.Status = 10  -- confirmed
	  AND b.BookingTime >= @start_date
	  AND b.BookingTime < @end_date
	  AND b.UserId IS NOT NULL
	  AND b.UserId <> 0
      AND p.Status NOT IN (2,6) -- from bookmore.ipynb
      AND p.RegionId = 0
),
ranked_bookings AS (       -- same user, same restaurant, booking order --> Rank
    SELECT
        pb.*,
        ROW_NUMBER() OVER (
            PARTITION BY pb.mars_userid, pb.RestaurantID
            ORDER BY pb.BookingDateTime, pb.BookingId
        ) AS Rank
    FROM promo_bookings pb
),
first_poi_booking AS (            -- first booking in each restaurant
    SELECT
        rb.mars_userid,
        rb.RestaurantID,
        rb.BookingId,
        rb.BookingDateTime AS first_booking_datetime
    FROM ranked_bookings rb
    WHERE rb.Rank = 1
),
ranked_pois AS (               -- same user, diff restaurant, first visit  --> Rank2
    SELECT
        fpb.mars_userid,
        fpb.RestaurantID,
        fpb.BookingId,
        fpb.first_booking_datetime,
        ROW_NUMBER() OVER (
            PARTITION BY fpb.mars_userid
            ORDER BY fpb.first_booking_datetime, fpb.RestaurantID
        ) AS Rank2,
        COUNT(*) OVER (
            PARTITION BY fpb.mars_userid
        ) AS UniquePOICount
    FROM first_poi_booking fpb
),
qualified_users AS (
	SELECT
		rp.mars_userid,
		MAX(rp.UniquePOICount) AS UniquePOICount,      
		MAX(CASE WHEN rp.Rank2 = 2 THEN rp.first_booking_datetime END) AS Target_Time
	FROM ranked_pois rp
	GROUP BY rp.mars_userid
	HAVING MAX(rp.UniquePOICount) >= 2
)
SELECT
	rb.RestaurantID,
	rb.RestaurantName,
	rb.BookingRefId,
	rb.mars_userid,
	rb.SubmitTime,
	rb.BookingDate,
	rb.BookingTime,
    CASE
        WHEN EXISTS (
            SELECT 1
            FROM mars.dbo.Booking no_show WITH (NOLOCK)
            WHERE no_show.UserId = rb.mars_userid
                AND no_show.Status = 4                 -- no show 
                AND no_show.BookingTime >= @start_date
                AND no_show.BookingTime < @end_date
        ) THEN 'Y'
        ELSE 'N'
    END AS hv_noshow,
	rb.AmendedSeat,
	rb.bookmenu_spending,
	CONVERT(varchar(19), rb.BookingDateTime, 120) AS BookingDateTime,
	rb.Rank,
	qu.UniquePOICount,
	rp.Rank2,
	CASE
        WHEN rp.Rank2 = 2
        AND rb.BookingId = rp.BookingId
        THEN CONVERT(varchar(19), qu.Target_Time, 120)
    END AS Target_Time
FROM ranked_bookings rb
INNER JOIN qualified_users qu
	ON qu.mars_userid = rb.mars_userid
LEFT JOIN ranked_pois rp
    ON rp.mars_userid = rb.mars_userid
   AND rp.RestaurantID = rb.RestaurantID
   AND rp.BookingId = rb.BookingId
ORDER BY rb.mars_userid, rb.BookingDateTime, rb.BookingId;

