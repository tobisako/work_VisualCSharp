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
    public enum menulist
    {
        MENULIST_START = 0,         // スタート識別用
        MENULIST_DISP_LOGIN,        // 「ひょうじ」→「ログイン画面」
        MENULIST_DISP_GAMEN_01,     // 「ひょうじ」→「画面その１」
        MENULIST_DISP_GAMEN_02,     // 「ひょうじ」→「画面その２」
        MENULIST_SECRET_NAGAS_S01,  // 「ひみつ」→「永島君の秘密」→「秘密その１」
        MENULIST_SECRET_NAGAS_S02,  // 「ひみつ」→「永島君の秘密」→「秘密その２」
        MENULIST_SECRET_NAGAS_S03,  // 「ひみつ」→「永島君の秘密」→「秘密その３」
        MENULIST_LAST               // ラスト認識用
    };

    public partial class UserControlMenuList : UserControl
    {
        private Form1 fm;   // 親フォームとのリンクを確保

        // 親フォームへのリンクを受け取る関数
        public void SetParentForm(Form1 f)
        {
            fm = f;
        }

        public UserControlMenuList()
        {
            InitializeComponent();
        }

        private void UserControlMenuList_Load(object sender, EventArgs e)
        {

        }

        private void 画面その１なんか表示するアレへToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoUserControlEvent_MenuList(menulist.MENULIST_DISP_GAMEN_01);
        }

        private void 画面その２ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoUserControlEvent_MenuList(menulist.MENULIST_DISP_GAMEN_02);
        }

        private void ログイン画面へToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoUserControlEvent_MenuList(menulist.MENULIST_DISP_LOGIN);
        }

        private void 秘密その２ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm.DoUserControlEvent_MenuList(menulist.MENULIST_SECRET_NAGAS_S02);
        }
    }
}
