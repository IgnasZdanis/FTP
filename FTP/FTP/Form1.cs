using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    public partial class Form1 : Form
    {

        FTPClient client = null;
        List<String> files = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new FTPClient();
            client.Connect("localhost", 21);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //client.Send("USER Ignas\r\n");
            //client.Send("PASS makaka\r\n");
            client.Send("USER " + usernameBox.Text + "\r\n");
            client.Send("PASS " + passwordBox.Text + "\r\n");
            //client.PassiveMode();
            GetList();
            //client.PassiveMode();
            //client.Send("LIST\r\n");

        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Disconnect();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            client.PassiveMode();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void enterFolderButton_Click(object sender, EventArgs e)
        {
            String folderName = files[fileList.SelectedIndex];
            client.ChangeDirectory(folderName);
            GetList();
        }

        private void parentDirectoryButton_Click(object sender, EventArgs e)
        {
            client.Send("CDUP\r\n");
            GetList();
        }

        private void GetList()
        {
            files = client.GetList();
            fileList.DataSource = null;
            fileList.DataSource = files;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            client.PassiveMode();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            String fileName = files[fileList.SelectedIndex];
            client.DownloadFile(fileName);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            client.UploadFile();
        }
    }
}
