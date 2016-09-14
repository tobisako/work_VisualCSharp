using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using hogedef;

// ０１：  ログイン画面
// ０２：　企業一覧画面
// ０３：　企業メニュー画面
// ０４：　企業の基本統計画面
// ０５：　企業の基本統計の中のコンセ一覧画面
// ０６：　企業の店舗一覧画面

namespace GameSen3
{
    public partial class Form1 : Form
    {
        private System.Drawing.Point pp;

        public Form1()
        {
            InitializeComponent();

            // 親フォーム（Form1）との通信用設定。
            userControlMenu1.SetParentForm(this);
            userControl011.SetParentForm(this);
            userControl021.SetParentForm(this);
            userControl031.SetParentForm(this);
            userControl041.SetParentForm(this);
            userControl051.SetParentForm(this);

            // フォーム位置の調整を。
            pp = new System.Drawing.Point(12, 33);  // ホーム位置
            userControl011.Location = pp;
            userControl021.Location = pp;
            userControl031.Location = pp;
            userControl041.Location = pp;
            userControl051.Location = pp;
            userControl011.Size = this.ClientSize;
            userControl021.Size = this.ClientSize;
            userControl031.Size = this.ClientSize;
            userControl041.Size = this.ClientSize;
            userControl051.Size = this.ClientSize;

            // 最初の表示ページ指定。
            DoFormEventProcess(gamen.GAMEN_UNKNOWN, gamen.GAMEN_02);
        }

        // イベント処理（画面遷移等）
        public int DoFormEventProcess(gamen dare, gamen doko)
        {
            // 指定画面に切り替えを行う
            GamenKirikae(doko);
            return 1;
        }

        // 画面切り替え処理
        private void GamenKirikae(gamen doko)
        {
            // 全画面を隠す。
            userControl011.Visible = false;
            userControl021.Visible = false;
            userControl031.Visible = false;
            userControl041.Visible = false;
            userControl051.Visible = false;

            // 指定画面だけ表示する。
            switch (doko)
            {
                case gamen.GAMEN_01: userControl011.Visible = true; break;
                case gamen.GAMEN_02: userControl021.Visible = true; break;
                case gamen.GAMEN_03: userControl031.Visible = true; break;
                case gamen.GAMEN_04: userControl041.Visible = true; break;
                case gamen.GAMEN_05: userControl051.Visible = true; break;
            }
        }
    }
}
