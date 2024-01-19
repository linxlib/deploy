namespace DeployClient.Modals
{
    partial class RemoteDirectorySelectModalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDirectorySelectModalForm));
            treeView1 = new TreeView();
            imageList1 = new ImageList(components);
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.ImageIndex = 0;
            treeView1.ImageList = imageList1;
            treeView1.Location = new Point(12, 74);
            treeView1.Name = "treeView1";
            treeView1.SelectedImageIndex = 0;
            treeView1.Size = new Size(345, 392);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "file.ico");
            imageList1.Images.SetKeyName(1, "folder.ico");
            // 
            // button1
            // 
            button1.Location = new Point(106, 472);
            button1.Name = "button1";
            button1.Size = new Size(137, 35);
            button1.TabIndex = 1;
            button1.Text = "选择";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 12);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 2;
            label1.Text = "根路径";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 12);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 3;
            label2.Text = "根路径";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 42);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 4;
            label3.Text = "选择";
            // 
            // RemoteDirectorySelectModalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 519);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(treeView1);
            Name = "RemoteDirectorySelectModalForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "目录选择";
            FormClosed += RemoteDirectorySelectModalForm_FormClosed;
            Shown += RemoteDirectorySelectModalForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button button1;
        private Label label1;
        private Label label2;
        private ImageList imageList1;
        private Label label3;
    }
}