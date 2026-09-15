USE Mars;
GO

DECLARE @UserEmail nvarchar = N'',         
@PayerReferenceId nvarchar = N'',         
@InternalReferenceId nvarchar = N'',         
@TransactionReferenceId nvarchar = N'',         
@Since nvarchar = N'',         
@Until nvarchar = N'',         
@UserSelectDateFrom nvarchar = N'',         
@UserSelectDateTo nvarchar = N'',         
@UserName nvarchar(4) = N'diu1',         
@isIncludePoi int = 6 /*Enum_PoiStatus.Demo*/,         
@VoucherCommodityType1 int = 1,         
@VoucherCommodityType2 int = 6,         
@VoucherCommodityType3 int = 51; 

DECLARE @vUserEmail varchar(100)=@UserEmail; 

DECLARE @vPayerReferenceId AS varchar(100) = @PayerReferenceId,                             
@vInternalReferenceId AS varchar(100) = @InternalReferenceId,                            
@vTransactionReferenceId AS varchar(100) = @TransactionReferenceId,                             
@vSince AS datetime = @Since,                             
@vUntil AS datetime = @Until,                             
@vUserSelectDateFrom AS datetime = @UserSelectDateFrom,                             
@vUserSelectDateTo AS datetime = @UserSelectDateTo; 

SELECT COUNT(0)  
FROM [PaymentTransaction] pt WITH (nolock)                           
LEFT JOIN [User] u WITH (nolock) ON u.SSOUserId = pt.SSOUserId                           
LEFT JOIN [Poi] p WITH (nolock) ON p.Poiid = pt.Poiid                           
LEFT JOIN [CorpAccountPoi] cap WITH (nolock) ON cap.Poiid = pt.Poiid 						  
LEFT JOIN [CorpAccount] ca WITH (nolock) ON ca.CorpAccountId = cap.CorpAccountId                           
LEFT JOIN [VoucherOrder] vo WITH (nolock) ON vo.PaymentTransactionId = pt.PaymentTransactionId                           
WHERE  pt.CommodityType in (@VoucherCommodityType1,@VoucherCommodityType2,@VoucherCommodityType3)  
And u.UserName = @UserName  
AND NOT EXISTS (SELECT PoiId FROM Poi WHERE PoiId = pt.PoiId AND Poi.[Status] = @isIncludePoi);