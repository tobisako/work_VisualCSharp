using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// ユーザーコントロール００番「ログイン画面」

namespace MobaTes
{
    public partial class UserControl00 : UserControl
    {
        private Form1 fm;   // 親フォームとのリンクを確保

        // 親フォームへのリンクを受け取る関数
        public void SetParentForm(Form1 f)
        {
            fm = f;
        }
        
        public UserControl00()
        {
            InitializeComponent();
        }
    }
}
