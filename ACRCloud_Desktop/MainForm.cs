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

        public static String formatLongToTimeStr(int sec)
        {
            TimeSpan ts = new TimeSpan(0, 0, sec);
            string str = (int)ts.TotalHours + ":" + ts.Minutes + ":" + ts.Seconds;
            return str;
        }
        public void enablebuttons()
        {
            Action<String> AsyncUIDelegate = delegate(string n) {choosefilebutton.Enabled = true; startbutton.Enabled = true; clearbutton.Enabled = true; ChoosedfileListBox.Enabled = true; };
            ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
        }

        int row_i = 0;
        private void Start()
        {
            try
            {
                int INTERCVAL = 0;
                INTERCVAL = int.Parse(intervaltextbox.Text);
                if (INTERCVAL < 5)
                {
                    MessageBox.Show("Interval must be greater than  5  seconds");
                }
                var config = new Dictionary<string, object>();
                config.Add("host", hosttextBox.Text.Trim());
                config.Add("access_key", keytextBox.Text.Trim());
                config.Add("access_secret", secrettextbox.Text.Trim());
                config.Add("timeout", 10); // seconds
                ACRCloudRecognizer re = new ACRCloudRecognizer(config);
                foreach (string file in ChoosedfileListBox.Items)
                {
                    int init_sec = 0;
                    int retry = 5;
                    while (true)
                    {
                        if (hosttextBox.Text == "") {
                            MessageBox.Show("Host can not be empty");
                            enablebuttons();
                            break;
                        }
                        if (keytextBox.Text == "") {
                            MessageBox.Show("Key can not be empty");
                            enablebuttons();
                            break;
                        }
                        if (secrettextbox.Text == "")
                        {
                            MessageBox.Show("Secret can not be empty");
                            enablebuttons();
                            break;
                        }

                        string result = re.RecognizeByFile(file, init_sec);
                        if (result == "empty")
                        {
                            retry -= 1;
                            if(retry == 0)
                            {
                                if (file.Equals(ChoosedfileListBox.Items[ChoosedfileListBox.Items.Count - 1].ToString()))
                                {
                                    MessageBox.Show("Done!");
                                    Action<String> AsyncUIDelegate = delegate(string n) { exportbutton.Enabled = true; };
                                    ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
                                    enablebuttons();
                                } 
                                break;
                            }
                        }
                        else
                        {
                            dynamic stuff = JsonConvert.DeserializeObject(result);
                            int code = 1001;
                            try { code = stuff.status.code; }
                            catch (Exception) { code = 1001; }
                            if (code == 0)
                            {
                                dynamic metadata = stuff.metadata;
                                Data d = new Data();

                                try { d.Filename = file; }
                                catch (Exception) { d.Filename = ""; }

                                try { d.Time = init_sec; }
                                catch (Exception) { d.Time = 0000; }

                                try { d.Title = metadata.music[0].title; }
                                catch (Exception) { d.Title = ""; }

                                try { d.Artist = metadata.music[0].artists[0].name; }
                                catch (Exception) { d.Artist = ""; }

                                try { d.Album = metadata.music[0].album.name; }
                                catch (Exception) { d.Album = ""; }

                                try { d.Acrid = metadata.music[0].acrid; }
                                catch (Exception) { d.Acrid = ""; }

                                try { d.Label = metadata.music[0].label; }
                                catch (Exception) { d.Label = ""; }

                                try { d.Isrc = metadata.music[0].external_ids.isrc; }
                                catch (Exception) { d.Isrc = ""; }

                                try { d.Deezer = metadata.music[0].external_metadata.deezer.track.id; }
                                catch (Exception) { d.Deezer = ""; }

                                try { d.Spotify = metadata.music[0].external_metadata.spotify.track.id; }
                                catch (Exception) { d.Spotify = ""; }

                                try { d.iTunes = metadata.music[0].external_metadata.itunes.track.id; }
                                catch (Exception) { d.iTunes = ""; }

                                try { d.Custom_Files_Title = metadata.custom_files[0].title; }
                                catch (Exception) { d.Custom_Files_Title = ""; }
                                
                                try { d.Audio_id = metadata.custom_files[0].audio_id; }
                                catch (Exception) { d.Audio_id = ""; }
                                SaveData.Save(row_i, d);
                                row_i++;
                                result = init_sec.ToString() + "\t" + d.Custom_Files_Title + "\t" + d.Title;


                            }
                            else if (code == 1001)
                            {
                                result = init_sec.ToString() + "\t" + "NoResult";
                            }
                            else if (code == 3001)
                            {
                                MessageBox.Show("Missing/Invalid Access Key");
                                enablebuttons();
                                break;
                            }
                            else if (code == 3002)
                            {
                                MessageBox.Show("Invalid ContentType. valid Content-Type is multipart/form-data");
                                enablebuttons();
                                break;
                            }
                            else if (code == 3003)
                            {
                                MessageBox.Show("Limit exceeded");
                                enablebuttons();
                                break;
                            }
                            else if (code == 3006)
                            {
                                MessageBox.Show("Invalid parameters");
                                enablebuttons();
                                break;
                            }
                            else if (code == 3014)
                            {
                                MessageBox.Show("InvalidSignature");
                                enablebuttons();
                                break;
                            }
                            else if (code == 3015)
                            {
                                MessageBox.Show("Could not generate fingerprint");
                                enablebuttons();
                                break;
                            }
                            else
                            {
                                result = init_sec.ToString() + "\t" + stuff.status.msg;
                            }
                            Action<String> AsyncUIDelegate = delegate(string n) { ResultListBox.Items.Add(result); ResultListBox.Refresh(); ResultListBox.SelectedIndex = this.ResultListBox.Items.Count - 1; };
                            ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });

                        }
                        init_sec += INTERCVAL;
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
                Data d = SaveData.dicData[i - 1];
                int row_ = 1 + i;
                int dt_row = i - 1;
                myExport.AddRow();
                try { myExport["Filename"] = d.Filename; }
                catch (Exception) { myExport["Filename"] = ""; }

                try { myExport["Time"] = formatLongToTimeStr(d.Time); }
                catch (Exception) { myExport["Time"] = ""; }

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

                try { myExport["Custom_Files_Title"] = d.Custom_Files_Title.ToString(); }
                catch (Exception) { myExport["Custom_Files_Title"] = ""; }

                try { myExport["Audio_id"] = d.Audio_id.ToString(); }
                catch (Exception) { myExport["Audio_id"] = ""; }
            }
            myExport.ExportToFile(P_obj_csvName);
           
        }
        private void clearbutton_Click(object sender, EventArgs e)
        {
            ChoosedfileListBox.Items.Clear();

        }

    }

}