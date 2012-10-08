using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Threading;


namespace Rippit
{
    
    public partial class MainWindow : Form
    {
        private Dictionary<string, string> prefixes = new Dictionary<string, string>();
        private Dictionary<string, string> dUrlPath = new Dictionary<string, string>();
        static bool cbSortState = false;

        public string Prefix
        {
            get
            {
                return "r/" + tSubreddit.Text +
                       prefixes[(cbSort.Enabled ? cbCategory.Text + "_" + cbSort.Text : cbCategory.Text)];
            }
            set
            {
                Prefix = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            prefixes["Hot"] = "/new";
            prefixes["Top_All time"] = "/top/all";
            prefixes["Top_This year"] = "/top/year";
            prefixes["Top_This month"] = "/top/month";
            prefixes["Top_This week"] = "/top/week";
            prefixes["Top_Today"] = "/top/day";

            cbCategory.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;
        }

        private void ToggleInputs(bool on)
        {
            cbSortState = cbSort.Enabled;
            
            btStart.Enabled = on;
            tSubreddit.Enabled = on;
            tFromPage.Enabled = on;
            tPath.Enabled = on;
            tToPage.Enabled = on;
            chbDownload.Enabled = on;
            cbCategory.Enabled = on;

            if(on)
                cbSort.Enabled = cbSortState;

            btStop.Enabled = !on;
            
        }
        
        private void InitSave()
        {
            SettingsExchanger settings = new SettingsExchanger
            {
                currentTitle = "",
                currentData = "",
                currentFile = "",
                isDownloading = chbDownload.Checked,
                startPage = int.Parse(tFromPage.Text) - 1,
                numPages = int.Parse(tToPage.Text) - (int.Parse(tFromPage.Text) - 1),
                
                progressData = 0,
                progressPages = 0,
                galPrefix = Prefix,
                savePath = tPath.Text,
                filename = ""
            };

            dgvSummary.Rows.Clear();
            dUrlPath.Clear();
            pbPages.Minimum = settings.startPage;
            pbPages.Maximum = settings.numPages + settings.startPage;
            pbImages.Maximum = 55;  // 56 pics per page    
            
            SaveThread.RunWorkerAsync(settings);
            ToggleInputs(false);
        }
   
        private void btStart_Click(object sender, EventArgs e)
        {
            InitSave();
        }        

        private void tmrAfterSave_Tick(object sender, EventArgs e)
        {
            pbPages.Value = pbPages.Minimum;
            pbImages.Value = pbImages.Minimum;

            ToggleInputs(true);
            tmrAfterSave.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tPath.Visible = (sender as CheckBox).Checked;
            lPath.Visible = (sender as CheckBox).Checked;
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedIndex == 0)
                cbSort.Enabled = false;
            else
                cbSort.Enabled = true;
        }

        private void SaveThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SettingsExchanger settings = e.Argument as SettingsExchanger;

            RootObject rObj = new RootObject();
            WebRequest wrURL = null;
            Stream objStream;
            StreamReader objReader;
            int Counter = 1;

            string firstPage = settings.startPage.ToString();
            string sURL = "http://imgur.com/" + settings.galPrefix + "/page/"+ firstPage + ".json";
            string sJSON = "";
            
           
                /* For every page... */
                for (int i = settings.startPage; i < settings.numPages + settings.startPage; i++)
                {
                    /* Create a request */
                    wrURL = WebRequest.Create(sURL);
                    wrURL.GetResponse();
                   

                    objStream = wrURL.GetResponse().GetResponseStream();
                    objReader = new StreamReader(objStream);

                    /* Read JSON */
                    sJSON = objReader.ReadLine();

                    /* Deserialize */
                    rObj = fastJSON.JSON.Instance.ToObject<RootObject>(sJSON);

                    /* For every picture on the list... */
                    for (int j = 0; j < rObj.data.Count; j++, Counter++)
                    {
                        /* Save only .ext */
                        if (rObj.data[j].ext != ".jpg" && 
                            rObj.data[j].ext != ".jpeg" && 
                            rObj.data[j].ext != ".png" &&
                            rObj.data[j].ext != ".gif")
                              continue;

                        /* Set filename */
                        string filename;
                        filename = rObj.data[j].hash + rObj.data[j].ext;

                        sURL = "http://i.imgur.com/" + filename;   

                        try
                        {
                            /* Get image */
                            using (WebClient wc = new WebClient())
                            using (Stream stream = wc.OpenRead(sURL))
                            {
                                settings.img = Image.FromStream(stream);                            
                            }
                       
                            if (settings.isDownloading)
                            {
                                /* Save in proper format */
                                switch (rObj.data[j].ext)
                                {
                                    case ".png":
                                        settings.img.Save(settings.savePath + filename, ImageFormat.Png);
                                        break;
                                    case ".jpg":
                                        settings.img.Save(settings.savePath + filename, ImageFormat.Jpeg);
                                        break;
                                    case ".jpeg":
                                        settings.img.Save(settings.savePath + filename, ImageFormat.Jpeg);
                                        break;
                                    case ".gif":
                                        settings.img.Save(settings.savePath + filename, ImageFormat.Gif);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        catch
                        {
                        }

                        if (SaveThread.CancellationPending)
	                    {
	                        e.Cancel = true;
	                        break;
	                    }
                        /* Wait after save */
                        Thread.Sleep(200);    

                        settings.progressPages = i;
                        settings.progressData = j;
                        settings.currentTitle = rObj.data[j].title;
                        settings.currentFile = sURL;
                        settings.filename = filename;
                        settings.currentData = (j + 1).ToString() + "/" + rObj.data.Count.ToString(); // e.g. 5/56
                        
                        /* Report back */
                        worker.ReportProgress(Counter, settings);    

                    }

                    /* Fetch next page */
                    sURL = "http://imgur.com/" + settings.galPrefix +"/page/" + (i+1).ToString() + ".json";   
                    
                }            

        }      

        private void SaveThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SettingsExchanger settings = e.UserState as SettingsExchanger;

            lCurrentUrl.Text = settings.currentFile;
            lImgCounter.Text = settings.currentData;

            pbPages.Value = settings.progressPages;
            pbImages.Value = settings.progressData;

            pictureBox3.Image = pictureBox2.Image;
            pictureBox2.Image = pictureBox1.Image; 
            pictureBox1.Image = settings.img;
            
            dgvSummary.Rows.Add(e.ProgressPercentage /* Counter */,
                                settings.currentFile,
                                settings.currentTitle);
            dUrlPath.Add(settings.currentFile, settings.savePath + settings.filename);

        }

        private void SaveThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbPages.Value = pbPages.Maximum;          // Update for the last day
            lCurrentUrl.Text = "";
            lImgCounter.Text = "";

          
            tmrAfterSave.Enabled = true;     // Delay progress bars
        }

        private void dgvSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView ob = sender as DataGridView;

            if (e.ColumnIndex == 1)
            {
                DataGridViewCell cell = ob[e.ColumnIndex, e.RowIndex] as DataGridViewCell;
                string url = cell.Value as string;
                if(chbDownload.Checked)
                    System.Diagnostics.Process.Start(dUrlPath[url]);
                else
                    System.Diagnostics.Process.Start(url);
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            SaveThread.CancelAsync();
        }     

    }    
  
    public class SettingsExchanger
    {
        public int numPages { get; set; }           // How many pages?
        public int startPage { get; set; }          // Start page num
        public bool isDownloading { get; set; }     // Download the file
        public string galPrefix { get; set; }       // Gallery prefix
        public int progressPages { get; set; }      // Progress for pages
        public int progressData { get; set; }       // Progress for images
        public string currentFile { get; set; }     // Current image url
        public string savePath { get; set; }        // Save path for image
        public string filename { get; set; }        // Filename
        public string currentData { get; set; }     // Current image counter
        public string currentTitle { get; set; }    // Current image title
        public Image img { get; set; }

    }
        
    public class Datum
    {
        public string hash { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string datetime { get; set; }
        public string ext { get; set; }
        public string mimetype { get; set; }
        public int views { get; set; }
        public string bandwidth { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
        public int ups { get; set; }
        public int downs { get; set; }
        public int points { get; set; }
        public string permalink { get; set; }
        public string subreddit { get; set; }
        public bool nsfw { get; set; }
        public int created { get; set; }
        public int score { get; set; }
        public string date { get; set; }
        public string source { get; set; }
        public object vote { get; set; }
    }

    public class RootObject
    {
        public List<Datum> data { get; set; }
        public int status { get; set; }
        public bool success { get; set; }
    }
}


