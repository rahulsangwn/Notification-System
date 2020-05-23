namespace ClientSide
{
    partial class NotificationForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewNotification = new System.Windows.Forms.DataGridView();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clear = new System.Windows.Forms.DataGridViewButtonColumn();
            this.notificationEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNotification
            // 
            this.dataGridViewNotification.AllowUserToAddRows = false;
            this.dataGridViewNotification.AllowUserToDeleteRows = false;
            this.dataGridViewNotification.AllowUserToOrderColumns = true;
            this.dataGridViewNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewNotification.AutoGenerateColumns = false;
            this.dataGridViewNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewTextBoxColumn,
            this.notificationDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.Clear});
            this.dataGridViewNotification.DataSource = this.notificationEntityBindingSource;
            this.dataGridViewNotification.EnableHeadersVisualStyles = false;
            this.dataGridViewNotification.Location = new System.Drawing.Point(12, 54);
            this.dataGridViewNotification.Name = "dataGridViewNotification";
            this.dataGridViewNotification.ReadOnly = true;
            this.dataGridViewNotification.RowHeadersVisible = false;
            this.dataGridViewNotification.RowTemplate.Height = 28;
            this.dataGridViewNotification.Size = new System.Drawing.Size(1092, 431);
            this.dataGridViewNotification.TabIndex = 0;
            this.dataGridViewNotification.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNotification_CellContentClick);
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.Frozen = true;
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 130;
            // 
            // notificationDataGridViewTextBoxColumn
            // 
            this.notificationDataGridViewTextBoxColumn.DataPropertyName = "Notification";
            this.notificationDataGridViewTextBoxColumn.Frozen = true;
            this.notificationDataGridViewTextBoxColumn.HeaderText = "Notification";
            this.notificationDataGridViewTextBoxColumn.Name = "notificationDataGridViewTextBoxColumn";
            this.notificationDataGridViewTextBoxColumn.ReadOnly = true;
            this.notificationDataGridViewTextBoxColumn.Width = 400;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.Frozen = true;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Clear
            // 
            this.Clear.Frozen = true;
            this.Clear.HeaderText = "";
            this.Clear.Name = "Clear";
            this.Clear.ReadOnly = true;
            this.Clear.Text = "Clear";
            this.Clear.UseColumnTextForButtonValue = true;
            this.Clear.Width = 80;
            // 
            // notificationEntityBindingSource
            // 
            this.notificationEntityBindingSource.DataSource = typeof(ClientSide.Data.NotificationEntity);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(458, 21);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(72, 20);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "label info";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 497);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.dataGridViewNotification);
            this.Name = "NotificationForm";
            this.Text = "NotificationForm";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNotification;
        private System.Windows.Forms.BindingSource notificationEntityBindingSource;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Clear;
    }
}