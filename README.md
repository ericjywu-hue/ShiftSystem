# 超商排班系統 (Convenience Store Shift Scheduling System)

Windows Forms 桌面應用程式，使用 C# + .NET Framework 4.7.2 + SQLite 開發，協助超商管理員工資料、安排每月班表，並提供工時統計與視覺化報表。

## 專案簡介

本系統為「視窗程式設計 (II)」課程期末專題，模擬超商現場常見的排班需求，包含員工資料維護、每月排班作業、衝突自動偵測、CSV 匯入匯出，以及統計報表視覺化。

## 功能特色

- **員工管理**：新增、編輯、刪除員工資料，支援姓名即時搜尋過濾，並可透過 CSV 一次匯入多位員工
  <img width="1122" height="807" alt="image" src="https://github.com/user-attachments/assets/0e7bbaa0-c767-45cf-88fd-15e3071922aa" />

- **排班管理**：依年月查詢排班紀錄，支援列表檢視與月曆檢視兩種畫面，新增排班時會自動偵測同一員工同日重複排班的衝突，並可將整月班表匯出為 CSV，也支援用 CSV 批次匯入大量排班資料
  <img width="1122" height="815" alt="image" src="https://github.com/user-attachments/assets/a69ca110-40fe-48ac-b746-44b43548883d" />
  <img width="1123" height="813" alt="image" src="https://github.com/user-attachments/assets/efc4cfbc-637a-4d0a-a90a-618655df02ba" />

- **統計報表**：以長條圖視覺化呈現每位員工當月工時與班次數，並提供明細表格
  <img width="1127" height="816" alt="image" src="https://github.com/user-attachments/assets/205f994d-e78a-47d6-b314-ec6e4f6963be" />


## 環境需求

- Visual Studio 2019 或 2022
- .NET Framework 4.7.2
- NuGet 套件：
  - `Stub.System.Data.SQLite.Core.NetFramework`（SQLite 資料庫存取，含原生 DLL）
  - `System.Windows.Forms.DataVisualization`（統計報表長條圖）

## 安裝與執行步驟

1. Clone 或下載本專案
2. 用 Visual Studio 開啟 `ShiftSystem.sln`
3. 開啟「工具」→「NuGet 套件管理員」→「套件管理器主控台」，輸入以下指令安裝資料庫套件：
   ```
   Install-Package System.Data.SQLite.Core
   ```
4. 開啟「專案」→「加入參考」，勾選 `System.Windows.Forms.DataVisualization` 組件
5. 按 F5 執行，程式會在執行檔同目錄下自動建立 `ShiftSystem.db` 資料庫檔案

> 注意：建議將專案資料夾放在 OneDrive 等雲端同步路徑之外，避免同步機制干擾 NuGet 套件還原與資料庫檔案讀寫。

## 專案結構

```
ShiftSystem/
├── Controls/
│   ├── EmployeeControl.cs / .Designer.cs   # 員工管理分頁
│   ├── ScheduleControl.cs / .Designer.cs   # 排班管理分頁
│   └── StatsControl.cs / .Designer.cs      # 統計報表分頁
├── Database/
│   └── DatabaseHelper.cs                   # SQLite 資料存取與初始化
├── Models/
│   ├── Employee.cs                         # 員工資料模型
│   └── Shift.cs                            # 班別資料模型
├── MainForm.cs / .Designer.cs              # 主視窗（TabControl 分頁容器）
├── Program.cs                              # 程式進入點
└── README.md
```

## 資料庫結構

| 資料表 | 欄位 | 說明 |
|---|---|---|
| Employee | Id, Name, Phone, Position | 員工基本資料 |
| Shift | Id, Name, StartTime, EndTime | 班別設定（早班/午班/晚班，可擴充） |
| Schedule | Id, EmployeeId, ShiftId, Date | 排班紀錄，關聯員工與班別 |

## CSV 匯入格式

**員工匯入**（姓名,電話,職位）：
```
姓名,電話,職位
王小明,0912345678,店長
李小美,0922334455,正職
```

**排班匯入**（姓名,班別,日期）：
```
姓名,班別,日期
王小明,早班,2026-06-01
李小美,午班,2026-06-01
```

## 開發者

學號：1121724
姓名：吳俊毅
課程：視窗程式設計 (II) 期末專題
