namespace FTP
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
            this.connectButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.enterFolderButton = new System.Windows.Forms.Button();
            this.parentDirectoryButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.hostNameBox = new System.Windows.Forms.TextBox();
            this.localListBox = new System.Windows.Forms.ListBox();
            this.localEnterButton = new System.Windows.Forms.Button();
            this.localBackButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.renameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(356, 8);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(126, 12);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 2;
            this.usernameBox.Text = "Ignas";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(241, 12);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.Text = "makaka";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(463, 8);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 4;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(369, 110);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(284, 147);
            this.fileList.TabIndex = 7;
            // 
            // enterFolderButton
            // 
            this.enterFolderButton.Location = new System.Drawing.Point(369, 263);
            this.enterFolderButton.Name = "enterFolderButton";
            this.enterFolderButton.Size = new System.Drawing.Size(75, 23);
            this.enterFolderButton.TabIndex = 8;
            this.enterFolderButton.Text = "Enter folder";
            this.enterFolderButton.UseVisualStyleBackColor = true;
            this.enterFolderButton.Click += new System.EventHandler(this.enterFolderButton_Click);
            // 
            // parentDirectoryButton
            // 
            this.parentDirectoryButton.Location = new System.Drawing.Point(369, 289);
            this.parentDirectoryButton.Name = "parentDirectoryButton";
            this.parentDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.parentDirectoryButton.TabIndex = 9;
            this.parentDirectoryButton.Text = "Back";
            this.parentDirectoryButton.UseVisualStyleBackColor = true;
            this.parentDirectoryButton.Click += new System.EventHandler(this.parentDirectoryButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(369, 81);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 11;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(241, 81);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 12;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // hostNameBox
            // 
            this.hostNameBox.Location = new System.Drawing.Point(11, 12);
            this.hostNameBox.Name = "hostNameBox";
            this.hostNameBox.Size = new System.Drawing.Size(100, 20);
            this.hostNameBox.TabIndex = 13;
            // 
            // localListBox
            // 
            this.localListBox.FormattingEnabled = true;
            this.localListBox.Location = new System.Drawing.Point(12, 136);
            this.localListBox.Name = "localListBox";
            this.localListBox.Size = new System.Drawing.Size(305, 121);
            this.localListBox.TabIndex = 14;
            // 
            // localEnterButton
            // 
            this.localEnterButton.Location = new System.Drawing.Point(12, 265);
            this.localEnterButton.Name = "localEnterButton";
            this.localEnterButton.Size = new System.Drawing.Size(75, 23);
            this.localEnterButton.TabIndex = 15;
            this.localEnterButton.Text = "Enter folder";
            this.localEnterButton.UseVisualStyleBackColor = true;
            this.localEnterButton.Click += new System.EventHandler(this.localEnterButton_Click);
            // 
            // localBackButton
            // 
            this.localBackButton.Location = new System.Drawing.Point(12, 294);
            this.localBackButton.Name = "localBackButton";
            this.localBackButton.Size = new System.Drawing.Size(75, 23);
            this.localBackButton.TabIndex = 16;
            this.localBackButton.Text = "Back";
            this.localBackButton.UseVisualStyleBackColor = true;
            this.localBackButton.Click += new System.EventHandler(this.localBackButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Enabled = false;
            this.pathBox.Location = new System.Drawing.Point(12, 110);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(305, 20);
            this.pathBox.TabIndex = 17;
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(578, 263);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 18;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // renameText
            // 
            this.renameText.Location = new System.Drawing.Point(521, 292);
            this.renameText.Name = "renameText";
            this.renameText.Size = new System.Drawing.Size(132, 20);
            this.renameText.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Host Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Rename to";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(463, 81);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 329);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renameText);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.localBackButton);
            this.Controls.Add(this.localEnterButton);
            this.Controls.Add(this.localListBox);
            this.Controls.Add(this.hostNameBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.parentDirectoryButton);
            this.Controls.Add(this.enterFolderButton);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button enterFolderButton;
        private System.Windows.Forms.Button parentDirectoryButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox hostNameBox;
        private System.Windows.Forms.ListBox localListBox;
        private System.Windows.Forms.Button localEnterButton;
        private System.Windows.Forms.Button localBackButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.TextBox renameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button deleteButton;
    }
}

