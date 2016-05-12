namespace ACRCloud_Desktop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.keytextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultListBox = new System.Windows.Forms.ListBox();
            this.startbutton = new System.Windows.Forms.Button();
            this.choosefilebutton = new System.Windows.Forms.Button();
            this.secrettextbox = new System.Windows.Forms.TextBox();
            this.ChoosedfileListBox = new System.Windows.Forms.ListBox();
            this.hosttextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.intervaltextbox = new System.Windows.Forms.TextBox();
            this.exportbutton = new System.Windows.Forms.Button();
            this.clearbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keytextBox
            // 
            this.keytextBox.Location = new System.Drawing.Point(114, 143);
            this.keytextBox.Name = "keytextBox";
            this.keytextBox.Size = new System.Drawing.Size(199, 21);
            this.keytextBox.TabIndex = 0;
            this.keytextBox.TextChanged += new System.EventHandler(this.keytextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Access Key :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Access Secret :";
            // 
            // ResultListBox
            // 
            this.ResultListBox.FormattingEnabled = true;
            this.ResultListBox.ItemHeight = 12;
            this.ResultListBox.Location = new System.Drawing.Point(12, 241);
            this.ResultListBox.Name = "ResultListBox";
            this.ResultListBox.Size = new System.Drawing.Size(760, 304);
            this.ResultListBox.TabIndex = 5;
            // 
            // startbutton
            // 
            this.startbutton.Location = new System.Drawing.Point(476, 168);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(131, 51);
            this.startbutton.TabIndex = 6;
            this.startbutton.Text = "Start";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // choosefilebutton
            // 
            this.choosefilebutton.Location = new System.Drawing.Point(33, 12);
            this.choosefilebutton.Name = "choosefilebutton";
            this.choosefilebutton.Size = new System.Drawing.Size(133, 60);
            this.choosefilebutton.TabIndex = 7;
            this.choosefilebutton.Text = "Choose Files";
            this.choosefilebutton.UseVisualStyleBackColor = true;
            this.choosefilebutton.Click += new System.EventHandler(this.choosefilebutton_Click);
            // 
            // secrettextbox
            // 
            this.secrettextbox.Location = new System.Drawing.Point(114, 188);
            this.secrettextbox.Multiline = true;
            this.secrettextbox.Name = "secrettextbox";
            this.secrettextbox.Size = new System.Drawing.Size(199, 31);
            this.secrettextbox.TabIndex = 10;
            this.secrettextbox.TextChanged += new System.EventHandler(this.secrettextbox_TextChanged);
            // 
            // ChoosedfileListBox
            // 
            this.ChoosedfileListBox.FormattingEnabled = true;
            this.ChoosedfileListBox.ItemHeight = 12;
            this.ChoosedfileListBox.Location = new System.Drawing.Point(390, 12);
            this.ChoosedfileListBox.Name = "ChoosedfileListBox";
            this.ChoosedfileListBox.Size = new System.Drawing.Size(368, 136);
            this.ChoosedfileListBox.TabIndex = 11;
            // 
            // hosttextBox
            // 
            this.hosttextBox.Location = new System.Drawing.Point(114, 96);
            this.hosttextBox.Name = "hosttextBox";
            this.hosttextBox.Size = new System.Drawing.Size(199, 21);
            this.hosttextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Host :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Interval :";
            // 
            // intervaltextbox
            // 
            this.intervaltextbox.Location = new System.Drawing.Point(390, 188);
            this.intervaltextbox.Name = "intervaltextbox";
            this.intervaltextbox.Size = new System.Drawing.Size(63, 21);
            this.intervaltextbox.TabIndex = 15;
            this.intervaltextbox.Text = "10";
            // 
            // exportbutton
            // 
            this.exportbutton.Enabled = false;
            this.exportbutton.Location = new System.Drawing.Point(627, 168);
            this.exportbutton.Name = "exportbutton";
            this.exportbutton.Size = new System.Drawing.Size(131, 51);
            this.exportbutton.TabIndex = 16;
            this.exportbutton.Text = "Export Results";
            this.exportbutton.UseVisualStyleBackColor = true;
            this.exportbutton.Click += new System.EventHandler(this.exportbutton_Click);
            // 
            // clearbutton
            // 
            this.clearbutton.Location = new System.Drawing.Point(180, 12);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(133, 60);
            this.clearbutton.TabIndex = 17;
            this.clearbutton.Text = "Clear Files";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.clearbutton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.exportbutton);
            this.Controls.Add(this.intervaltextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hosttextBox);
            this.Controls.Add(this.ChoosedfileListBox);
            this.Controls.Add(this.secrettextbox);
            this.Controls.Add(this.choosefilebutton);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.ResultListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keytextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ACRCloud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keytextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ResultListBox;
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.Button choosefilebutton;
        private System.Windows.Forms.TextBox secrettextbox;
        private System.Windows.Forms.ListBox ChoosedfileListBox;
        private System.Windows.Forms.TextBox hosttextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox intervaltextbox;
        private System.Windows.Forms.Button exportbutton;
        private System.Windows.Forms.Button clearbutton;
    }
}

