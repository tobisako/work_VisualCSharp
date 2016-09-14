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
    public partial class UserControlMenu : UserControl
    {
        private Form1 fm;   // 親フォーム位置保存

        // コールバックを親フォームに伝える仕組み
        public void SetParentForm(Form1 f)
        {
            fm = f;
        }

        public UserControlMenu()
        {
            InitializeComponent();
        }

        // 
        private void 三毛猫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoFormEventProcess(gamen.GAMEN_UNKNOWN, gamen.GAMEN_01);
        }

        private void マンチカンToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoFormEventProcess(gamen.GAMEN_UNKNOWN, gamen.GAMEN_02);
        }

        private void シャム猫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoFormEventProcess(gamen.GAMEN_UNKNOWN, gamen.GAMEN_03);
        }

        private void キジトラToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoFormEventProcess(gamen.GAMEN_UNKNOWN, gamen.GAMEN_04);
        }

        private void サバトラToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoFormEventProcess(gamen.GAMEN_UNKNOWN, gamen.GAMEN_05);
        }
    }
}
