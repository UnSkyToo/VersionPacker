namespace VersionPackerGUI
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
            this.lOldVersion = new System.Windows.Forms.Label();
            this.numericOldVersion1 = new System.Windows.Forms.NumericUpDown();
            this.numericOldVersion2 = new System.Windows.Forms.NumericUpDown();
            this.numericOldVersion3 = new System.Windows.Forms.NumericUpDown();
            this.numericOldVersion4 = new System.Windows.Forms.NumericUpDown();
            this.groupPath = new System.Windows.Forms.GroupBox();
            this.btnClearIgnoreList = new System.Windows.Forms.Button();
            this.btnDeleteIgnoreItem = new System.Windows.Forms.Button();
            this.btnAddIgnoreFolder = new System.Windows.Forms.Button();
            this.btnAddIgnoreFile = new System.Windows.Forms.Button();
            this.lIgnoreList = new System.Windows.Forms.Label();
            this.listIgnore = new System.Windows.Forms.ListBox();
            this.linkResourcePath = new System.Windows.Forms.LinkLabel();
            this.linkPatchPath = new System.Windows.Forms.LinkLabel();
            this.linkVersionPath = new System.Windows.Forms.LinkLabel();
            this.lResourcePath = new System.Windows.Forms.Label();
            this.lPatchPath = new System.Windows.Forms.Label();
            this.lVersionPath = new System.Windows.Forms.Label();
            this.lNewVersion = new System.Windows.Forms.Label();
            this.numericNewVersion1 = new System.Windows.Forms.NumericUpDown();
            this.numericNewVersion2 = new System.Windows.Forms.NumericUpDown();
            this.numericNewVersion3 = new System.Windows.Forms.NumericUpDown();
            this.numericNewVersion4 = new System.Windows.Forms.NumericUpDown();
            this.groupVersion = new System.Windows.Forms.GroupBox();
            this.groupFunction = new System.Windows.Forms.GroupBox();
            this.btnCreateWholePack = new System.Windows.Forms.Button();
            this.btnCreatePatch = new System.Windows.Forms.Button();
            this.groupConfig = new System.Windows.Forms.GroupBox();
            this.txtUpdaterUrl = new System.Windows.Forms.TextBox();
            this.lUpdaterUrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion4)).BeginInit();
            this.groupPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion4)).BeginInit();
            this.groupVersion.SuspendLayout();
            this.groupFunction.SuspendLayout();
            this.groupConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lOldVersion
            // 
            this.lOldVersion.AutoSize = true;
            this.lOldVersion.Location = new System.Drawing.Point(6, 24);
            this.lOldVersion.Name = "lOldVersion";
            this.lOldVersion.Size = new System.Drawing.Size(53, 12);
            this.lOldVersion.TabIndex = 0;
            this.lOldVersion.Text = "老版本号";
            // 
            // numericOldVersion1
            // 
            this.numericOldVersion1.Location = new System.Drawing.Point(65, 20);
            this.numericOldVersion1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOldVersion1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericOldVersion1.Name = "numericOldVersion1";
            this.numericOldVersion1.Size = new System.Drawing.Size(36, 21);
            this.numericOldVersion1.TabIndex = 1;
            this.numericOldVersion1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericOldVersion1.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // numericOldVersion2
            // 
            this.numericOldVersion2.Location = new System.Drawing.Point(107, 20);
            this.numericOldVersion2.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOldVersion2.Name = "numericOldVersion2";
            this.numericOldVersion2.Size = new System.Drawing.Size(36, 21);
            this.numericOldVersion2.TabIndex = 1;
            this.numericOldVersion2.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // numericOldVersion3
            // 
            this.numericOldVersion3.Location = new System.Drawing.Point(149, 20);
            this.numericOldVersion3.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOldVersion3.Name = "numericOldVersion3";
            this.numericOldVersion3.Size = new System.Drawing.Size(36, 21);
            this.numericOldVersion3.TabIndex = 1;
            this.numericOldVersion3.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // numericOldVersion4
            // 
            this.numericOldVersion4.Location = new System.Drawing.Point(191, 20);
            this.numericOldVersion4.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericOldVersion4.Name = "numericOldVersion4";
            this.numericOldVersion4.Size = new System.Drawing.Size(36, 21);
            this.numericOldVersion4.TabIndex = 1;
            this.numericOldVersion4.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // groupPath
            // 
            this.groupPath.Controls.Add(this.btnClearIgnoreList);
            this.groupPath.Controls.Add(this.btnDeleteIgnoreItem);
            this.groupPath.Controls.Add(this.btnAddIgnoreFolder);
            this.groupPath.Controls.Add(this.btnAddIgnoreFile);
            this.groupPath.Controls.Add(this.lIgnoreList);
            this.groupPath.Controls.Add(this.listIgnore);
            this.groupPath.Controls.Add(this.linkResourcePath);
            this.groupPath.Controls.Add(this.linkPatchPath);
            this.groupPath.Controls.Add(this.linkVersionPath);
            this.groupPath.Controls.Add(this.lResourcePath);
            this.groupPath.Controls.Add(this.lPatchPath);
            this.groupPath.Controls.Add(this.lVersionPath);
            this.groupPath.Location = new System.Drawing.Point(20, 218);
            this.groupPath.Name = "groupPath";
            this.groupPath.Size = new System.Drawing.Size(561, 280);
            this.groupPath.TabIndex = 2;
            this.groupPath.TabStop = false;
            this.groupPath.Text = "目录";
            // 
            // btnClearIgnoreList
            // 
            this.btnClearIgnoreList.Location = new System.Drawing.Point(471, 229);
            this.btnClearIgnoreList.Name = "btnClearIgnoreList";
            this.btnClearIgnoreList.Size = new System.Drawing.Size(84, 37);
            this.btnClearIgnoreList.TabIndex = 6;
            this.btnClearIgnoreList.Text = "清空";
            this.btnClearIgnoreList.UseVisualStyleBackColor = true;
            this.btnClearIgnoreList.Click += new System.EventHandler(this.btnClearIgnoreList_Click);
            // 
            // btnDeleteIgnoreItem
            // 
            this.btnDeleteIgnoreItem.Location = new System.Drawing.Point(471, 186);
            this.btnDeleteIgnoreItem.Name = "btnDeleteIgnoreItem";
            this.btnDeleteIgnoreItem.Size = new System.Drawing.Size(84, 37);
            this.btnDeleteIgnoreItem.TabIndex = 5;
            this.btnDeleteIgnoreItem.Text = "删除";
            this.btnDeleteIgnoreItem.UseVisualStyleBackColor = true;
            this.btnDeleteIgnoreItem.Click += new System.EventHandler(this.btnDeleteIgnoreItem_Click);
            // 
            // btnAddIgnoreFolder
            // 
            this.btnAddIgnoreFolder.Location = new System.Drawing.Point(471, 143);
            this.btnAddIgnoreFolder.Name = "btnAddIgnoreFolder";
            this.btnAddIgnoreFolder.Size = new System.Drawing.Size(84, 37);
            this.btnAddIgnoreFolder.TabIndex = 4;
            this.btnAddIgnoreFolder.Text = "添加文件夹";
            this.btnAddIgnoreFolder.UseVisualStyleBackColor = true;
            this.btnAddIgnoreFolder.Click += new System.EventHandler(this.btnAddIgnoreFolder_Click);
            // 
            // btnAddIgnoreFile
            // 
            this.btnAddIgnoreFile.Location = new System.Drawing.Point(471, 100);
            this.btnAddIgnoreFile.Name = "btnAddIgnoreFile";
            this.btnAddIgnoreFile.Size = new System.Drawing.Size(84, 37);
            this.btnAddIgnoreFile.TabIndex = 4;
            this.btnAddIgnoreFile.Text = "添加文件";
            this.btnAddIgnoreFile.UseVisualStyleBackColor = true;
            this.btnAddIgnoreFile.Click += new System.EventHandler(this.btnAddIgnoreFile_Click);
            // 
            // lIgnoreList
            // 
            this.lIgnoreList.AutoSize = true;
            this.lIgnoreList.Location = new System.Drawing.Point(6, 85);
            this.lIgnoreList.Name = "lIgnoreList";
            this.lIgnoreList.Size = new System.Drawing.Size(53, 12);
            this.lIgnoreList.TabIndex = 3;
            this.lIgnoreList.Text = "忽略列表";
            // 
            // listIgnore
            // 
            this.listIgnore.FormattingEnabled = true;
            this.listIgnore.HorizontalScrollbar = true;
            this.listIgnore.ItemHeight = 12;
            this.listIgnore.Location = new System.Drawing.Point(6, 100);
            this.listIgnore.Name = "listIgnore";
            this.listIgnore.Size = new System.Drawing.Size(459, 172);
            this.listIgnore.TabIndex = 2;
            // 
            // linkResourcePath
            // 
            this.linkResourcePath.AutoSize = true;
            this.linkResourcePath.Location = new System.Drawing.Point(77, 63);
            this.linkResourcePath.Name = "linkResourcePath";
            this.linkResourcePath.Size = new System.Drawing.Size(77, 12);
            this.linkResourcePath.TabIndex = 1;
            this.linkResourcePath.TabStop = true;
            this.linkResourcePath.Text = "点击选择目录";
            this.linkResourcePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResourcePath_LinkClicked);
            // 
            // linkPatchPath
            // 
            this.linkPatchPath.AutoSize = true;
            this.linkPatchPath.Location = new System.Drawing.Point(77, 40);
            this.linkPatchPath.Name = "linkPatchPath";
            this.linkPatchPath.Size = new System.Drawing.Size(77, 12);
            this.linkPatchPath.TabIndex = 1;
            this.linkPatchPath.TabStop = true;
            this.linkPatchPath.Text = "点击选择目录";
            this.linkPatchPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPatchPath_LinkClicked);
            // 
            // linkVersionPath
            // 
            this.linkVersionPath.AutoSize = true;
            this.linkVersionPath.Location = new System.Drawing.Point(77, 17);
            this.linkVersionPath.Name = "linkVersionPath";
            this.linkVersionPath.Size = new System.Drawing.Size(77, 12);
            this.linkVersionPath.TabIndex = 1;
            this.linkVersionPath.TabStop = true;
            this.linkVersionPath.Text = "点击选择目录";
            this.linkVersionPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVersionPath_LinkClicked);
            // 
            // lResourcePath
            // 
            this.lResourcePath.AutoSize = true;
            this.lResourcePath.Location = new System.Drawing.Point(6, 63);
            this.lResourcePath.Name = "lResourcePath";
            this.lResourcePath.Size = new System.Drawing.Size(65, 12);
            this.lResourcePath.TabIndex = 0;
            this.lResourcePath.Text = "资源包目录";
            // 
            // lPatchPath
            // 
            this.lPatchPath.AutoSize = true;
            this.lPatchPath.Location = new System.Drawing.Point(6, 40);
            this.lPatchPath.Name = "lPatchPath";
            this.lPatchPath.Size = new System.Drawing.Size(65, 12);
            this.lPatchPath.TabIndex = 0;
            this.lPatchPath.Text = "差异包目录";
            // 
            // lVersionPath
            // 
            this.lVersionPath.AutoSize = true;
            this.lVersionPath.Location = new System.Drawing.Point(6, 17);
            this.lVersionPath.Name = "lVersionPath";
            this.lVersionPath.Size = new System.Drawing.Size(65, 12);
            this.lVersionPath.TabIndex = 0;
            this.lVersionPath.Text = "版本库目录";
            // 
            // lNewVersion
            // 
            this.lNewVersion.AutoSize = true;
            this.lNewVersion.Location = new System.Drawing.Point(6, 51);
            this.lNewVersion.Name = "lNewVersion";
            this.lNewVersion.Size = new System.Drawing.Size(53, 12);
            this.lNewVersion.TabIndex = 0;
            this.lNewVersion.Text = "新版本号";
            // 
            // numericNewVersion1
            // 
            this.numericNewVersion1.Location = new System.Drawing.Point(65, 47);
            this.numericNewVersion1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericNewVersion1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNewVersion1.Name = "numericNewVersion1";
            this.numericNewVersion1.Size = new System.Drawing.Size(36, 21);
            this.numericNewVersion1.TabIndex = 1;
            this.numericNewVersion1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNewVersion1.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // numericNewVersion2
            // 
            this.numericNewVersion2.Location = new System.Drawing.Point(107, 47);
            this.numericNewVersion2.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericNewVersion2.Name = "numericNewVersion2";
            this.numericNewVersion2.Size = new System.Drawing.Size(36, 21);
            this.numericNewVersion2.TabIndex = 1;
            this.numericNewVersion2.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // numericNewVersion3
            // 
            this.numericNewVersion3.Location = new System.Drawing.Point(149, 47);
            this.numericNewVersion3.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericNewVersion3.Name = "numericNewVersion3";
            this.numericNewVersion3.Size = new System.Drawing.Size(36, 21);
            this.numericNewVersion3.TabIndex = 1;
            this.numericNewVersion3.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // numericNewVersion4
            // 
            this.numericNewVersion4.Location = new System.Drawing.Point(191, 47);
            this.numericNewVersion4.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericNewVersion4.Name = "numericNewVersion4";
            this.numericNewVersion4.Size = new System.Drawing.Size(36, 21);
            this.numericNewVersion4.TabIndex = 1;
            this.numericNewVersion4.ValueChanged += new System.EventHandler(this.numericOldVersion_ValueChanged);
            // 
            // groupVersion
            // 
            this.groupVersion.Controls.Add(this.lOldVersion);
            this.groupVersion.Controls.Add(this.lNewVersion);
            this.groupVersion.Controls.Add(this.numericNewVersion4);
            this.groupVersion.Controls.Add(this.numericOldVersion1);
            this.groupVersion.Controls.Add(this.numericOldVersion4);
            this.groupVersion.Controls.Add(this.numericNewVersion1);
            this.groupVersion.Controls.Add(this.numericNewVersion3);
            this.groupVersion.Controls.Add(this.numericOldVersion2);
            this.groupVersion.Controls.Add(this.numericOldVersion3);
            this.groupVersion.Controls.Add(this.numericNewVersion2);
            this.groupVersion.Location = new System.Drawing.Point(20, 12);
            this.groupVersion.Name = "groupVersion";
            this.groupVersion.Size = new System.Drawing.Size(240, 128);
            this.groupVersion.TabIndex = 3;
            this.groupVersion.TabStop = false;
            this.groupVersion.Text = "版本";
            // 
            // groupFunction
            // 
            this.groupFunction.Controls.Add(this.btnCreateWholePack);
            this.groupFunction.Controls.Add(this.btnCreatePatch);
            this.groupFunction.Location = new System.Drawing.Point(266, 12);
            this.groupFunction.Name = "groupFunction";
            this.groupFunction.Size = new System.Drawing.Size(315, 128);
            this.groupFunction.TabIndex = 4;
            this.groupFunction.TabStop = false;
            this.groupFunction.Text = "功能";
            // 
            // btnCreateWholePack
            // 
            this.btnCreateWholePack.Location = new System.Drawing.Point(167, 20);
            this.btnCreateWholePack.Name = "btnCreateWholePack";
            this.btnCreateWholePack.Size = new System.Drawing.Size(115, 33);
            this.btnCreateWholePack.TabIndex = 0;
            this.btnCreateWholePack.Text = "生成新版本整包";
            this.btnCreateWholePack.UseVisualStyleBackColor = true;
            this.btnCreateWholePack.Click += new System.EventHandler(this.btnCreateWholePack_Click);
            // 
            // btnCreatePatch
            // 
            this.btnCreatePatch.Location = new System.Drawing.Point(17, 20);
            this.btnCreatePatch.Name = "btnCreatePatch";
            this.btnCreatePatch.Size = new System.Drawing.Size(115, 33);
            this.btnCreatePatch.TabIndex = 0;
            this.btnCreatePatch.Text = "生成新版本补丁";
            this.btnCreatePatch.UseVisualStyleBackColor = true;
            this.btnCreatePatch.Click += new System.EventHandler(this.btnCreatePatch_Click);
            // 
            // groupConfig
            // 
            this.groupConfig.Controls.Add(this.txtUpdaterUrl);
            this.groupConfig.Controls.Add(this.lUpdaterUrl);
            this.groupConfig.Location = new System.Drawing.Point(20, 146);
            this.groupConfig.Name = "groupConfig";
            this.groupConfig.Size = new System.Drawing.Size(561, 66);
            this.groupConfig.TabIndex = 5;
            this.groupConfig.TabStop = false;
            this.groupConfig.Text = "配置";
            // 
            // txtUpdaterUrl
            // 
            this.txtUpdaterUrl.Location = new System.Drawing.Point(101, 14);
            this.txtUpdaterUrl.Name = "txtUpdaterUrl";
            this.txtUpdaterUrl.Size = new System.Drawing.Size(323, 21);
            this.txtUpdaterUrl.TabIndex = 1;
            this.txtUpdaterUrl.TextChanged += new System.EventHandler(this.txtUpdaterUrl_TextChanged);
            // 
            // lUpdaterUrl
            // 
            this.lUpdaterUrl.AutoSize = true;
            this.lUpdaterUrl.Location = new System.Drawing.Point(6, 17);
            this.lUpdaterUrl.Name = "lUpdaterUrl";
            this.lUpdaterUrl.Size = new System.Drawing.Size(89, 12);
            this.lUpdaterUrl.TabIndex = 0;
            this.lUpdaterUrl.Text = "更新服务器地址";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 502);
            this.Controls.Add(this.groupConfig);
            this.Controls.Add(this.groupFunction);
            this.Controls.Add(this.groupVersion);
            this.Controls.Add(this.groupPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VersionPackerGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOldVersion4)).EndInit();
            this.groupPath.ResumeLayout(false);
            this.groupPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewVersion4)).EndInit();
            this.groupVersion.ResumeLayout(false);
            this.groupVersion.PerformLayout();
            this.groupFunction.ResumeLayout(false);
            this.groupConfig.ResumeLayout(false);
            this.groupConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lOldVersion;
        private System.Windows.Forms.NumericUpDown numericOldVersion1;
        private System.Windows.Forms.NumericUpDown numericOldVersion2;
        private System.Windows.Forms.NumericUpDown numericOldVersion3;
        private System.Windows.Forms.NumericUpDown numericOldVersion4;
        private System.Windows.Forms.GroupBox groupPath;
        private System.Windows.Forms.LinkLabel linkVersionPath;
        private System.Windows.Forms.Label lVersionPath;
        private System.Windows.Forms.LinkLabel linkPatchPath;
        private System.Windows.Forms.Label lPatchPath;
        private System.Windows.Forms.Label lNewVersion;
        private System.Windows.Forms.NumericUpDown numericNewVersion1;
        private System.Windows.Forms.NumericUpDown numericNewVersion2;
        private System.Windows.Forms.NumericUpDown numericNewVersion3;
        private System.Windows.Forms.NumericUpDown numericNewVersion4;
        private System.Windows.Forms.GroupBox groupVersion;
        private System.Windows.Forms.GroupBox groupFunction;
        private System.Windows.Forms.Button btnCreateWholePack;
        private System.Windows.Forms.Button btnCreatePatch;
        private System.Windows.Forms.LinkLabel linkResourcePath;
        private System.Windows.Forms.Label lResourcePath;
        private System.Windows.Forms.GroupBox groupConfig;
        private System.Windows.Forms.Label lUpdaterUrl;
        private System.Windows.Forms.TextBox txtUpdaterUrl;
        private System.Windows.Forms.Label lIgnoreList;
        private System.Windows.Forms.ListBox listIgnore;
        private System.Windows.Forms.Button btnAddIgnoreFolder;
        private System.Windows.Forms.Button btnAddIgnoreFile;
        private System.Windows.Forms.Button btnDeleteIgnoreItem;
        private System.Windows.Forms.Button btnClearIgnoreList;
    }
}

