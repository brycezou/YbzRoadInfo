namespace RoadInfoReport
{
    partial class ReportForm
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
            this.webBrowser_BaiduMap = new System.Windows.Forms.WebBrowser();
            this.button_LoadXlsxFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_MarkPointOnce = new System.Windows.Forms.Button();
            this.button_ClearAllMarkers = new System.Windows.Forms.Button();
            this.button_ReportMode = new System.Windows.Forms.Button();
            this.checkBox_autoLoadImage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // webBrowser_BaiduMap
            // 
            this.webBrowser_BaiduMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_BaiduMap.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_BaiduMap.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser_BaiduMap.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser_BaiduMap.Name = "webBrowser_BaiduMap";
            this.webBrowser_BaiduMap.ScriptErrorsSuppressed = true;
            this.webBrowser_BaiduMap.Size = new System.Drawing.Size(969, 609);
            this.webBrowser_BaiduMap.TabIndex = 0;
            this.webBrowser_BaiduMap.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_BaiduMap_PreviewKeyDown);
            // 
            // button_LoadXlsxFile
            // 
            this.button_LoadXlsxFile.Location = new System.Drawing.Point(601, 562);
            this.button_LoadXlsxFile.Margin = new System.Windows.Forms.Padding(4);
            this.button_LoadXlsxFile.Name = "button_LoadXlsxFile";
            this.button_LoadXlsxFile.Size = new System.Drawing.Size(148, 39);
            this.button_LoadXlsxFile.TabIndex = 1;
            this.button_LoadXlsxFile.Text = "导入EXCEL文件";
            this.button_LoadXlsxFile.UseVisualStyleBackColor = true;
            this.button_LoadXlsxFile.Click += new System.EventHandler(this.button_LoadXlsxFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.xlsx";
            this.openFileDialog.Filter = "EXCEL文件(*.xlsx)|*.xlsx";
            // 
            // button_MarkPointOnce
            // 
            this.button_MarkPointOnce.Location = new System.Drawing.Point(759, 562);
            this.button_MarkPointOnce.Margin = new System.Windows.Forms.Padding(4);
            this.button_MarkPointOnce.Name = "button_MarkPointOnce";
            this.button_MarkPointOnce.Size = new System.Drawing.Size(96, 39);
            this.button_MarkPointOnce.TabIndex = 2;
            this.button_MarkPointOnce.Text = "标 记";
            this.button_MarkPointOnce.UseVisualStyleBackColor = true;
            this.button_MarkPointOnce.Click += new System.EventHandler(this.button_MarkPointOnce_Click);
            // 
            // button_ClearAllMarkers
            // 
            this.button_ClearAllMarkers.Location = new System.Drawing.Point(864, 562);
            this.button_ClearAllMarkers.Margin = new System.Windows.Forms.Padding(4);
            this.button_ClearAllMarkers.Name = "button_ClearAllMarkers";
            this.button_ClearAllMarkers.Size = new System.Drawing.Size(96, 39);
            this.button_ClearAllMarkers.TabIndex = 3;
            this.button_ClearAllMarkers.Text = "清 空";
            this.button_ClearAllMarkers.UseVisualStyleBackColor = true;
            this.button_ClearAllMarkers.Click += new System.EventHandler(this.button_ClearAllMarkers_Click);
            // 
            // button_ReportMode
            // 
            this.button_ReportMode.Location = new System.Drawing.Point(812, 12);
            this.button_ReportMode.Margin = new System.Windows.Forms.Padding(4);
            this.button_ReportMode.Name = "button_ReportMode";
            this.button_ReportMode.Size = new System.Drawing.Size(148, 39);
            this.button_ReportMode.TabIndex = 4;
            this.button_ReportMode.Text = "进入汇报模式";
            this.button_ReportMode.UseVisualStyleBackColor = true;
            this.button_ReportMode.Click += new System.EventHandler(this.button_ReportMode_Click);
            // 
            // checkBox_autoLoadImage
            // 
            this.checkBox_autoLoadImage.AutoSize = true;
            this.checkBox_autoLoadImage.Location = new System.Drawing.Point(16, 572);
            this.checkBox_autoLoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_autoLoadImage.Name = "checkBox_autoLoadImage";
            this.checkBox_autoLoadImage.Size = new System.Drawing.Size(89, 19);
            this.checkBox_autoLoadImage.TabIndex = 5;
            this.checkBox_autoLoadImage.Text = "加载图片";
            this.checkBox_autoLoadImage.UseVisualStyleBackColor = true;
            this.checkBox_autoLoadImage.CheckStateChanged += new System.EventHandler(this.checkBox_autoLoadImage_CheckStateChanged);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 609);
            this.Controls.Add(this.checkBox_autoLoadImage);
            this.Controls.Add(this.button_ClearAllMarkers);
            this.Controls.Add(this.button_MarkPointOnce);
            this.Controls.Add(this.button_LoadXlsxFile);
            this.Controls.Add(this.button_ReportMode);
            this.Controls.Add(this.webBrowser_BaiduMap);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(987, 654);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公路普查结果汇报";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportForm_FormClosed);
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.SizeChanged += new System.EventHandler(this.ReportForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReportForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser_BaiduMap;
        private System.Windows.Forms.Button button_LoadXlsxFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_MarkPointOnce;
        private System.Windows.Forms.Button button_ClearAllMarkers;
        private System.Windows.Forms.Button button_ReportMode;
        private System.Windows.Forms.CheckBox checkBox_autoLoadImage;
    }
}

