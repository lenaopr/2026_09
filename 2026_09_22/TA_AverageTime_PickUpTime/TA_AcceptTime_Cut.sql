DECLARE @start_date date = '2026-08-01';
DECLARE @end_date date = '2026-09-01';

WITH order_base AS (
    SELECT
        DATEDIFF(SECOND, tao.CreateTime, tao.AcceptedTime) / 60.0
            AS accept_order_time_minutes
    FROM mars.dbo.TakeAwayOrder tao WITH (NOLOCK)
    INNER JOIN openrice3.dbo.Poi poi WITH (NOLOCK)
        ON poi.PoiId = tao.ORPoiId
    WHERE tao.AcceptedTime >= @start_date
      AND tao.AcceptedTime < @end_date
      AND tao.Status = 10       -- completed
      AND tao.AcceptedTime >= tao.CreateTime
      AND DATEPART(HOUR, tao.AcceptedTime) BETWEEN 12 AND 14
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
),
time_distribution AS (
    SELECT
        FLOOR(accept_order_time_minutes * 2) / 2.0 AS bucket_start_minutes
    FROM order_base
)
SELECT
    CAST(bucket_start_minutes AS decimal(10, 1)) AS accept_order_time_from_minutes,
    CAST(bucket_start_minutes + 0.5 AS decimal(10, 1)) AS accept_order_time_to_minutes,
    COUNT_BIG(*) AS takeaway_order_count
FROM time_distribution
GROUP BY bucket_start_minutes
ORDER BY bucket_start_minutes;