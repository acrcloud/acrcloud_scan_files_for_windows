namespace ACRCloud_File_Scan
{
    partial class MainFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ResultListBox = new System.Windows.Forms.ListBox();
            this.ChooseFilesButton = new System.Windows.Forms.Button();
            this.ClearFilesButton = new System.Windows.Forms.Button();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ExportResultsButton = new System.Windows.Forms.Button();
            this.ChangeConfigButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IntervalTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StopTextBox = new System.Windows.Forms.TextBox();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(15, 245);
            this.ProgressBar.Maximum = 1000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(585, 40);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 0;
            // 
            // ResultListBox
            // 
            this.ResultListBox.FormattingEnabled = true;
            this.ResultListBox.ItemHeight = 12;
            this.ResultListBox.Location = new System.Drawing.Point(15, 295);
            this.ResultListBox.Name = "ResultListBox";
            this.ResultListBox.Size = new System.Drawing.Size(585, 184);
            this.ResultListBox.TabIndex = 1;
            // 
            // ChooseFilesButton
            // 
            this.ChooseFilesButton.Location = new System.Drawing.Point(12, 80);
            this.ChooseFilesButton.Name = "ChooseFilesButton";
            this.ChooseFilesButton.Size = new System.Drawing.Size(150, 40);
            this.ChooseFilesButton.TabIndex = 2;
            this.ChooseFilesButton.Text = "Choose Files";
            this.ChooseFilesButton.UseVisualStyleBackColor = true;
            this.ChooseFilesButton.Click += new System.EventHandler(this.ChooseFilesButton_Click);
            // 
            // ClearFilesButton
            // 
            this.ClearFilesButton.Location = new System.Drawing.Point(165, 80);
            this.ClearFilesButton.Name = "ClearFilesButton";
            this.ClearFilesButton.Size = new System.Drawing.Size(150, 40);
            this.ClearFilesButton.TabIndex = 3;
            this.ClearFilesButton.Text = "Clear Files";
            this.ClearFilesButton.UseVisualStyleBackColor = true;
            this.ClearFilesButton.Click += new System.EventHandler(this.ClearFilesButton_Click);
            // 
            // FilesListBox
            // 
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.ItemHeight = 12;
            this.FilesListBox.Location = new System.Drawing.Point(15, 130);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(300, 100);
            this.FilesListBox.TabIndex = 4;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(340, 80);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(260, 40);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start Recognize";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ExportResultsButton
            // 
            this.ExportResultsButton.Enabled = false;
            this.ExportResultsButton.Location = new System.Drawing.Point(340, 135);
            this.ExportResultsButton.Name = "ExportResultsButton";
            this.ExportResultsButton.Size = new System.Drawing.Size(260, 40);
            this.ExportResultsButton.TabIndex = 6;
            this.ExportResultsButton.Text = "Export Results";
            this.ExportResultsButton.UseVisualStyleBackColor = true;
            this.ExportResultsButton.Click += new System.EventHandler(this.ExportResultsButton_Click);
            // 
            // ChangeConfigButton
            // 
            this.ChangeConfigButton.Location = new System.Drawing.Point(340, 190);
            this.ChangeConfigButton.Name = "ChangeConfigButton";
            this.ChangeConfigButton.Size = new System.Drawing.Size(260, 40);
            this.ChangeConfigButton.TabIndex = 8;
            this.ChangeConfigButton.Text = "Change Config";
            this.ChangeConfigButton.UseVisualStyleBackColor = true;
            this.ChangeConfigButton.Click += new System.EventHandler(this.ChangeConfigButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Interval(s):";
            // 
            // IntervalTextBox
            // 
            this.IntervalTextBox.Location = new System.Drawing.Point(340, 45);
            this.IntervalTextBox.Name = "IntervalTextBox";
            this.IntervalTextBox.Size = new System.Drawing.Size(80, 21);
            this.IntervalTextBox.TabIndex = 10;
            this.IntervalTextBox.Text = "10";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // StopTextBox
            // 
            this.StopTextBox.Location = new System.Drawing.Point(520, 45);
            this.StopTextBox.Name = "StopTextBox";
            this.StopTextBox.Size = new System.Drawing.Size(80, 21);
            this.StopTextBox.TabIndex = 18;
            this.StopTextBox.Text = "0";
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(430, 45);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(80, 21);
            this.StartTextBox.TabIndex = 17;
            this.StartTextBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Stop(s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Start(s):";
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 491);
            this.Controls.Add(this.StopTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IntervalTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangeConfigButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExportResultsButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FilesListBox);
            this.Controls.Add(this.ClearFilesButton);
            this.Controls.Add(this.ChooseFilesButton);
            this.Controls.Add(this.ResultListBox);
            this.Controls.Add(this.ProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrom";
            this.Text = "ACRCloud File Scan";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.ListBox ResultListBox;
        private System.Windows.Forms.Button ChooseFilesButton;
        private System.Windows.Forms.Button ClearFilesButton;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ExportResultsButton;
        private System.Windows.Forms.Button ChangeConfigButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IntervalTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox StopTextBox;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

