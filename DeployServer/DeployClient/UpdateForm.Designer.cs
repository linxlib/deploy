namespace DeployClient
{
    partial class UpdateForm
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
            button1 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            versionIntDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            inDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isDeleteDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            hashDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sizeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isPublishDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            publishTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            versionBindingSource = new BindingSource(components);
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)versionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(664, 12);
            button1.Name = "button1";
            button1.Size = new Size(109, 47);
            button1.TabIndex = 0;
            button1.Text = "上传新版本";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 27);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 1;
            label1.Text = "当前最新版本";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, versionIntDataGridViewTextBoxColumn, inDateDataGridViewTextBoxColumn, isDeleteDataGridViewCheckBoxColumn, hashDataGridViewTextBoxColumn, sizeDataGridViewTextBoxColumn, isPublishDataGridViewCheckBoxColumn, publishTimeDataGridViewTextBoxColumn });
            dataGridView1.DataSource = versionBindingSource;
            dataGridView1.Location = new Point(0, 80);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(1029, 370);
            dataGridView1.TabIndex = 2;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "名称";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // versionIntDataGridViewTextBoxColumn
            // 
            versionIntDataGridViewTextBoxColumn.DataPropertyName = "VersionInt";
            versionIntDataGridViewTextBoxColumn.HeaderText = "版本号";
            versionIntDataGridViewTextBoxColumn.Name = "versionIntDataGridViewTextBoxColumn";
            // 
            // inDateDataGridViewTextBoxColumn
            // 
            inDateDataGridViewTextBoxColumn.DataPropertyName = "InDate";
            inDateDataGridViewTextBoxColumn.HeaderText = "加入时间";
            inDateDataGridViewTextBoxColumn.Name = "inDateDataGridViewTextBoxColumn";
            inDateDataGridViewTextBoxColumn.Width = 180;
            // 
            // isDeleteDataGridViewCheckBoxColumn
            // 
            isDeleteDataGridViewCheckBoxColumn.DataPropertyName = "IsDelete";
            isDeleteDataGridViewCheckBoxColumn.HeaderText = "作废";
            isDeleteDataGridViewCheckBoxColumn.Name = "isDeleteDataGridViewCheckBoxColumn";
            // 
            // hashDataGridViewTextBoxColumn
            // 
            hashDataGridViewTextBoxColumn.DataPropertyName = "Hash";
            hashDataGridViewTextBoxColumn.HeaderText = "更新包hash";
            hashDataGridViewTextBoxColumn.Name = "hashDataGridViewTextBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            sizeDataGridViewTextBoxColumn.HeaderText = "大小";
            sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            // 
            // isPublishDataGridViewCheckBoxColumn
            // 
            isPublishDataGridViewCheckBoxColumn.DataPropertyName = "IsPublish";
            isPublishDataGridViewCheckBoxColumn.HeaderText = "已发布";
            isPublishDataGridViewCheckBoxColumn.Name = "isPublishDataGridViewCheckBoxColumn";
            // 
            // publishTimeDataGridViewTextBoxColumn
            // 
            publishTimeDataGridViewTextBoxColumn.DataPropertyName = "PublishTime";
            publishTimeDataGridViewTextBoxColumn.HeaderText = "发布时间";
            publishTimeDataGridViewTextBoxColumn.Name = "publishTimeDataGridViewTextBoxColumn";
            publishTimeDataGridViewTextBoxColumn.Width = 180;
            // 
            // versionBindingSource
            // 
            versionBindingSource.DataSource = typeof(Entity.Version);
            // 
            // button2
            // 
            button2.Location = new Point(554, 12);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(71, 47);
            button2.TabIndex = 3;
            button2.Text = "发布";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(447, 12);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(92, 47);
            button3.TabIndex = 4;
            button3.Text = "查看更新日志";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 27);
            label2.Name = "label2";
            label2.Size = new Size(80, 17);
            label2.TabIndex = 5;
            label2.Text = "当前最新版本";
            // 
            // button4
            // 
            button4.Location = new Point(352, 12);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(71, 47);
            button4.TabIndex = 6;
            button4.Text = "删除";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(813, 12);
            button5.Name = "button5";
            button5.Size = new Size(109, 47);
            button5.TabIndex = 7;
            button5.Text = "上传最新版本";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "UpdateForm";
            Text = "版本更新";
            Shown += UpdateForm_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)versionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Button button4;
        private BindingSource versionBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn versionIntDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn inDateDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isDeleteDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn hashDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isPublishDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn publishTimeDataGridViewTextBoxColumn;
        private Button button5;
    }
}