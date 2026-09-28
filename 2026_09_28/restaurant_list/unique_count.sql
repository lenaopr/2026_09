use [openrice3];

SELECT DISTINCT
    P.*
-- SELECT P.*
FROM [POI] AS P
WHERE P.[Status] IN (10, 3)
  AND P.RegionId = 0
   AND (
      EXISTS (
          SELECT 1
          FROM [CategoryPoi] AS CP
          WHERE CP.Poiid = P.Poiid
            AND CP.CategoryTypeId = 2
            AND CP.CategoryId IN (1202, 1006, 1014, 1203, 1003)
      )
      OR EXISTS (
          SELECT 1
          FROM [CategoryPoi] AS CP
          WHERE CP.Poiid = P.Poiid
            AND CP.CategoryTypeId = 3
            AND CP.CategoryId IN (1007, 1024, 20230, 1009, 1094)
      )
  );


/*
  AND EXISTS (
      SELECT 1
      FROM [CategoryPoi] AS CP
      WHERE CP.Poiid = P.Poiid
        AND CP.CategoryTypeId = 2
        AND CP.CategoryId IN (1202, 1006, 1014, 1203, 1003) 
  );
  */