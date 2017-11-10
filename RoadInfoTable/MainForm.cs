using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO.Ports;


namespace RoadInfoTable
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)] 

    public partial class MainForm : Form
    {      
        private int m_plusMinusSymbel = 1;

        public MainForm()
        {
            InitializeComponent();
            this.comboBox_markType.SelectedIndex = 0;
            this.comboBox_plateStyle.SelectedIndex = 0;
            this.comboBox_layStyle.SelectedIndex = 0;
            this.comboBox_leftRight.SelectedIndex = 1;
            this.textBox_checkTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            this.textBox_PhotoName.Text = "";
            this.textBox_Width.Text = "60";
            this.textBox_Height.Text = "60";
            this.radioButton_Plus.Checked = true;
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //程序初始化: 加载地图, 打开服务器, 初始化摄像头, 连接数据库
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadBaiduMap("\\res\\map4Investigating.html");
            int resCode = InitialDatabase();
            switch (resCode)
            {
                case -1: MessageBox.Show("读取数据库配置文件失败, 程序即将关闭!");
                    this.Close(); break;
                case -2: MessageBox.Show("数据库连接失败, 程序即将关闭!");
                    this.Close(); break;
                default: break;
            }
            resCode = InitialCamera();
            switch (resCode)
            {
                case -1: MessageBox.Show("读取摄像头配置文件失败, 程序即将关闭!");
                    this.Close(); break;
                case -2: MessageBox.Show("摄像头打开失败, 程序即将关闭!");
                    this.Close(); break;
                default: break;
            }
            //debugModel();
            string[] strPorts = SerialPort.GetPortNames();
            foreach (string str in strPorts)
                this.comboBox_CommPort.Items.Add(str);
        }

        private void debugModel()
        {
            this.textBox_Longitude.Text = "118871910";
            this.textBox_Latitude.Text = "32024681";
            this.textBox_PhotoName.Text = "11887191032024681_photoName.jpg";
            this.textBox_Number.Text = "K10.333";
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //点击"查询"按钮
        private void button_Quary_Click(object sender, EventArgs e)
        {
            string strRoadName = this.comboBox_RoadNames.Text;
            if (strRoadName.Equals("$请选择线路"))
            {
                MessageBox.Show(" 请先选择一条线路! ");
                return;
            }
            QueryForm qForm = new QueryForm(this.m_Conn, strRoadName);
            qForm.ShowDialog();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //添加新线路
        private void buttonAddNewRoad_Click(object sender, EventArgs e)
        {
            AddRoadForm arForm = new AddRoadForm(m_Conn, comboBox_RoadNames, GlobalVariable.ADD_NEW_ROAD, textBox_Longitude.Text, textBox_Latitude.Text);
            arForm.Show();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //修改线路的路名和桩号
        private void buttonModifyRoad_Click(object sender, EventArgs e)
        {
            AddRoadForm arForm = new AddRoadForm(m_Conn, comboBox_RoadNames, GlobalVariable.MODIFY_ROAD_INFO, textBox_Longitude.Text, textBox_Latitude.Text);
            arForm.Show();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //根据起点桩号自动计算当前点桩号
        private void buttonAutoByStart_Click(object sender, EventArgs e)
        {
            if (this.textBox_Longitude.Text.Equals(""))
            {
                MessageBox.Show("请检查GPS设备!");
                return;
            }
            string strRoadName = this.comboBox_RoadNames.Text;
            if (strRoadName.Equals("$请选择线路"))
            {
                MessageBox.Show(" 请先选择一条线路! ");
                return;
            }
            if (MessageBox.Show("确定根据起点自动计算桩号?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                m_Conn.Open();
                string strQuery = String.Format("SELECT SP_longitude, SP_latitude, SP_pointNumber FROM  roadinfotb WHERE roadName = \'{0}\'", strRoadName);
                MySqlCommand cmd = new MySqlCommand(strQuery, m_Conn);
                MySqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.m_strReferenceLongitude = sdr["SP_longitude"].ToString();
                    this.m_strReferenceLatitude = sdr["SP_latitude"].ToString();
                    this.m_strReferencePointNumber = sdr["SP_pointNumber"].ToString();
                }
                m_Conn.Close();
                this.labelSystemStatus.Text = "根据起点桩号 " + this.m_strReferencePointNumber + " 自动计算桩号";
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //根据参考点桩号自动计算当前点桩号
        private void buttonAutoByCurrent_Click(object sender, EventArgs e)
        {
            if (this.textBox_Longitude.Text.Equals(""))
            {
                MessageBox.Show("请检查GPS设备!");
                return;
            }
            string strRoadName = this.comboBox_RoadNames.Text;
            if (strRoadName.Equals("$请选择线路"))
            {
                MessageBox.Show(" 请先选择一条线路! ");
                return;
            }
            if (this.textBox_CurrReference.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("参考桩号不能为空!");
                return;
            }
            if (MessageBox.Show("确定根据当前桩号自动计算桩号?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.m_strReferenceLongitude = this.textBox_Longitude.Text;
                this.m_strReferenceLatitude = this.textBox_Latitude.Text;
                this.m_strReferencePointNumber = this.textBox_CurrReference.Text;
                this.labelSystemStatus.Text = "根据校核桩号 " + m_strReferencePointNumber + " 自动计算桩号";
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20150325
        //粗略检查桩号是否合法
        private void textBox_CurrReference_TextChanged(object sender, EventArgs e)
        {
            string strPointNumber = this.textBox_CurrReference.Text.Trim();
            if (strPointNumber.Length >= 1 && strPointNumber[0] != 'K')
            {
                MessageBox.Show("第一位必须为大写字母K, 示范：K200.500");
                this.textBox_CurrReference.Text = "";
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20151103
        //选择上行还是下行路线
        private void radioButton_Plus_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radiobtn = (RadioButton)sender;
            if (radiobtn.Checked) 
            {
                if (radiobtn.Text.Trim().Equals("+"))
                    m_plusMinusSymbel = 1;
                else if (radiobtn.Text.Trim().Equals("-"))
                    m_plusMinusSymbel = -1;
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20151103
        //选择串口
        private void comboBox_CommPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strPorts = SerialPort.GetPortNames();
            this.comboBox_CommPort.Items.Clear();
            foreach (string str in strPorts)
                this.comboBox_CommPort.Items.Add(str);
            try
            {
                m_CommGps = new ReceiveGpsData(this.comboBox_CommPort.Text, this);
                if (m_CommGps.m_bSuccessful)
                    m_CommGps.OpenComm();
                this.comboBox_CommPort.Enabled = false;
            }
            catch (System.Exception)
            {
                MessageBox.Show("端口错误, GPS模块初始化失败!");
                if (m_CommGps.m_bSuccessful)
                {
                    m_CommGps.CloseComm();
                    m_CommGps = null;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20151103
        //快捷键P
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                string strRoadName = this.comboBox_RoadNames.Text;
                if (strRoadName.Equals("$请选择线路"))
                {
                    MessageBox.Show(" 请先选择一条线路! ");
                    return;
                }
                string strLongitude = this.textBox_Longitude.Text;
                if (strLongitude.Equals(""))
                {
                    MessageBox.Show(" 未能获取经度信息, 请检查GPS设备! ");
                    return;
                }
                if (m_Is2Preview)
                {
                    MessageBox.Show(" 请先打开摄像头! ");
                    return;
                }
                try {
                    m_IsPhotoTaken = true;
                    Thread.Sleep(50);
                    Add2Database();
                } catch (System.Exception) {
                    m_IsPhotoTaken = false;
                }
            }
        }

    }
}
