using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.IO;
using System.Collections;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace RoadInfoManager
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)] 

    public partial class FormManager : Form
    {
        private string m_strConn = null;
        private MySqlConnection m_Conn = null;
        private string m_strQuery = new StringBuilder().Append("SELECT ")
                              .Append("idnumber AS \'序号\', ")           .Append("roadName AS \'线路名称\', ")
                              .Append("checkTime AS \'检查时间\', ") .Append("pointNumber AS \'桩号\', ")
                              .Append("longitude AS \'经度\', ")            .Append("latitude AS \'纬度\', ")
                              .Append("leftRight AS \'左/右侧\', ")        .Append("markType AS \'标志类型\', ")
                              .Append("layStyle AS \'架设形式\', ")      .Append("plateStyle AS \'版面形式\', ")
                              .Append("width AS \'版面宽度\', ")          .Append("height  AS \'版面高度\', ")
                              .Append("photoName  AS \'照片名称\' ") .Append("FROM ").ToString();

        private string[] m_strTitleArray = { "序号", "线路名称", "检查时间", "桩号", "经度", "纬度", "左/右侧", 
                                                                 "标志类型", "架设形式", "版面形式", "版面宽度", "版面高度", "照片名称" };

        private AutoSizeForm m_asForm = null;
        private ImageShowForm m_isfForm = null;
        private ArrayList m_img2ShowList = new ArrayList();
        private ArrayList m_form2ShowImageList = new ArrayList();
        private bool m_IsLoadImageAutomatically = false;

        //////////////////////////////////////////////////////////////////////////**********20141204
        //构造函数
        public FormManager()
        {
            m_asForm = new AutoSizeForm();
            m_form2ShowImageList.Clear();                       //显示图像的窗体链表
            m_img2ShowList.Clear();                                  //待显示的图像链表
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////**********20151029
        private void FormManager_Load(object sender, EventArgs e)
        {
            LoadBaiduMap("\\Resources\\BaiduMap4Manager.html");
            m_asForm.controllInitializeSize(this);
            int resCode = InitialDatabase();
            switch (resCode)
            {
                case -1: MessageBox.Show("读取配置文件失败, 程序即将关闭!");
                              this.Close();   break;
                case -2: MessageBox.Show("数据库连接失败, 程序即将关闭!");
                              this.Close();   break;
                default:  break; 
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20151030
        //初始化数据库
        private int InitialDatabase()
        {
            string strConnName = null;
            try {
                strConnName = ParseConfigFile.GetAppConfig("db_which");
                m_strConn = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
                m_Conn = new MySqlConnection(m_strConn);
            } catch (System.Exception) {
                return -1;
            }
            try {
                QueryData2Combox(m_Conn);
            } catch (System.Exception) {
                return -2;
            }
            return 0;
        }

        //////////////////////////////////////////////////////////////////////////**********20151030
        //从表中查询数据并赋给Combox控件
        private void QueryData2Combox(MySqlConnection conn)
        {
            string strQuery = "SELECT roadName FROM roadinfotb";
            MySqlDataAdapter da = new MySqlDataAdapter(strQuery, conn);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "dataSet");
            this.comboBox_RoadNames.DisplayMember = "roadName";
            this.comboBox_RoadNames.ValueMember = "roadName";
            this.comboBox_RoadNames.DataSource = dataSet.Tables[0].DefaultView;
            conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //从表中查询数据并赋给dataGridView控件
        private void QueryDataFromTable(string strQuery, MySqlConnection conn)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(strQuery, conn);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "dataSet");
            this.dataGridView_editTable.DataSource = dataSet.Tables[0].DefaultView;
            conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //加载并显示地图
        private void LoadBaiduMap(string strJSfileName)
        {
            webBrowser_baiduMap.ObjectForScripting = this;
            string str_url = Application.StartupPath + strJSfileName;
            Uri url = new Uri(str_url);
            webBrowser_baiduMap.Url = url;
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //根据数据库中的数据更新地图上的标记点
        private void UpdateBaiduMap(string strRoadName)
        {
            webBrowser_baiduMap.Document.InvokeScript("CSharpCallJs_clearAllMarker", new Object[] { });
            string strQuery = "SELECT roadName, checkTime, pointNumber, longitude, latitude, leftRight, markType, layStyle, plateStyle, photoName FROM " + strRoadName;
            try {
                m_Conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, m_Conn);
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read()) 
                {
                    string strTitle = "道路" + sdr["leftRight"].ToString() + "侧, " + "桩号: " + sdr["pointNumber"].ToString();
                    string strContent = "线路名称: " + sdr["roadName"].ToString() + "<br>检查时间: " + sdr["checkTime"].ToString() + "<br>标志类型: " + sdr["markType"].ToString() + "<br>架设形式: " + sdr["layStyle"].ToString() + "<br>版面形式: " + sdr["plateStyle"].ToString();
                    string strLocation = Convert.ToDouble(sdr["longitude"].ToString()) / 1e6 + "|" + Convert.ToDouble(sdr["latitude"].ToString()) / 1e6;
                    string strImageName = sdr["photoName"].ToString();
                    webBrowser_baiduMap.Document.InvokeScript("CSharpCallJs_addMarker", new Object[] { strTitle, strContent, strLocation, strImageName });
                }
                m_Conn.Close();
            } catch (System.Exception) {
                MessageBox.Show("数据库无法连接, 地图更新失败!");
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20151030
        //更换线路对应的表格和地图更新操作
        private void comboBox_RoadNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strRoadName = this.comboBox_RoadNames.Text.Trim();
            if (strRoadName.Equals(""))     //关闭窗口时会发生
                return;
            if (strRoadName.Equals("$请选择线路")) {
                this.dataGridView_editTable.DataSource = null;
                return;
            }
            try {
                QueryDataFromTable(m_strQuery + strRoadName, m_Conn);
                UpdateBaiduMap(strRoadName);
            } catch (System.Exception) {
                MessageBox.Show("数据库查询失败!");
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //窗体尺寸改变时调用窗口自适应类的方法进行处理
        private void FormManager_SizeChanged(object sender, EventArgs e)
        {
            m_asForm.controlAutoSize(this);
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //JS调用WinForm的测试代码
        public void JsCallCSharpTest()
        {
            MessageBox.Show("JsCallCSharpTest OK!"); 
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //JS调用WinForm显示标志牌图像
        public void JsCallCSharp_ShowImage(string strImageName)
        {
            if (!m_IsLoadImageAutomatically)
                return;

            JsCallCSharp_CloseImage();

            string strPrefix = strImageName.Split(new char[] { '_' })[0];
            foreach (string item in Directory.GetFiles("Photos", "*.jpg")) {
                if (item.Replace("Photos\\", "").StartsWith(strPrefix))
                    m_img2ShowList.Add(item);
            }

            foreach(string strpath in m_img2ShowList)
            {
                if (File.Exists(strpath)) {
                    ImageShowForm isf = new ImageShowForm(strpath);
                    m_form2ShowImageList.Add(isf);
                } else {
                    MessageBox.Show("  照片不存在!  \n\n  请确认Photos文件夹位于应用程序目录下!  ");
                }
            }

            foreach (ImageShowForm isf in m_form2ShowImageList)
                isf.Show();
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //JS调用WinForm关闭标志牌图像
        public void JsCallCSharp_CloseImage()
        {
            for (int i = 0; i < m_form2ShowImageList.Count; i++)
            {
                if (m_form2ShowImageList[i] != null)
                {
                    ((ImageShowForm)m_form2ShowImageList[i]).Close();
                    m_form2ShowImageList[i] = null;
                }
            }
            m_form2ShowImageList.Clear();
            m_img2ShowList.Clear();
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //从表格中删除一条记录
        private void dataGridView_editTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("确定要删除这一条记录吗?   ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            string strRoadName = this.comboBox_RoadNames.Text.Trim();
            string strDelete = String.Format("DELETE FROM {0} WHERE number = {1}", strRoadName, dataGridView_editTable.SelectedRows[0].Cells[0].Value);
            try {
                DeleteDataFromTable(strDelete);
            } catch (System.Exception) {
                MessageBox.Show("数据库连接失败!");
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //从数据库中删除一条记录
        private void DeleteDataFromTable(string strDelete)
        {
            m_Conn.Open();
            MySqlCommand cmd = new MySqlCommand(strDelete, m_Conn);
            cmd.ExecuteNonQuery();
            m_Conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //读取复选框状态, 看是否要自动加载标志牌图片
        private void checkBox_AutoLoadImage_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkBox_AutoLoadImage.CheckState == CheckState.Checked) {
                m_IsLoadImageAutomatically = true;
            } else{
                m_IsLoadImageAutomatically = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141204
        //双击表格时弹出图像
        private void dataGridView_editTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strImageName = dataGridView_editTable.SelectedRows[0].Cells[12].Value.ToString();     //得到照片名称
            if (m_isfForm != null) {
                m_isfForm.Close();
                m_isfForm = null;
            }
            if (File.Exists("Photos\\" + strImageName)) {
                m_isfForm = new ImageShowForm("Photos\\" + strImageName);
                m_isfForm.ControlBox = true;
                m_isfForm.TopMost = false;
                m_isfForm.Show();
            } else {
                    MessageBox.Show("  照片不存在!  \n\n  请确认Photos文件夹位于应用程序目录下!  ");
            }
        }

    }
}
