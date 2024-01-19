namespace DeployClient
{
    partial class ServiceModalForm
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
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            serviceBindingSource = new BindingSource(components);
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox2 = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 28);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 0;
            label1.Text = "名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 73);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 1;
            label2.Text = "服务名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 118);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 2;
            label3.Text = "参数";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 164);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 3;
            label4.Text = "路径";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 203);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 5;
            label6.Text = "服务类型";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(397, 28);
            label7.Name = "label7";
            label7.Size = new Size(56, 17);
            label7.TabIndex = 6;
            label7.Text = "上次部署";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(397, 73);
            label8.Name = "label8";
            label8.Size = new Size(56, 17);
            label8.TabIndex = 7;
            label8.Text = "加入时间";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(397, 117);
            label9.Name = "label9";
            label9.Size = new Size(56, 17);
            label9.TabIndex = 8;
            label9.Text = "修改时间";
            // 
            // button1
            // 
            button1.Location = new Point(77, 250);
            button1.Name = "button1";
            button1.Size = new Size(144, 46);
            button1.TabIndex = 7;
            button1.Text = "确认";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(324, 250);
            button2.Name = "button2";
            button2.Size = new Size(144, 46);
            button2.TabIndex = 8;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", serviceBindingSource, "Name", true, DataSourceUpdateMode.OnPropertyChanged));
            textBox1.Location = new Point(104, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(256, 23);
            textBox1.TabIndex = 1;
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Entity.Service);
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("Text", serviceBindingSource, "ServiceName", true, DataSourceUpdateMode.OnPropertyChanged));
            textBox2.Location = new Point(104, 70);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(256, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.DataBindings.Add(new Binding("Text", serviceBindingSource, "Arg", true, DataSourceUpdateMode.OnPropertyChanged));
            textBox3.Location = new Point(104, 115);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(256, 23);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.DataBindings.Add(new Binding("Text", serviceBindingSource, "RealPath", true, DataSourceUpdateMode.OnPropertyChanged));
            textBox4.Location = new Point(104, 161);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(256, 23);
            textBox4.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.DataBindings.Add(new Binding("Text", serviceBindingSource, "ServiceType", true, DataSourceUpdateMode.OnPropertyChanged));
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "IIS", "Console", "Service", "Systemd", "Dir" });
            comboBox2.Location = new Point(104, 200);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(256, 25);
            comboBox2.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.DataBindings.Add(new Binding("Text", serviceBindingSource, "LastDeployTime", true));
            label10.Location = new Point(459, 28);
            label10.Name = "label10";
            label10.Size = new Size(50, 17);
            label10.TabIndex = 17;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.DataBindings.Add(new Binding("Text", serviceBindingSource, "InDate", true));
            label11.Location = new Point(459, 73);
            label11.Name = "label11";
            label11.Size = new Size(50, 17);
            label11.TabIndex = 18;
            label11.Text = "label11";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.DataBindings.Add(new Binding("Text", serviceBindingSource, "EditDate", true));
            label12.Location = new Point(459, 117);
            label12.Name = "label12";
            label12.Size = new Size(50, 17);
            label12.TabIndex = 19;
            label12.Text = "label12";
            // 
            // button3
            // 
            button3.Location = new Point(397, 157);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(101, 24);
            button3.TabIndex = 20;
            button3.Text = "选择服务器路径";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(397, 197);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(101, 24);
            button4.TabIndex = 21;
            button4.Text = "选择IIS服务";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_ClickAsync;
            // 
            // ServiceModalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 316);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(comboBox2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ServiceModalForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "服务";
            FormClosing += ServiceModalForm_FormClosing;
            Shown += ServiceModalForm_Load;
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox2;
        private Label label10;
        private Label label11;
        private Label label12;
        private BindingSource serviceBindingSource;
        private Button button3;
        private Button button4;
    }
}