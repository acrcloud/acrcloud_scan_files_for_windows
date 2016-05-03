using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACRCloud_Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void keytextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void secrettextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void choosefilebutton_Click(object sender, EventArgs e)
        {
            string filelist = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose File";
            fileDialog.Multiselect = true;
            fileDialog.Filter = "All Files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in fileDialog.FileNames)
                {
                    filelist += (file + '\n');
                    ChoosedfileListBox.Items.Add(file);
                }
                MessageBox.Show("Choose:\n" + filelist, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            }

        private void startbutton_Click(object sender, EventArgs e)
        {
            Thread sub = new Thread(Start);
            if (ChoosedfileListBox.Items.Count != 0)
            {
                sub.Start();//开始
                choosefilebutton.Enabled = false;
                clearbutton.Enabled = false;
                startbutton.Enabled = false;
                exportbutton.Enabled = false;
                ChoosedfileListBox.Enabled = false;

            }
            else 
            {
                MessageBox.Show("Please choose files you want to recognize");
            }
        }
        int row_i = 0;
        private void Start()
        {
            try
            {
                int init_sec = 0;
                int INTERCVAL = 0;
                INTERCVAL = int.Parse(intervaltextbox.Text);
                if (INTERCVAL < 5)
                {
                    MessageBox.Show("Interval must be greater than  5  seconds");
                }
                var config = new Dictionary<string, object>();
                config.Add("host", hosttextBox.Text);
                config.Add("access_key", keytextBox.Text);
                config.Add("access_secret", secrettextbox.Text);
                config.Add("timeout", 10); // seconds
                ACRCloudRecognizer re = new ACRCloudRecognizer(config);
                foreach (string file in ChoosedfileListBox.Items)
                {
                    while (true)
                    {
                        string result = re.RecognizeByFile(file, init_sec);
                        if (result == "")
                        {
                            init_sec = 0;
                            Action<String> AsyncUIDelegate = delegate(string n) { MessageBox.Show("Done!"); choosefilebutton.Enabled = true; startbutton.Enabled = true; clearbutton.Enabled = true; exportbutton.Enabled = true; ChoosedfileListBox.Enabled = true; };
                            ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
                            break;
                        }
                        else
                        {
                            dynamic stuff = JsonConvert.DeserializeObject(result);
                            string msg = stuff.status.msg;
                            if (msg == "Success")
                            {
                                result = init_sec.ToString() + "\t" + stuff.metadata.music[0].title;
                                dynamic metadata = stuff.metadata.music[0];

                                Data d = new Data();
                                try{d.Time = init_sec.ToString();}
                                catch (Exception){d.Time = "";}
                                    
                                try{ d.Title = metadata.title;}
                                catch (Exception){d.Title = "";}
                                   
                                try{ d.Artist = metadata.artists[0].name;}
                                catch (Exception){d.Artist = "";}
                                    
                                try{ d.Album = metadata.album.name;}
                                catch (Exception){ d.Album = "";}
                                    
                                try{ d.Acrid = metadata.acrid;}
                                catch (Exception){d.Acrid ="";}
                                    
                                try{d.Label = metadata.label;}
                                catch (Exception) {d.Label ="";}
                                    
                                try{d.Isrc = metadata.external_ids.isrc;}
                                catch (Exception){d.Isrc = "";}

                                try{d.Deezer = metadata.external_metadata.deezer.track.id;}
                                catch (Exception){d.Deezer = "";} 

                                try{d.Spotify = metadata.external_metadata.spotify.track.id;}
                                catch (Exception){d.Spotify ="";}

                                try{d.iTunes = metadata.external_metadata.itunes.track.id;}
                                catch (Exception){ d.iTunes = "";}
                                SaveData.Save(row_i, d);
                                row_i++;

                            }
                            else if (msg == "NoResult")
                            {
                                result = init_sec.ToString() + "\t" + "NoResult";
                            }
                            else
                            {
                                result = init_sec.ToString() + "\t" + stuff.status.msg;
                            }
                            Action<String> AsyncUIDelegate = delegate(string n) { ResultListBox.Items.Add(result); ResultListBox.Refresh(); ResultListBox.SelectedIndex = this.ResultListBox.Items.Count - 1; };
                            ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
                            init_sec += INTERCVAL;

                        }

                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        private void exportbutton_Click(object sender, EventArgs e)
        {
            string path = "";
            FolderBrowserDialog FBDialog = new FolderBrowserDialog();
            if (FBDialog.ShowDialog() == DialogResult.OK)
            {
                path = FBDialog.SelectedPath;
            }
            string P_obj_csvName = "";
            if (path.EndsWith("\\"))
                P_obj_csvName = path + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            else
                P_obj_csvName = path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            MessageBox.Show(P_obj_csvName);

            var myExport = new CsvExport();
            
            for (int i = 1; i <= row_i; i++)
            {
                Data d = SaveData.dicData[i-1];
                int row_ = 1 + i;
                int dt_row = i - 1;
                myExport.AddRow();
                try{myExport["Time"] = d.Time.ToString();}
                catch (Exception){myExport["Time"] = "";}

                try { myExport["Title"] = d.Title.ToString(); }
                catch (Exception) { myExport["Title"] = ""; }

                try { myExport["Artist"] = d.Artist.ToString(); }
                catch (Exception) { myExport["Artist"] = ""; }

                try { myExport["Album"] = d.Album.ToString(); }
                catch (Exception) { myExport["Album"] = ""; }

                try { myExport["Acrid"] = d.Acrid.ToString(); }
                catch (Exception) { myExport["Acrid"] = ""; }

                try { myExport["Label"] = d.Label.ToString(); }
                catch (Exception) { myExport["Label"] = ""; }

                try { myExport["Isrc"] = d.Isrc.ToString(); }
                catch (Exception) { myExport["Isrc"] = ""; }

                try { myExport["Deezer"] = d.Deezer.ToString(); }
                catch (Exception) { myExport["Deezer"] = ""; }

                try { myExport["Spotify"] = d.Spotify.ToString(); }
                catch (Exception) { myExport["Spotify"] = ""; }

                try { myExport["iTunes"] = d.iTunes.ToString(); }
                catch (Exception) { myExport["iTunes"] = ""; }

            }
            myExport.ExportToFile(P_obj_csvName);
        }
        private void clearbutton_Click(object sender, EventArgs e)
        {
            ChoosedfileListBox.Items.Clear();

        }

    }

}