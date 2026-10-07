
-- 2026-06-19	2026-06-25 repeated

DECLARE @first_week_start date = '2024-07-19';
DECLARE @today date = '2026-10-01';

;WITH weeks AS (
	SELECT @first_week_start AS start_date

	UNION ALL

	SELECT DATEADD(day, 7, start_date)
	FROM weeks
	WHERE DATEADD(day, 7, start_date) <= @today
),
weekly_booking AS (
	SELECT
		CAST(
			DATEADD(
				day,
				(DATEDIFF(day, @first_week_start, CAST(b.BookingTime AS date)) / 7) * 7,
				@first_week_start
			) AS date
		) AS start_date,
		COUNT_BIG(*) AS booking,
		SUM(b.Seat) AS seat,
		COUNT(DISTINCT b.PoiId) AS poi
	FROM mars.dbo.Booking b WITH (NOLOCK)
	INNER JOIN mars.dbo.Poi p WITH (NOLOCK)
		ON p.PoiId = b.PoiId
	INNER JOIN mars.dbo.Region r WITH (NOLOCK)
		ON r.RegionId = p.RegionId          
	INNER JOIN mars.dbo.Country c WITH (NOLOCK)
		ON c.CountryId = r.CountryId              -- CN countryid = 2
	WHERE b.Status IN (3, 4, 5, 10)         -- "Cancel": "3", "NoShow": "4", "Pending": "5", "Confirm": "10"
	  AND c.CountryCode = 'CN'
	  AND b.BookingTime >= @first_week_start
	  AND b.BookingTime < DATEADD(day, 1, @today)
	GROUP BY DATEADD(
		day,
		(DATEDIFF(day, @first_week_start, CAST(b.BookingTime AS date)) / 7) * 7,
		@first_week_start
	)
)
SELECT
	w.start_date,
	CASE
		WHEN DATEADD(day, 6, w.start_date) > @today THEN @today
		ELSE DATEADD(day, 6, w.start_date)
	END AS end_date,
	ISNULL(wb.booking, 0) AS booking,
	ISNULL(wb.seat, 0) AS seat,
	ISNULL(wb.poi, 0) AS poi
FROM weeks w
LEFT JOIN weekly_booking wb
	ON wb.start_date = w.start_date
ORDER BY w.start_date DESC
OPTION (MAXRECURSION 0);
