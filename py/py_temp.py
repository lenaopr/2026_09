import pyodbc
import pandas as pd
from pathlib import Path


def get_connection():
    """
    建立 SQL Server 連線
    """
    conn = pyodbc.connect(
        'DRIVER={ODBC Driver 18 for SQL Server};'
        'SERVER=192.168.61.119,7622;'
        'DATABASE=Mars;'
        'UID=你的帳號;'
        'PWD=你的密碼;'
        'Encrypt=yes;'
        'TrustServerCertificate=yes;'
    )
    return conn


def query_to_df(sql, params=None):
    """
    執行查詢並回傳 DataFrame
    params 可傳 tuple，例如 params=(100,)
    """
    conn = get_connection()
    try:
        df = pd.read_sql(sql, conn, params=params)
        return df
    finally:
        conn.close()


def execute_sql(sql, params=None):
    """
    執行 INSERT / UPDATE / DELETE
    """
    conn = get_connection()
    try:
        cursor = conn.cursor()
        if params:
            cursor.execute(sql, params)
        else:
            cursor.execute(sql)
        conn.commit()
        print("SQL 執行成功")
    finally:
        conn.close()


def fetch_one(sql, params=None):
    """
    查單一值，例如 COUNT(*)
    """
    conn = get_connection()
    try:
        cursor = conn.cursor()
        if params:
            cursor.execute(sql, params)
        else:
            cursor.execute(sql)
        row = cursor.fetchone()
        return row[0] if row else None
    finally:
        conn.close()


def save_to_excel(df, file_path):
    """
    儲存 DataFrame 到 Excel
    """
    path = Path(file_path)
    path.parent.mkdir(parents=True, exist_ok=True)
    df.to_excel(path, index=False)
    print(f"已輸出 Excel: {path}")


def save_to_csv(df, file_path, encoding="utf-8-sig"):
    """
    儲存 DataFrame 到 CSV
    utf-8-sig 可避免 Excel 開中文亂碼
    """
    path = Path(file_path)
    path.parent.mkdir(parents=True, exist_ok=True)
    df.to_csv(path, index=False, encoding=encoding)
    print(f"已輸出 CSV: {path}")
