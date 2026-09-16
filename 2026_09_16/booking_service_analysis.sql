USE mars;

DECLARE @start_date DATE = '2026-01-01';
DECLARE @end_date DATE = '2026-09-17'; -- exclusive; update for a later reporting cut-off

WITH activity AS (
	SELECT
		'Submitted' AS activity_type,
		b.BookingId,
		b.UserId,
		b.Source
	FROM mars.dbo.Booking b WITH (NOLOCK)
	WHERE b.SubmitTime >= @start_date
	  AND b.SubmitTime < @end_date

	UNION ALL

	SELECT
		'Attended' AS activity_type,
		b.BookingId,
		b.UserId,
		b.Source
	FROM mars.dbo.Booking b WITH (NOLOCK)
	WHERE b.BookingTime >= @start_date
	  AND b.BookingTime < @end_date
	  AND b.Status = 10
),
enriched AS (
	SELECT
		a.activity_type,
		a.BookingId,
		a.UserId,
		CASE a.Source
			WHEN 1 THEN 'Web'
			WHEN 4 THEN 'WAP'
			WHEN 7 THEN 'Merchant Site'
			WHEN 12 THEN 'iPhone'
			WHEN 13 THEN 'Android'
			WHEN 41 THEN 'Google'
			ELSE CONCAT('Other (', a.Source, ')')
		END AS booking_source,
		c.CountryId,
		c.NameLang1 AS country_name,
		c.AreaCode AS country_dial_code
	FROM activity a
	LEFT JOIN mars.dbo.[User] mu WITH (NOLOCK)
		ON mu.UserId = a.UserId
	LEFT JOIN openrice3.dbo.[User] ou WITH (NOLOCK)
		ON ou.SSOUserId = mu.SSOUserId
	LEFT JOIN openrice3.dbo.Country c WITH (NOLOCK)
		ON c.CountryId = ou.PhoneAreaCode
)
SELECT
	'Segment by booking source' AS report_section,
	activity_type,
	booking_source,
	CASE
		WHEN CountryId = 1 THEN 'Hong Kong (+852)'
		WHEN CountryId = 3 THEN 'Mainland China (+86)'
		WHEN CountryId IS NOT NULL THEN 'Overseas'
		ELSE 'Unknown / no profile country'
	END AS user_market,
	CAST(NULL AS nvarchar(100)) AS overseas_country,
	CAST(NULL AS int) AS overseas_dial_code,
	COUNT(*) AS booking_count,
	COUNT(DISTINCT NULLIF(UserId, 0)) AS known_user_count
FROM enriched
GROUP BY
	activity_type,
	booking_source,
	CASE
		WHEN CountryId = 1 THEN 'Hong Kong (+852)'
		WHEN CountryId = 3 THEN 'Mainland China (+86)'
		WHEN CountryId IS NOT NULL THEN 'Overseas'
		ELSE 'Unknown / no profile country'
	END

UNION ALL

SELECT
	'Overseas ranking' AS report_section,
	activity_type,
	'All booking sources' AS booking_source,
	'Overseas' AS user_market,
	country_name AS overseas_country,
	country_dial_code AS overseas_dial_code,
	COUNT(*) AS booking_count,
	COUNT(DISTINCT NULLIF(UserId, 0)) AS known_user_count
FROM enriched
WHERE CountryId NOT IN (1, 3)
GROUP BY activity_type, country_name, country_dial_code
ORDER BY report_section, activity_type, booking_count DESC;
