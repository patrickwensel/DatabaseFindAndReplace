﻿namespace DataBaseGrepper
{
    partial class Form1
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFindAndPreview = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnFindReplaceAndPreview = new System.Windows.Forms.Button();
            this.btbFindReplaceGenateScriptsPreview = new System.Windows.Forms.Button();
            this.btnFindReplaceGenerateScriptsToFile = new System.Windows.Forms.Button();
            this.btnFindReplaceRunOnDatabase = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.rbResults = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Find";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(116, 118);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(385, 20);
            this.txtFind.TabIndex = 4;
            // 
            // btnFindAndPreview
            // 
            this.btnFindAndPreview.AutoSize = true;
            this.btnFindAndPreview.Enabled = false;
            this.btnFindAndPreview.Location = new System.Drawing.Point(162, 196);
            this.btnFindAndPreview.Name = "btnFindAndPreview";
            this.btnFindAndPreview.Size = new System.Drawing.Size(99, 23);
            this.btnFindAndPreview.TabIndex = 8;
            this.btnFindAndPreview.Text = "Find and Preview";
            this.btnFindAndPreview.UseVisualStyleBackColor = true;
            this.btnFindAndPreview.Click += new System.EventHandler(this.btnFindAndPreview_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.AutoSize = true;
            this.btnTestConnection.Location = new System.Drawing.Point(12, 196);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(144, 23);
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Test Database Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnFindReplaceAndPreview
            // 
            this.btnFindReplaceAndPreview.AutoSize = true;
            this.btnFindReplaceAndPreview.Enabled = false;
            this.btnFindReplaceAndPreview.Location = new System.Drawing.Point(267, 196);
            this.btnFindReplaceAndPreview.Name = "btnFindReplaceAndPreview";
            this.btnFindReplaceAndPreview.Size = new System.Drawing.Size(144, 23);
            this.btnFindReplaceAndPreview.TabIndex = 9;
            this.btnFindReplaceAndPreview.Text = "Find/Replace and Preview";
            this.btnFindReplaceAndPreview.UseVisualStyleBackColor = true;
            // 
            // btbFindReplaceGenateScriptsPreview
            // 
            this.btbFindReplaceGenateScriptsPreview.AutoSize = true;
            this.btbFindReplaceGenateScriptsPreview.Enabled = false;
            this.btbFindReplaceGenateScriptsPreview.Location = new System.Drawing.Point(417, 196);
            this.btbFindReplaceGenateScriptsPreview.Name = "btbFindReplaceGenateScriptsPreview";
            this.btbFindReplaceGenateScriptsPreview.Size = new System.Drawing.Size(205, 23);
            this.btbFindReplaceGenateScriptsPreview.TabIndex = 10;
            this.btbFindReplaceGenateScriptsPreview.Text = "Find/Replace Generate Scripts Preview";
            this.btbFindReplaceGenateScriptsPreview.UseVisualStyleBackColor = true;
            // 
            // btnFindReplaceGenerateScriptsToFile
            // 
            this.btnFindReplaceGenerateScriptsToFile.AutoSize = true;
            this.btnFindReplaceGenerateScriptsToFile.Location = new System.Drawing.Point(628, 196);
            this.btnFindReplaceGenerateScriptsToFile.Name = "btnFindReplaceGenerateScriptsToFile";
            this.btnFindReplaceGenerateScriptsToFile.Size = new System.Drawing.Size(205, 23);
            this.btnFindReplaceGenerateScriptsToFile.TabIndex = 11;
            this.btnFindReplaceGenerateScriptsToFile.Text = "Find/Replace Generate Scripts to File";
            this.btnFindReplaceGenerateScriptsToFile.UseVisualStyleBackColor = true;
            this.btnFindReplaceGenerateScriptsToFile.Click += new System.EventHandler(this.btnFindReplaceGenerateScriptsToFile_Click);
            // 
            // btnFindReplaceRunOnDatabase
            // 
            this.btnFindReplaceRunOnDatabase.AutoSize = true;
            this.btnFindReplaceRunOnDatabase.Enabled = false;
            this.btnFindReplaceRunOnDatabase.Location = new System.Drawing.Point(839, 196);
            this.btnFindReplaceRunOnDatabase.Name = "btnFindReplaceRunOnDatabase";
            this.btnFindReplaceRunOnDatabase.Size = new System.Drawing.Size(204, 23);
            this.btnFindReplaceRunOnDatabase.TabIndex = 12;
            this.btnFindReplaceRunOnDatabase.Text = "Find/Replace Run on Database";
            this.btnFindReplaceRunOnDatabase.UseVisualStyleBackColor = true;
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(116, 144);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(385, 20);
            this.txtReplace.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Replace";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(116, 14);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(385, 20);
            this.txtServerName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Server Name";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(116, 40);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(385, 20);
            this.txtDatabaseName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Database Name";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(116, 66);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(385, 20);
            this.txtLogin.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Login";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(116, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(385, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Password";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatus,
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 633);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // rbResults
            // 
            this.rbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rbResults.CausesValidation = false;
            this.rbResults.Location = new System.Drawing.Point(12, 225);
            this.rbResults.Name = "rbResults";
            this.rbResults.Size = new System.Drawing.Size(1031, 405);
            this.rbResults.TabIndex = 13;
            this.rbResults.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 655);
            this.Controls.Add(this.rbResults);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFindReplaceRunOnDatabase);
            this.Controls.Add(this.btnFindReplaceGenerateScriptsToFile);
            this.Controls.Add(this.btbFindReplaceGenateScriptsPreview);
            this.Controls.Add(this.btnFindReplaceAndPreview);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnFindAndPreview);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label3);
            this.MinimumSize = new System.Drawing.Size(1071, 694);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Find and Replace";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFindAndPreview;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnFindReplaceAndPreview;
        private System.Windows.Forms.Button btbFindReplaceGenateScriptsPreview;
        private System.Windows.Forms.Button btnFindReplaceGenerateScriptsToFile;
        private System.Windows.Forms.Button btnFindReplaceRunOnDatabase;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.RichTextBox rbResults;
    }
}

