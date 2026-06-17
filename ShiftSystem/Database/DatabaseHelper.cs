using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using ShiftSystem.Models;

namespace ShiftSystem.Database
{
    public static class DatabaseHelper
    {
        private static readonly string DbPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "ShiftSystem.db");

        private static string ConnectionString => $"Data Source={DbPath};Version=3;";

        public static void Initialize()
        {
            if (!File.Exists(DbPath))
                SQLiteConnection.CreateFile(DbPath);

            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                ExecuteSql(conn, @"
                    CREATE TABLE IF NOT EXISTS Employee (
                        Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name     TEXT NOT NULL,
                        Phone    TEXT,
                        Position TEXT
                    );");

                ExecuteSql(conn, @"
                    CREATE TABLE IF NOT EXISTS Shift (
                        Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name      TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime   TEXT NOT NULL
                    );");

                ExecuteSql(conn, @"
                    CREATE TABLE IF NOT EXISTS Schedule (
                        Id         INTEGER PRIMARY KEY AUTOINCREMENT,
                        EmployeeId INTEGER NOT NULL,
                        ShiftId    INTEGER NOT NULL,
                        Date       TEXT NOT NULL,
                        FOREIGN KEY(EmployeeId) REFERENCES Employee(Id),
                        FOREIGN KEY(ShiftId)    REFERENCES Shift(Id)
                    );");

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Shift;";
                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    ExecuteSql(conn, "INSERT INTO Shift (Name, StartTime, EndTime) VALUES ('早班', '07:00', '15:00');");
                    ExecuteSql(conn, "INSERT INTO Shift (Name, StartTime, EndTime) VALUES ('午班', '15:00', '23:00');");
                    ExecuteSql(conn, "INSERT INTO Shift (Name, StartTime, EndTime) VALUES ('晚班', '23:00', '07:00');");
                }
            }
        }

        private static void ExecuteSql(SQLiteConnection conn, string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public static List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Employee ORDER BY Id;", conn);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Phone = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Position = reader.IsDBNull(3) ? "" : reader.GetString(3)
                        });
            }
            return list;
        }

        public static void AddEmployee(Employee e)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    "INSERT INTO Employee (Name, Phone, Position) VALUES (@n, @p, @pos);", conn);
                cmd.Parameters.AddWithValue("@n", e.Name);
                cmd.Parameters.AddWithValue("@p", e.Phone);
                cmd.Parameters.AddWithValue("@pos", e.Position);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateEmployee(Employee e)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    "UPDATE Employee SET Name=@n, Phone=@p, Position=@pos WHERE Id=@id;", conn);
                cmd.Parameters.AddWithValue("@n", e.Name);
                cmd.Parameters.AddWithValue("@p", e.Phone);
                cmd.Parameters.AddWithValue("@pos", e.Position);
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEmployee(int id)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    "DELETE FROM Schedule WHERE EmployeeId=@id; DELETE FROM Employee WHERE Id=@id;", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Shift> GetAllShifts()
        {
            var list = new List<Shift>();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Shift ORDER BY Id;", conn);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(new Shift
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            StartTime = reader.GetString(2),
                            EndTime = reader.GetString(3)
                        });
            }
            return list;
        }

        public static bool HasConflict(int employeeId, string date)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Schedule WHERE EmployeeId=@eid AND Date=@d;", conn);
                cmd.Parameters.AddWithValue("@eid", employeeId);
                cmd.Parameters.AddWithValue("@d", date);
                return (long)cmd.ExecuteScalar() > 0;
            }
        }

        public static void AddSchedule(int employeeId, int shiftId, string date)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    "INSERT INTO Schedule (EmployeeId, ShiftId, Date) VALUES (@eid, @sid, @d);", conn);
                cmd.Parameters.AddWithValue("@eid", employeeId);
                cmd.Parameters.AddWithValue("@sid", shiftId);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteSchedule(int scheduleId)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM Schedule WHERE Id=@id;", conn);
                cmd.Parameters.AddWithValue("@id", scheduleId);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetScheduleByMonth(int year, int month)
        {
            var dt = new DataTable();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string pattern = $"{year:D4}-{month:D2}-%";
                var cmd = new SQLiteCommand(@"
                    SELECT s.Id, e.Name AS 員工, sh.Name AS 班別,
                           sh.StartTime || '~' || sh.EndTime AS 時段, s.Date AS 日期
                    FROM Schedule s
                    JOIN Employee e  ON s.EmployeeId = e.Id
                    JOIN Shift    sh ON s.ShiftId    = sh.Id
                    WHERE s.Date LIKE @pat
                    ORDER BY s.Date, e.Name;", conn);
                cmd.Parameters.AddWithValue("@pat", pattern);
                using (var adapter = new SQLiteDataAdapter(cmd))
                    adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetMonthlyHours(int year, int month)
        {
            var dt = new DataTable();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string pattern = $"{year:D4}-{month:D2}-%";
                var cmd = new SQLiteCommand(@"
                    SELECT e.Name AS 員工, COUNT(*) AS 班次, COUNT(*) * 8 AS 工時
                    FROM Schedule s
                    JOIN Employee e ON s.EmployeeId = e.Id
                    WHERE s.Date LIKE @pat
                    GROUP BY e.Id
                    ORDER BY 工時 DESC;", conn);
                cmd.Parameters.AddWithValue("@pat", pattern);
                using (var adapter = new SQLiteDataAdapter(cmd))
                    adapter.Fill(dt);
            }
            return dt;
        }

        public static void ExportToCsv(int year, int month, string filePath)
        {
            var dt = GetScheduleByMonth(year, month);
            var lines = new System.Collections.Generic.List<string> { "員工,班別,時段,日期" };
            foreach (DataRow row in dt.Rows)
                lines.Add($"{row[1]},{row[2]},{row[3]},{row[4]}");
            File.WriteAllLines(filePath, lines, System.Text.Encoding.UTF8);
        }
    }
}