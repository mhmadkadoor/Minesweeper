namespace Minesweeper
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startPnl = new Panel();
            infoLable = new Label();
            label2 = new Label();
            label1 = new Label();
            PlayBtn = new Button();
            yTxtF = new TextBox();
            xTxtF = new TextBox();
            startPnl.SuspendLayout();
            SuspendLayout();
            // 
            // startPnl
            // 
            startPnl.Controls.Add(infoLable);
            startPnl.Controls.Add(label2);
            startPnl.Controls.Add(label1);
            startPnl.Controls.Add(PlayBtn);
            startPnl.Controls.Add(yTxtF);
            startPnl.Controls.Add(xTxtF);
            startPnl.Location = new Point(64, 51);
            startPnl.Name = "startPnl";
            startPnl.Size = new Size(285, 272);
            startPnl.TabIndex = 0;
            // 
            // infoLable
            // 
            infoLable.AutoSize = true;
            infoLable.Location = new Point(86, 113);
            infoLable.Name = "infoLable";
            infoLable.Size = new Size(60, 15);
            infoLable.TabIndex = 3;
            infoLable.Text = "Wellcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21F);
            label2.Location = new Point(138, 57);
            label2.Name = "label2";
            label2.Size = new Size(46, 38);
            label2.TabIndex = 2;
            label2.Text = "Y :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F);
            label1.Location = new Point(18, 54);
            label1.Name = "label1";
            label1.Size = new Size(48, 38);
            label1.TabIndex = 2;
            label1.Text = "X :";
            // 
            // PlayBtn
            // 
            PlayBtn.Font = new Font("Segoe UI", 24F);
            PlayBtn.Location = new Point(86, 142);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Size = new Size(107, 55);
            PlayBtn.TabIndex = 1;
            PlayBtn.Text = "Play";
            PlayBtn.UseVisualStyleBackColor = true;
            PlayBtn.Click += PlayBtn_Click;
            // 
            // yTxtF
            // 
            yTxtF.Font = new Font("Segoe UI", 20F);
            yTxtF.Location = new Point(192, 52);
            yTxtF.Name = "yTxtF";
            yTxtF.Size = new Size(52, 43);
            yTxtF.TabIndex = 0;
            yTxtF.Text = "8";
            yTxtF.TextAlign = HorizontalAlignment.Center;
            // 
            // xTxtF
            // 
            xTxtF.Font = new Font("Segoe UI", 20F);
            xTxtF.Location = new Point(72, 52);
            xTxtF.Name = "xTxtF";
            xTxtF.Size = new Size(52, 43);
            xTxtF.TabIndex = 0;
            xTxtF.Text = "8";
            xTxtF.TextAlign = HorizontalAlignment.Center;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(419, 393);
            Controls.Add(startPnl);
            MaximumSize = new Size(435, 432);
            MinimumSize = new Size(435, 432);
            Name = "mainForm";
            Text = "Minesweeper";
            startPnl.ResumeLayout(false);
            startPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel startPnl;
        private TextBox xTxtF;
        private Label label1;
        private Button PlayBtn;
        private TextBox yTxtF;
        private Label label2;
        private Label infoLable;
    }
}
