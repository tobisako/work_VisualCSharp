using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Timer tim = null;
        private int move_volume;
        private int startAngle;
        private int sweepAngle;
        private Boolean bMoveDirection;
        private int count;
        private int max_count;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MotionInit();   // 口の方向を調整
            TimerStart();   // タイマ起動
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (checkBox1.Checked)
            {
                Brush brush = new SolidBrush(Color.Black);
                e.Graphics.FillPie(brush, 10, 10, 200, 200, startAngle, sweepAngle);
            }
            else
            {
                Pen pen = new Pen(Color.Black);
                e.Graphics.DrawPie(pen, 10, 10, 200, 200, startAngle, sweepAngle);
            }
        }

        // タイマー用
        private void Test_Tick(object sender, EventArgs e)
        {
            MotionMove();
            Invalidate();
        }

        // 口の動き初期化
        private void MotionInit()
        {
            switch (GetRadioNum())
            {
                case 0: // 上
                    startAngle = 270;
                    break;
                case 1: // 右
                    startAngle = 0;
                    break;
                case 2: // 下
                    startAngle = 90;
                    break;
                case 3: // 左
                    startAngle = 180;
                    break;
                default:
                    startAngle = 0;
                    break;
            }
            sweepAngle = 360;
            move_volume = 5;
            count = 0;
            max_count = 10;
            bMoveDirection = true;
        }

        // 口を開けたり閉じたりする計算。
        private void MotionMove()
        {
            if (bMoveDirection)
            {   // 口を開ける
                startAngle += move_volume;
                sweepAngle -= move_volume * 2;
                count++;
            }
            else
            {   // 口を閉じる
                startAngle -= move_volume;
                sweepAngle += move_volume * 2;
                count--;
            }

            // 口反転判定。
            if (count <= 0)
            {
                bMoveDirection = true;
            }
            if (count >= max_count)
            {
                bMoveDirection = false;
            }
        }

        // 口の動き制御関数
        private void MotionCtl()
        {
            Boolean hoge = radioButton1.Checked;
        }

        // タイマー起動関数
        private void TimerStart()
        {
            if (tim == null)
            {
                tim = new Timer();
                tim.Interval = 20;
                tim.Tick += new EventHandler(Test_Tick);
                tim.Start();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int num = trackBar1.Value;
            tim.Interval = num;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MotionInit();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MotionInit();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MotionInit();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            MotionInit();
        }
    }
}
