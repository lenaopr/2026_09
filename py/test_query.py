import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns

from py.py_temp import query_to_df, fetch_one, save_to_excel, save_to_csv


# 1. 查單一值：總筆數
count_sql = "SELECT COUNT(*) FROM dbo.[User]"
total_count = fetch_one(count_sql)
print("User 總筆數:", total_count)


# 2. 查資料成 DataFrame
sql = """
SELECT TOP 100
    *
FROM dbo.[User]
"""

df = query_to_df(sql)

print("\n=== 前 5 筆 ===")
print(df.head())

print("\n=== 欄位資訊 ===")
print(df.info())

print("\n=== 基本統計 ===")
print(df.describe(include="all"))


# 3. 輸出檔案
save_to_excel(df, "py/user_top100.xlsx")
save_to_csv(df, "py/user_top100.csv")


# 4. 如果有數值欄位，可以畫圖
# 這裡示範：自動找第一個數值欄位來畫 histogram
numeric_cols = df.select_dtypes(include="number").columns

if len(numeric_cols) > 0:
    col = numeric_cols[0]
    print(f"\n使用數值欄位 {col} 畫直方圖")

    plt.figure(figsize=(8, 5))
    df[col].dropna().hist(bins=20)
    plt.title(f"Distribution of {col}")
    plt.xlabel(col)
    plt.ylabel("Frequency")
    plt.tight_layout()
    plt.show()
else:
    print("\n沒有找到可畫圖的數值欄位")
