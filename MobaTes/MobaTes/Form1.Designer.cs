namespace MobaTes
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.userControl01_1 = new MobaTes.UserControl01();
            this.userControlSP_1 = new MobaTes.UserControlSP();
            this.userControl02_1 = new MobaTes.UserControl02();
            this.userControl00_1 = new MobaTes.UserControl00();
            this.userControlMenuList1 = new MobaTes.UserControlMenuList();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "※「ひょうじ」→「画面その１」を選べば、高田さん作成画面にジャンプします。";
            // 
            // userControl01_1
            // 
            this.userControl01_1.Location = new System.Drawing.Point(39, 390);
            this.userControl01_1.Name = "userControl01_1";
            this.userControl01_1.Size = new System.Drawing.Size(102, 26);
            this.userControl01_1.TabIndex = 8;
            // 
            // userControlSP_1
            // 
            this.userControlSP_1.Location = new System.Drawing.Point(39, 460);
            this.userControlSP_1.Name = "userControlSP_1";
            this.userControlSP_1.Size = new System.Drawing.Size(118, 12);
            this.userControlSP_1.TabIndex = 10;
            // 
            // userControl02_1
            // 
            this.userControl02_1.Location = new System.Drawing.Point(39, 422);
            this.userControl02_1.Name = "userControl02_1";
            this.userControl02_1.Size = new System.Drawing.Size(78, 17);
            this.userControl02_1.TabIndex = 9;
            // 
            // userControl00_1
            // 
            this.userControl00_1.Location = new System.Drawing.Point(39, 372);
            this.userControl00_1.Name = "userControl00_1";
            this.userControl00_1.Size = new System.Drawing.Size(113, 25);
            this.userControl00_1.TabIndex = 4;
            // 
            // userControlMenuList1
            // 
            this.userControlMenuList1.Location = new System.Drawing.Point(-3, -3);
            this.userControlMenuList1.Name = "userControlMenuList1";
            this.userControlMenuList1.Size = new System.Drawing.Size(362, 25);
            this.userControlMenuList1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 540);
            this.Controls.Add(this.userControl01_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControlSP_1);
            this.Controls.Add(this.userControl02_1);
            this.Controls.Add(this.userControl00_1);
            this.Controls.Add(this.userControlMenuList1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControlMenuList userControlMenuList1;
        private UserControl00 userControl00_1;
        private UserControl01 userControl01_1;
        private UserControl02 userControl02_1;
        private UserControlSP userControlSP_1;
        private System.Windows.Forms.Label label1;
    }
}

