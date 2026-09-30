/*
Manually Accepted Order Time hourly Breakdown for August 2026

Accept Order Time = AcceptedTime - CreateTime

North Point, Quarry Bay, Tai Koo, Sai Wan Ho, and Shau Kei Wan.
Distinct id: 1004, 1014, 1023, 1009, 1018

Order date and hour are based on TakeAwayOrder.AcceptedTime. (Status = 10).
*/
DECLARE @start_date date = '2026-08-01';
DECLARE @end_date date = '2026-09-01';

WITH order_base AS (
    SELECT
        CAST(tao.AcceptedTime AS date) AS order_date,
        DATEPART(HOUR, tao.AcceptedTime) AS order_hour,
        DATEDIFF(SECOND, tao.CreateTime, tao.AcceptedTime) / 60.0
            AS accept_order_time_minutes
    FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
    INNER JOIN openrice3.dbo.Poi poi WITH (NOLOCK)
        ON poi.PoiId = tao.ORPoiId
    WHERE tao.CreateTime >= @start_date
      AND tao.CreateTime < @end_date
      AND tao.Status = 10       -- completed
      AND tao.AcceptedTime >= tao.CreateTime
      AND poi.DistrictId IN (
		  1004, -- North Point
		  1009, -- Sai Wan Ho
		  1014, -- Quarry Bay
		  1018, -- Shau Kei Wan
		  1023  -- Tai Koo
	  )
    AND JSON_VALUE(tao.MetaData, '$.AcceptedUser.Type') IS NOT NULL
    AND JSON_VALUE(tao.MetaData, '$.AcceptedUser.Type') <> '0'
    AND DATEDIFF(MINUTE, tao.CreateTime, tao.AcceptedTime) <= 30
)
SELECT
	order_date,
	CAST(AVG(CASE WHEN order_hour = 0 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [0],
    CAST(AVG(CASE WHEN order_hour = 1 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [1],
    CAST(AVG(CASE WHEN order_hour = 2 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [2],
    CAST(AVG(CASE WHEN order_hour = 3 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [3],
    CAST(AVG(CASE WHEN order_hour = 4 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [4],
    CAST(AVG(CASE WHEN order_hour = 5 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [5],
    CAST(AVG(CASE WHEN order_hour = 6 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [6],
    CAST(AVG(CASE WHEN order_hour = 7 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [7],
    CAST(AVG(CASE WHEN order_hour = 8 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [8],
    CAST(AVG(CASE WHEN order_hour = 9 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [9],
    CAST(AVG(CASE WHEN order_hour = 10 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [10],
    CAST(AVG(CASE WHEN order_hour = 11 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [11],
    CAST(AVG(CASE WHEN order_hour = 12 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [12],
    CAST(AVG(CASE WHEN order_hour = 13 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [13],
    CAST(AVG(CASE WHEN order_hour = 14 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [14],
    CAST(AVG(CASE WHEN order_hour = 15 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [15],
    CAST(AVG(CASE WHEN order_hour = 16 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [16],
    CAST(AVG(CASE WHEN order_hour = 17 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [17],
    CAST(AVG(CASE WHEN order_hour = 18 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [18],
    CAST(AVG(CASE WHEN order_hour = 19 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [19],
    CAST(AVG(CASE WHEN order_hour = 20 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [20],
    CAST(AVG(CASE WHEN order_hour = 21 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [21],
    CAST(AVG(CASE WHEN order_hour = 22 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [22],
    CAST(AVG(CASE WHEN order_hour = 23 THEN accept_order_time_minutes END) AS decimal(10, 2)) AS [23]
FROM order_base
GROUP BY order_date
ORDER BY order_date DESC;