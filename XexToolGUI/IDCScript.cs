﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace XexToolGUI
{
    public partial class IDCScript : Form
    {
        public IDCScript()
        {
            InitializeComponent();
        }

        private void UpdateTextBoxText(string text)
        {
            Debug.WriteLine(text);
            if (CheckBox1.Checked)
            {
                idcLogBox.AppendText(Environment.NewLine);
                idcLogBox.AppendText(text + Environment.NewLine);
            }
            else
                idcLogBox.Text = text;
        }

        private void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;
            Invoke(new UpdateTextBoxTextDelegate(UpdateTextBoxText), e.Data);
        }

        private void openxexButton1_Click(object sender, EventArgs e)
        {
            var num = (int)OpenFileDialog1.ShowDialog();
            SearchxexTextBox.Text = OpenFileDialog1.FileName;
        }

        private void saveidcButton2_Click(object sender, EventArgs e)
        {
            var num = (int)SaveFileDialog1.ShowDialog();
            SaveidcTextBox.Text = SaveFileDialog1.FileName;
        }

        private void CreateidcButton_Click(object sender, EventArgs e)
        {
            Process(" -i " + SaveidcTextBox.Text + " " + SearchxexTextBox.Text);
        }
        private void Process(string arg)
        {
                Program.process = new Process();
                Program.process.OutputDataReceived += ProcessOutputDataReceived;
                Program.CurrentProcess(arg);
        }
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idcLogBox.Text = "";
            SearchxexTextBox.Text = "";
            SaveidcTextBox.Text = "";
        }

        public delegate void UpdateTextBoxTextDelegate(string text);

        private void IDCScript_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.xexgui.Show();
            Program.IDCScript = null;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.HelpReverse == null)
            {
                Program.HelpReverse = new HelpReverse();
            }
            Hide();
            Program.HelpReverse.ShowDialog(this);  //Show Form assigning this form as the forms owner
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Info == null)
            {
                Program.Info = new info();
            }
            Hide();
            Program.Info.ShowDialog(this);  //Show Form assigning this form as the forms owner
        }
    }
}
