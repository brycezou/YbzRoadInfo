using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace RoadInfoTable
{
    public partial class AddRoadForm : Form
    {
        private MySqlConnection m_Conn = null;
        private ComboBox m_ComRoadNames = null;
        private int m_How2Use = 0;      //程序的使用方式, 添加线路或修改线路信息
        private string m_strLongitude = "";
        private string m_strLatitude = "";

        public AddRoadForm()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //含参构造函数, 根据需求初始化应用程序
        public AddRoadForm(MySqlConnection conn, ComboBox combox, int how2use, string longitude, string latitude)
        {
            InitializeComponent();
            m_Conn = conn;
            m_ComRoadNames = combox;
            m_How2Use = how2use;
            m_strLongitude = longitude;     //当前点的地理坐标
            m_strLatitude = latitude;
            this.textBox_SPlongitude.Text = m_strLongitude;
            this.textBox_SPlatitude.Text = m_strLatitude;

            switch (m_How2Use)
            {
                case GlobalVariable.ADD_NEW_ROAD:           //如果是添加新线路
                    this.buttonOK.Text = "添加";
                    this.Text = "添加新线路";
                    this.textBox_StartPointNumber.Text = "K0.000";
                    this.textBox_EndPointNumber.Text = "K0.000";
                    break;
                case GlobalVariable.MODIFY_ROAD_INFO:    //如果是修改线路信息
                    this.textBox_roadName.Enabled = false;
                    this.textBox_roadName.Text = this.m_ComRoadNames.Text;
                    this.buttonOK.Text = "修改";
                    this.Text = "修改线路信息";
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //根据成员变量的值初始化不同用途的界面
        private void AddRoadForm_Load(object sender, EventArgs e)
        {
            switch (m_How2Use)
            {
                case GlobalVariable.ADD_NEW_ROAD:
                    break;
                case GlobalVariable.MODIFY_ROAD_INFO:
                    if (this.m_ComRoadNames.Text.Trim().Equals("$请选择线路"))
                    {
                        MessageBox.Show("请先选择一条线路!");
                        this.Close();
                    }
                    else
                    {
                        try
                        {
                            GetDataFromTable(this.m_ComRoadNames.Text);
                        }
                        catch (System.Exception)
                        {
                            MessageBox.Show("数据库查询失败!");
                            this.Close();
                        }
                    }
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //查询指定线路的起终点路名、桩号信息
        private void GetDataFromTable(string strRoadName)
        {
            m_Conn.Open();
            string strQuery = String.Format("SELECT * FROM  roadinfotb WHERE roadName = \'{0}\'", strRoadName);
            MySqlCommand cmd = new MySqlCommand(strQuery, m_Conn);
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                this.textBox_StartPointRoadName.Text = sdr["SP_roadName"].ToString();
                this.textBox_StartPointNumber.Text = sdr["SP_pointNumber"].ToString();
                this.textBox_EndPointRoadName.Text = sdr["EP_roadName"].ToString();
                this.textBox_EndPointNumber.Text = sdr["EP_pointNumber"].ToString();
                if (this.textBox_SPlongitude.Text.Equals("") || this.textBox_SPlatitude.Text.Equals(""))
                {
                    this.textBox_SPlongitude.Text = sdr["SP_longitude"].ToString();
                    this.textBox_SPlatitude.Text = sdr["SP_latitude"].ToString();
                }
                m_Conn.Close();
            }
            else
            {
                MessageBox.Show("系统错误: 该线路不存在, 数据同步失败!");
                m_Conn.Close();
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //确认添加或修改的按钮事件
        private void buttonOK_Click(object sender, EventArgs e)
        {
            switch (m_How2Use)
            {
            case GlobalVariable.ADD_NEW_ROAD:
                    OnAddNewRoad();
            	break;
            case GlobalVariable.MODIFY_ROAD_INFO:
                    OnModifyRoadInfo();
                break;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //添加一条新线路: 添加线路信息到表, 创建新线路表
        private void OnAddNewRoad()
        {
            string strRoadName = this.textBox_roadName.Text.Trim();
            if (strRoadName.Equals(""))
            {
                MessageBox.Show(" 请输入线路名称! ");
                return;
            }
            else
            {
                bool isExist = false;
                try
                {
                    isExist = IsRoadExistInTable(strRoadName);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("数据库连接失败!");
                    return;
                }
                if (isExist)
                {
                    MessageBox.Show(" 该线路已存在! ");
                    return;
                }

                if (MessageBox.Show(" 线路名称不可更改, 请确保正确! \n 继续添加吗?   ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string strSP_RoadName = this.textBox_StartPointRoadName.Text.Trim();
                    string strSP_PointNumber = this.textBox_StartPointNumber.Text.Trim();
                    string strEP_RoadName = this.textBox_EndPointRoadName.Text.Trim();
                    string strEP_PointNumber = this.textBox_EndPointNumber.Text.Trim();

                    string str = "INSERT INTO roadinfotb ( roadName, SP_roadName, SP_pointNumber, SP_longitude, SP_latitude, EP_roadName, EP_pointNumber ) VALUES ";
                    string strSqlInsert = String.Format("{0}(\'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\')",
                                                                        str, strRoadName, strSP_RoadName, strSP_PointNumber, m_strLongitude, m_strLatitude, strEP_RoadName, strEP_PointNumber);
                    string strQuery = "SELECT roadName FROM roadinfotb";
                    try
                    {
                        DatabaseUtil.DoCmd(strSqlInsert, m_Conn);
                        DatabaseUtil.DoCmd(String.Format("CALL AddOneRoad(\'{0}\')", strRoadName), m_Conn);
                        DatabaseUtil.QueryData2ComboBox(strQuery, m_Conn, "roadName", this.m_ComRoadNames);
                        this.m_ComRoadNames.SelectedIndex = this.m_ComRoadNames.FindStringExact(strRoadName);
                        this.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("数据库连接失败!");
                        return;
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //查看表中是否已存在指定线路名称
        private bool IsRoadExistInTable(string strToFindRoad)
        {
            m_Conn.Open();
            string strQuery = String.Format("SELECT roadName FROM roadinfotb");
            MySqlCommand cmd = new MySqlCommand(strQuery, m_Conn);
            MySqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["roadName"].ToString().Equals(strToFindRoad))
                {
                    m_Conn.Close();
                    return true;
                }
            }
            m_Conn.Close();
            return false;
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //修改已有线路信息
        private void OnModifyRoadInfo()
        {
            string strRoadName = this.textBox_roadName.Text.Trim();
            if (IsRoadExistInTable(strRoadName))
            {
                if (MessageBox.Show(" 确定要修改吗?   ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string strSP_RoadName = this.textBox_StartPointRoadName.Text.Trim();
                    string strSP_PointNumber = this.textBox_StartPointNumber.Text.Trim();
                    string strEP_RoadName = this.textBox_EndPointRoadName.Text.Trim();
                    string strEP_PointNumber = this.textBox_EndPointNumber.Text.Trim();
                    string strSP_longitude = this.textBox_SPlongitude.Text.Trim();
                    string strSP_latitude = this.textBox_SPlatitude.Text.Trim();
                    try
                    {
                        string strUpdate = String.Format("UPDATE roadinfotb SET  SP_roadName = \'{0}\', SP_pointNumber = \'{1}\', SP_longitude = \'{2}\', SP_latitude = \'{3}\', EP_roadName = \'{4}\', EP_pointNumber = \'{5}\' WHERE roadName = \'{6}\'",
                                                               strSP_RoadName, strSP_PointNumber, strSP_longitude, strSP_latitude, strEP_RoadName, strEP_PointNumber, strRoadName);
                        DatabaseUtil.DoCmd(strUpdate, m_Conn);
                        this.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("数据库连接失败!");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show(" 系统错误: 该线路不存在! ");
                this.Enabled = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //关闭窗口
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
