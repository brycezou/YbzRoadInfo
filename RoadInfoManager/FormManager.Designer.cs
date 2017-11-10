namespace RoadInfoManager
{
    partial class FormManager
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
            this.comboBox_RoadNames = new System.Windows.Forms.ComboBox();
            this.webBrowser_baiduMap = new System.Windows.Forms.WebBrowser();
            this.label_roadName = new System.Windows.Forms.Label();
            this.dataGridView_editTable = new System.Windows.Forms.DataGridView();
            this.checkBox_AutoLoadImage = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_editTable)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_RoadNames
            // 
            this.comboBox_RoadNames.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_RoadNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoadNames.FormattingEnabled = true;
            this.comboBox_RoadNames.Location = new System.Drawing.Point(101, 15);
            this.comboBox_RoadNames.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_RoadNames.MaxLength = 40;
            this.comboBox_RoadNames.Name = "comboBox_RoadNames";
            this.comboBox_RoadNames.Size = new System.Drawing.Size(430, 23);
            this.comboBox_RoadNames.TabIndex = 41;
            this.comboBox_RoadNames.SelectedIndexChanged += new System.EventHandler(this.comboBox_RoadNames_SelectedIndexChanged);
            // 
            // webBrowser_baiduMap
            // 
            this.webBrowser_baiduMap.Location = new System.Drawing.Point(549, 15);
            this.webBrowser_baiduMap.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser_baiduMap.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser_baiduMap.Name = "webBrowser_baiduMap";
            this.webBrowser_baiduMap.ScriptErrorsSuppressed = true;
            this.webBrowser_baiduMap.Size = new System.Drawing.Size(408, 554);
            this.webBrowser_baiduMap.TabIndex = 43;
            // 
            // label_roadName
            // 
            this.label_roadName.AutoSize = true;
            this.label_roadName.Location = new System.Drawing.Point(16, 20);
            this.label_roadName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_roadName.Name = "label_roadName";
            this.label_roadName.Size = new System.Drawing.Size(82, 15);
            this.label_roadName.TabIndex = 40;
            this.label_roadName.Text = "线路名称：";
            // 
            // dataGridView_editTable
            // 
            this.dataGridView_editTable.AllowUserToAddRows = false;
            this.dataGridView_editTable.AllowUserToOrderColumns = true;
            this.dataGridView_editTable.AllowUserToResizeColumns = false;
            this.dataGridView_editTable.AllowUserToResizeRows = false;
            this.dataGridView_editTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_editTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_editTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_editTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_editTable.Location = new System.Drawing.Point(16, 57);
            this.dataGridView_editTable.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_editTable.MultiSelect = false;
            this.dataGridView_editTable.Name = "dataGridView_editTable";
            this.dataGridView_editTable.ReadOnly = true;
            this.dataGridView_editTable.RowTemplate.Height = 23;
            this.dataGridView_editTable.Size = new System.Drawing.Size(515, 539);
            this.dataGridView_editTable.TabIndex = 42;
            this.dataGridView_editTable.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_editTable_RowHeaderMouseDoubleClick);
            this.dataGridView_editTable.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_editTable_UserDeletingRow);
            // 
            // checkBox_AutoLoadImage
            // 
            this.checkBox_AutoLoadImage.AutoSize = true;
            this.checkBox_AutoLoadImage.Location = new System.Drawing.Point(549, 577);
            this.checkBox_AutoLoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_AutoLoadImage.Name = "checkBox_AutoLoadImage";
            this.checkBox_AutoLoadImage.Size = new System.Drawing.Size(164, 19);
            this.checkBox_AutoLoadImage.TabIndex = 44;
            this.checkBox_AutoLoadImage.Text = "自动加载标志牌图片";
            this.checkBox_AutoLoadImage.UseVisualStyleBackColor = true;
            this.checkBox_AutoLoadImage.CheckStateChanged += new System.EventHandler(this.checkBox_AutoLoadImage_CheckStateChanged);
            // 
            // FormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(969, 609);
            this.Controls.Add(this.checkBox_AutoLoadImage);
            this.Controls.Add(this.webBrowser_baiduMap);
            this.Controls.Add(this.comboBox_RoadNames);
            this.Controls.Add(this.dataGridView_editTable);
            this.Controls.Add(this.label_roadName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(987, 654);
            this.Name = "FormManager";
            this.Text = "交通标志信息管理系统";
            this.Load += new System.EventHandler(this.FormManager_Load);
            this.SizeChanged += new System.EventHandler(this.FormManager_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_editTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_RoadNames;
        private System.Windows.Forms.WebBrowser webBrowser_baiduMap;
        private System.Windows.Forms.Label label_roadName;
        private System.Windows.Forms.DataGridView dataGridView_editTable;
        private System.Windows.Forms.CheckBox checkBox_AutoLoadImage;
    }
}

