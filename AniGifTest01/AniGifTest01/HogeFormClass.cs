using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AniGifTest01
{
    public class HogeFormClass : Form
    {
        // フィールド群
        FieldControl fc_ref;   // フィールドコントロールＩＦ
        Bitmap picBmp;
        PictureBox  picBox;
        Graphics    grph;
        BufferedGraphicsContext b_context;          // ダブルバッファ用
        BufferedGraphics        b_grph;             // ダブルバッファ用 
//        Byte                    b_BufferingMode;    // ダブルバッファ用
        Byte                    b_dbcnt;            // ダブルバッファ用
        int hoge_width;
        int hoge_height;
        Boolean bKey_Up;        // キー入力　上
        Boolean bKey_Down;      // キー入力　下
        Boolean bKey_Left;      // キー入力　左
        Boolean bKey_Right;     // キー入力　右
        Boolean bKey_Space;     // キー入力　スペース

        // プロパティ
        public Boolean eKey_Up
        {
            get
            {
                return bKey_Up;
            }
        }
        public Boolean eKey_Down
        {
            get
            {
                return bKey_Down;
            }
        }
        public Boolean eKey_Left
        {
            get
            {
                return bKey_Left;
            }
        }
        public Boolean eKey_Right
        {
            get
            {
                return bKey_Right;
            }
        }
        public Boolean eKey_Space
        {
            get
            {
                Boolean bRetKey_Space = bKey_Space;
                bKey_Space = false;                     // 参照されると消す。
                return bRetKey_Space;
            }
        }

        // コンストラクタ
        public HogeFormClass() {}   // 引数無しでインスタンス生成出来ない設計。
        public HogeFormClass(FieldControl fc, int w, int h)
        {
            fc_ref = fc;
            this.hoge_width = w;
            this.hoge_height = h;
        }

        // ウィンドウ表示開始
        public void HogeStartShow()
        {
            this.FieldInit();
            this.Show();
        }

        // フィールド初期化
        public void FieldInit()
        {
            // フォーム生成
            this.InitializeHogeComponent();

            // フィールド用ビットマップ生成など
            this.picBmp = new Bitmap(this.Width, this.Height);
            this.picBox.Image = this.picBmp;
            this.grph = Graphics.FromImage(this.picBox.Image);

            // ダブルバッファ初期化
            this.b_context = BufferedGraphicsManager.Current;
            this.b_context.MaximumBuffer = new System.Drawing.Size(this.Width + 1, this.Height + 1);
            this.b_grph = this.b_context.Allocate(this.picBox.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
//            this.b_BufferingMode = 2;
            this.b_dbcnt = 0;
        }

        // ウィンドウ・コンポーネント初期化
        private void InitializeHogeComponent()
        {
            this.SuspendLayout();

            // フォームそのもの
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(this.hoge_width, this.hoge_height);
            this.Name = "HogeForm1";
            this.Text = "HogeForm1";

            this.picBox = new PictureBox();
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(this.Width, this.Height);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HogeFormClass_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HogeFormClass_KeyUp);
            this.Controls.Add(this.picBox);

            this.ResumeLayout(false);
        }

        // フォーム描画
        public void DrawHogeForm()
        {
            this.DrawToDoubleBuffer(this.b_grph.Graphics);
            this.b_grph.Render(Graphics.FromHwnd(this.picBox.Handle));
        }

        // ダブルバッファー処理
        private void DrawToDoubleBuffer(Graphics g)
        {
            if (++this.b_dbcnt > 5)
            {
                this.b_dbcnt = 0;
                g.FillRectangle(Brushes.Black, 0, 0, this.picBox.Width, this.picBox.Height);
            }
            // 登録制にする様にリファクタリングしてみよう。次回は。
            fc_ref.DrawAllUnit(g);
        }

        // ペイントイベント処理
        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            this.b_grph.Render(this.grph);   // レンダリング
        }

        // ※未使用。
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HogeFormClass
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "HogeFormClass";
            this.ResumeLayout(false);
        }

        // キー入力検知（押す）
        private void HogeFormClass_KeyDown(object sender, KeyEventArgs e)
        {
            SetKeyStatus(e, true);
        }

        // キー入力検知（離す）
        private void HogeFormClass_KeyUp(object sender, KeyEventArgs e)
        {
            SetKeyStatus(e, false);
        }

        // キーコード格納
        private void SetKeyStatus(KeyEventArgs e, Boolean bSet)
        {
            switch (e.KeyValue)
            {
                case 37:    // 左
                    bKey_Left = bSet;
                    break;

                case 38:    // 上
                    bKey_Up = bSet;
                    break;

                case 39:    // 右
                    bKey_Right = bSet;
                    break;

                case 40:    // 下
                    bKey_Down = bSet;
                    break;

                case 32:    // スペース
                    bKey_Space = bSet;
                    break;
            }
        }
    }
}
