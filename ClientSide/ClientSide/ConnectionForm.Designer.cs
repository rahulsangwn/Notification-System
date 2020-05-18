namespace ClientSide
{
    partial class ConnectionForm
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
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxConnectionLog = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonServerNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(146, 33);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(170, 26);
            this.textBoxServerIP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server IP";
            // 
            // textBoxConnectionLog
            // 
            this.textBoxConnectionLog.Location = new System.Drawing.Point(59, 112);
            this.textBoxConnectionLog.Multiline = true;
            this.textBoxConnectionLog.Name = "textBoxConnectionLog";
            this.textBoxConnectionLog.ReadOnly = true;
            this.textBoxConnectionLog.Size = new System.Drawing.Size(679, 207);
            this.textBoxConnectionLog.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(571, 33);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(89, 34);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonServerNext
            // 
            this.buttonServerNext.Location = new System.Drawing.Point(632, 368);
            this.buttonServerNext.Name = "buttonServerNext";
            this.buttonServerNext.Size = new System.Drawing.Size(105, 42);
            this.buttonServerNext.TabIndex = 4;
            this.buttonServerNext.Text = "Next";
            this.buttonServerNext.UseVisualStyleBackColor = true;
            this.buttonServerNext.Click += new System.EventHandler(this.buttonServerNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(410, 33);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(113, 26);
            this.textBoxServerPort.TabIndex = 6;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonServerNext);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxConnectionLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxServerIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectionForm";
            this.Text = "Connect to Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxConnectionLog;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonServerNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServerPort;
    }
}

