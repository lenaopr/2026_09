USE Mars;
GO

DECLARE @StartDate date = '2025-01-01';
DECLARE @EndDate date = '2026-09-01';

;WITH VoucherUsers AS (
    -- A voucher service user is a user with a redeemed voucher.
    SELECT DISTINCT ow.SSOUserId
    FROM dbo.OfferWallet ow WITH (NOLOCK)
    WHERE ow.CommodityType = 3
        AND ow.Status = 15
        AND ow.RedeemPoiId IS NOT NULL
        AND ow.ModifyTime >= @StartDate
        AND ow.ModifyTime < @EndDate
        AND ow.SSOUserId IS NOT NULL
),
BookWithMenuUsers AS (
    -- A book-with-menu user has a successful menu payment for an booking.
    SELECT DISTINCT u.SSOUserId
    FROM dbo.BookingPaymentTransaction bpt WITH (NOLOCK)
    INNER JOIN dbo.Booking b WITH (NOLOCK)
        ON b.BookingId = bpt.BookingId
    INNER JOIN dbo.[User] u WITH (NOLOCK)
        ON u.UserId = b.UserId
    WHERE b.Status = 10
        AND bpt.PaymentStatus = 10
        AND bpt.BookingPaymentTransactionType = 1
        AND bpt.PaymentTime >= @StartDate
        AND bpt.PaymentTime < @EndDate
        AND u.SSOUserId IS NOT NULL
        AND EXISTS (
            SELECT 1
            FROM dbo.BookingMenuOrder bmo WITH (NOLOCK)
            WHERE bmo.BookingId = b.BookingId
                AND bmo.Status IN (10, 15)
)
),
TotalUsers AS (
    SELECT DISTINCT SSOUserId
    FROM dbo.[User] WITH (NOLOCK)
    WHERE SSOUserId IS NOT NULL
)

SELECT
    (SELECT COUNT(*) FROM VoucherUsers) AS VoucherServiceUsers,
    CAST(
        100.0 * (SELECT COUNT(*) FROM VoucherUsers) /
        NULLIF((SELECT COUNT(*) FROM TotalUsers), 0)
        AS decimal(6, 5)
    ) AS VoucherServiceUserPercent,

    (SELECT COUNT(*) FROM BookWithMenuUsers) AS BookWithMenuServiceUsers,
    CAST(
        100.0 * (SELECT COUNT(*) FROM BookWithMenuUsers) /
        NULLIF((SELECT COUNT(*) FROM TotalUsers), 0)
        AS decimal(6, 5)
    ) AS BookWithMenuServiceUserPercent,

    (SELECT COUNT(*) FROM TotalUsers) AS TotalUsers;