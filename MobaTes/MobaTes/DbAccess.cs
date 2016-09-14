using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;     // MessageBox()
using System.Data;              // DataTable()

// データベースにアクセスするクラスっぽく。

namespace MobaTes
{
    class DbAccess
    {
        DbAccess()
        {
        }

        //MySQLへの接続情報
        private static MySqlConnection conn;

        public static bool Connect(string user, string pass)
        {
            // string constr = string.Format("userid={0};password={1};database=jihei;Host=192.168.0.111", user, pass);

            string conjihei = string.Format("userid={0};database=jihei;Host=192.168.0.111", user, pass);
            string constr = string.Format("userid={0};database=jihei;Host=192.168.0.111", user, pass, "sjis");

            conn = new MySqlConnection(conjihei);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("接続しっぱい！\n" + ex.Message );
                return false;
            }

            //MessageBox.Show("接続せいこう！\n");
            return true;
        }

        int Hoge()
        {
            return 5;
        }

        //テーブルからデータを取得する
        public static bool TableReader(string select_sql, DataTable datatable)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(select_sql, conn);
            try
            {
                da.Fill(datatable);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("データ取得に失敗しました\n" + ex.Message);
                return false;
            }
            return true;
        }    
    
    }
}

