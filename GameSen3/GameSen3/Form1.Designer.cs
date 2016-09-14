namespace GameSen3
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
            this.button1 = new System.Windows.Forms.Button();
            this.userControl051 = new GameSen3.UserControl05();
            this.userControl041 = new GameSen3.UserControl04();
            this.userControl031 = new GameSen3.UserControl03();
            this.userControl021 = new GameSen3.UserControl02();
            this.userControl011 = new GameSen3.UserControl01();
            this.userControlMenu1 = new GameSen3.UserControlMenu();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(580, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 63);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // userControl051
            // 
            this.userControl051.Location = new System.Drawing.Point(174, 160);
            this.userControl051.Name = "userControl051";
            this.userControl051.Size = new System.Drawing.Size(79, 35);
            this.userControl051.TabIndex = 5;
            // 
            // userControl041
            // 
            this.userControl041.Location = new System.Drawing.Point(12, 316);
            this.userControl041.Name = "userControl041";
            this.userControl041.Size = new System.Drawing.Size(83, 85);
            this.userControl041.TabIndex = 4;
            // 
            // userControl031
            // 
            this.userControl031.Location = new System.Drawing.Point(12, 218);
            this.userControl031.Name = "userControl031";
            this.userControl031.Size = new System.Drawing.Size(117, 71);
            this.userControl031.TabIndex = 3;
            // 
            // userControl021
            // 
            this.userControl021.Location = new System.Drawing.Point(12, 130);
            this.userControl021.Name = "userControl021";
            this.userControl021.Size = new System.Drawing.Size(92, 65);
            this.userControl021.TabIndex = 2;
            // 
            // userControl011
            // 
            this.userControl011.Location = new System.Drawing.Point(12, 33);
            this.userControl011.Name = "userControl011";
            this.userControl011.Size = new System.Drawing.Size(63, 25);
            this.userControl011.TabIndex = 1;
            // 
            // userControlMenu1
            // 
            this.userControlMenu1.Location = new System.Drawing.Point(315, 116);
            this.userControlMenu1.Name = "userControlMenu1";
            this.userControlMenu1.Size = new System.Drawing.Size(496, 173);
            this.userControlMenu1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 449);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userControl051);
            this.Controls.Add(this.userControl041);
            this.Controls.Add(this.userControl031);
            this.Controls.Add(this.userControl021);
            this.Controls.Add(this.userControl011);
            this.Controls.Add(this.userControlMenu1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlMenu userControlMenu1;
        private UserControl01 userControl011;
        private UserControl02 userControl021;
        private UserControl03 userControl031;
        private UserControl04 userControl041;
        private UserControl05 userControl051;
        private System.Windows.Forms.Button button1;
    }
}

