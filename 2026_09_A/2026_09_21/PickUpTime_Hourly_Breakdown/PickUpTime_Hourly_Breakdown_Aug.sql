/*
Pick-up time hourly breakdown for North Point, Quarry Bay, Tai Koo, 
Sai Wan Ho, and Shau Kei Wan in August 2026.
Distinct id: 1004, 1014, 1023, 1009, 1018

Order date and hour are based on TakeAwayOrder.PickupTime. (Status = 10).
*/
DECLARE @start_date date = '2026-08-01';
DECLARE @end_date date = '2026-09-01';

WITH order_base AS (
    SELECT
        CAST(tao.PickupTime AS date) AS pickup_date,
        DATEPART(HOUR, tao.PickupTime) AS pickup_hour
    FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
    INNER JOIN openrice3.dbo.Poi poi WITH (NOLOCK)
        ON poi.PoiId = tao.ORPoiId
    WHERE tao.PickupTime >= @start_date
      AND tao.PickupTime < @end_date
      AND tao.Status = 10       -- completed
      AND poi.DistrictId IN (
		  1004, -- North Point
		  1009, -- Sai Wan Ho
		  1014, -- Quarry Bay
		  1018, -- Shau Kei Wan
		  1023  -- Tai Koo
	  )
)
SELECT
	pickup_date,
	SUM(CASE WHEN pickup_hour = 0 THEN 1 ELSE 0 END) AS [0],
	SUM(CASE WHEN pickup_hour = 1 THEN 1 ELSE 0 END) AS [1],
	SUM(CASE WHEN pickup_hour = 2 THEN 1 ELSE 0 END) AS [2],
	SUM(CASE WHEN pickup_hour = 3 THEN 1 ELSE 0 END) AS [3],
	SUM(CASE WHEN pickup_hour = 4 THEN 1 ELSE 0 END) AS [4],
	SUM(CASE WHEN pickup_hour = 5 THEN 1 ELSE 0 END) AS [5],
	SUM(CASE WHEN pickup_hour = 6 THEN 1 ELSE 0 END) AS [6],
	SUM(CASE WHEN pickup_hour = 7 THEN 1 ELSE 0 END) AS [7],
	SUM(CASE WHEN pickup_hour = 8 THEN 1 ELSE 0 END) AS [8],
	SUM(CASE WHEN pickup_hour = 9 THEN 1 ELSE 0 END) AS [9],
	SUM(CASE WHEN pickup_hour = 10 THEN 1 ELSE 0 END) AS [10],
	SUM(CASE WHEN pickup_hour = 11 THEN 1 ELSE 0 END) AS [11],
	SUM(CASE WHEN pickup_hour = 12 THEN 1 ELSE 0 END) AS [12],
	SUM(CASE WHEN pickup_hour = 13 THEN 1 ELSE 0 END) AS [13],
	SUM(CASE WHEN pickup_hour = 14 THEN 1 ELSE 0 END) AS [14],
	SUM(CASE WHEN pickup_hour = 15 THEN 1 ELSE 0 END) AS [15],
	SUM(CASE WHEN pickup_hour = 16 THEN 1 ELSE 0 END) AS [16],
	SUM(CASE WHEN pickup_hour = 17 THEN 1 ELSE 0 END) AS [17],
	SUM(CASE WHEN pickup_hour = 18 THEN 1 ELSE 0 END) AS [18],
	SUM(CASE WHEN pickup_hour = 19 THEN 1 ELSE 0 END) AS [19],
	SUM(CASE WHEN pickup_hour = 20 THEN 1 ELSE 0 END) AS [20],
	SUM(CASE WHEN pickup_hour = 21 THEN 1 ELSE 0 END) AS [21],
	SUM(CASE WHEN pickup_hour = 22 THEN 1 ELSE 0 END) AS [22],
	SUM(CASE WHEN pickup_hour = 23 THEN 1 ELSE 0 END) AS [23]
FROM order_base
GROUP BY pickup_date
ORDER BY pickup_date DESC;
