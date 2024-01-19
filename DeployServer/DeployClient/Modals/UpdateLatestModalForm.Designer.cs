namespace DeployClient.Modals
{
    partial class UpdateLatestModalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 24);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 2;
            label3.Text = "上传最新包";
            // 
            // button1
            // 
            button1.Location = new Point(108, 21);
            button1.Name = "button1";
            button1.Size = new Size(165, 23);
            button1.TabIndex = 5;
            button1.Text = "点击上传";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 63);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 6;
            label4.Text = "时间";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 109);
            label5.Name = "label5";
            label5.Size = new Size(32, 17);
            label5.TabIndex = 7;
            label5.Text = "大小";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 152);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 8;
            label6.Text = "哈希值";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(58, 193);
            label8.Name = "label8";
            label8.Size = new Size(43, 17);
            label8.TabIndex = 13;
            label8.Text = "下载id";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(108, 63);
            label9.Name = "label9";
            label9.Size = new Size(32, 17);
            label9.TabIndex = 14;
            label9.Text = "时间";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(108, 109);
            label10.Name = "label10";
            label10.Size = new Size(32, 17);
            label10.TabIndex = 15;
            label10.Text = "时间";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(108, 152);
            label11.Name = "label11";
            label11.Size = new Size(32, 17);
            label11.TabIndex = 16;
            label11.Text = "时间";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(108, 193);
            label12.Name = "label12";
            label12.Size = new Size(32, 17);
            label12.TabIndex = 17;
            label12.Text = "时间";
            // 
            // UpdateLatestModalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 231);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Name = "UpdateLatestModalForm";
            Text = "最新版";
            Shown += UpdateLatestModalForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}