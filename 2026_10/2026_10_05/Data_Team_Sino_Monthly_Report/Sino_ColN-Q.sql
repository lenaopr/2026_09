DECLARE @landmarkId as int
DECLARE @START as DATETIME
DECLARE @END as DATETIME

SET @landmarkId = 35329
-- 42 屯門市廣場，65 荃新天地，35215 利東街，35329 奧海城

SET @START = '2026-09-01'
SET @END = '2026-10-01'

SELECT
    A = SUM(CASE WHEN [Source] <> 20 AND CreateTime < @END THEN 1 ELSE 0 END),
    B = SUM(CASE WHEN [Source] <> 20 AND CreateTime >= @START AND CreateTime < @END THEN 1 ELSE 0 END),
    C = SUM(CASE WHEN [Source] = 20 AND CreateTime < @END THEN 1 ELSE 0 END),
    D = SUM(CASE WHEN [Source] = 20 AND CreateTime >= @START AND CreateTime < @END THEN 1 ELSE 0 END)
FROM openrice3.dbo.BookmarkLandmark
WHERE LandmarkId = @landmarkId;