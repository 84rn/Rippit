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
        /* This sets the postfixes for the URL */
        private Dictionary<string, string> postfixes = new Dictionary<string, string>();
        /* Path / URL */
        private Dictionary<string, string> dUrlPath = new Dictionary<string, string>();
        
        static bool cbSortState = false;

        /* Buffer for new pictures in the gallery */
        private List<PictureBox> pbBuffer = new List<PictureBox>();
        
        /* U know what it does. */
        public string Prefix
        {
            get
            {
                return "r/" + tSubreddit.Text +
                       postfixes[(cbSort.Enabled ? cbCategory.Text + "_" + cbSort.Text : cbCategory.Text)];
            }
            set
            {
                Prefix = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            /* Set the postfixes */
            postfixes["Hot"] = "/new";
            postfixes["Top_All time"] = "/top/all";
            postfixes["Top_This year"] = "/top/year";
            postfixes["Top_This month"] = "/top/month";
            postfixes["Top_This week"] = "/top/week";
            postfixes["Top_Today"] = "/top/day";

            cbCategory.SelectedIndex = 0;
            cbSort.SelectedIndex = 0;
         // tabSummary.SelectedIndex = 1;
        }

        /* Toggle the state of all buttons/controls */
        private void ToggleInputs(bool on)
        {
            if(!on)
             cbSortState = cbSort.Enabled;
            
            btStart.Enabled = on;
            tSubreddit.Enabled = on;
            tFromPage.Enabled = on;
            tPath.Enabled = on;
            tToPage.Enabled = on;
            chbDownload.Enabled = on;
            cbCategory.Enabled = on;

            if (on)
                cbSort.Enabled = cbSortState;
            else
                cbSort.Enabled = false;

            btStop.Enabled = !on;
            
        }

        /* Check if the path is OK */
        private int CheckPath()
        {
            Match match = Regex.Match(tPath.Text, @"^.:\\.*\\?$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                match = Regex.Match(tPath.Text, @"^.:\\.*\\$", RegexOptions.IgnoreCase);
                if(match.Success)
                    return 2; // with /
                else
                    return 1; // without /     
            }
            else
                return 0;
        }
        
        /* INITIALIZE! */
        private void InitSave()
        {
            string tempPath = "";

            switch(CheckPath())
            {
                case 1:
                    tempPath = tPath.Text + "\\";
                    break;
                case 2:
                    tempPath = tPath.Text;
                    break;
                case 0:
                    MessageBox.Show("The entered path is wrong!","Wrong save path!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;                   
            }

            if (chbDownload.Checked && !Directory.Exists(tempPath))
            {
                 DialogResult result = MessageBox.Show("Directory " + tempPath + " doesn't exist. Do you want to create it?", "Wrong path", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                 if (result == DialogResult.Yes)
                 {
                     Directory.CreateDirectory(tempPath);
                 }
                 else
                 {
                     chbDownload.Checked = false;
                 }
            }
              
            /* Set the exchanger */
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
                savePath = tempPath,
                filename = ""
            };

            /* Clear all the shit */
            pbBuffer.Clear();
            flowGallery.Controls.Clear();
            dgvSummary.Rows.Clear();
            dUrlPath.Clear();
            pbPages.Minimum = settings.startPage;
            pbPages.Maximum = settings.numPages + settings.startPage;
            pbImages.Maximum = 55;  // 56 pics per page    
            
            /* AWWW YISSS */
            SaveThread.RunWorkerAsync(settings);
            ToggleInputs(false);
        }
        
        /* Set the status in StatusBar */
        private void SetStatus(string s, int i)
        {
            switch(i)
            {
                case 1:
                    lStatus.Text = s;
                    break;
                case 2:
                    lStatus2.Text = s;
                    break;
                case 3:
                    lStatus3.Text = s;
                    break;
            }
        }

        /* Add another pic */        
        private void AddGalleryPic(Image img)
        {

            PictureBox x = new PictureBox();

            Bitmap b = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(img, 0, 0, 100, 100);
            g.Dispose();

            //x.BackgroundImageLayout = ImageLayout.Stretch;
            x.BackgroundImage = (Image)b;

            x.Size = new Size(100, 100);
            x.Padding = new Padding(0);
            x.Margin = new Padding(0);
            x.Click += new EventHandler(Gallery_Click);
            x.Cursor = Cursors.Hand;

            /* If it's OVER 9000, wait for 8 more and add them */
            if (flowGallery.Controls.Count == 24)
            {
                pbBuffer.Add(x);

                if (pbBuffer.Count == 8)
                {
                    for (int j = 7; j >= 0; j--)
                        flowGallery.Controls.RemoveAt(j);
                    flowGallery.Controls.AddRange(pbBuffer.ToArray());

                    pbBuffer.Clear();
                }

            }
            else
                flowGallery.Controls.Add(x);
        }

        #region Event Handlers

        private void btStart_Click(object sender, EventArgs e)
        {
            InitSave();
        }        

        /* Finish */
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

        /* If in download mode, click to get a pic from HDD. If not, URL */
        private void dgvSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView ob = sender as DataGridView;

            if (e.ColumnIndex == 1)
            {
                DataGridViewCell cell = ob[e.ColumnIndex, e.RowIndex] as DataGridViewCell;
                string url = cell.Value as string;
                if (chbDownload.Checked)
                    System.Diagnostics.Process.Start(dUrlPath[url]);
                else
                    System.Diagnostics.Process.Start(url);
            }
        }

        /* You've had enough */
        private void btStop_Click(object sender, EventArgs e)
        {
            SaveThread.CancelAsync();
        }

        private void Gallery_Click(object sender, EventArgs e)
        {
            PictureBox x = sender as PictureBox;

            int i = flowGallery.Controls.IndexOf(x);
            DataGridViewCell cell = dgvSummary[1, dgvSummary.Rows.Count - 1 - (flowGallery.Controls.Count - 1 - i) - (pbBuffer.Count)];
            string url = cell.Value as string;
            if (chbDownload.Checked)
                System.Diagnostics.Process.Start(dUrlPath[url]);
            else
                System.Diagnostics.Process.Start(url);

        }

        /* Filter the strokes */
        private void Pages_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                case Keys.Back:
                    e.SuppressKeyPress = false;
                    return;
                default:
                    break;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);

            if (!modifier && nonNumber)
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        #region SaveThread Handlers

        private void SaveThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            SettingsExchanger settings = e.Argument as SettingsExchanger;

            RootObject rObj = new RootObject();
            WebRequest wrURL = null;
            Stream objStream;
            StreamReader objReader;
            int Counter = 1;
            int badCounter = 0;
            string name = null;

            int retry = 1;

            string firstPage = settings.startPage.ToString();
            string sURL = "http://imgur.com/" + settings.galPrefix + "/page/"+ firstPage + ".json";
            string sJSON = "";

            SetStatus("Working...", 1);
            /* For every page... */
            for (int i = settings.startPage; i < settings.numPages + settings.startPage; i++)
            {
                /* Set the result */
                e.Result = i+1;
                /* Create a request */
                wrURL = WebRequest.Create(sURL);
                wrURL.Timeout = 4000;
                try
                {
                    wrURL.GetResponse();
                    objStream = wrURL.GetResponse().GetResponseStream();
                }
                catch
                {
                    if (retry < 11)
                    {
                        SetStatus("Couldn't fetch page " + (i + 1).ToString() + ". Retrying. (" + retry + ")", 1);
                        i--;
                        retry++;

                        continue;
                    }
                    else
                        return;
                }

                retry = 1;
                
                objReader = new StreamReader(objStream);

                /* Read JSON */
                sJSON = objReader.ReadLine();

                /* Deserialize */
                try
                {
                    rObj = fastJSON.JSON.Instance.ToObject<RootObject>(sJSON);

                    if (rObj.data.Count == 0)
                        return;
                }
                catch
                {
                    SetStatus("Couldn't fetch data. Is Imgur in maintenance?", 1);                    
                    Thread.Sleep(2000);
                    return;
                }
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

                        name = rObj.data[j].title + rObj.data[j].ext;
                        string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

                        foreach (char c in invalid)
                        {
                            name = name.Replace(c.ToString(), "");
                        }
                        if (settings.isDownloading)
                        {
                            /* Save in proper format */
                            switch (rObj.data[j].ext)
                            {
                                case ".png":
                                    settings.img.Save(settings.savePath + name, ImageFormat.Png);
                                    break;
                                case ".jpg":
                                    settings.img.Save(settings.savePath + name, ImageFormat.Jpeg);
                                    break;
                                case ".jpeg":
                                    settings.img.Save(settings.savePath + name, ImageFormat.Jpeg);
                                    break;
                                case ".gif":
                                    settings.img.Save(settings.savePath + name, ImageFormat.Gif);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch
                    {
                        badCounter++;
                        SetStatus("Couldn't save "+badCounter.ToString()+" file(s). Last: " + filename, 2);
                    }

                    if (SaveThread.CancellationPending)
	                {	                    
                        Thread.Sleep(1500); 
	                    return;
	                }
                    /* Wait after save */
                    //Thread.Sleep(300);

                    settings.numImages = rObj.data.Count-1;
                    settings.progressPages = i;
                    settings.progressData = j;
                    settings.currentTitle = rObj.data[j].title;
                    settings.currentFile = sURL;
                    settings.filename = name ;
                    settings.currentData = (j + 1).ToString() + "/" + rObj.data.Count.ToString(); // e.g. 5/56
                        
                    /* Report back */
                    worker.ReportProgress(Counter, settings);                    

                }

                /* Fetch next page */
                sURL = "http://imgur.com/" + settings.galPrefix +"/page/" + (i+1).ToString() + ".json";   
                    
            }            

        }      

        /* New pic is coming */
        private void SaveThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SettingsExchanger settings = e.UserState as SettingsExchanger;

            if (pbImages.Maximum != settings.numImages)
                pbImages.Maximum = settings.numImages;


            pbPages.Value = settings.progressPages;
            pbImages.Value = settings.progressData;

            pictureBox3.BackgroundImage = pictureBox2.BackgroundImage;
            pictureBox2.BackgroundImage = pictureBox1.BackgroundImage; 
            pictureBox1.BackgroundImage = settings.img;

            try
            {
                dgvSummary.Rows.Add(e.ProgressPercentage /* Counter */,
                                settings.currentFile,
                                settings.currentTitle);
                dgvSummary.FirstDisplayedScrollingRowIndex = dgvSummary.RowCount - 1;
            }
            catch
            {
            }
            try
            {
                if(chbDownload.Checked)
                dUrlPath.Add(settings.currentFile, settings.savePath + settings.filename);
                else
                    dUrlPath.Add(settings.currentFile, settings.savePath + settings.filename);

            }
            catch
            {
                SetStatus("Image " + settings.currentFile + " is a duplicate. Ignoring.", 3);
            }

            /* Add another image to gallery */
           
            AddGalleryPic(settings.img);       
                
        }

        private void SaveThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbPages.Value = pbPages.Maximum;          // Update for the last day

            SetStatus("Finished on page " + e.Result, 1);
            SetStatus("", 2);
            SetStatus("", 3);
          
            tmrAfterSave.Enabled = true;     // Delay progress bars
        }

        #endregion



    }

    /* Exchange the data between BGW and GUI.
     * Yes, I'm aware it can be done better */
    public class SettingsExchanger
    {
        public int numPages { get; set; }           // How many pages?
        public int numImages { get; set; }
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

    #region JSON Data

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

    #endregion

}


