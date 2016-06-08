namespace ACRCloud_File_Scan
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.HostLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.SecretLabel = new System.Windows.Forms.Label();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.SecretTextBox = new System.Windows.Forms.TextBox();
            this.HostComboBox = new System.Windows.Forms.ComboBox();
            this.SaveConfigButton = new System.Windows.Forms.Button();
            this.ConfigCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(20, 25);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(41, 12);
            this.HostLabel.TabIndex = 0;
            this.HostLabel.Text = "Host :";
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(20, 70);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(35, 12);
            this.KeyLabel.TabIndex = 1;
            this.KeyLabel.Text = "Key :";
            // 
            // SecretLabel
            // 
            this.SecretLabel.AutoSize = true;
            this.SecretLabel.Location = new System.Drawing.Point(12, 120);
            this.SecretLabel.Name = "SecretLabel";
            this.SecretLabel.Size = new System.Drawing.Size(53, 12);
            this.SecretLabel.TabIndex = 2;
            this.SecretLabel.Text = "Secret :";
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(70, 65);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(200, 21);
            this.KeyTextBox.TabIndex = 14;
            // 
            // SecretTextBox
            // 
            this.SecretTextBox.Location = new System.Drawing.Point(70, 110);
            this.SecretTextBox.Multiline = true;
            this.SecretTextBox.Name = "SecretTextBox";
            this.SecretTextBox.Size = new System.Drawing.Size(200, 30);
            this.SecretTextBox.TabIndex = 15;
            // 
            // HostComboBox
            // 
            this.HostComboBox.FormattingEnabled = true;
            this.HostComboBox.Items.AddRange(new object[] {
            "eu-west-1.api.acrcloud.com",
            "ap-southeast-1.api.acrcloud.com",
            "us-west-2.api.acrcloud.com"});
            this.HostComboBox.Location = new System.Drawing.Point(70, 20);
            this.HostComboBox.Name = "HostComboBox";
            this.HostComboBox.Size = new System.Drawing.Size(200, 20);
            this.HostComboBox.TabIndex = 16;
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.Location = new System.Drawing.Point(25, 165);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(90, 25);
            this.SaveConfigButton.TabIndex = 17;
            this.SaveConfigButton.Text = "Save";
            this.SaveConfigButton.UseVisualStyleBackColor = true;
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // ConfigCancelButton
            // 
            this.ConfigCancelButton.Location = new System.Drawing.Point(170, 165);
            this.ConfigCancelButton.Name = "ConfigCancelButton";
            this.ConfigCancelButton.Size = new System.Drawing.Size(90, 25);
            this.ConfigCancelButton.TabIndex = 18;
            this.ConfigCancelButton.Text = "Cancel";
            this.ConfigCancelButton.UseVisualStyleBackColor = true;
            this.ConfigCancelButton.Click += new System.EventHandler(this.ConfigCancelButton_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.ConfigCancelButton);
            this.Controls.Add(this.SaveConfigButton);
            this.Controls.Add(this.HostComboBox);
            this.Controls.Add(this.SecretTextBox);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.SecretLabel);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.HostLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Label SecretLabel;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.TextBox SecretTextBox;
        private System.Windows.Forms.ComboBox HostComboBox;
        private System.Windows.Forms.Button SaveConfigButton;
        private System.Windows.Forms.Button ConfigCancelButton;
    }
}