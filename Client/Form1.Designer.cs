namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.ipaddr = new System.Windows.Forms.TextBox();
            this.player = new System.Windows.Forms.TextBox();
            this.member = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.A = new System.Windows.Forms.Button();
            this.B = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.D = new System.Windows.Forms.Button();
            this.E = new System.Windows.Forms.Button();
            this.F = new System.Windows.Forms.Button();
            this.G = new System.Windows.Forms.Button();
            this.H = new System.Windows.Forms.Button();
            this.I = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "連線";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ConnectServer);
            // 
            // ipaddr
            // 
            this.ipaddr.Location = new System.Drawing.Point(63, 24);
            this.ipaddr.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ipaddr.Name = "ipaddr";
            this.ipaddr.Size = new System.Drawing.Size(162, 36);
            this.ipaddr.TabIndex = 4;
            this.ipaddr.Text = "127.0.0.1";
            // 
            // player
            // 
            this.player.Location = new System.Drawing.Point(243, 24);
            this.player.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(212, 36);
            this.player.TabIndex = 5;
            this.player.Text = "A";
            // 
            // member
            // 
            this.member.FormattingEnabled = true;
            this.member.Location = new System.Drawing.Point(243, 80);
            this.member.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.member.Name = "member";
            this.member.Size = new System.Drawing.Size(212, 32);
            this.member.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "請選擇對手";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(472, 80);
            this.Start.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(186, 42);
            this.Start.TabIndex = 8;
            this.Start.Text = "開始遊戲！";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(61, 152);
            this.A.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(152, 140);
            this.A.TabIndex = 9;
            this.A.UseVisualStyleBackColor = true;
            this.A.Click += new System.EventHandler(this.answer_Click);
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(225, 152);
            this.B.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(152, 140);
            this.B.TabIndex = 9;
            this.B.UseVisualStyleBackColor = true;
            this.B.Click += new System.EventHandler(this.answer_Click);
            // 
            // C
            // 
            this.C.Location = new System.Drawing.Point(390, 152);
            this.C.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(152, 140);
            this.C.TabIndex = 9;
            this.C.UseVisualStyleBackColor = true;
            this.C.Click += new System.EventHandler(this.answer_Click);
            // 
            // D
            // 
            this.D.Location = new System.Drawing.Point(61, 304);
            this.D.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(152, 140);
            this.D.TabIndex = 9;
            this.D.UseVisualStyleBackColor = true;
            this.D.Click += new System.EventHandler(this.answer_Click);
            // 
            // E
            // 
            this.E.Location = new System.Drawing.Point(225, 304);
            this.E.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(152, 140);
            this.E.TabIndex = 9;
            this.E.UseVisualStyleBackColor = true;
            this.E.Click += new System.EventHandler(this.answer_Click);
            // 
            // F
            // 
            this.F.Location = new System.Drawing.Point(390, 304);
            this.F.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(152, 140);
            this.F.TabIndex = 9;
            this.F.UseVisualStyleBackColor = true;
            this.F.Click += new System.EventHandler(this.answer_Click);
            // 
            // G
            // 
            this.G.Location = new System.Drawing.Point(61, 456);
            this.G.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(152, 140);
            this.G.TabIndex = 9;
            this.G.UseVisualStyleBackColor = true;
            this.G.Click += new System.EventHandler(this.answer_Click);
            // 
            // H
            // 
            this.H.Location = new System.Drawing.Point(225, 456);
            this.H.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.H.Name = "H";
            this.H.Size = new System.Drawing.Size(152, 140);
            this.H.TabIndex = 9;
            this.H.UseVisualStyleBackColor = true;
            this.H.Click += new System.EventHandler(this.answer_Click);
            // 
            // I
            // 
            this.I.Location = new System.Drawing.Point(390, 456);
            this.I.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.I.Name = "I";
            this.I.Size = new System.Drawing.Size(152, 140);
            this.I.TabIndex = 9;
            this.I.UseVisualStyleBackColor = true;
            this.I.Click += new System.EventHandler(this.answer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 638);
            this.Controls.Add(this.I);
            this.Controls.Add(this.H);
            this.Controls.Add(this.G);
            this.Controls.Add(this.F);
            this.Controls.Add(this.E);
            this.Controls.Add(this.D);
            this.Controls.Add(this.C);
            this.Controls.Add(this.B);
            this.Controls.Add(this.A);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.member);
            this.Controls.Add(this.player);
            this.Controls.Add(this.ipaddr);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ipaddr;
        private System.Windows.Forms.TextBox player;
        private System.Windows.Forms.ComboBox member;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button A;
        private System.Windows.Forms.Button B;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button D;
        private System.Windows.Forms.Button E;
        private System.Windows.Forms.Button F;
        private System.Windows.Forms.Button G;
        private System.Windows.Forms.Button H;
        private System.Windows.Forms.Button I;
    }
}

