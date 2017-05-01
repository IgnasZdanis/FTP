using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    public partial class Form1 : Form
    {
        String currentDirectory = @"C:\Users\Ignas";
        String previousDirectory = null;
        FTPClient client = null;
        List<String> files = null;
        List<String> localList = null;
        public Form1()
        {
            InitializeComponent();
            client = new FTPClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Connect(hostNameBox.Text, 21);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (client.connected)
            {
                if (!ResponseSuccesful(client.Send("USER " + usernameBox.Text + "\r\n"))) 
                {
                    MessageBox.Show("Wrong username");
                    return;
                }
                if (!ResponseSuccesful(client.Send("PASS " + passwordBox.Text + "\r\n")))
                {
                    MessageBox.Show("Wrong username or password");
                    return;
                }
                client.loggedIn = true;
                GetList();
                GetLocalList();
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            localListBox.DataSource = null;
            fileList.DataSource = null;
            client.loggedIn = false;
            client.connected = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }

        private void enterFolderButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                String folderName = files[fileList.SelectedIndex];
                if (!ResponseSuccesful(client.ChangeDirectory(folderName)))
                {
                    MessageBox.Show("Not a folder");
                    return;
                }
                GetList();
            }           
        }

        private void parentDirectoryButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                client.Send("CDUP\r\n");
                GetList();
            }
        }

        private void GetList()
        {
            files = client.GetList();
            fileList.DataSource = null;
            fileList.DataSource = files;
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                String fileName = files[fileList.SelectedIndex];
                client.DownloadFile(fileName);
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                string filepath = localList[localListBox.SelectedIndex];
                client.UploadFile(filepath);
                files = client.GetList();
                fileList.DataSource = null;
                fileList.DataSource = files;
            }
        }

        public bool ResponseSuccesful(String response)
        {
            if (response.Substring(0, 1) == "1") return true;
            if (response.Substring(0, 1) == "2") return true;
            if (response.Substring(0, 1) == "3") return true;
            return false;
        }

        public void GetLocalList()
        {
            try
            {
                String[] localDirectories = Directory.GetDirectories(currentDirectory);
                String[] localFiles = Directory.GetFiles(currentDirectory);
                localList = new List<string>();
                List<String> dataSource = new List<string>();
                foreach (String s in localDirectories)
                {
                    localList.Add(s);
                    dataSource.Add("Folder: " + s.Substring(currentDirectory.Length + 1));
                }

                foreach (String s in localFiles)
                {
                    localList.Add(s);
                    dataSource.Add("File: " + s.Substring(currentDirectory.Length + 1));
                }

                pathBox.Text = currentDirectory;

                localListBox.DataSource = null;
                localListBox.DataSource = dataSource;
            }
            catch
            {
                MessageBox.Show("Access denied!");
            }
        }

        private void localEnterButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                currentDirectory = localList[localListBox.SelectedIndex];
                GetLocalList();
            }
        }

        private void localBackButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                if (currentDirectory != @"C:\")
                {
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf('\\'));
                    if (currentDirectory == "C:")
                    {
                        Console.WriteLine("asd");
                        currentDirectory = @"C:\";
                    }
                    Console.WriteLine(currentDirectory);
                    GetLocalList();
                }                
            }           
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (client.loggedIn)
            {
                //client.Send();
                client.RenameFile(files[fileList.SelectedIndex], renameText.Text);
            }
        }
    }
}
