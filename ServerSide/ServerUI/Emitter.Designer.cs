namespace ServerUI
{
    partial class Emitter
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
            this.buttonPush = new System.Windows.Forms.Button();
            this.textBoxNotification = new System.Windows.Forms.TextBox();
            this.labelNotificationType = new System.Windows.Forms.Label();
            this.comboBoxNotificationType = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPush
            // 
            this.buttonPush.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPush.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPush.Location = new System.Drawing.Point(50, 401);
            this.buttonPush.Name = "buttonPush";
            this.buttonPush.Size = new System.Drawing.Size(121, 39);
            this.buttonPush.TabIndex = 2;
            this.buttonPush.Text = "Push";
            this.buttonPush.UseVisualStyleBackColor = false;
            this.buttonPush.Click += new System.EventHandler(this.buttonPush_Click);
            // 
            // textBoxNotification
            // 
            this.textBoxNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNotification.Location = new System.Drawing.Point(50, 243);
            this.textBoxNotification.Multiline = true;
            this.textBoxNotification.Name = "textBoxNotification";
            this.textBoxNotification.Size = new System.Drawing.Size(628, 129);
            this.textBoxNotification.TabIndex = 3;
            // 
            // labelNotificationType
            // 
            this.labelNotificationType.AutoSize = true;
            this.labelNotificationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotificationType.Location = new System.Drawing.Point(46, 64);
            this.labelNotificationType.Name = "labelNotificationType";
            this.labelNotificationType.Size = new System.Drawing.Size(130, 20);
            this.labelNotificationType.TabIndex = 6;
            this.labelNotificationType.Text = "Notification Type:";
            // 
            // comboBoxNotificationType
            // 
            this.comboBoxNotificationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNotificationType.FormattingEnabled = true;
            this.comboBoxNotificationType.Items.AddRange(new object[] {
            "Events or Celebrations",
            "Urgent Help",
            "Holiday",
            "Organization News",
            "New Policy"});
            this.comboBoxNotificationType.Location = new System.Drawing.Point(50, 87);
            this.comboBoxNotificationType.Name = "comboBoxNotificationType";
            this.comboBoxNotificationType.Size = new System.Drawing.Size(628, 28);
            this.comboBoxNotificationType.TabIndex = 7;
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "All",
            "Gurgoan",
            "Jaipur",
            "Noida",
            "Banglore",
            "Engineer",
            "HR"});
            this.comboBoxGroup.Location = new System.Drawing.Point(50, 166);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(628, 28);
            this.comboBoxGroup.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select a Group/ Fill comma seprated Emails: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Notification Body:";
            // 
            // Emitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 487);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.comboBoxNotificationType);
            this.Controls.Add(this.labelNotificationType);
            this.Controls.Add(this.textBoxNotification);
            this.Controls.Add(this.buttonPush);
            this.Name = "Emitter";
            this.Text = "Emitter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Emitter_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPush;
        private System.Windows.Forms.TextBox textBoxNotification;
        private System.Windows.Forms.Label labelNotificationType;
        private System.Windows.Forms.ComboBox comboBoxNotificationType;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

