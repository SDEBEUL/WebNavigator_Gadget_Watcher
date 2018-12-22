namespace WebNavigator_Gadget_Watcher
{
    partial class WebNavigator_Gadget_Watcher_ConfigForm
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
            this.panel_setup = new System.Windows.Forms.Panel();
            this.tb_ExportedFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_readConfig = new System.Windows.Forms.Button();
            this.cb_WatchConfig = new System.Windows.Forms.CheckBox();
            this.tb_xmlConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_saveConfig = new System.Windows.Forms.Button();
            this.tb_HtmlExportPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_StartMonitoring = new System.Windows.Forms.Button();
            this.tb_netExportPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_netExportUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_netExportLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_INETCachePath = new System.Windows.Forms.TextBox();
            this.cb_EnblInetCachClean = new System.Windows.Forms.CheckBox();
            this.panel_setup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_setup
            // 
            this.panel_setup.Controls.Add(this.tb_ExportedFile);
            this.panel_setup.Controls.Add(this.label2);
            this.panel_setup.Controls.Add(this.btn_readConfig);
            this.panel_setup.Controls.Add(this.cb_WatchConfig);
            this.panel_setup.Controls.Add(this.tb_xmlConfig);
            this.panel_setup.Controls.Add(this.label1);
            this.panel_setup.Location = new System.Drawing.Point(13, 12);
            this.panel_setup.Name = "panel_setup";
            this.panel_setup.Size = new System.Drawing.Size(839, 130);
            this.panel_setup.TabIndex = 0;
            // 
            // tb_ExportedFile
            // 
            this.tb_ExportedFile.Location = new System.Drawing.Point(167, 80);
            this.tb_ExportedFile.Name = "tb_ExportedFile";
            this.tb_ExportedFile.Size = new System.Drawing.Size(530, 20);
            this.tb_ExportedFile.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gadget exported jpg file";
            // 
            // btn_readConfig
            // 
            this.btn_readConfig.Location = new System.Drawing.Point(712, 15);
            this.btn_readConfig.Name = "btn_readConfig";
            this.btn_readConfig.Size = new System.Drawing.Size(114, 37);
            this.btn_readConfig.TabIndex = 3;
            this.btn_readConfig.Text = "Read WIN CC  config";
            this.btn_readConfig.UseVisualStyleBackColor = true;
            this.btn_readConfig.Click += new System.EventHandler(this.btn_readConfig_Click);
            // 
            // cb_WatchConfig
            // 
            this.cb_WatchConfig.AutoSize = true;
            this.cb_WatchConfig.Location = new System.Drawing.Point(25, 51);
            this.cb_WatchConfig.Name = "cb_WatchConfig";
            this.cb_WatchConfig.Size = new System.Drawing.Size(340, 17);
            this.cb_WatchConfig.TabIndex = 2;
            this.cb_WatchConfig.Text = "Watch config file for changes (Appl restart when change detected)";
            this.cb_WatchConfig.UseVisualStyleBackColor = true;
            // 
            // tb_xmlConfig
            // 
            this.tb_xmlConfig.Location = new System.Drawing.Point(167, 15);
            this.tb_xmlConfig.Name = "tb_xmlConfig";
            this.tb_xmlConfig.Size = new System.Drawing.Size(530, 20);
            this.tb_xmlConfig.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gadget xml config file";
            // 
            // dgv_data
            // 
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Location = new System.Drawing.Point(12, 245);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.Size = new System.Drawing.Size(839, 413);
            this.dgv_data.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_saveConfig);
            this.panel1.Controls.Add(this.tb_HtmlExportPath);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_StartMonitoring);
            this.panel1.Controls.Add(this.tb_netExportPass);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tb_netExportUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_netExportLocation);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(13, 674);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 142);
            this.panel1.TabIndex = 6;
            // 
            // btn_saveConfig
            // 
            this.btn_saveConfig.Location = new System.Drawing.Point(25, 102);
            this.btn_saveConfig.Name = "btn_saveConfig";
            this.btn_saveConfig.Size = new System.Drawing.Size(82, 23);
            this.btn_saveConfig.TabIndex = 10;
            this.btn_saveConfig.Text = "Safe Config";
            this.btn_saveConfig.UseVisualStyleBackColor = true;
            this.btn_saveConfig.Click += new System.EventHandler(this.btn_saveConfig_Click);
            // 
            // tb_HtmlExportPath
            // 
            this.tb_HtmlExportPath.Location = new System.Drawing.Point(167, 76);
            this.tb_HtmlExportPath.Name = "tb_HtmlExportPath";
            this.tb_HtmlExportPath.Size = new System.Drawing.Size(650, 20);
            this.tb_HtmlExportPath.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Html Export path";
            // 
            // btn_StartMonitoring
            // 
            this.btn_StartMonitoring.Location = new System.Drawing.Point(722, 102);
            this.btn_StartMonitoring.Name = "btn_StartMonitoring";
            this.btn_StartMonitoring.Size = new System.Drawing.Size(95, 23);
            this.btn_StartMonitoring.TabIndex = 6;
            this.btn_StartMonitoring.Text = "StartMonitoring";
            this.btn_StartMonitoring.UseVisualStyleBackColor = true;
            this.btn_StartMonitoring.Click += new System.EventHandler(this.btn_StartMonitoring_Click);
            // 
            // tb_netExportPass
            // 
            this.tb_netExportPass.Location = new System.Drawing.Point(300, 44);
            this.tb_netExportPass.Name = "tb_netExportPass";
            this.tb_netExportPass.Size = new System.Drawing.Size(139, 20);
            this.tb_netExportPass.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // tb_netExportUser
            // 
            this.tb_netExportUser.Location = new System.Drawing.Point(73, 44);
            this.tb_netExportUser.Name = "tb_netExportUser";
            this.tb_netExportUser.Size = new System.Drawing.Size(162, 20);
            this.tb_netExportUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User";
            // 
            // tb_netExportLocation
            // 
            this.tb_netExportLocation.Location = new System.Drawing.Point(167, 18);
            this.tb_netExportLocation.Name = "tb_netExportLocation";
            this.tb_netExportLocation.Size = new System.Drawing.Size(650, 20);
            this.tb_netExportLocation.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Jpg Export networkLocation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Configuration";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cb_EnblInetCachClean);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tb_INETCachePath);
            this.panel2.Location = new System.Drawing.Point(13, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 78);
            this.panel2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "InetCachePath";
            // 
            // tb_INETCachePath
            // 
            this.tb_INETCachePath.Location = new System.Drawing.Point(167, 18);
            this.tb_INETCachePath.Name = "tb_INETCachePath";
            this.tb_INETCachePath.Size = new System.Drawing.Size(530, 20);
            this.tb_INETCachePath.TabIndex = 6;
            // 
            // cb_EnblInetCachClean
            // 
            this.cb_EnblInetCachClean.AutoSize = true;
            this.cb_EnblInetCachClean.Location = new System.Drawing.Point(25, 44);
            this.cb_EnblInetCachClean.Name = "cb_EnblInetCachClean";
            this.cb_EnblInetCachClean.Size = new System.Drawing.Size(90, 17);
            this.cb_EnblInetCachClean.TabIndex = 6;
            this.cb_EnblInetCachClean.Text = "Enbl cleaning";
            this.cb_EnblInetCachClean.UseVisualStyleBackColor = true;
            // 
            // WebNavigator_Gadget_Watcher_ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 862);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.panel_setup);
            this.MaximumSize = new System.Drawing.Size(880, 900);
            this.MinimumSize = new System.Drawing.Size(880, 900);
            this.Name = "WebNavigator_Gadget_Watcher_ConfigForm";
            this.Text = "WebNavigator_Gadget_Watcher";
            this.panel_setup.ResumeLayout(false);
            this.panel_setup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_setup;
        private System.Windows.Forms.TextBox tb_ExportedFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_readConfig;
        private System.Windows.Forms.CheckBox cb_WatchConfig;
        private System.Windows.Forms.TextBox tb_xmlConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_netExportPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_netExportUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_netExportLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_StartMonitoring;
        private System.Windows.Forms.Button btn_saveConfig;
        private System.Windows.Forms.TextBox tb_HtmlExportPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_INETCachePath;
        private System.Windows.Forms.CheckBox cb_EnblInetCachClean;
    }
}

