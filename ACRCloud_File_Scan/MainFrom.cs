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

namespace ACRCloud_File_Scan
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        int row_i = 0;
        private void StartButton_Click(object sender, EventArgs e)
        {
            ResultListBox.Items.Clear();
            Thread sub = new Thread(Start);
            if (FilesListBox.Items.Count != 0)
            {
                sub.Start();//开始
                ChooseFilesButton.Enabled = false;
                ClearFilesButton.Enabled = false;
                StartButton.Enabled = false;
                ExportResultsButton.Enabled = false;
                FilesListBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please choose files you want to recognize");
            }
        }
        public void Enablebuttons()
        {
            Action<String> AsyncUIDelegate = delegate(string n)
            {
                ChooseFilesButton.Enabled = true;
                StartButton.Enabled = true; 
                ClearFilesButton.Enabled = true;
                ChooseFilesButton.Enabled = true;
                FilesListBox.Enabled = true;
            };
            ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
        }

        public Data resdata(dynamic metadata, string file, int init_sec)
        {
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

            try { d.Youtube = metadata.music[0].external_metadata.youtube.vid; }
            catch (Exception) { d.Youtube = ""; }

            try { d.Custom_Files_Title = metadata.custom_files[0].title; }
            catch (Exception) { d.Custom_Files_Title = ""; }

            try { d.Audio_id = metadata.custom_files[0].audio_id; }
            catch (Exception) { d.Audio_id = ""; }

            return d;
        }
        private void Start()
        {
            try
            {
                int TotalDuration = 0;
                foreach (string file in FilesListBox.Items)
                {
                    ACRCloudExtrTool ACRET = new ACRCloudExtrTool();
                    TotalDuration = TotalDuration + ACRET.GetDurationMillisecondByFile(file);

                }

                int INTERCVAL = 0;
                INTERCVAL = int.Parse(IntervalTextBox.Text);
                int NowDuration = 0;
                if (INTERCVAL < 5)
                {
                    MessageBox.Show("Interval must be greater than  5  seconds");
                }
                string configtext = System.IO.File.ReadAllText(@"acrcloud_config.json");
                dynamic configjson = JsonConvert.DeserializeObject(configtext);
                string host = configjson.host;
                string access_key = configjson.access_key;
                string access_secret = configjson.access_secret;
                var config = new Dictionary<string, object>();
                config.Add("host", host.Trim());
                config.Add("access_key", access_key.Trim());
                config.Add("access_secret", access_secret.Trim());
                config.Add("timeout", 10); // seconds
                ACRCloudRecognizer re = new ACRCloudRecognizer(config);
                foreach (string file in FilesListBox.Items)
                {
                    int init_sec = 0;
                    int retry = 3;
                    while (true) 
                    {
                        if (host.Trim() == "")
                        {
                            MessageBox.Show("Host can not be empty");
                            Enablebuttons();
                            break;
                        }
                        if (access_key.Trim() == "")
                        {
                            MessageBox.Show("Key can not be empty");
                            Enablebuttons();
                            break;
                        }
                        if (access_secret.Trim() == "")
                        {
                            MessageBox.Show("Secret can not be empty");
                            Enablebuttons();
                            break;
                        }
                        string result = re.RecognizeByFile(file, init_sec);
                        dynamic stuff;
                        try
                        {
                            stuff = JsonConvert.DeserializeObject(result);
                        }
                        catch(Exception)
                        {
                            stuff = JsonConvert.DeserializeObject(ACRCloudStatusCode.NO_RESULT);
                        }
                        int code;
                        try { code = stuff.status.code; }
                        catch (Exception) { code = 1001; }
                        if (result == "empty")
                        {
                            if (file.Equals(FilesListBox.Items[FilesListBox.Items.Count - 1].ToString()))
                            {
                                Action<String> AsyncUIDelegate = delegate(string n) 
                                { 
                                    ExportResultsButton.Enabled = true; 
                                    ProgressBar.Value = ProgressBar.Maximum; 
                                };
                                ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
                                MessageBox.Show("Done!");
                                Enablebuttons();
                            }
                            break;
                        }
                        else if(code == 3000)
                        {
                            retry -= 1;
                            if (retry == 0)
                            {
                                if (file.Equals(FilesListBox.Items[FilesListBox.Items.Count - 1].ToString()))
                                {
                                    MessageBox.Show("Please Check Your Network");
                                    Action<String> AsyncUIDelegate = delegate(string n) { 
                                        ExportResultsButton.Enabled = true;
                                        ProgressBar.Value = 0;
                                    };
                                    ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });
                                    Enablebuttons();
                                }
                                break;
                            }
                        }
                        else
                        {

                            if (code == 0)
                            {
                                dynamic metadata = stuff.metadata;
                                Data d = new Data();
                                d = resdata(metadata,file,init_sec);
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
                                Enablebuttons();
                                break;
                            }
                            else if (code == 3002)
                            {
                                MessageBox.Show("Invalid ContentType. valid Content-Type is multipart/form-data");
                                Enablebuttons();
                                break;
                            }
                            else if (code == 3003)
                            {
                                MessageBox.Show("Limit exceeded");
                                Enablebuttons();
                                break;
                            }
                            else if (code == 3006)
                            {
                                MessageBox.Show("Invalid parameters");
                                Enablebuttons();
                                break;
                            }
                            else if (code == 3014)
                            {
                                MessageBox.Show("InvalidSignature");
                                Enablebuttons();
                                break;
                            }
                            else if (code == 3015)
                            {
                                MessageBox.Show("Could not generate fingerprint");
                                Enablebuttons();
                                break;
                            }
                            else
                            {
                                result = init_sec.ToString() + "\t" + stuff.status.msg;
                            }
                            Action<String> AsyncUIDelegate = delegate(string n) 
                            { 
                                ResultListBox.Items.Add(result);
                                ResultListBox.Refresh();
                                ResultListBox.SelectedIndex = this.ResultListBox.Items.Count - 1;
                            };
                            ResultListBox.Invoke(AsyncUIDelegate, new object[] { "" });

                            Action<String> pb = delegate(string n)
                            {
                                float ProgressBarValue = (float)NowDuration / (float)TotalDuration * 1000000;
                                if (ProgressBarValue > 1000)
                                {
                                    this.ProgressBar.Value = 1000-INTERCVAL;
                                }
                                else
                                {
                                    this.ProgressBar.Value = (int)ProgressBarValue;
                                }
                            };
                            this.ProgressBar.Invoke(pb, new object[] { "" });
                        }
                        init_sec += INTERCVAL;
                        NowDuration += INTERCVAL;

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ChangeConfigButton_Click(object sender, EventArgs e)
        {
            
            ConfigForm config = new ConfigForm();
            this.StartPosition = FormStartPosition.CenterScreen;
            config.Show();
        }

        private void ChooseFilesButton_Click(object sender, EventArgs e)
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
                    FilesListBox.Items.Add(file);
                }
                MessageBox.Show("Choose:\n" + filelist, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFilesButton_Click(object sender, EventArgs e)
        {
            FilesListBox.Items.Clear();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"acrcloud_config.json") == false)
            {
                ConfigForm config = new ConfigForm();
                this.StartPosition = FormStartPosition.CenterScreen;
                config.Show();
            }
        }

        public static String formatLongToTimeStr(int sec)
        {
            TimeSpan ts = new TimeSpan(0, 0, sec);
            string str = (int)ts.TotalHours + ":" + ts.Minutes + ":" + ts.Seconds;
            return str;
        }
        private void ExportResultsButton_Click(object sender, EventArgs e)
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

                try { myExport["Youtube"] = d.Youtube.ToString(); }
                catch (Exception) { myExport["Youtube"] = ""; }

                try { myExport["Custom_Files_Title"] = d.Custom_Files_Title.ToString(); }
                catch (Exception) { myExport["Custom_Files_Title"] = ""; }

                try { myExport["Audio_id"] = d.Audio_id.ToString(); }
                catch (Exception) { myExport["Audio_id"] = ""; }
            }
            myExport.ExportToFile(P_obj_csvName);

        }
    }
}
