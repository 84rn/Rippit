namespace Rippit
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tToPage = new System.Windows.Forms.TextBox();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.pbImages = new System.Windows.Forms.ProgressBar();
            this.lPath = new System.Windows.Forms.Label();
            this.tPath = new System.Windows.Forms.TextBox();
            this.chbDownload = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tFromPage = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tSubreddit = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabSummary = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbPages = new System.Windows.Forms.ProgressBar();
            this.tmrAfterSave = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SaveThread = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lStatus3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabSummary.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.StatusStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 106);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btStop);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tToPage);
            this.groupBox1.Controls.Add(this.cbSort);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.pbImages);
            this.groupBox1.Controls.Add(this.lPath);
            this.groupBox1.Controls.Add(this.tPath);
            this.groupBox1.Controls.Add(this.chbDownload);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tFromPage);
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tSubreddit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btStop
            // 
            this.btStop.Enabled = false;
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btStop.Location = new System.Drawing.Point(417, 25);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(100, 55);
            this.btStop.TabIndex = 102;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "to";
            // 
            // tToPage
            // 
            this.tToPage.Location = new System.Drawing.Point(156, 55);
            this.tToPage.Name = "tToPage";
            this.tToPage.Size = new System.Drawing.Size(45, 20);
            this.tToPage.TabIndex = 2;
            this.tToPage.Text = "200";
            this.tToPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pages_KeyDown);
            // 
            // cbSort
            // 
            this.cbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "All time",
            "This year",
            "This month",
            "This week",
            "Today"});
            this.cbSort.Location = new System.Drawing.Point(678, 28);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(121, 21);
            this.cbSort.TabIndex = 6;
            // 
            // cbCategory
            // 
            this.cbCategory.DisplayMember = "New";
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbCategory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Hot",
            "Top"});
            this.cbCategory.Location = new System.Drawing.Point(538, 28);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbCategory.TabIndex = 5;
            this.cbCategory.ValueMember = "New";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pbImages
            // 
            this.pbImages.Location = new System.Drawing.Point(87, 86);
            this.pbImages.MarqueeAnimationSpeed = 0;
            this.pbImages.Maximum = 55;
            this.pbImages.Name = "pbImages";
            this.pbImages.Size = new System.Drawing.Size(194, 10);
            this.pbImages.TabIndex = 8;
            // 
            // lPath
            // 
            this.lPath.AutoSize = true;
            this.lPath.Location = new System.Drawing.Point(535, 59);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(29, 13);
            this.lPath.TabIndex = 7;
            this.lPath.Text = "Path";
            // 
            // tPath
            // 
            this.tPath.Location = new System.Drawing.Point(537, 76);
            this.tPath.Name = "tPath";
            this.tPath.Size = new System.Drawing.Size(262, 20);
            this.tPath.TabIndex = 3;
            this.tPath.Text = "C:\\";
            // 
            // chbDownload
            // 
            this.chbDownload.AutoSize = true;
            this.chbDownload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbDownload.Checked = true;
            this.chbDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDownload.Location = new System.Drawing.Point(207, 56);
            this.chbDownload.Name = "chbDownload";
            this.chbDownload.Size = new System.Drawing.Size(74, 17);
            this.chbDownload.TabIndex = 7;
            this.chbDownload.Text = "Download";
            this.chbDownload.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbDownload.UseVisualStyleBackColor = true;
            this.chbDownload.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Pages";
            // 
            // tFromPage
            // 
            this.tFromPage.Location = new System.Drawing.Point(88, 54);
            this.tFromPage.Name = "tFromPage";
            this.tFromPage.Size = new System.Drawing.Size(45, 20);
            this.tFromPage.TabIndex = 1;
            this.tFromPage.Text = "1";
            this.tFromPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pages_KeyDown);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(309, 25);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(102, 55);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Get the pictures!";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subreddit";
            // 
            // tSubreddit
            // 
            this.tSubreddit.Location = new System.Drawing.Point(87, 25);
            this.tSubreddit.Name = "tSubreddit";
            this.tSubreddit.Size = new System.Drawing.Size(194, 20);
            this.tSubreddit.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabSummary);
            this.panel2.Location = new System.Drawing.Point(12, 121);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 329);
            this.panel2.TabIndex = 1;
            // 
            // tabSummary
            // 
            this.tabSummary.Controls.Add(this.tabPage2);
            this.tabSummary.Controls.Add(this.tabPage1);
            this.tabSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSummary.Location = new System.Drawing.Point(0, 0);
            this.tabSummary.Name = "tabSummary";
            this.tabSummary.Padding = new System.Drawing.Point(0, 0);
            this.tabSummary.SelectedIndex = 0;
            this.tabSummary.Size = new System.Drawing.Size(810, 329);
            this.tabSummary.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowGallery);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(802, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gallery";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowGallery
            // 
            this.flowGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowGallery.Location = new System.Drawing.Point(0, 0);
            this.flowGallery.Margin = new System.Windows.Forms.Padding(0);
            this.flowGallery.Name = "flowGallery";
            this.flowGallery.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.flowGallery.Size = new System.Drawing.Size(802, 303);
            this.flowGallery.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSummary);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Summary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvSummary
            // 
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AllowUserToResizeColumns = false;
            this.dgvSummary.AllowUserToResizeRows = false;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.URL,
            this.Desc});
            this.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSummary.Location = new System.Drawing.Point(3, 3);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.Size = new System.Drawing.Size(796, 297);
            this.dgvSummary.TabIndex = 99;
            this.dgvSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSummary_CellContentClick);
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Num.HeaderText = "#";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Num.Width = 20;
            // 
            // URL
            // 
            this.URL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            this.URL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.URL.TrackVisitedState = false;
            this.URL.Width = 35;
            // 
            // Desc
            // 
            this.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Desc.HeaderText = "Description";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pbPages
            // 
            this.pbPages.Location = new System.Drawing.Point(12, 476);
            this.pbPages.Name = "pbPages";
            this.pbPages.Size = new System.Drawing.Size(810, 23);
            this.pbPages.TabIndex = 2;
            // 
            // tmrAfterSave
            // 
            this.tmrAfterSave.Interval = 2000;
            this.tmrAfterSave.Tick += new System.EventHandler(this.tmrAfterSave_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(541, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // SaveThread
            // 
            this.SaveThread.WorkerReportsProgress = true;
            this.SaveThread.WorkerSupportsCancellation = true;
            this.SaveThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SaveThread_DoWork);
            this.SaveThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SaveThread_ProgressChanged);
            this.SaveThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SaveThread_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(807, 198);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(260, 192);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(272, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(260, 192);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lStatus,
            this.lStatus2,
            this.lStatus3});
            this.StatusStrip.Location = new System.Drawing.Point(0, 737);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(841, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 13;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = false;
            this.lStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.lStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(200, 22);
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lStatus2
            // 
            this.lStatus2.AutoSize = false;
            this.lStatus2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lStatus2.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.lStatus2.Margin = new System.Windows.Forms.Padding(0);
            this.lStatus2.Name = "lStatus2";
            this.lStatus2.Size = new System.Drawing.Size(250, 22);
            this.lStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lStatus3
            // 
            this.lStatus3.Margin = new System.Windows.Forms.Padding(0);
            this.lStatus3.Name = "lStatus3";
            this.lStatus3.Size = new System.Drawing.Size(0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(9, 505);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(813, 217);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 759);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.pbPages);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rippit";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabSummary.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tSubreddit;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tFromPage;
        private System.Windows.Forms.ProgressBar pbPages;
        private System.Windows.Forms.Label lPath;
        private System.Windows.Forms.TextBox tPath;
        private System.Windows.Forms.CheckBox chbDownload;
        private System.Windows.Forms.ProgressBar pbImages;
        private System.Windows.Forms.Timer tmrAfterSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker SaveThread;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tToPage;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lStatus;
        private System.Windows.Forms.ToolStripStatusLabel lStatus2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabSummary;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewLinkColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowGallery;
        private System.Windows.Forms.ToolStripStatusLabel lStatus3;



    }
}

