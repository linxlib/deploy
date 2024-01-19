namespace DeployClient.Modals
{
    partial class AvailableServiceForm
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
            listBox1 = new ListBox();
            serviceBindingSource = new BindingSource(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.DataSource = serviceBindingSource;
            listBox1.DisplayMember = "Name";
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(348, 310);
            listBox1.TabIndex = 0;
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Entity.Service);
            // 
            // button1
            // 
            button1.Location = new Point(92, 349);
            button1.Name = "button1";
            button1.Size = new Size(188, 40);
            button1.TabIndex = 1;
            button1.Text = "选择";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AvailableServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 401);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "AvailableServiceForm";
            Text = "AvailableServiceForm";
            Shown += AvailableServiceForm_Shown;
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private BindingSource serviceBindingSource;
    }
}