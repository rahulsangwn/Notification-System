namespace ClientSide
{
    partial class ModeSelectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonEmail = new System.Windows.Forms.RadioButton();
            this.radioButtonSMS = new System.Windows.Forms.RadioButton();
            this.radioButtonPortal = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIdentity = new System.Windows.Forms.TextBox();
            this.buttonModeSelectionFormNext = new System.Windows.Forms.Button();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Receiving Mode:";
            // 
            // radioButtonEmail
            // 
            this.radioButtonEmail.AutoSize = true;
            this.radioButtonEmail.Location = new System.Drawing.Point(107, 104);
            this.radioButtonEmail.Name = "radioButtonEmail";
            this.radioButtonEmail.Size = new System.Drawing.Size(73, 24);
            this.radioButtonEmail.TabIndex = 1;
            this.radioButtonEmail.TabStop = true;
            this.radioButtonEmail.Text = "Email";
            this.radioButtonEmail.UseVisualStyleBackColor = true;
            // 
            // radioButtonSMS
            // 
            this.radioButtonSMS.AutoSize = true;
            this.radioButtonSMS.Location = new System.Drawing.Point(285, 104);
            this.radioButtonSMS.Name = "radioButtonSMS";
            this.radioButtonSMS.Size = new System.Drawing.Size(69, 24);
            this.radioButtonSMS.TabIndex = 2;
            this.radioButtonSMS.TabStop = true;
            this.radioButtonSMS.Text = "SMS";
            this.radioButtonSMS.UseVisualStyleBackColor = true;
            // 
            // radioButtonPortal
            // 
            this.radioButtonPortal.AutoSize = true;
            this.radioButtonPortal.Location = new System.Drawing.Point(460, 104);
            this.radioButtonPortal.Name = "radioButtonPortal";
            this.radioButtonPortal.Size = new System.Drawing.Size(124, 24);
            this.radioButtonPortal.TabIndex = 3;
            this.radioButtonPortal.TabStop = true;
            this.radioButtonPortal.Text = "Online Portal";
            this.radioButtonPortal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "E-mail / Phone: ";
            // 
            // textBoxIdentity
            // 
            this.textBoxIdentity.Location = new System.Drawing.Point(195, 221);
            this.textBoxIdentity.Name = "textBoxIdentity";
            this.textBoxIdentity.Size = new System.Drawing.Size(262, 26);
            this.textBoxIdentity.TabIndex = 5;
            // 
            // buttonModeSelectionFormNext
            // 
            this.buttonModeSelectionFormNext.Location = new System.Drawing.Point(285, 321);
            this.buttonModeSelectionFormNext.Name = "buttonModeSelectionFormNext";
            this.buttonModeSelectionFormNext.Size = new System.Drawing.Size(113, 41);
            this.buttonModeSelectionFormNext.TabIndex = 6;
            this.buttonModeSelectionFormNext.Text = "Next";
            this.buttonModeSelectionFormNext.UseVisualStyleBackColor = true;
            // 
            // buttonVerify
            // 
            this.buttonVerify.Location = new System.Drawing.Point(497, 216);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(87, 40);
            this.buttonVerify.TabIndex = 7;
            this.buttonVerify.Text = "Verify";
            this.buttonVerify.UseVisualStyleBackColor = true;
            // 
            // ModeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 422);
            this.Controls.Add(this.buttonVerify);
            this.Controls.Add(this.buttonModeSelectionFormNext);
            this.Controls.Add(this.textBoxIdentity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButtonPortal);
            this.Controls.Add(this.radioButtonSMS);
            this.Controls.Add(this.radioButtonEmail);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModeSelectionForm";
            this.Text = "Select Receiving Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonEmail;
        private System.Windows.Forms.RadioButton radioButtonSMS;
        private System.Windows.Forms.RadioButton radioButtonPortal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIdentity;
        private System.Windows.Forms.Button buttonModeSelectionFormNext;
        private System.Windows.Forms.Button buttonVerify;
    }
}