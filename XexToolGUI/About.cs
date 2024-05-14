using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using XexToolGUI.Properties;

namespace XexToolGUI
{
    partial class About : Form
    {      
         SoundPlayer player { get; set; }
        public About()
        {
            InitializeComponent();
            player = new SoundPlayer(new MemoryStream(Resources.About_sound));
            player.PlayLooping();
            Text = "Info XexTool GUI";
            labelProductName.Text = "XexToolGUI for xorloser's xextool";
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = "Copyright © Serenity 2022";
            labelCompanyName.Text = "Thanks to:";
            textBoxDescription.Text = "Made By mLoaD \r\n xorloser  for your Program and your Hard work \r\n Open Sourced By Serenity.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
            Program.xexgui.Show();
            Program.About = null;
            if(player != null)
            {
                player.Stop();
                player = null;
            }
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.xexgui.Show();
            Program.About = null;

            if (player != null)
            {
                player.Stop();
                player = null;
            }
        }
    }
}
