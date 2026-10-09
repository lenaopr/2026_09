-- Output Example:
-- Contract ID,	BBO POIID (Mars.dbo.POI.poiid),	OR POIID(openrice3.dbo.POI.poiid)	Restaurant Name Lang1, 	OR POI status,	Contract Type,	Contract Start Date, Contract End Date,
-- 105166,	130678,	990651,	森記車仔麵,	Normal,	Takeaway,	2025-05-28,	2050-12-31
-- 57111,	2835,	507985,	_0010,	ChangedHands,	Takeaway,	2012-01-01,	2051-01-01

-- Request:
-- active takeaway contract (Contract End date > today)

-- "ORPoiStatus": {
--    "Hide": "0",
--    "Closed": "1",
--    "Normal": "10",
--    "Renovate": "3",
--    "Moved": "4",
--    "ChangedHands": "2",
--    "Delisted": "9"
--  },

-- New Request: provide the commission rates for all restaurants that currently have TAS
-- 具體output 格式請你refers to image.png
-- The commission should be save in mars.dbo.BizServiceChargeItemPoiPrice table.

USE Mars;
GO

IF OBJECT_ID('tempdb..#ActiveTAContracts') IS NOT NULL
	DROP TABLE #ActiveTAContracts;

SELECT DISTINCT
	bc.ContractId AS [Contract ID],
	mp.PoiId AS [BBO POIID],
	mp.OrPoiId AS [OR POIID],
	orp.NameLang1 AS [Restaurant Name Lang1],
	CASE orp.Status
		WHEN 0 THEN N'Hide'
		WHEN 1 THEN N'Closed'
		WHEN 10 THEN N'Normal'
		WHEN 3 THEN N'Renovate'
		WHEN 4 THEN N'Moved'
		WHEN 2 THEN N'ChangedHands'
		WHEN 9 THEN N'Delisted'
		ELSE CONVERT(nvarchar(20), orp.Status)
	END AS [OR POI status],
	N'Takeaway' AS [Contract Type],
	bc.ContractStartTime AS [Contract Start Date],
	bc.ContractEndTime AS [Contract End Date]
INTO #ActiveTAContracts
FROM dbo.BizContract bc WITH (NOLOCK)
INNER JOIN dbo.BizService bs WITH (NOLOCK)
	ON bs.ContractId = bc.ContractId
   AND bs.ServiceTypeId = 4           -- Takeaway
   AND bs.Status = 10
   AND bs.ServiceStartTime <= CAST(GETDATE() AS date)
   AND bs.ServiceEndTime >= CAST(GETDATE() AS date)
INNER JOIN dbo.Poi mp WITH (NOLOCK)
	ON mp.PoiId = bs.PoiId
LEFT JOIN openrice3.dbo.Poi orp WITH (NOLOCK)
	ON orp.PoiId = mp.OrPoiId
WHERE bc.ContractEndTime > CAST(GETDATE() AS date)
;

-- Sheet 1: ChargeTakeAwayCommissionInPercent
SELECT
	ta.[Contract ID],
	ta.[BBO POIID],
	ta.[OR POIID],
	ta.[Restaurant Name Lang1],
	ta.[OR POI status],
	ta.[Contract Type],
	ta.[Contract Start Date],
	ta.[Contract End Date],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_AlipayHK' THEN charge.UnitPrice END) AS [AlipayHK],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_Alipay' THEN charge.UnitPrice END) AS [Alipay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_CreditCard' THEN charge.UnitPrice END) AS [Visa/Mastercard],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_AE' THEN charge.UnitPrice END) AS [Amex],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_BoCPay' THEN charge.UnitPrice END) AS [BOC Pay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_GooglePay' THEN charge.UnitPrice END) AS [Google Pay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_ApplePay' THEN charge.UnitPrice END) AS [Apple Pay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_UnionPayInternational' THEN charge.UnitPrice END) AS [UnionPay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_PayMe' THEN charge.UnitPrice END) AS [PayMe],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_UnionPayApp' THEN charge.UnitPrice END) AS [UnionPay App],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_OctopusWallet' THEN charge.UnitPrice END) AS [Octopus App],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionInPercent_ClickToPay' THEN charge.UnitPrice END) AS [Click to Pay]
FROM #ActiveTAContracts ta
LEFT JOIN dbo.BizServiceChargeItemPoiPrice charge WITH (NOLOCK)
	ON charge.ContractId = ta.[Contract ID]
   AND charge.PoiId = ta.[BBO POIID]
   AND charge.Status = 10
GROUP BY
	ta.[Contract ID], ta.[BBO POIID], ta.[OR POIID], ta.[Restaurant Name Lang1],
	ta.[OR POI status], ta.[Contract Type], ta.[Contract Start Date], ta.[Contract End Date]
ORDER BY ta.[Contract ID] DESC, ta.[BBO POIID];

-- Sheet 2: ChargeTakeAwayCommissionPercent_ByQR
SELECT
	ta.[Contract ID],
	ta.[BBO POIID],
	ta.[OR POIID],
	ta.[Restaurant Name Lang1],
	ta.[OR POI status],
	ta.[Contract Type],
	ta.[Contract Start Date],
	ta.[Contract End Date],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_AlipayHK' THEN charge.UnitPrice END) AS [AlipayHK],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_Alipay' THEN charge.UnitPrice END) AS [Alipay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_CreditCard' THEN charge.UnitPrice END) AS [Visa/Mastercard],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_AE' THEN charge.UnitPrice END) AS [Amex],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_BoCPay' THEN charge.UnitPrice END) AS [BOC Pay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_GooglePay' THEN charge.UnitPrice END) AS [Google Pay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_ApplePay' THEN charge.UnitPrice END) AS [Apple Pay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_UnionPayInternational' THEN charge.UnitPrice END) AS [UnionPay],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_PayMe' THEN charge.UnitPrice END) AS [PayMe],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_UnionPayApp' THEN charge.UnitPrice END) AS [UnionPay App],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_OctopusWallet' THEN charge.UnitPrice END) AS [Octopus App],
	MAX(CASE WHEN charge.Name = N'ChargeTakeAwayCommissionPercent_ByQR_ClickToPay' THEN charge.UnitPrice END) AS [Click to Pay]
FROM #ActiveTAContracts ta
LEFT JOIN dbo.BizServiceChargeItemPoiPrice charge WITH (NOLOCK)
	ON charge.ContractId = ta.[Contract ID]
   AND charge.PoiId = ta.[BBO POIID]
   AND charge.Status = 10
GROUP BY
	ta.[Contract ID], ta.[BBO POIID], ta.[OR POIID], ta.[Restaurant Name Lang1],
	ta.[OR POI status], ta.[Contract Type], ta.[Contract Start Date], ta.[Contract End Date]
ORDER BY ta.[Contract ID] DESC, ta.[BBO POIID];

-- Sheet 3: ChargePromotionidThemeListinginPercent
SELECT
	ta.[Contract ID],
	ta.[BBO POIID],
	ta.[OR POIID],
	ta.[Restaurant Name Lang1],
	ta.[OR POI status],
	ta.[Contract Type],
	ta.[Contract Start Date],
	ta.[Contract End Date],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_AlipayHK' THEN charge.UnitPrice END) AS [AlipayHK],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_Alipay' THEN charge.UnitPrice END) AS [Alipay],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_CreditCard' THEN charge.UnitPrice END) AS [Visa/Mastercard],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_AE' THEN charge.UnitPrice END) AS [Amex],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_BoCPay' THEN charge.UnitPrice END) AS [BOC Pay],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_GooglePay' THEN charge.UnitPrice END) AS [Google Pay],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_ApplePay' THEN charge.UnitPrice END) AS [Apple Pay],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_UnionPayInternational' THEN charge.UnitPrice END) AS [UnionPay],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_PayMe' THEN charge.UnitPrice END) AS [PayMe],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_UnionPayApp' THEN charge.UnitPrice END) AS [UnionPay App],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_OctopusWallet' THEN charge.UnitPrice END) AS [Octopus App],
	MAX(CASE WHEN charge.Name = N'ChargePromotionidThemeListinginPercent_ClickToPay' THEN charge.UnitPrice END) AS [Click to Pay]
FROM #ActiveTAContracts ta
LEFT JOIN dbo.BizServiceChargeItemPoiPrice charge WITH (NOLOCK)
	ON charge.ContractId = ta.[Contract ID]
   AND charge.PoiId = ta.[BBO POIID]
   AND charge.Status = 10
GROUP BY
	ta.[Contract ID], ta.[BBO POIID], ta.[OR POIID], ta.[Restaurant Name Lang1],
	ta.[OR POI status], ta.[Contract Type], ta.[Contract Start Date], ta.[Contract End Date]
ORDER BY ta.[Contract ID] DESC, ta.[BBO POIID];

DROP TABLE #ActiveTAContracts;