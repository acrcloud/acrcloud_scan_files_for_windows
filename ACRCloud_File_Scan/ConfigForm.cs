using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ACRCloud_File_Scan
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }
        public void WriteConfig(string text)
        {
            FileStream fs = new FileStream("acrcloud_config.json", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }
        private void ConfigCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            string configstr;
            string host = this.HostComboBox.Text;
            string key = this.KeyTextBox.Text;
            string secret = this.SecretTextBox.Text;
            configstr = "{"+"\n"+@"  ""host"": """+host + @"""," +"\n"+@"  ""access_key"": """ + key +@""","+"\n" +@"  ""access_secret"": """ + secret + @"""" +"\n}";
            WriteConfig(configstr);
            MessageBox.Show("Save config data successfully!");
            this.Close();
        }
    }
}
