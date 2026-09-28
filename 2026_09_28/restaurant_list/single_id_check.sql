use [openrice3];

SELECT * 
FROM [POI] P
INNER JOIN [CategoryPoi] CP ON CP.Poiid = P.Poiid
WHERE CategoryId in (1003) 
AND CategoryTypeId = 2
-- AND CategoryTypeId = 3
AND P.[Status] IN (10, 3)
AND RegionId = 0


-- WHERE CategoryId in (1202, 1006, 1014, 1203, 1003) 

/*
中式糖水,  CategoryId = 1202
台式飲品,  CategoryId = 1006
甜品/糖水,  CategoryId = 1014
西式糕點,  CategoryId = 1203
麵包店,  CategoryId = 1003

-- WHERE CategoryId in (1007, 1024, 20230, 1009, 1094) 

快餐店   1007
樓上cafe  1024
糖水舖     20230
茶餐廳/冰室   1009
蛋糕店     1094

SELECT TOP 1000 * 
FROM [POI] P
INNER JOIN [CategoryPoi] CP ON CP.Poiid = P.Poiid
WHERE CP.CategoryId = 1202 AND CP.CategoryTypeId = 2
AND P.[Status] IN (10, 3)
AND P.RegionId = 0

*/