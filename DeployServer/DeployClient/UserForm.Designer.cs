namespace DeployClient
{
    partial class UserForm
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
            userBindingSource = new BindingSource(components);
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isAdminDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            enableDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            inDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            editDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastLoginTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            isAdminDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            enableDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            inDateDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            editDateDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            lastLoginTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Entity.User);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "用户名";
            nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "邮箱";
            emailDataGridViewTextBoxColumn.MinimumWidth = 8;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 180;
            // 
            // isAdminDataGridViewCheckBoxColumn
            // 
            isAdminDataGridViewCheckBoxColumn.DataPropertyName = "IsAdmin";
            isAdminDataGridViewCheckBoxColumn.HeaderText = "管理员";
            isAdminDataGridViewCheckBoxColumn.MinimumWidth = 8;
            isAdminDataGridViewCheckBoxColumn.Name = "isAdminDataGridViewCheckBoxColumn";
            isAdminDataGridViewCheckBoxColumn.Width = 120;
            // 
            // enableDataGridViewCheckBoxColumn
            // 
            enableDataGridViewCheckBoxColumn.DataPropertyName = "Enable";
            enableDataGridViewCheckBoxColumn.HeaderText = "启用";
            enableDataGridViewCheckBoxColumn.MinimumWidth = 8;
            enableDataGridViewCheckBoxColumn.Name = "enableDataGridViewCheckBoxColumn";
            enableDataGridViewCheckBoxColumn.Width = 120;
            // 
            // inDateDataGridViewTextBoxColumn
            // 
            inDateDataGridViewTextBoxColumn.DataPropertyName = "InDate";
            inDateDataGridViewTextBoxColumn.HeaderText = "加入时间";
            inDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            inDateDataGridViewTextBoxColumn.Name = "inDateDataGridViewTextBoxColumn";
            inDateDataGridViewTextBoxColumn.Width = 200;
            // 
            // editDateDataGridViewTextBoxColumn
            // 
            editDateDataGridViewTextBoxColumn.DataPropertyName = "EditDate";
            editDateDataGridViewTextBoxColumn.HeaderText = "修改时间";
            editDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            editDateDataGridViewTextBoxColumn.Name = "editDateDataGridViewTextBoxColumn";
            editDateDataGridViewTextBoxColumn.Width = 200;
            // 
            // lastLoginTimeDataGridViewTextBoxColumn
            // 
            lastLoginTimeDataGridViewTextBoxColumn.DataPropertyName = "LastLoginTime";
            lastLoginTimeDataGridViewTextBoxColumn.HeaderText = "上次登录";
            lastLoginTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            lastLoginTimeDataGridViewTextBoxColumn.Name = "lastLoginTimeDataGridViewTextBoxColumn";
            lastLoginTimeDataGridViewTextBoxColumn.Width = 200;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn1, emailDataGridViewTextBoxColumn1, isAdminDataGridViewCheckBoxColumn1, enableDataGridViewCheckBoxColumn1, inDateDataGridViewTextBoxColumn1, editDateDataGridViewTextBoxColumn1, lastLoginTimeDataGridViewTextBoxColumn1 });
            dataGridView1.DataSource = userBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(979, 267);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "用户名";
            nameDataGridViewTextBoxColumn1.MinimumWidth = 8;
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.ReadOnly = true;
            nameDataGridViewTextBoxColumn1.Width = 150;
            // 
            // emailDataGridViewTextBoxColumn1
            // 
            emailDataGridViewTextBoxColumn1.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn1.HeaderText = "邮箱";
            emailDataGridViewTextBoxColumn1.MinimumWidth = 8;
            emailDataGridViewTextBoxColumn1.Name = "emailDataGridViewTextBoxColumn1";
            emailDataGridViewTextBoxColumn1.ReadOnly = true;
            emailDataGridViewTextBoxColumn1.Width = 150;
            // 
            // isAdminDataGridViewCheckBoxColumn1
            // 
            isAdminDataGridViewCheckBoxColumn1.DataPropertyName = "IsAdmin";
            isAdminDataGridViewCheckBoxColumn1.HeaderText = "管理员";
            isAdminDataGridViewCheckBoxColumn1.MinimumWidth = 8;
            isAdminDataGridViewCheckBoxColumn1.Name = "isAdminDataGridViewCheckBoxColumn1";
            isAdminDataGridViewCheckBoxColumn1.ReadOnly = true;
            isAdminDataGridViewCheckBoxColumn1.Width = 60;
            // 
            // enableDataGridViewCheckBoxColumn1
            // 
            enableDataGridViewCheckBoxColumn1.DataPropertyName = "Enable";
            enableDataGridViewCheckBoxColumn1.HeaderText = "启用";
            enableDataGridViewCheckBoxColumn1.MinimumWidth = 8;
            enableDataGridViewCheckBoxColumn1.Name = "enableDataGridViewCheckBoxColumn1";
            enableDataGridViewCheckBoxColumn1.ReadOnly = true;
            enableDataGridViewCheckBoxColumn1.Width = 60;
            // 
            // inDateDataGridViewTextBoxColumn1
            // 
            inDateDataGridViewTextBoxColumn1.DataPropertyName = "InDate";
            inDateDataGridViewTextBoxColumn1.HeaderText = "加入时间";
            inDateDataGridViewTextBoxColumn1.MinimumWidth = 8;
            inDateDataGridViewTextBoxColumn1.Name = "inDateDataGridViewTextBoxColumn1";
            inDateDataGridViewTextBoxColumn1.ReadOnly = true;
            inDateDataGridViewTextBoxColumn1.Width = 180;
            // 
            // editDateDataGridViewTextBoxColumn1
            // 
            editDateDataGridViewTextBoxColumn1.DataPropertyName = "EditDate";
            editDateDataGridViewTextBoxColumn1.HeaderText = "修改时间";
            editDateDataGridViewTextBoxColumn1.MinimumWidth = 8;
            editDateDataGridViewTextBoxColumn1.Name = "editDateDataGridViewTextBoxColumn1";
            editDateDataGridViewTextBoxColumn1.ReadOnly = true;
            editDateDataGridViewTextBoxColumn1.Width = 180;
            // 
            // lastLoginTimeDataGridViewTextBoxColumn1
            // 
            lastLoginTimeDataGridViewTextBoxColumn1.DataPropertyName = "LastLoginTime";
            lastLoginTimeDataGridViewTextBoxColumn1.HeaderText = "上次登录";
            lastLoginTimeDataGridViewTextBoxColumn1.MinimumWidth = 8;
            lastLoginTimeDataGridViewTextBoxColumn1.Name = "lastLoginTimeDataGridViewTextBoxColumn1";
            lastLoginTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            lastLoginTimeDataGridViewTextBoxColumn1.Width = 180;
            // 
            // button1
            // 
            button1.Location = new Point(44, 300);
            button1.Name = "button1";
            button1.Size = new Size(92, 39);
            button1.TabIndex = 1;
            button1.Text = "新用户";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(164, 300);
            button2.Name = "button2";
            button2.Size = new Size(92, 39);
            button2.TabIndex = 2;
            button2.Text = "修改";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(290, 300);
            button3.Name = "button3";
            button3.Size = new Size(92, 39);
            button3.TabIndex = 3;
            button3.Text = "停用";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(417, 300);
            button4.Name = "button4";
            button4.Size = new Size(92, 39);
            button4.TabIndex = 4;
            button4.Text = "删除";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(550, 300);
            button5.Name = "button5";
            button5.Size = new Size(92, 39);
            button5.TabIndex = 5;
            button5.Text = "审核通过";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(672, 310);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(99, 21);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "仅显示未审核";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Click += checkBox1_Click;
            checkBox1.MouseClick += checkBox1_MouseClick;
            // 
            // UserForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1003, 372);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "UserForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "用户";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private BindingSource userBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isAdminDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn enableDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn inDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn editDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastLoginTimeDataGridViewTextBoxColumn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn isAdminDataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn enableDataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn inDateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn editDateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn lastLoginTimeDataGridViewTextBoxColumn1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private CheckBox checkBox1;
    }
}