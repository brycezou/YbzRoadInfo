using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace RoadInfoTable
{
    partial class MainForm
    {
        private const double EARTH_RADIUS = 6378.137;      //地球半径
        private ReceiveGpsData m_CommGps = null;

        //在百度地图上更新当前位置标记的委托
        private delegate void DelegateRefreshPresentLocation(double longitude, double latitude);
        private string m_strReferenceLongitude = "";
        private string m_strReferenceLatitude = "";
        private string m_strReferencePointNumber = "";

        //////////////////////////////////////////////////////////////////////////**********20141014
        //将接收到的Json格式的地理坐标数据解析后显示到文本框中
        //将地理坐标值传递给JavaScript脚本
        public void ParseJsonData(string strRecvdLocationData)
        {
            if (strRecvdLocationData.Equals(""))
                return;

            JObject jObj = null;
            try
            {
                jObj = JObject.Parse(strRecvdLocationData);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Json解析错误!");
                return;
            }
            string strLongitude = jObj["Longitude"].ToString().Replace("\"", "");
            string strLatitude = jObj["Latitude"].ToString().Replace("\"", "");
            this.textBox_Longitude.Text = strLongitude;
            this.textBox_Latitude.Text = strLatitude;
            AutoCalcuPointNumber();
            //生成图像文件名称
            this.textBox_PhotoName.Text = strLongitude + strLatitude + "_"
                                                            + DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace(":", "") + ".jpg";
            this.textBox_checkTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

            //在百度地图上更新当前位置标记的委托
            DelegateRefreshPresentLocation drpl = new DelegateRefreshPresentLocation(UpdatePresentLocation);
            this.Invoke(drpl, new object[] { Convert.ToDouble(strLongitude) / 1e6, Convert.ToDouble(strLatitude) / 1e6 });
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //根据参考点地理坐标计算当前地理坐标的桩号
        private void AutoCalcuPointNumber()
        {
            string strCur_longitude = this.textBox_Longitude.Text;
            string strCur_latitude = this.textBox_Latitude.Text;
            if (m_strReferenceLatitude.Equals("") || strCur_latitude.Equals("") || strCur_longitude.Equals("") || m_strReferenceLongitude.Equals("") || m_strReferencePointNumber.Equals(""))
            {
                return;
            }
            double distance = LongitudeLatitude2Kilometer(Convert.ToDouble(strCur_latitude) / 1e6, Convert.ToDouble(strCur_longitude) / 1e6,
                                                                                    Convert.ToDouble(m_strReferenceLatitude) / 1e6, Convert.ToDouble(m_strReferenceLongitude) / 1e6);
            double dbCur_Number = Convert.ToDouble(m_strReferencePointNumber.Replace('K', ' ').Trim()) + distance * m_plusMinusSymbel;
            this.textBox_Number.Text = "K" + dbCur_Number.ToString("#0.000");   //保留三位小数, 四舍五入
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //计算两个地理坐标点之间的距离, 单位为千米
        private double LongitudeLatitude2Kilometer(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = lat1 * Math.PI / 180.0;
            double radLat2 = lat2 * Math.PI / 180.0;
            double a = radLat1 - radLat2;
            double b = lng1 * Math.PI / 180.0 - lng2 * Math.PI / 180.0;

            double distance = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            distance = distance * EARTH_RADIUS;
            distance = Math.Round(distance * 10000) / 10000;
            return distance;
        }

    }
}
