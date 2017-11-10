using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace RoadInfoTable
{
    partial class MainForm
    {
        private string m_strConn = null;
        private MySqlConnection m_Conn = null;

        //////////////////////////////////////////////////////////////////////////**********20151102
        //初始化数据库
        private int InitialDatabase()
        {
            string strConnName = null;
            try
            {
                strConnName = ParseConfigFile.GetAppConfig("db_which");
                m_strConn = ConfigurationManager.ConnectionStrings[strConnName].ConnectionString;
                m_Conn = new MySqlConnection(m_strConn);
            }
            catch (System.Exception)
            {
                return -1;
            }
            try
            {
                string strQuery = "SELECT roadName FROM roadinfotb";
                DatabaseUtil.QueryData2ComboBox(strQuery, m_Conn, "roadName", this.comboBox_RoadNames);
            }
            catch (System.Exception)
            {
                return -2;
            }
            return 0;
        }

        //////////////////////////////////////////////////////////////////////////**********20151103
        //向数据库添加一条记录
        private void Add2Database()
        {
            string strLongitude = this.textBox_Longitude.Text;                  //经度
            if (strLongitude.Equals(""))
            {
                MessageBox.Show(" 未能获取经度信息, 请检查GPS设备! ");
                return;
            }
            string strLatitude = this.textBox_Latitude.Text;                        //纬度
            if (strLatitude.Equals(""))
            {
                MessageBox.Show(" 未能获取纬度信息, 请检查GPS设备! ");
                return;
            }
            if (this.textBox_PhotoName.Text.Equals(""))                         //照片名
            {
                MessageBox.Show("  未能获取有效照片名, 不能保存!  \n  请检查GPS设备!");
                return;
            }
            string strRoadName = this.comboBox_RoadNames.Text;      //线路名
            if (strRoadName.Equals("$请选择线路"))
            {
                MessageBox.Show(" 请先选择一条线路! ");
                return;
            }
            string strCheckTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            this.textBox_checkTime.Text = strCheckTime;                       //检查时间
            string strPointNumber = this.textBox_Number.Text;               //桩号
            if (strPointNumber.Equals(""))
            {
                MessageBox.Show(" 请输入桩号! ");
                return;
            }
            string strMarkType = this.comboBox_markType.SelectedItem.ToString();
            string strPlateStyle = this.comboBox_plateStyle.SelectedItem.ToString();
            string strLeftRight = this.comboBox_leftRight.SelectedItem.ToString();
            string strlayStyle = this.comboBox_layStyle.SelectedItem.ToString();
            string strWidth = this.textBox_Width.Text;
            string strHeight = this.textBox_Height.Text;
            string strPhotoName = m_strSavedPhotoName;

            string str = "INSERT INTO " + strRoadName + " (roadName,checkTime,pointNumber,longitude,latitude,leftRight,markType,layStyle,plateStyle,width,height,photoName) VALUES ";
            string strInsert = String.Format("{0}(\'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\', \'{8}\', \'{9}\', \'{10}\', \'{11}\', \'{12}\')", 
                                                                str, strRoadName, strCheckTime, strPointNumber, strLongitude, strLatitude,  
                                                                strLeftRight, strMarkType, strlayStyle, strPlateStyle, strWidth, strHeight, strPhotoName);
            try {
                DatabaseUtil.DoCmd(strInsert, m_Conn);
            } catch (System.Exception) {
                MessageBox.Show("添加数据失败!");
                return;
            }
            //webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJS_test", new Object[] { "Goodbye", 2013 });     //测试C#与JS脚本通信
            string strTitle      = (new StringBuilder()).Append("道路").Append(strLeftRight).
                                                                              Append("侧, 桩号: ").Append(strPointNumber).ToString();
            string strContent = (new StringBuilder()).Append("线路名称: ").Append(strRoadName).
                                                                              Append("<br>检查时间: ").Append(strCheckTime).
                                                                              Append("<br>标志类型: ").Append(strMarkType).
                                                                              Append("<br>架设形式: ").Append(strlayStyle).
                                                                              Append("<br>版面形式: ").Append(strPlateStyle).ToString();
            string strLocation = Convert.ToDouble(strLongitude) / 1e6 + "|" + Convert.ToDouble(strLatitude) / 1e6;
            //调用JavaScript脚本, 向百度地图添加一个标志牌的标注
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_addMarker", new Object[] { strTitle, strContent, strLocation });
        }

    }
}
