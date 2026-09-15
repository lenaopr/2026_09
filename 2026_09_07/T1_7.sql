USE Mars;
GO

DECLARE @StartDate date = '2026-08-01';
DECLARE @EndDate date = '2026-09-01';

;WITH ActiveOp3Users AS (
    SELECT DISTINCT u.SSOUserId
    FROM openrice3.dbo.[User] u WITH (NOLOCK)
    WHERE u.SSOUserId IS NOT NULL
        AND u.Status = 10    -- active
        AND u.LastLoginTime >= @StartDate
        AND u.LastLoginTime < @EndDate
),
VoucherUsers AS (
    SELECT DISTINCT vo.SSOUserId
    FROM dbo.VoucherOrder vo WITH (NOLOCK)
    INNER JOIN openrice3.dbo.[User] op3User WITH (NOLOCK)
        ON op3User.SSOUserId = vo.SSOUserId
    WHERE vo.SSOUserId IS NOT NULL
        AND vo.Status = 10    -- paid
        AND op3User.Status = 10  -- active
        AND vo.ModifyTime >= @StartDate
        AND vo.ModifyTime < @EndDate
),

BookWithMenuUsers AS (
    -- A book-with-menu user has a successful menu payment for an booking.
    SELECT DISTINCT marsUser.SSOUserId
    FROM dbo.BookingPaymentTransaction bpt WITH (NOLOCK)
    INNER JOIN dbo.Booking b WITH (NOLOCK)
        ON b.BookingId = bpt.BookingId
    INNER JOIN dbo.[User] marsUser WITH (NOLOCK)
        ON marsUser.UserId = b.UserId
    INNER JOIN openrice3.dbo.[User] op3User WITH (NOLOCK)
        ON op3User.SSOUserId = marsUser.SSOUserId
    WHERE marsUser.SSOUserId IS NOT NULL
        AND op3User.Status = 10  -- active
        AND bpt.PaymentStatus = 10    -- paid                 -- b.Status = 10 : confirmed
        AND bpt.BookingPaymentTransactionType = 1   -- booking menu
        AND bpt.PaymentTime >= @StartDate
        AND bpt.PaymentTime < @EndDate
        AND EXISTS (
            SELECT 1
            FROM dbo.BookingMenuOrder bmo WITH (NOLOCK)
            WHERE bmo.BookingId = b.BookingId
                AND bmo.Status IN (10, 15) -- active or redeemed
        )
),
OverlapUsers AS (
    SELECT vu.SSOUserId
    FROM VoucherUsers vu
    INNER JOIN BookWithMenuUsers bmwu
        ON bmwu.SSOUserId = vu.SSOUserId
)

SELECT
    (SELECT COUNT(*) FROM VoucherUsers) AS VoucherServiceUsers,
    CAST(
        100.0 * (SELECT COUNT(*) FROM VoucherUsers) /
        NULLIF((SELECT COUNT(*) FROM ActiveOp3Users), 0)
        AS decimal(6, 5)
    ) AS VoucherServiceUserPercent,

    (SELECT COUNT(*) FROM BookWithMenuUsers) AS BookWithMenuServiceUsers,
    CAST(
        100.0 * (SELECT COUNT(*) FROM BookWithMenuUsers) /
        NULLIF((SELECT COUNT(*) FROM ActiveOp3Users), 0)
        AS decimal(6, 5)
    ) AS BookWithMenuServiceUserPercent,

    (SELECT COUNT(*) FROM OverlapUsers) AS OverlapUsers,

    (SELECT COUNT(*) FROM ActiveOp3Users) AS ActiveUsers;