using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using hogedef;

namespace GameSen3
{
    public partial class UserControl01 : UserControl
    {
        private Form1 fm;   // 親フォーム位置保存

        // コールバックを親フォームに伝える仕組み
        public void SetParentForm(Form1 f)
        {
            fm = f;
        }

        public UserControl01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm.DoFormEventProcess(gamen.GAMEN_01, gamen.GAMEN_02);
        }
    }
}
