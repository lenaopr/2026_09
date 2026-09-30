DECLARE @ActiveDays int = 30;
 
WITH active_ios_devices AS (
    SELECT
        'OR App' AS App,
        UserId AS UserId,
        TRY_CONVERT(
            int,
            LEFT(OSVersion, CHARINDEX('.', OSVersion + '.') - 1)
        ) AS IOSMajorVersion
    FROM openrice3.dbo.UserDevice WITH (NOLOCK)
    WHERE DeviceTypeId = 2
      AND Status = 10
      AND UserId IS NOT NULL
      AND ModifyTime >= DATEADD(day, -@ActiveDays, GETDATE())
 
    UNION ALL
 
    SELECT
        'Merchant App' AS App,
        CorpUserId AS UserId,
        TRY_CONVERT(
            int,
            LEFT(OSVersion, CHARINDEX('.', OSVersion + '.') - 1)
        ) AS IOSMajorVersion
    FROM Mars.dbo.CorpUserDevice WITH (NOLOCK)
    WHERE DeviceTypeId = 2
      AND Status = 10
      AND CorpUserId IS NOT NULL
      AND ModifyTime >= DATEADD(day, -@ActiveDays, GETDATE())
)
SELECT
    App,
    COUNT(DISTINCT CASE WHEN IOSMajorVersion < 17 THEN UserId END) AS IOSBelow17Users,
    COUNT(DISTINCT CASE WHEN IOSMajorVersion = 17 THEN UserId END) AS IOS17Users,
    COUNT(DISTINCT CASE WHEN IOSMajorVersion > 17 THEN UserId END) AS IOSAbove17Users,
    COUNT(DISTINCT CASE WHEN IOSMajorVersion >= 17 THEN UserId END) AS IOS17OrAboveUsers
FROM active_ios_devices
GROUP BY App
ORDER BY App;