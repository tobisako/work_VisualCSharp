using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobaTes
{

    public partial class UserControl01 : UserControl
    {
        private Form1 fm;   // 親フォームとのリンクを確保

        // 親フォームへのリンクを受け取る関数
        public void SetParentForm(Form1 f)
        {
            fm = f;
        }

        // このユーザーコントロールが表示された時にForm1から呼び出される関数
        public void StartAction()
        {
            ///////////////////////////////////////////////////////////////
            // ↓↓↓高田さんが記述してはった処理です。

            //DataTableオブジェクトを用意
            DataTable ShopTable = new DataTable();

            //string strSQL = "select * from("
            //              + " select '0' id ,'全企業' name ,'N' multiple from dual"
            //              + " union all"
            //              + " SELECT id, name, multiple FROM enterprise WHERE deleted ='N')";
            string strSQL = "SELECT id, name, multiple FROM enterprise WHERE deleted ='N'";
            //string strSQL = "SELECT * FROM V_SHOP_LIST";
            DbAccess.TableReader(strSQL, ShopTable);

            //コンボボックスのDataSourceにDataTableを割り当てる
            cmbBox1.DataSource = ShopTable;

            //表示される値はDataTableのNAME列
            cmbBox1.DisplayMember = "NAME";
            
            //対応する値はDataTableのID列
            cmbBox1.ValueMember = "id";
            cmbBox1.SelectedIndex = 4;//ペットプラザ

            // ↑↑↑高田さんが記述してはった処理です。
            ///////////////////////////////////////////////////////////////
        }
        
        public UserControl01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////
            // ↓↓↓高田さんが記述してはった処理です。

            DataTable dt = new DataTable();
//            string strSQL = "select CONCAT(CAST(year AS CHAR), '年', CAST(month AS CHAR), '月') date,cntreg,cntdel,cntacc, (tblstats.cntreg-tblstats.cntdel) as zougen FROM"
            string strSQL = "select year,month,cntreg,cntdel,cntacc, (tblstats.cntreg-tblstats.cntdel) as zougen FROM"
                    + " (SELECT year,month,"
                    + " sum(case when name='register' then total else 0 end) cntreg,"
                    + " sum(case when name='delete' then total else 0 end) cntdel,"
                    + " sum(case when name='access' then total else 0 end) cntacc"
                    + " FROM stats";
            string strWHERE = " WHERE e_id=" + cmbBox1.SelectedValue;
            if (cmbBox1.SelectedIndex == 4) 
                    strWHERE = strWHERE + " and k_id=0 and s_id=0"; 
            string strSQL1 = " group by year,month) tblstats"
                    + " order by year desc,month desc"
                    + " limit 0,10";

            //System.Text.Encoding src = System.Text.Encoding.ASCII;
            System.Text.Encoding dest = System.Text.Encoding.GetEncoding("Shift_JIS");

            string sjis_str = ConvertEncoding(strSQL + strWHERE + strSQL1, dest);

            DbAccess.TableReader(sjis_str, dt);

            dataGridView1.DataSource = dt;

            // ↑↑↑高田さんが記述してはった処理です。
            ///////////////////////////////////////////////////////////////
        }
        public static string ConvertEncoding(string src, System.Text.Encoding destEnc)
        {
            byte[] src_temp = System.Text.Encoding.ASCII.GetBytes(src);
            byte[] dest_temp = System.Text.Encoding.Convert(System.Text.Encoding.ASCII, destEnc, src_temp);
            string ret = destEnc.GetString(dest_temp);
            return ret;
        }

        private void cmbBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource ="";

        }

    }
}
