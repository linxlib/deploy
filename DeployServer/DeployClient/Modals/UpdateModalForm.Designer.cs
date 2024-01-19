namespace DeployClient.Modals
{
    partial class UpdateModalForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            versionBindingSource = new BindingSource(components);
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)versionBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 25);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 0;
            label1.Text = "版本";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 72);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 1;
            label2.Text = "版本号";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 117);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 2;
            label3.Text = "上传更新包";
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", versionBindingSource, "Name", true, DataSourceUpdateMode.OnPropertyChanged));
            textBox1.Location = new Point(108, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 23);
            textBox1.TabIndex = 3;
            // 
            // versionBindingSource
            // 
            versionBindingSource.DataSource = typeof(Entity.Version);
            // 
            // numericUpDown1
            // 
            numericUpDown1.DataBindings.Add(new Binding("Value", versionBindingSource, "VersionInt", true, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDown1.Location = new Point(108, 66);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(165, 23);
            numericUpDown1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(108, 114);
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
            label4.Location = new Point(70, 165);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 6;
            label4.Text = "时间";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 211);
            label5.Name = "label5";
            label5.Size = new Size(32, 17);
            label5.TabIndex = 7;
            label5.Text = "大小";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 254);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 8;
            label6.Text = "哈希值";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(293, 25);
            label7.Name = "label7";
            label7.Size = new Size(56, 17);
            label7.TabIndex = 9;
            label7.Text = "更新日志";
            // 
            // richTextBox1
            // 
            richTextBox1.DataBindings.Add(new Binding("Text", versionBindingSource, "ReleaseLog", true, DataSourceUpdateMode.OnPropertyChanged));
            richTextBox1.Location = new Point(355, 25);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(279, 297);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(108, 358);
            button2.Name = "button2";
            button2.Size = new Size(149, 41);
            button2.TabIndex = 11;
            button2.Text = "确定";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(394, 358);
            button3.Name = "button3";
            button3.Size = new Size(149, 41);
            button3.TabIndex = 12;
            button3.Text = "取消";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(58, 295);
            label8.Name = "label8";
            label8.Size = new Size(43, 17);
            label8.TabIndex = 13;
            label8.Text = "下载id";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.DataBindings.Add(new Binding("Text", versionBindingSource, "InDate", true, DataSourceUpdateMode.OnPropertyChanged));
            label9.Location = new Point(108, 165);
            label9.Name = "label9";
            label9.Size = new Size(32, 17);
            label9.TabIndex = 14;
            label9.Text = "时间";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.DataBindings.Add(new Binding("Text", versionBindingSource, "Size", true, DataSourceUpdateMode.OnPropertyChanged));
            label10.Location = new Point(108, 211);
            label10.Name = "label10";
            label10.Size = new Size(32, 17);
            label10.TabIndex = 15;
            label10.Text = "时间";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.DataBindings.Add(new Binding("Text", versionBindingSource, "Hash", true, DataSourceUpdateMode.OnPropertyChanged));
            label11.Location = new Point(108, 254);
            label11.Name = "label11";
            label11.Size = new Size(32, 17);
            label11.TabIndex = 16;
            label11.Text = "时间";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.DataBindings.Add(new Binding("Text", versionBindingSource, "DownloadID", true, DataSourceUpdateMode.OnPropertyChanged));
            label12.Location = new Point(108, 295);
            label12.Name = "label12";
            label12.Size = new Size(32, 17);
            label12.TabIndex = 17;
            label12.Text = "时间";
            // 
            // UpdateModalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 450);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateModalForm";
            Text = "版本";
            Shown += UpdateModalForm_Shown;
            ((System.ComponentModel.ISupportInitialize)versionBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private RichTextBox richTextBox1;
        private Button button2;
        private Button button3;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private BindingSource versionBindingSource;
    }
}