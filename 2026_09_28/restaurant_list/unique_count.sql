SELECT count(P.Poiid) AS count
-- SELECT P.*
FROM [POI] AS P
WHERE P.[Status] IN (10, 3)
  AND P.RegionId = 0
  AND EXISTS (
      SELECT 1
      FROM [CategoryPoi] AS CP
      WHERE CP.Poiid = P.Poiid
        AND CP.CategoryTypeId = 2
        AND CP.CategoryId IN (1202, 1006, 1014, 1203, 1003) 
  );