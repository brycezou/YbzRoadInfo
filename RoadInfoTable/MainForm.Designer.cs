namespace RoadInfoTable
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
            this.label_roadName = new System.Windows.Forms.Label();
            this.label_checkTime = new System.Windows.Forms.Label();
            this.webBrowser_BaiduMap = new System.Windows.Forms.WebBrowser();
            this.textBox_checkTime = new System.Windows.Forms.TextBox();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.button_StartPreview = new System.Windows.Forms.Button();
            this.imageBox_Small = new Emgu.CV.UI.ImageBox();
            this.textBox_PhotoName = new System.Windows.Forms.TextBox();
            this.label_PhotoName = new System.Windows.Forms.Label();
            this.button_Quary = new System.Windows.Forms.Button();
            this.button_UpdateMap = new System.Windows.Forms.Button();
            this.buttonAddNewRoad = new System.Windows.Forms.Button();
            this.comboBox_RoadNames = new System.Windows.Forms.ComboBox();
            this.buttonModifyRoad = new System.Windows.Forms.Button();
            this.labelSystemStatus = new System.Windows.Forms.Label();
            this.textBox_Latitude = new System.Windows.Forms.TextBox();
            this.label_Latitude = new System.Windows.Forms.Label();
            this.textBox_Longitude = new System.Windows.Forms.TextBox();
            this.label__Longitude = new System.Windows.Forms.Label();
            this.label_X = new System.Windows.Forms.Label();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.label_plateSize = new System.Windows.Forms.Label();
            this.comboBox_plateStyle = new System.Windows.Forms.ComboBox();
            this.label_plateStyle = new System.Windows.Forms.Label();
            this.comboBox_markType = new System.Windows.Forms.ComboBox();
            this.label_markType = new System.Windows.Forms.Label();
            this.comboBox_layStyle = new System.Windows.Forms.ComboBox();
            this.label_layStyle = new System.Windows.Forms.Label();
            this.comboBox_leftRight = new System.Windows.Forms.ComboBox();
            this.label_leftRight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAutoByCurrent = new System.Windows.Forms.Button();
            this.buttonAutoByStart = new System.Windows.Forms.Button();
            this.textBox_Number = new System.Windows.Forms.TextBox();
            this.label_Number = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Minus = new System.Windows.Forms.RadioButton();
            this.radioButton_Plus = new System.Windows.Forms.RadioButton();
            this.textBox_CurrReference = new System.Windows.Forms.TextBox();
            this.comboBox_CommPort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_Small)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_roadName
            // 
            this.label_roadName.AutoSize = true;
            this.label_roadName.Location = new System.Drawing.Point(16, 19);
            this.label_roadName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_roadName.Name = "label_roadName";
            this.label_roadName.Size = new System.Drawing.Size(82, 15);
            this.label_roadName.TabIndex = 0;
            this.label_roadName.Text = "线路名称：";
            // 
            // label_checkTime
            // 
            this.label_checkTime.AutoSize = true;
            this.label_checkTime.Location = new System.Drawing.Point(573, 19);
            this.label_checkTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_checkTime.Name = "label_checkTime";
            this.label_checkTime.Size = new System.Drawing.Size(52, 15);
            this.label_checkTime.TabIndex = 1;
            this.label_checkTime.Text = "时间：";
            // 
            // webBrowser_BaiduMap
            // 
            this.webBrowser_BaiduMap.Location = new System.Drawing.Point(19, 45);
            this.webBrowser_BaiduMap.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser_BaiduMap.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser_BaiduMap.Name = "webBrowser_BaiduMap";
            this.webBrowser_BaiduMap.ScriptErrorsSuppressed = true;
            this.webBrowser_BaiduMap.Size = new System.Drawing.Size(744, 282);
            this.webBrowser_BaiduMap.TabIndex = 2;
            this.webBrowser_BaiduMap.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // textBox_checkTime
            // 
            this.textBox_checkTime.Location = new System.Drawing.Point(623, 14);
            this.textBox_checkTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_checkTime.Name = "textBox_checkTime";
            this.textBox_checkTime.ReadOnly = true;
            this.textBox_checkTime.Size = new System.Drawing.Size(140, 25);
            this.textBox_checkTime.TabIndex = 3;
            // 
            // imageBox
            // 
            this.imageBox.BackColor = System.Drawing.Color.Black;
            this.imageBox.Enabled = false;
            this.imageBox.Location = new System.Drawing.Point(19, 345);
            this.imageBox.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(449, 297);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // button_StartPreview
            // 
            this.button_StartPreview.Location = new System.Drawing.Point(608, 608);
            this.button_StartPreview.Margin = new System.Windows.Forms.Padding(4);
            this.button_StartPreview.Name = "button_StartPreview";
            this.button_StartPreview.Size = new System.Drawing.Size(155, 34);
            this.button_StartPreview.TabIndex = 24;
            this.button_StartPreview.Text = "开始采集";
            this.button_StartPreview.UseVisualStyleBackColor = true;
            this.button_StartPreview.Click += new System.EventHandler(this.button_StartPreview_Click);
            // 
            // imageBox_Small
            // 
            this.imageBox_Small.BackColor = System.Drawing.Color.Black;
            this.imageBox_Small.Location = new System.Drawing.Point(498, 416);
            this.imageBox_Small.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox_Small.Name = "imageBox_Small";
            this.imageBox_Small.Size = new System.Drawing.Size(265, 181);
            this.imageBox_Small.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox_Small.TabIndex = 25;
            this.imageBox_Small.TabStop = false;
            // 
            // textBox_PhotoName
            // 
            this.textBox_PhotoName.Location = new System.Drawing.Point(890, 55);
            this.textBox_PhotoName.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PhotoName.Name = "textBox_PhotoName";
            this.textBox_PhotoName.ReadOnly = true;
            this.textBox_PhotoName.Size = new System.Drawing.Size(207, 25);
            this.textBox_PhotoName.TabIndex = 26;
            // 
            // label_PhotoName
            // 
            this.label_PhotoName.AutoSize = true;
            this.label_PhotoName.Location = new System.Drawing.Point(795, 60);
            this.label_PhotoName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PhotoName.Name = "label_PhotoName";
            this.label_PhotoName.Size = new System.Drawing.Size(82, 15);
            this.label_PhotoName.TabIndex = 27;
            this.label_PhotoName.Text = "图片名称：";
            // 
            // button_Quary
            // 
            this.button_Quary.Location = new System.Drawing.Point(637, 345);
            this.button_Quary.Margin = new System.Windows.Forms.Padding(4);
            this.button_Quary.Name = "button_Quary";
            this.button_Quary.Size = new System.Drawing.Size(126, 58);
            this.button_Quary.TabIndex = 28;
            this.button_Quary.Text = "查询数据";
            this.button_Quary.UseVisualStyleBackColor = true;
            this.button_Quary.Click += new System.EventHandler(this.button_Quary_Click);
            // 
            // button_UpdateMap
            // 
            this.button_UpdateMap.Location = new System.Drawing.Point(498, 344);
            this.button_UpdateMap.Margin = new System.Windows.Forms.Padding(4);
            this.button_UpdateMap.Name = "button_UpdateMap";
            this.button_UpdateMap.Size = new System.Drawing.Size(126, 58);
            this.button_UpdateMap.TabIndex = 37;
            this.button_UpdateMap.Text = "刷新地图";
            this.button_UpdateMap.UseVisualStyleBackColor = true;
            this.button_UpdateMap.Click += new System.EventHandler(this.button_UpdateMap_Click);
            // 
            // buttonAddNewRoad
            // 
            this.buttonAddNewRoad.Location = new System.Drawing.Point(466, 12);
            this.buttonAddNewRoad.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddNewRoad.Name = "buttonAddNewRoad";
            this.buttonAddNewRoad.Size = new System.Drawing.Size(35, 29);
            this.buttonAddNewRoad.TabIndex = 38;
            this.buttonAddNewRoad.Text = "+";
            this.buttonAddNewRoad.UseVisualStyleBackColor = true;
            this.buttonAddNewRoad.Click += new System.EventHandler(this.buttonAddNewRoad_Click);
            // 
            // comboBox_RoadNames
            // 
            this.comboBox_RoadNames.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox_RoadNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoadNames.FormattingEnabled = true;
            this.comboBox_RoadNames.Location = new System.Drawing.Point(95, 14);
            this.comboBox_RoadNames.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_RoadNames.MaxLength = 40;
            this.comboBox_RoadNames.Name = "comboBox_RoadNames";
            this.comboBox_RoadNames.Size = new System.Drawing.Size(352, 23);
            this.comboBox_RoadNames.TabIndex = 39;
            // 
            // buttonModifyRoad
            // 
            this.buttonModifyRoad.Location = new System.Drawing.Point(508, 12);
            this.buttonModifyRoad.Margin = new System.Windows.Forms.Padding(4);
            this.buttonModifyRoad.Name = "buttonModifyRoad";
            this.buttonModifyRoad.Size = new System.Drawing.Size(35, 29);
            this.buttonModifyRoad.TabIndex = 40;
            this.buttonModifyRoad.Text = "M";
            this.buttonModifyRoad.UseVisualStyleBackColor = true;
            this.buttonModifyRoad.Click += new System.EventHandler(this.buttonModifyRoad_Click);
            // 
            // labelSystemStatus
            // 
            this.labelSystemStatus.AutoSize = true;
            this.labelSystemStatus.Location = new System.Drawing.Point(23, 110);
            this.labelSystemStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSystemStatus.Name = "labelSystemStatus";
            this.labelSystemStatus.Size = new System.Drawing.Size(151, 15);
            this.labelSystemStatus.TabIndex = 46;
            this.labelSystemStatus.Text = "                  ";
            // 
            // textBox_Latitude
            // 
            this.textBox_Latitude.Location = new System.Drawing.Point(1013, 14);
            this.textBox_Latitude.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Latitude.Name = "textBox_Latitude";
            this.textBox_Latitude.ReadOnly = true;
            this.textBox_Latitude.Size = new System.Drawing.Size(84, 25);
            this.textBox_Latitude.TabIndex = 50;
            // 
            // label_Latitude
            // 
            this.label_Latitude.AutoSize = true;
            this.label_Latitude.Location = new System.Drawing.Point(963, 19);
            this.label_Latitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Latitude.Name = "label_Latitude";
            this.label_Latitude.Size = new System.Drawing.Size(52, 15);
            this.label_Latitude.TabIndex = 49;
            this.label_Latitude.Text = "纬度：";
            // 
            // textBox_Longitude
            // 
            this.textBox_Longitude.Location = new System.Drawing.Point(845, 14);
            this.textBox_Longitude.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Longitude.Name = "textBox_Longitude";
            this.textBox_Longitude.ReadOnly = true;
            this.textBox_Longitude.Size = new System.Drawing.Size(99, 25);
            this.textBox_Longitude.TabIndex = 48;
            // 
            // label__Longitude
            // 
            this.label__Longitude.AutoSize = true;
            this.label__Longitude.Location = new System.Drawing.Point(795, 19);
            this.label__Longitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label__Longitude.Name = "label__Longitude";
            this.label__Longitude.Size = new System.Drawing.Size(52, 15);
            this.label__Longitude.TabIndex = 47;
            this.label__Longitude.Text = "经度：";
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(983, 257);
            this.label_X.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(22, 15);
            this.label_X.TabIndex = 62;
            this.label_X.Text = "×";
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(1015, 252);
            this.textBox_Height.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(83, 25);
            this.textBox_Height.TabIndex = 61;
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(890, 252);
            this.textBox_Width.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(83, 25);
            this.textBox_Width.TabIndex = 60;
            // 
            // label_plateSize
            // 
            this.label_plateSize.AutoSize = true;
            this.label_plateSize.Location = new System.Drawing.Point(795, 257);
            this.label_plateSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_plateSize.Name = "label_plateSize";
            this.label_plateSize.Size = new System.Drawing.Size(82, 15);
            this.label_plateSize.TabIndex = 59;
            this.label_plateSize.Text = "版面尺寸：";
            // 
            // comboBox_plateStyle
            // 
            this.comboBox_plateStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_plateStyle.FormattingEnabled = true;
            this.comboBox_plateStyle.Items.AddRange(new object[] {
            "矩形",
            "圆形",
            "三角形"});
            this.comboBox_plateStyle.Location = new System.Drawing.Point(890, 135);
            this.comboBox_plateStyle.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_plateStyle.Name = "comboBox_plateStyle";
            this.comboBox_plateStyle.Size = new System.Drawing.Size(207, 23);
            this.comboBox_plateStyle.TabIndex = 58;
            // 
            // label_plateStyle
            // 
            this.label_plateStyle.AutoSize = true;
            this.label_plateStyle.Location = new System.Drawing.Point(795, 139);
            this.label_plateStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_plateStyle.Name = "label_plateStyle";
            this.label_plateStyle.Size = new System.Drawing.Size(82, 15);
            this.label_plateStyle.TabIndex = 57;
            this.label_plateStyle.Text = "版面形式：";
            // 
            // comboBox_markType
            // 
            this.comboBox_markType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_markType.FormattingEnabled = true;
            this.comboBox_markType.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J"});
            this.comboBox_markType.Location = new System.Drawing.Point(890, 96);
            this.comboBox_markType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_markType.Name = "comboBox_markType";
            this.comboBox_markType.Size = new System.Drawing.Size(207, 23);
            this.comboBox_markType.TabIndex = 56;
            // 
            // label_markType
            // 
            this.label_markType.AutoSize = true;
            this.label_markType.Location = new System.Drawing.Point(795, 100);
            this.label_markType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_markType.Name = "label_markType";
            this.label_markType.Size = new System.Drawing.Size(82, 15);
            this.label_markType.TabIndex = 55;
            this.label_markType.Text = "标志类型：";
            // 
            // comboBox_layStyle
            // 
            this.comboBox_layStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_layStyle.FormattingEnabled = true;
            this.comboBox_layStyle.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBox_layStyle.Location = new System.Drawing.Point(890, 174);
            this.comboBox_layStyle.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_layStyle.Name = "comboBox_layStyle";
            this.comboBox_layStyle.Size = new System.Drawing.Size(207, 23);
            this.comboBox_layStyle.TabIndex = 54;
            // 
            // label_layStyle
            // 
            this.label_layStyle.AutoSize = true;
            this.label_layStyle.Location = new System.Drawing.Point(795, 178);
            this.label_layStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_layStyle.Name = "label_layStyle";
            this.label_layStyle.Size = new System.Drawing.Size(82, 15);
            this.label_layStyle.TabIndex = 53;
            this.label_layStyle.Text = "架设形式：";
            // 
            // comboBox_leftRight
            // 
            this.comboBox_leftRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_leftRight.FormattingEnabled = true;
            this.comboBox_leftRight.Items.AddRange(new object[] {
            "左",
            "右"});
            this.comboBox_leftRight.Location = new System.Drawing.Point(890, 213);
            this.comboBox_leftRight.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_leftRight.Name = "comboBox_leftRight";
            this.comboBox_leftRight.Size = new System.Drawing.Size(207, 23);
            this.comboBox_leftRight.TabIndex = 52;
            // 
            // label_leftRight
            // 
            this.label_leftRight.AutoSize = true;
            this.label_leftRight.Location = new System.Drawing.Point(795, 217);
            this.label_leftRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_leftRight.Name = "label_leftRight";
            this.label_leftRight.Size = new System.Drawing.Size(75, 15);
            this.label_leftRight.TabIndex = 51;
            this.label_leftRight.Text = "左/右侧：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 67;
            this.label1.Text = "准则：";
            // 
            // buttonAutoByCurrent
            // 
            this.buttonAutoByCurrent.Location = new System.Drawing.Point(175, 66);
            this.buttonAutoByCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAutoByCurrent.Name = "buttonAutoByCurrent";
            this.buttonAutoByCurrent.Size = new System.Drawing.Size(65, 26);
            this.buttonAutoByCurrent.TabIndex = 66;
            this.buttonAutoByCurrent.Text = "当前";
            this.buttonAutoByCurrent.UseVisualStyleBackColor = true;
            this.buttonAutoByCurrent.Click += new System.EventHandler(this.buttonAutoByCurrent_Click);
            // 
            // buttonAutoByStart
            // 
            this.buttonAutoByStart.Location = new System.Drawing.Point(93, 66);
            this.buttonAutoByStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAutoByStart.Name = "buttonAutoByStart";
            this.buttonAutoByStart.Size = new System.Drawing.Size(65, 26);
            this.buttonAutoByStart.TabIndex = 65;
            this.buttonAutoByStart.Text = "起点";
            this.buttonAutoByStart.UseVisualStyleBackColor = true;
            this.buttonAutoByStart.Click += new System.EventHandler(this.buttonAutoByStart_Click);
            // 
            // textBox_Number
            // 
            this.textBox_Number.Location = new System.Drawing.Point(93, 29);
            this.textBox_Number.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Number.MaxLength = 8;
            this.textBox_Number.Name = "textBox_Number";
            this.textBox_Number.ReadOnly = true;
            this.textBox_Number.Size = new System.Drawing.Size(64, 25);
            this.textBox_Number.TabIndex = 64;
            // 
            // label_Number
            // 
            this.label_Number.AutoSize = true;
            this.label_Number.Location = new System.Drawing.Point(23, 34);
            this.label_Number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Number.Name = "label_Number";
            this.label_Number.Size = new System.Drawing.Size(52, 15);
            this.label_Number.TabIndex = 63;
            this.label_Number.Text = "桩号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Minus);
            this.groupBox1.Controls.Add(this.radioButton_Plus);
            this.groupBox1.Controls.Add(this.textBox_CurrReference);
            this.groupBox1.Controls.Add(this.buttonAutoByStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonAutoByCurrent);
            this.groupBox1.Controls.Add(this.labelSystemStatus);
            this.groupBox1.Controls.Add(this.label_Number);
            this.groupBox1.Controls.Add(this.textBox_Number);
            this.groupBox1.Location = new System.Drawing.Point(796, 300);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(301, 144);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "关于桩号";
            // 
            // radioButton_Minus
            // 
            this.radioButton_Minus.AutoSize = true;
            this.radioButton_Minus.Location = new System.Drawing.Point(253, 69);
            this.radioButton_Minus.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Minus.Name = "radioButton_Minus";
            this.radioButton_Minus.Size = new System.Drawing.Size(36, 19);
            this.radioButton_Minus.TabIndex = 70;
            this.radioButton_Minus.TabStop = true;
            this.radioButton_Minus.Text = "-";
            this.radioButton_Minus.UseVisualStyleBackColor = true;
            this.radioButton_Minus.CheckedChanged += new System.EventHandler(this.radioButton_Plus_CheckedChanged);
            // 
            // radioButton_Plus
            // 
            this.radioButton_Plus.AutoSize = true;
            this.radioButton_Plus.Location = new System.Drawing.Point(253, 31);
            this.radioButton_Plus.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Plus.Name = "radioButton_Plus";
            this.radioButton_Plus.Size = new System.Drawing.Size(36, 19);
            this.radioButton_Plus.TabIndex = 69;
            this.radioButton_Plus.TabStop = true;
            this.radioButton_Plus.Text = "+";
            this.radioButton_Plus.UseVisualStyleBackColor = true;
            this.radioButton_Plus.CheckedChanged += new System.EventHandler(this.radioButton_Plus_CheckedChanged);
            // 
            // textBox_CurrReference
            // 
            this.textBox_CurrReference.Location = new System.Drawing.Point(175, 29);
            this.textBox_CurrReference.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_CurrReference.MaxLength = 8;
            this.textBox_CurrReference.Name = "textBox_CurrReference";
            this.textBox_CurrReference.Size = new System.Drawing.Size(64, 25);
            this.textBox_CurrReference.TabIndex = 68;
            this.textBox_CurrReference.TextChanged += new System.EventHandler(this.textBox_CurrReference_TextChanged);
            // 
            // comboBox_CommPort
            // 
            this.comboBox_CommPort.FormattingEnabled = true;
            this.comboBox_CommPort.ItemHeight = 15;
            this.comboBox_CommPort.Location = new System.Drawing.Point(498, 619);
            this.comboBox_CommPort.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_CommPort.Name = "comboBox_CommPort";
            this.comboBox_CommPort.Size = new System.Drawing.Size(102, 23);
            this.comboBox_CommPort.TabIndex = 69;
            this.comboBox_CommPort.SelectedIndexChanged += new System.EventHandler(this.comboBox_CommPort_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1114, 660);
            this.Controls.Add(this.comboBox_CommPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_X);
            this.Controls.Add(this.textBox_Height);
            this.Controls.Add(this.textBox_Width);
            this.Controls.Add(this.label_plateSize);
            this.Controls.Add(this.comboBox_plateStyle);
            this.Controls.Add(this.label_plateStyle);
            this.Controls.Add(this.comboBox_markType);
            this.Controls.Add(this.label_markType);
            this.Controls.Add(this.comboBox_layStyle);
            this.Controls.Add(this.label_layStyle);
            this.Controls.Add(this.comboBox_leftRight);
            this.Controls.Add(this.label_leftRight);
            this.Controls.Add(this.textBox_Latitude);
            this.Controls.Add(this.textBox_Longitude);
            this.Controls.Add(this.buttonModifyRoad);
            this.Controls.Add(this.comboBox_RoadNames);
            this.Controls.Add(this.buttonAddNewRoad);
            this.Controls.Add(this.button_UpdateMap);
            this.Controls.Add(this.button_Quary);
            this.Controls.Add(this.label_PhotoName);
            this.Controls.Add(this.textBox_PhotoName);
            this.Controls.Add(this.imageBox_Small);
            this.Controls.Add(this.button_StartPreview);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.textBox_checkTime);
            this.Controls.Add(this.webBrowser_BaiduMap);
            this.Controls.Add(this.label_roadName);
            this.Controls.Add(this.label_checkTime);
            this.Controls.Add(this.label_Latitude);
            this.Controls.Add(this.label__Longitude);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1132, 705);
            this.MinimumSize = new System.Drawing.Size(1132, 705);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公路交通标志普查助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_Small)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_roadName;
        private System.Windows.Forms.Label label_checkTime;
        private System.Windows.Forms.WebBrowser webBrowser_BaiduMap;
        private System.Windows.Forms.TextBox textBox_checkTime;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.Button button_StartPreview;
        private Emgu.CV.UI.ImageBox imageBox_Small;
        private System.Windows.Forms.TextBox textBox_PhotoName;
        private System.Windows.Forms.Label label_PhotoName;
        private System.Windows.Forms.Button button_Quary;
        private System.Windows.Forms.Button button_UpdateMap;
        private System.Windows.Forms.Button buttonAddNewRoad;
        private System.Windows.Forms.ComboBox comboBox_RoadNames;
        private System.Windows.Forms.Button buttonModifyRoad;
        private System.Windows.Forms.Label labelSystemStatus;
        private System.Windows.Forms.TextBox textBox_Latitude;
        private System.Windows.Forms.Label label_Latitude;
        private System.Windows.Forms.TextBox textBox_Longitude;
        private System.Windows.Forms.Label label__Longitude;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.Label label_plateSize;
        private System.Windows.Forms.ComboBox comboBox_plateStyle;
        private System.Windows.Forms.Label label_plateStyle;
        private System.Windows.Forms.ComboBox comboBox_markType;
        private System.Windows.Forms.Label label_markType;
        private System.Windows.Forms.ComboBox comboBox_layStyle;
        private System.Windows.Forms.Label label_layStyle;
        private System.Windows.Forms.ComboBox comboBox_leftRight;
        private System.Windows.Forms.Label label_leftRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAutoByCurrent;
        private System.Windows.Forms.Button buttonAutoByStart;
        private System.Windows.Forms.TextBox textBox_Number;
        private System.Windows.Forms.Label label_Number;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_CurrReference;
        private System.Windows.Forms.RadioButton radioButton_Plus;
        private System.Windows.Forms.RadioButton radioButton_Minus;
        private System.Windows.Forms.ComboBox comboBox_CommPort;
    }
}

