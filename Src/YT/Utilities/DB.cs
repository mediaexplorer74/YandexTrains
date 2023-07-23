// DB

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Data.Sqlite;
//using System.Data.SQLite;

namespace YandexTrains
{
    class DB
    {
        public struct Station
        {
            public string title;
            public string code;
        };


        // TODO
        public static void Write_station(string title, string code)
        {
            /*
            using (SqliteConnection Connect = new SqliteConnection(
                @"Data Source=D:\Studio 2022\C#\GetTime\GetTime\stations.db; Version=3;"))
            {
                string commandText = "INSERT INTO [base] ([code], [title]) VALUES(@code, @title)";
                SqliteCommand Command = new SqliteCommand(commandText, Connect);
                Command.Parameters.AddWithValue("@code", code);
                Command.Parameters.AddWithValue("@title", title);
                Connect.Open();
                Command.ExecuteNonQuery();
                Connect.Close();
            }
            */
        }


        // TODO
        public static Station Find_station_code(string title)
        {
            /*
            using (SqliteConnection Connect = new SqliteConnection(
                @"Data Source=D:\Studio 2022\C#\GetTime\GetTime\stations.db; Version=3;"))
            {
                string commandText = "SELECT * FROM [base]";
                SqliteCommand Command = new SqliteCommand(commandText, Connect);

                DataTable data = new DataTable();
                
                // RnD
                //SqliteDataAdapter adapter = new SqliteDataAdapter(Command);
                
                //adapter.Fill(data);
                
                Console.WriteLine($"Прочитано {data.Rows.Count} записей из таблицы БД");
                
                var res_station = new Station();
                foreach (DataRow row in data.Rows)
                {
                    //RnD
                    / *
                    if (title == row.Field<string>("title"))
                    {
                        //RnD
                        //res_station.code = row.Field<string>("code");
                        //res_station.title = row.Field<string>("title");
                        return res_station;
                    }
                    * /
                }

                return res_station;
            }
            */
            return default;
        }//Find_station_code
    }
}
