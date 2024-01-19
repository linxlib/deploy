namespace DeployClient
{
    partial class UserModalForm
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
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            bindingSource1 = new BindingSource(components);
            textBox2 = new TextBox();
            button3 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 20);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "用户名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 62);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 1;
            label2.Text = "邮箱";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 143);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 2;
            label3.Text = "头像";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 102);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 3;
            label4.Text = "密码";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 143);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 4;
            label5.Text = "管理员";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 188);
            label6.Name = "label6";
            label6.Size = new Size(32, 17);
            label6.TabIndex = 5;
            label6.Text = "启用";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(274, 20);
            label7.Name = "label7";
            label7.Size = new Size(56, 17);
            label7.TabIndex = 6;
            label7.Text = "注册时间";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(274, 62);
            label8.Name = "label8";
            label8.Size = new Size(56, 17);
            label8.TabIndex = 7;
            label8.Text = "修改时间";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(250, 100);
            label9.Name = "label9";
            label9.Size = new Size(80, 17);
            label9.TabIndex = 8;
            label9.Text = "上次登录时间";
            // 
            // button1
            // 
            button1.Location = new Point(66, 291);
            button1.Name = "button1";
            button1.Size = new Size(124, 41);
            button1.TabIndex = 5;
            button1.Text = "确认";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(274, 291);
            button2.Name = "button2";
            button2.Size = new Size(124, 41);
            button2.TabIndex = 6;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("DataContext", bindingSource1, "Name", true));
            textBox1.DataBindings.Add(new Binding("Text", bindingSource1, "Name", true));
            textBox1.Location = new Point(90, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 23);
            textBox1.TabIndex = 1;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Entity.User);
            // 
            // textBox2
            // 
            textBox2.DataBindings.Add(new Binding("DataContext", bindingSource1, "Email", true));
            textBox2.DataBindings.Add(new Binding("Text", bindingSource1, "Email", true));
            textBox2.Location = new Point(90, 59);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(162, 23);
            textBox2.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(90, 98);
            button3.Name = "button3";
            button3.Size = new Size(104, 25);
            button3.TabIndex = 13;
            button3.Text = "重置密码";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.DataBindings.Add(new Binding("CheckState", bindingSource1, "IsAdmin", true));
            checkBox1.DataBindings.Add(new Binding("DataContext", bindingSource1, "IsAdmin", true));
            checkBox1.Location = new Point(91, 143);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 3;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.DataBindings.Add(new Binding("CheckState", bindingSource1, "Enable", true));
            checkBox2.DataBindings.Add(new Binding("DataContext", bindingSource1, "Enable", true));
            checkBox2.Location = new Point(90, 188);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 4;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(274, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(405, 143);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 17;
            button4.Text = "上传";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(405, 182);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 18;
            button5.Text = "清除";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(405, 223);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 19;
            button6.Text = "默认";
            button6.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.DataBindings.Add(new Binding("DataContext", bindingSource1, "InDate", true));
            label10.DataBindings.Add(new Binding("Text", bindingSource1, "InDate", true));
            label10.Location = new Point(336, 19);
            label10.Name = "label10";
            label10.Size = new Size(56, 17);
            label10.TabIndex = 20;
            label10.Text = "注册时间";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.DataBindings.Add(new Binding("DataContext", bindingSource1, "EditDate", true));
            label11.DataBindings.Add(new Binding("Text", bindingSource1, "EditDate", true));
            label11.Location = new Point(336, 62);
            label11.Name = "label11";
            label11.Size = new Size(56, 17);
            label11.TabIndex = 21;
            label11.Text = "注册时间";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.DataBindings.Add(new Binding("DataContext", bindingSource1, "LastLoginTime", true));
            label12.DataBindings.Add(new Binding("Text", bindingSource1, "LastLoginTime", true));
            label12.Location = new Point(336, 100);
            label12.Name = "label12";
            label12.Size = new Size(56, 17);
            label12.TabIndex = 22;
            label12.Text = "注册时间";
            // 
            // openFileDialog1
            // 
            openFileDialog1.AddToRecent = false;
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp";
            openFileDialog1.Title = "选择头像";
            // 
            // UserModalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 348);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserModalForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "用户";
            Load += UserModalForm_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private PictureBox pictureBox1;
        private Button button4;
        private Button button5;
        private Button button6;
        private BindingSource bindingSource1;
        private Label label10;
        private Label label11;
        private Label label12;
        private OpenFileDialog openFileDialog1;
    }
}