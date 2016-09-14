using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gamen_enum;           // 画面enumをインクルード。

namespace MobaTes
{
    public partial class Form1 : Form
    {
        private System.Drawing.Point pp;

        public Form1()
        {
            InitializeComponent();

            DbAccess.Connect("admin", "Aqtor0919Passwd2013");

            // ユーザーコントロール画面の初期化
            GamenInit();
        }

        // ユーザーコントロール画面の初期化
        private void GamenInit()
        {
            // 親フォーム（Form1）との通信用設定。
            userControlMenuList1.SetParentForm(this);
            userControl00_1.SetParentForm(this);
            userControl01_1.SetParentForm(this);

            // フォーム位置の調整
            pp = new System.Drawing.Point(12, 33);  // ホーム位置
            userControl00_1.Location = pp;
            userControl01_1.Location = pp;
            userControl02_1.Location = pp;
            userControlSP_1.Location = pp;
            userControl00_1.Size = this.ClientSize;
            userControl01_1.Size = this.ClientSize;
            userControl02_1.Size = this.ClientSize;
            userControlSP_1.Size = this.ClientSize;
            
            // 最初の画面表示
            ChangeGamen(gamen.GAMEN_LAST);      // とりあえず最初は「画面無し」にしとく。
        }

        // メニューリストからのイベント処理機構
        public void DoUserControlEvent_MenuList( menulist meri )
        {
            switch (meri)
            {
                case menulist.MENULIST_DISP_LOGIN:
                    ChangeGamen(gamen.GAMEN_00_LOGIN);
                    break;

                case menulist.MENULIST_DISP_GAMEN_01:
                    ChangeGamen(gamen.GAMEN_01);
                    break;

                case menulist.MENULIST_DISP_GAMEN_02:
                    ChangeGamen(gamen.GAMEN_02);
                    break;

                case menulist.MENULIST_SECRET_NAGAS_S02:
                    ChangeGamen(gamen.GAMEN_SPECIAL);
                    break;
            }
        }

        // 画面切換え処理（画面遷移）
        public void ChangeGamen(gamen hoge)
        {
            // ステップ１：全てのユーザーコントロール画面を隠す。
            userControl00_1.Visible = false;
            userControl01_1.Visible = false;
            userControl02_1.Visible = false;
            userControlSP_1.Visible = false;

            // ステップ２：指定のユーザーコントロール画面（UserControl）だけ表示する。
            switch (hoge)
            {
                case gamen.GAMEN_00_LOGIN:
                    userControl00_1.Visible = true; // 画面表示
                    UserControl00_Activeted();      // 画面表示されたときの動作を呼び出す
                    break;

                case gamen.GAMEN_01:
                    userControl01_1.Visible = true; // 画面表示
                    UserControl01_Activeted();      // 画面表示されたときの動作を呼び出す
                    break;

                case gamen.GAMEN_02:
                    userControl02_1.Visible = true; // 画面表示
                    UserControl02_Activeted();      // 画面表示されたときの動作を呼び出す
                    break;

                case gamen.GAMEN_SPECIAL:
                    userControlSP_1.Visible = true;
                    break;
            }
        }

        // 画面００が表示されたときの動作！
        private void UserControl00_Activeted()
        {
        }

        // 画面０１が表示されたときの動作！
        private void UserControl01_Activeted()
        {
            // ユーザーコントロール「UserControl01」の関数を呼び出したる。
            userControl01_1.StartAction();
        }

        // 画面０２が表示されたときの動作！
        private void UserControl02_Activeted()
        {
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            /* 「UserControl01.cs」へ移動しますた。

            //DataTableオブジェクトを用意
            DataTable ShopTable = new DataTable();

            string strSQL = "SELECT id,name FROM enterprise WHERE deleted ='N'";
            DbAccess.TableReader(strSQL, ShopTable);

            //コンボボックスのDataSourceにDataTableを割り当てる
            cmbBox1.DataSource = ShopTable;

            //表示される値はDataTableのNAME列
            cmbBox1.DisplayMember = "NAME";

            //対応する値はDataTableのID列
            cmbBox1.ValueMember = "ID";
            cmbBox1.SelectedIndex = 4;//ペットプラザ

             */
        }

        // もうこのボタンはないのです・・・。
        private void button1_Click(object sender, EventArgs e)
        {

            /* 「UserControl01.cs」へ移動しますた。

            DataTable dt = new DataTable();
            string strSQL = "select tblstats.*, (tblstats.cntreg-tblstats.cntdel) as zougen FROM"
                    + " (SELECT year, month,"
                    + " sum(case when name='register' then total else 0 end) cntreg,"
                    + " sum(case when name='delete' then total else 0 end) cntdel,"
                    + " sum(case when name='access' then total else 0 end) cntacc"
                    + " FROM stats";
            string strWHERE = " WHERE e_id=" + cmbBox1.SelectedValue;
            //if (cmbBox1.SelectedText==  "22") 
            //        strWHERE = strWHERE + " and k_id=20 and s_id=60"; 
            string strSQL1 = " group by year,month) tblstats"
                    + " order by year desc,month desc"
                    + " limit 0,10";

            DbAccess.TableReader(strSQL + strWHERE + strSQL1, dt);

            dataGridView1.DataSource = dt;

            */
        }
    }
}
