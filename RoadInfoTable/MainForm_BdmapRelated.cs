using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace RoadInfoTable
{
    partial class MainForm
    {
        //////////////////////////////////////////////////////////////////////////**********20141014
        //加载并显示地图
        private void LoadBaiduMap(string strJSfileName)
        {
            webBrowser_BaiduMap.ObjectForScripting = this;
            string str_url = Application.StartupPath + strJSfileName;
            Uri url = new Uri(str_url);
            webBrowser_BaiduMap.Url = url;
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //将当前地理坐标传给JS脚本, 控制地图定位到当前地理坐标
        private void UpdatePresentLocation(double longitude, double latitude)
        {
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_addPresentCircle", new Object[] { longitude, latitude });
        }

        //////////////////////////////////////////////////////////////////////////**********20151103
        //点击"刷新地图"按钮, 查询特定线路的标志牌数据, 显示到地图上
        private void button_UpdateMap_Click(object sender, EventArgs e)
        {
            string strRoadName = this.comboBox_RoadNames.Text;
            if (strRoadName.Equals("$请选择线路"))
            {
                MessageBox.Show(" 请先选择一条线路! ");
                return;
            }
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_clearAllMarker", new Object[] { });
            string strQuery = "SELECT roadName, checkTime, pointNumber, longitude, latitude, leftRight, markType, layStyle, plateStyle FROM " + strRoadName;
            try
            {
                m_Conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, m_Conn);
                MySqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    string strTitle     =  (new StringBuilder()).Append("道路").Append(sdr["leftRight"].ToString()).
                                                                                      Append("侧, 桩号: ").Append(sdr["pointNumber"].ToString()).ToString();
                    string strContent = (new StringBuilder()).Append("线路名称: ").Append(sdr["roadName"].ToString()).
                                                                                      Append("<br>检查时间: ").Append(sdr["checkTime"].ToString()).
                                                                                      Append("<br>标志类型: ").Append(sdr["markType"].ToString()).
                                                                                      Append("<br>架设形式: ").Append(sdr["layStyle"].ToString()).
                                                                                      Append("<br>版面形式: ").Append(sdr["plateStyle"].ToString()).ToString();
                    string strLocation = Convert.ToDouble(sdr["longitude"].ToString()) / 1e6 + "|" + Convert.ToDouble(sdr["latitude"].ToString()) / 1e6;
                    webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_addMarker", new Object[] { strTitle, strContent, strLocation });
                }
                m_Conn.Close();
            }
            catch (System.Exception)
            {
                MessageBox.Show("更新地图失败!");
            }
        }

    }
}
