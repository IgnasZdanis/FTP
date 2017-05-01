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
            this.loginButton = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(488, 38);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(357, 12);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 2;
            this.usernameBox.Text = "Ignas";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(463, 12);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.Text = "makaka";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(109, 12);
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
            this.fileList.Location = new System.Drawing.Point(333, 84);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(230, 173);
            this.fileList.TabIndex = 7;
            // 
            // enterFolderButton
            // 
            this.enterFolderButton.Location = new System.Drawing.Point(324, 265);
            this.enterFolderButton.Name = "enterFolderButton";
            this.enterFolderButton.Size = new System.Drawing.Size(75, 23);
            this.enterFolderButton.TabIndex = 8;
            this.enterFolderButton.Text = "Enter folder";
            this.enterFolderButton.UseVisualStyleBackColor = true;
            this.enterFolderButton.Click += new System.EventHandler(this.enterFolderButton_Click);
            // 
            // parentDirectoryButton
            // 
            this.parentDirectoryButton.Location = new System.Drawing.Point(324, 294);
            this.parentDirectoryButton.Name = "parentDirectoryButton";
            this.parentDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.parentDirectoryButton.TabIndex = 9;
            this.parentDirectoryButton.Text = "Back";
            this.parentDirectoryButton.UseVisualStyleBackColor = true;
            this.parentDirectoryButton.Click += new System.EventHandler(this.parentDirectoryButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(405, 265);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 11;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(161, 275);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 12;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // hostNameBox
            // 
            this.hostNameBox.Location = new System.Drawing.Point(12, 41);
            this.hostNameBox.Name = "hostNameBox";
            this.hostNameBox.Size = new System.Drawing.Size(100, 20);
            this.hostNameBox.TabIndex = 13;
            // 
            // localListBox
            // 
            this.localListBox.FormattingEnabled = true;
            this.localListBox.Location = new System.Drawing.Point(12, 110);
            this.localListBox.Name = "localListBox";
            this.localListBox.Size = new System.Drawing.Size(232, 147);
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
            this.pathBox.Location = new System.Drawing.Point(12, 84);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(232, 20);
            this.pathBox.TabIndex = 17;
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(488, 265);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 18;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // renameText
            // 
            this.renameText.Location = new System.Drawing.Point(463, 297);
            this.renameText.Name = "renameText";
            this.renameText.Size = new System.Drawing.Size(100, 20);
            this.renameText.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 329);
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
            this.Controls.Add(this.loginButton);
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
        private System.Windows.Forms.Button loginButton;
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
    }
}

