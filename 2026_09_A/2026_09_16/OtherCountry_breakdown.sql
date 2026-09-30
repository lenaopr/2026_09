WITH booking_by_type AS (
    SELECT
        H.NameLang1, DinerPhoneAreaCode_Hash,       
        'Submitted' AS [Type],
        COUNT(*) AS booking_count
    FROM mars.dbo.Booking B WITH (NOLOCK)
    INNER JOIN HomeRegion H ON HASHBYTES('MD5',cast(H.[HomeRegionId] as varbinary(16))) = DinerPhoneAreaCode_Hash
    WHERE B.BookingTime >= '2026-01-01'
    AND B.Status IN (3, 4, 5, 10)
    GROUP BY H.NameLang1, DinerPhoneAreaCode_Hash
    UNION ALL

    SELECT
        H.NameLang1, DinerPhoneAreaCode_Hash,
        'Attended' AS [Type],
        COUNT(*) AS booking_count
    FROM mars.dbo.Booking B WITH (NOLOCK)
    INNER JOIN HomeRegion H ON HASHBYTES('MD5',cast(H.[HomeRegionId] as varbinary(16))) = DinerPhoneAreaCode_Hash
    WHERE B.BookingTime >= '2026-01-01'
    AND B.Status = 10
    GROUP BY H.NameLang1, DinerPhoneAreaCode_Hash
),
top_5_country AS (
    SELECT TOP (5)
        NameLang1,
        DinerPhoneAreaCode_Hash,
        booking_count,
        ROW_NUMBER() OVER (ORDER BY booking_count DESC) AS country_rank
    FROM booking_by_type
    WHERE [Type] = 'Submitted'
      AND DinerPhoneAreaCode_Hash IS NOT NULL
    ORDER BY booking_count DESC
),
final_result AS (
    SELECT
        CASE
            WHEN t.DinerPhoneAreaCode_Hash IS NOT NULL  
                THEN b.NameLang1
            ELSE 'Other country'
        END AS NameLang1,
        CASE
            WHEN t.DinerPhoneAreaCode_Hash IS NOT NULL
                THEN b.DinerPhoneAreaCode_Hash
            ELSE NULL
        END AS DinerPhoneAreaCode_Hash,
        b.[Type],
        SUM(b.booking_count) AS booking_count,
        ISNULL(t.country_rank, 6) AS country_rank
    FROM booking_by_type b
    LEFT JOIN top_5_country t
        ON t.DinerPhoneAreaCode_Hash = b.DinerPhoneAreaCode_Hash
    GROUP BY
        b.[Type],
        CASE
            WHEN t.DinerPhoneAreaCode_Hash IS NOT NULL
                THEN b.NameLang1
            ELSE 'Other country'
        END,
        CASE
            WHEN t.DinerPhoneAreaCode_Hash IS NOT NULL
                THEN b.DinerPhoneAreaCode_Hash
            ELSE NULL
        END,
        ISNULL(t.country_rank, 6)
)
SELECT
    NameLang1 AS Area,
    [Type],
    booking_count
FROM booking_by_type
WHERE [Type] = 'Attended'
ORDER BY booking_count DESC;