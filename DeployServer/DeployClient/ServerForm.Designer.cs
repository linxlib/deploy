namespace DeployClient
{
    partial class ServerForm
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
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            label45 = new Label();
            serviceBindingSource1 = new BindingSource(components);
            label46 = new Label();
            label43 = new Label();
            label44 = new Label();
            label41 = new Label();
            label42 = new Label();
            label37 = new Label();
            label38 = new Label();
            label35 = new Label();
            label36 = new Label();
            label33 = new Label();
            label34 = new Label();
            label31 = new Label();
            label32 = new Label();
            label29 = new Label();
            label30 = new Label();
            label1 = new Label();
            listBox2 = new ListBox();
            serviceBindingSource = new BindingSource(components);
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(385, 19);
            groupBox1.Margin = new Padding(5, 4, 5, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 4, 5, 4);
            groupBox1.Size = new Size(811, 272);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "信息";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label45);
            groupBox3.Controls.Add(label46);
            groupBox3.Controls.Add(label43);
            groupBox3.Controls.Add(label44);
            groupBox3.Controls.Add(label41);
            groupBox3.Controls.Add(label42);
            groupBox3.Controls.Add(label37);
            groupBox3.Controls.Add(label38);
            groupBox3.Controls.Add(label35);
            groupBox3.Controls.Add(label36);
            groupBox3.Controls.Add(label33);
            groupBox3.Controls.Add(label34);
            groupBox3.Controls.Add(label31);
            groupBox3.Controls.Add(label32);
            groupBox3.Controls.Add(label29);
            groupBox3.Controls.Add(label30);
            groupBox3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(18, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(751, 225);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "服务";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.DataBindings.Add(new Binding("Text", serviceBindingSource1, "EditDate", true));
            label45.Location = new Point(547, 131);
            label45.Name = "label45";
            label45.Size = new Size(64, 21);
            label45.TabIndex = 29;
            label45.Text = "label45";
            // 
            // serviceBindingSource1
            // 
            serviceBindingSource1.DataSource = typeof(Entity.Service);
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(436, 131);
            label46.Name = "label46";
            label46.Size = new Size(74, 21);
            label46.TabIndex = 28;
            label46.Text = "修改时间";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.DataBindings.Add(new Binding("Text", serviceBindingSource1, "InDate", true));
            label43.Location = new Point(547, 90);
            label43.Name = "label43";
            label43.Size = new Size(64, 21);
            label43.TabIndex = 27;
            label43.Text = "label43";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(436, 90);
            label44.Name = "label44";
            label44.Size = new Size(74, 21);
            label44.TabIndex = 26;
            label44.Text = "加入时间";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.DataBindings.Add(new Binding("Text", serviceBindingSource1, "LastDeployTime", true));
            label41.Location = new Point(547, 49);
            label41.Name = "label41";
            label41.Size = new Size(64, 21);
            label41.TabIndex = 25;
            label41.Text = "label41";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(436, 49);
            label42.Name = "label42";
            label42.Size = new Size(74, 21);
            label42.TabIndex = 24;
            label42.Text = "上次部署";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.DataBindings.Add(new Binding("Text", serviceBindingSource1, "ServiceType", true));
            label37.Location = new Point(547, 172);
            label37.Name = "label37";
            label37.Size = new Size(64, 21);
            label37.TabIndex = 21;
            label37.Text = "label37";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(436, 172);
            label38.Name = "label38";
            label38.Size = new Size(42, 21);
            label38.TabIndex = 20;
            label38.Text = "类型";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.DataBindings.Add(new Binding("Text", serviceBindingSource1, "RealPath", true));
            label35.Location = new Point(107, 172);
            label35.Name = "label35";
            label35.Size = new Size(64, 21);
            label35.TabIndex = 19;
            label35.Text = "label35";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(29, 172);
            label36.Name = "label36";
            label36.Size = new Size(42, 21);
            label36.TabIndex = 18;
            label36.Text = "路径";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.DataBindings.Add(new Binding("Text", serviceBindingSource1, "Arg", true));
            label33.Location = new Point(107, 131);
            label33.Name = "label33";
            label33.Size = new Size(64, 21);
            label33.TabIndex = 17;
            label33.Text = "label33";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(29, 131);
            label34.Name = "label34";
            label34.Size = new Size(42, 21);
            label34.TabIndex = 16;
            label34.Text = "参数";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.DataBindings.Add(new Binding("Text", serviceBindingSource1, "ServiceName", true));
            label31.Location = new Point(107, 90);
            label31.Name = "label31";
            label31.Size = new Size(64, 21);
            label31.TabIndex = 15;
            label31.Text = "label31";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(29, 90);
            label32.Name = "label32";
            label32.Size = new Size(58, 21);
            label32.TabIndex = 14;
            label32.Text = "服务名";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.DataBindings.Add(new Binding("Text", serviceBindingSource1, "Name", true));
            label29.Location = new Point(107, 46);
            label29.Name = "label29";
            label29.Size = new Size(64, 21);
            label29.TabIndex = 13;
            label29.Text = "label29";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(29, 46);
            label30.Name = "label30";
            label30.Size = new Size(42, 21);
            label30.TabIndex = 12;
            label30.Text = "名称";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 19);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 2;
            label1.Text = "服务";
            // 
            // listBox2
            // 
            listBox2.DataSource = serviceBindingSource;
            listBox2.DisplayMember = "Name";
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 17;
            listBox2.Location = new Point(26, 62);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(342, 310);
            listBox2.TabIndex = 5;
            listBox2.ValueMember = "Id";
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Entity.Service);
            // 
            // button7
            // 
            button7.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(525, 312);
            button7.Name = "button7";
            button7.Size = new Size(64, 43);
            button7.TabIndex = 14;
            button7.Text = "删除";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button8.Location = new Point(455, 312);
            button8.Name = "button8";
            button8.Size = new Size(64, 43);
            button8.TabIndex = 13;
            button8.Text = "编辑";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button9.Location = new Point(385, 312);
            button9.Name = "button9";
            button9.Size = new Size(64, 43);
            button9.TabIndex = 12;
            button9.Text = "新增";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // ServerForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1186, 397);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(listBox2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "服务管理";
            Load += ServerForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private ListBox listBox2;
        private Button button7;
        private Button button8;
        private Button button9;
        private GroupBox groupBox3;
        private BindingSource serviceBindingSource;
        private Label label45;
        private Label label46;
        private Label label43;
        private Label label44;
        private Label label41;
        private Label label42;
        private Label label37;
        private Label label38;
        private Label label35;
        private Label label36;
        private Label label33;
        private Label label34;
        private Label label31;
        private Label label32;
        private Label label29;
        private Label label30;
        private BindingSource serviceBindingSource1;
    }
}