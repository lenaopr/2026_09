import pyodbc
import pandas as pd
conn = pyodbc.connect(
    'DRIVER={ODBC Driver 18 for SQL Server};'
    'SERVER=192.168.61.119,7622;'
    'DATABASE=Mars;'
    'UID=BAReporting;'
    'PWD=KeHeCReme8he;'
    'Encrypt=yes;'
    'TrustServerCertificate=yes;'
)
sql = """
SELECT TOP 100 *
FROM dbo.[User]
"""

df = pd.read_sql(sql, conn)

print(df.head())
print(df.info())

conn.close()
#cursor.execute("SELECT name FROM sys.databases ORDER BY name")
#rows = cursor.fetchall()
#for r in rows:
#    print(r[0])

