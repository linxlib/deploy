namespace DeployClient
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            label2 = new Label();
            groupBox1 = new GroupBox();
            button5 = new Button();
            label19 = new Label();
            serviceBindingSource = new BindingSource(components);
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            button4 = new Button();
            button3 = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel4 = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            用户管理ToolStripMenuItem = new ToolStripMenuItem();
            服务管理ToolStripMenuItem = new ToolStripMenuItem();
            部署日志ToolStripMenuItem = new ToolStripMenuItem();
            其他管理ToolStripMenuItem = new ToolStripMenuItem();
            安全组管理ToolStripMenuItem = new ToolStripMenuItem();
            域名解析管理ToolStripMenuItem = new ToolStripMenuItem();
            版本更新ToolStripMenuItem = new ToolStripMenuItem();
            linkLabel1 = new LinkLabel();
            listBox2 = new ListBox();
            linkLabel2 = new LinkLabel();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button6 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 24);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 1;
            label2.Text = "服务";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(269, 24);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(609, 257);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "服务信息";
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(373, 214);
            button5.Margin = new Padding(5, 4, 5, 4);
            button5.Name = "button5";
            button5.Size = new Size(106, 35);
            button5.TabIndex = 18;
            button5.Text = "查看文件目录";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.DataBindings.Add(new Binding("Text", serviceBindingSource, "ListenUrl", true, DataSourceUpdateMode.OnPropertyChanged));
            label19.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(382, 115);
            label19.Margin = new Padding(5, 0, 5, 0);
            label19.Name = "label19";
            label19.Size = new Size(37, 20);
            label19.TabIndex = 17;
            label19.Text = "监听";
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Entity.Service);
            serviceBindingSource.CurrentChanged += serviceBindingSource_CurrentChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(333, 115);
            label18.Margin = new Padding(5, 0, 5, 0);
            label18.Name = "label18";
            label18.Size = new Size(37, 20);
            label18.TabIndex = 16;
            label18.Text = "监听";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(383, 71);
            label17.Margin = new Padding(5, 0, 5, 0);
            label17.Name = "label17";
            label17.Size = new Size(37, 20);
            label17.TabIndex = 15;
            label17.Text = "名称";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.DataBindings.Add(new Binding("Text", serviceBindingSource, "LastDeployTime", true));
            label16.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(382, 30);
            label16.Margin = new Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new Size(37, 20);
            label16.TabIndex = 14;
            label16.Text = "名称";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.DataBindings.Add(new Binding("Text", serviceBindingSource, "Arg", true));
            label15.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(88, 205);
            label15.Margin = new Padding(5, 0, 5, 0);
            label15.Name = "label15";
            label15.Size = new Size(37, 20);
            label15.TabIndex = 13;
            label15.Text = "名称";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.DataBindings.Add(new Binding("Text", serviceBindingSource, "RealPath", true));
            label14.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(88, 161);
            label14.Margin = new Padding(5, 0, 5, 0);
            label14.Name = "label14";
            label14.Size = new Size(37, 20);
            label14.TabIndex = 12;
            label14.Text = "名称";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.DataBindings.Add(new Binding("Text", serviceBindingSource, "ServiceType", true));
            label13.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(88, 115);
            label13.Margin = new Padding(5, 0, 5, 0);
            label13.Name = "label13";
            label13.Size = new Size(37, 20);
            label13.TabIndex = 11;
            label13.Text = "名称";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.DataBindings.Add(new Binding("Text", serviceBindingSource, "ServiceName", true));
            label12.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(88, 71);
            label12.Margin = new Padding(5, 0, 5, 0);
            label12.Name = "label12";
            label12.Size = new Size(37, 20);
            label12.TabIndex = 10;
            label12.Text = "名称";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.DataBindings.Add(new Binding("Text", serviceBindingSource, "Name", true));
            label11.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(88, 30);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(37, 20);
            label11.TabIndex = 9;
            label11.Text = "名称";
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(438, 171);
            button4.Margin = new Padding(5, 4, 5, 4);
            button4.Name = "button4";
            button4.Size = new Size(112, 35);
            button4.TabIndex = 8;
            button4.Text = "关闭";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(308, 171);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(106, 35);
            button3.TabIndex = 7;
            button3.Text = "重启";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(28, 205);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(37, 20);
            label10.TabIndex = 6;
            label10.Text = "参数";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(333, 71);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(37, 20);
            label9.TabIndex = 5;
            label9.Text = "状态";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(305, 30);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 4;
            label8.Text = "上次部署";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(28, 161);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 3;
            label7.Text = "路径";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(28, 115);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(37, 20);
            label6.TabIndex = 2;
            label6.Text = "类型";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(17, 71);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 1;
            label5.Text = "服务名";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(28, 30);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 0;
            label4.Text = "名称";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "目录", "文件选择", "压缩包" });
            comboBox1.Location = new Point(278, 343);
            comboBox1.Margin = new Padding(5, 4, 5, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(296, 304);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 6;
            label3.Text = "本地发布路径";
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(274, 400);
            button1.Margin = new Padding(5, 4, 5, 4);
            button1.Name = "button1";
            button1.Size = new Size(164, 55);
            button1.TabIndex = 7;
            button1.Text = "选择";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(448, 304);
            textBox1.Margin = new Padding(5, 4, 5, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(430, 151);
            textBox1.TabIndex = 8;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(274, 477);
            button2.Margin = new Padding(5, 4, 5, 4);
            button2.Name = "button2";
            button2.Size = new Size(273, 123);
            button2.TabIndex = 9;
            button2.Text = "部署";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel4, toolStripStatusLabel5 });
            statusStrip1.Location = new Point(0, 613);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(2, 0, 22, 0);
            statusStrip1.Size = new Size(888, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(32, 17);
            toolStripStatusLabel1.Text = "用户";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(44, 17);
            toolStripStatusLabel2.Text = "管理员";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(32, 17);
            toolStripStatusLabel3.Text = "时间";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new Size(56, 17);
            toolStripStatusLabel4.Text = "连接状态";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(44, 17);
            toolStripStatusLabel5.Text = "服务器";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 用户管理ToolStripMenuItem, 服务管理ToolStripMenuItem, 部署日志ToolStripMenuItem, 其他管理ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(125, 92);
            // 
            // 用户管理ToolStripMenuItem
            // 
            用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            用户管理ToolStripMenuItem.Size = new Size(124, 22);
            用户管理ToolStripMenuItem.Text = "用户管理";
            用户管理ToolStripMenuItem.Click += 用户管理ToolStripMenuItem_Click;
            // 
            // 服务管理ToolStripMenuItem
            // 
            服务管理ToolStripMenuItem.Name = "服务管理ToolStripMenuItem";
            服务管理ToolStripMenuItem.Size = new Size(124, 22);
            服务管理ToolStripMenuItem.Text = "服务管理";
            服务管理ToolStripMenuItem.Click += 服务管理ToolStripMenuItem_Click;
            // 
            // 部署日志ToolStripMenuItem
            // 
            部署日志ToolStripMenuItem.Name = "部署日志ToolStripMenuItem";
            部署日志ToolStripMenuItem.Size = new Size(124, 22);
            部署日志ToolStripMenuItem.Text = "部署记录";
            部署日志ToolStripMenuItem.Click += 部署日志ToolStripMenuItem_Click;
            // 
            // 其他管理ToolStripMenuItem
            // 
            其他管理ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 安全组管理ToolStripMenuItem, 域名解析管理ToolStripMenuItem, 版本更新ToolStripMenuItem });
            其他管理ToolStripMenuItem.Name = "其他管理ToolStripMenuItem";
            其他管理ToolStripMenuItem.Size = new Size(124, 22);
            其他管理ToolStripMenuItem.Text = "其他管理";
            // 
            // 安全组管理ToolStripMenuItem
            // 
            安全组管理ToolStripMenuItem.Name = "安全组管理ToolStripMenuItem";
            安全组管理ToolStripMenuItem.Size = new Size(148, 22);
            安全组管理ToolStripMenuItem.Text = "安全组管理";
            // 
            // 域名解析管理ToolStripMenuItem
            // 
            域名解析管理ToolStripMenuItem.Name = "域名解析管理ToolStripMenuItem";
            域名解析管理ToolStripMenuItem.Size = new Size(148, 22);
            域名解析管理ToolStripMenuItem.Text = "域名解析管理";
            // 
            // 版本更新ToolStripMenuItem
            // 
            版本更新ToolStripMenuItem.Name = "版本更新ToolStripMenuItem";
            版本更新ToolStripMenuItem.Size = new Size(148, 22);
            版本更新ToolStripMenuItem.Text = "版本更新";
            版本更新ToolStripMenuItem.Click += 版本更新ToolStripMenuItem_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.ContextMenuStrip = contextMenuStrip1;
            linkLabel1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.Location = new Point(725, 517);
            linkLabel1.Margin = new Padding(5, 0, 5, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(42, 21);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "管理";
            linkLabel1.Click += linkLabel1_Click;
            // 
            // listBox2
            // 
            listBox2.DataSource = serviceBindingSource;
            listBox2.DisplayMember = "Name";
            listBox2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 20;
            listBox2.Location = new Point(15, 56);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(236, 544);
            listBox2.TabIndex = 15;
            listBox2.ValueMember = "Id";
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel2.Location = new Point(725, 477);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(74, 21);
            linkLabel2.TabIndex = 16;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "切换用户";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            linkLabel2.MouseClick += linkLabel2_MouseClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(568, 462);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(122, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "zip";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Multiselect = true;
            // 
            // button6
            // 
            button6.Location = new Point(725, 569);
            button6.Name = "button6";
            button6.Size = new Size(112, 31);
            button6.TabIndex = 18;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(888, 635);
            Controls.Add(button6);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel2);
            Controls.Add(listBox2);
            Controls.Add(linkLabel1);
            Controls.Add(statusStrip1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "部署客户端 v2 by linx@2023";
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button4;
        private Button button3;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private StatusStrip statusStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 用户管理ToolStripMenuItem;
        private ToolStripMenuItem 服务管理ToolStripMenuItem;
        private ToolStripMenuItem 部署日志ToolStripMenuItem;
        private ToolStripMenuItem 其他管理ToolStripMenuItem;
        private ToolStripMenuItem 安全组管理ToolStripMenuItem;
        private ToolStripMenuItem 域名解析管理ToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private LinkLabel linkLabel1;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripMenuItem 版本更新ToolStripMenuItem;
        private ListBox listBox2;
        private LinkLabel linkLabel2;
        private BindingSource serviceBindingSource;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label19;
        private Label label18;
        private Button button5;
        private Button button6;
    }
}