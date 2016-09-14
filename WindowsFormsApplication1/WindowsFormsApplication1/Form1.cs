using System;

using System.Collections;   // コレクションを追加

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "uho";

            // ArrayList作成してみる
            ArrayList al = new ArrayList();
            al.Add(1);
            al.Add('A');
            al.Add("hoge");
            al.Add(3.14);
            al.Add(true);

            // 生成したArrayListを全部表示する
            foreach (Object obj in al)
            {
                label1.Text += obj.ToString();
            }

        }
    }
}
