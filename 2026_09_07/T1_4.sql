USE Mars;
GO

DECLARE @StartDate date = '2025-01-01';
DECLARE @EndDate date = '2026-09-01';


;WITH ActiveOp3Users AS (
    SELECT DISTINCT u.SSOUserId
    FROM openrice3.dbo.[User] u WITH (NOLOCK)
    WHERE u.SSOUserId IS NOT NULL
        AND u.Status = 10    --active
        AND u.LastLoginTime >= @StartDate
        AND u.LastLoginTime < @EndDate
),
VoucherUsers AS (
    -- A voucher service user is a user with a redeemed voucher.
    SELECT DISTINCT ow.SSOUserId
    FROM dbo.OfferWallet ow WITH (NOLOCK)
    INNER JOIN ActiveOp3Users oru
        ON oru.SSOUserId = ow.SSOUserId
    WHERE ow.CommodityType = 3    -- Voucher
        AND ow.Status = 15      -- Redeemed
        AND ow.RedeemPoiId IS NOT NULL
        AND ow.ModifyTime >= @StartDate
        AND ow.ModifyTime < @EndDate
),
BookWithMenuUsers AS (
    -- A book-with-menu user has a successful menu payment for an booking.
    SELECT DISTINCT marsUser.SSOUserId
    FROM dbo.BookingPaymentTransaction bpt WITH (NOLOCK)
    INNER JOIN dbo.Booking b WITH (NOLOCK)
        ON b.BookingId = bpt.BookingId
    INNER JOIN dbo.[User] marsUser WITH (NOLOCK)
        ON marsUser.UserId = b.UserId
    INNER JOIN ActiveOp3Users activeUser
        ON activeUser.SSOUserId = marsUser.SSOUserId
    WHERE b.Status = 10  -- confirmed
        AND bpt.PaymentStatus = 10    -- paid
        AND bpt.BookingPaymentTransactionType = 1   -- booking menu
        AND bpt.PaymentTime >= @StartDate
        AND bpt.PaymentTime < @EndDate
        AND marsUser.SSOUserId IS NOT NULL
        AND EXISTS (
            SELECT 1
            FROM dbo.BookingMenuOrder bmo WITH (NOLOCK)
            WHERE bmo.BookingId = b.BookingId
                AND bmo.Status IN (10, 15) -- active & redeemed
)
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

    (SELECT COUNT(*) FROM ActiveOp3Users) AS ActiveUsers;