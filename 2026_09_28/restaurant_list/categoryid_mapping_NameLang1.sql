use [openrice3];

SELECT CategoryId, CategoryTypeId, NameLang1
FROM [dbo].[Category]
WHERE CategoryTypeId = 2
AND NameLang1 in (N'中式糖水', N'台式飲品', N'甜品/糖水', N'西式糕點', N'麵包店');

SELECT CategoryId, CategoryTypeId, NameLang1
FROM [dbo].[Category]
WHERE CategoryTypeId = 3
AND NameLang1 in (N'快餐店', N'樓上cafe', N'糖水舖', N'茶餐廳/冰室', N'蛋糕店');