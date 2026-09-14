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
    SELECT DISTINCT vo.SSOUserId
    FROM dbo.VoucherOrder vo WITH (NOLOCK)
    INNER JOIN ActiveOp3Users oru
        ON oru.SSOUserId = vo.SSOUserId
    WHERE vo.Status = 10    -- paid
        -- AND vo.Status = 15      -- Redeemed
       --  AND vo.RedeemPoiId IS NOT NULL
        AND vo.ModifyTime >= @StartDate
        AND vo.ModifyTime < @EndDate
)

SELECT
    (SELECT COUNT(*) FROM VoucherUsers) AS VoucherServiceUsers,

    (SELECT COUNT(*) FROM ActiveOp3Users) AS ActiveUsers;