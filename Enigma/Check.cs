using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Globalization;

namespace Enigma
{
    public class Check
    {
        public static bool SecurityCheck(Computer computer)
        {
            try
            {
                var conn = CreateConnection();

                if (conn == null)
                {
                    return false;
                }

                //DropTable(conn);

                CreateTable(conn);

                var existingComputer = GetComputer(conn, computer);
                if (existingComputer != null)
                {
                    return true;
                }

                int count = ComputerAmmount(conn);
                if (count < 2)
                {
                    InsertData(conn, computer);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SecurityCheck error: {ex.Message}");
                return false;
            }
        }

        private static SQLiteConnection CreateConnection()
        {
            try
            {
                var sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
                sqlite_conn.Open();

                return sqlite_conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connection: {ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }

        private static void CreateTable(SQLiteConnection conn)
        {
            try
            {
                SQLiteCommand sqlite_cmd;

                string Createsql = $"CREATE TABLE IF NOT EXISTS computer (\r\n " +
                    $"id INTEGER PRIMARY KEY,\r\n " +
                    $"characteristic1  TEXT,\r\n " +
                    $"characteristic2  TEXT,\r\n" +
                    $"characteristic3  TEXT\r\n);";

                sqlite_cmd = conn.CreateCommand();

                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CreateTable error: " + ex.ToString());
            }
        }

        private static void InsertData(SQLiteConnection conn, Computer computer)
        {
            try
            {
                string insertComputerSql = $"INSERT INTO computer (characteristic1, characteristic2, characteristic3) VALUES" +
                    $" (\"{computer.characteristic1}\", \"{computer.characteristic2}\", \"{computer.characteristic3}\");";
                var cmd = new SQLiteCommand(insertComputerSql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.ToString());
         
            }
        }

        private static Computer GetComputer(SQLiteConnection conn, Computer computer)
        {
            try
            {
                string getComputerSql = $"SELECT characteristic1, characteristic2, characteristic3 " +
                                          $"FROM computer " +
                                          $"WHERE characteristic1 = \"{computer.characteristic1}\" " +
                                          $"AND characteristic2 = \"{computer.characteristic2}\" " +
                                          $"AND characteristic3 = \"{computer.characteristic3}\";";

                var cmd = new SQLiteCommand(getComputerSql, conn);

                var data = cmd.ExecuteReader();

                if (data.Read())
                {
                    return new Computer
                    {
                        characteristic1 = data.GetString(0),
                        characteristic2 = data.GetString(1),
                        characteristic3 = data.GetString(2)
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetComputer error: " + ex.ToString());
            }

            return null; // Если компьютер не найден
        }

        private static int ComputerAmmount(SQLiteConnection conn)
        {
            try
            {
                string countSql = "SELECT COUNT(*) FROM computer;";

                using (var cmd = new SQLiteCommand(countSql, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComputerAmmount error: " + ex.ToString());
                return 0;
            }
        }

        public static void DropTable(SQLiteConnection conn)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = $"DROP TABLE computer";

                sqlite_cmd = conn.CreateCommand();

                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("DropTable error: " + ex.ToString());
            }
        }
    }
}

