using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;


namespace RoadInfoTable
{
    public class ReceiveGpsData
    {
        private SerialPort m_SerialPort = null;
        private StringBuilder m_strTemp = null;

        public bool m_bSuccessful = false;
        private bool m_bStart = false;

        private const int LOCATION_STATE = 6;
        private const int LOCAT_LATITUDE = 2;
        private const int LOC_LONGITUDE = 4;

        private const int GPS_REFRESH_FREQUENCY = 3;
        private int m_CurrCounter = 0;

        private MainForm m_MForm;

        public ReceiveGpsData(string strComPort, MainForm mf)
        {
            try
            {
                m_SerialPort = new SerialPort(strComPort, 9600, Parity.None, 8, StopBits.One);
                m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                m_MForm = mf;
                m_bSuccessful = true;
            }
            catch (System.Exception)
            {
                if (m_SerialPort.IsOpen)
                {
                    m_SerialPort.Close();
                    m_SerialPort = null;
                }
                m_bSuccessful = false;
            }
        }

        public void OpenComm()
        {
            if (m_bSuccessful)
            {
                m_strTemp = new StringBuilder();
                m_SerialPort.Open();
            }
        }

        public void CloseComm()
        {
            if (m_bSuccessful)
            {
                m_SerialPort.Close();
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strRecvd = m_SerialPort.ReadLine();
            for (int i = 0; i < strRecvd.Length; i++)
            {
                if (!m_bStart && strRecvd[i] == '$')
                {
                    m_strTemp.Clear();
                    m_bStart = true;
                    m_strTemp.Append(strRecvd[i]);
                }
                else if (m_bStart && strRecvd[i] != '$')
                {
                    m_strTemp.Append(strRecvd[i]);
                }
                else if (m_bStart && strRecvd[i] == '$')
                {
                    string strResult = m_strTemp.ToString();
                    if (strResult.IndexOf("$GPGGA") == 0)
                    {
                        ParseLocationData(strResult);
                    }
                    m_strTemp.Clear();
                    m_strTemp.Append(strRecvd[i]);
                }
            }
        }

        private void ParseLocationData(string str)
        {
            if (m_CurrCounter < GPS_REFRESH_FREQUENCY)
            {
                m_CurrCounter++;
                return;
            }
            m_CurrCounter = 0;

            string[] strArray = str.Split(new char[] {','});
            if (strArray[LOCATION_STATE].Equals("1") || strArray[LOCATION_STATE].Equals("2"))
            {
                string[] stemp = strArray[LOCAT_LATITUDE].Split(new char[] {'.'});
                stemp[0].Substring(stemp[0].Length - 2);
                string dd = stemp[0].Substring(0, stemp[0].Length - 2);
                string mm = stemp[0].Substring(stemp[0].Length - 2) + "." + stemp[1];
                double latitude = Convert.ToDouble(dd) + Convert.ToDouble(mm) / 60;

                stemp = strArray[LOC_LONGITUDE].Split(new char[] { '.' });
                stemp[0].Substring(stemp[0].Length - 2);
                dd = stemp[0].Substring(0, stemp[0].Length - 2);
                mm = stemp[0].Substring(stemp[0].Length - 2) + "." + stemp[1];
                double longitude = Convert.ToDouble(dd) + Convert.ToDouble(mm) / 60;

                double bd_lat, bd_lon;
                WGS84ToBD09.GpsToBd(latitude, longitude, out bd_lat, out bd_lon);

                int longitude2 = (int)Math.Round(bd_lon * 1e6);
                int latitude2 = (int)Math.Round(bd_lat * 1e6);
                //MessageBox.Show(gp_lat+"\n"+gp_lon+"\n"+bd_lat+"\n"+bd_lon);
                string strJson = String.Format("{{\"Longitude\":\"{0}\",\"Latitude\":\"{1}\"}}", longitude2, latitude2);
                m_MForm.ParseJsonData(strJson);
            }
            else
            {
                m_MForm.ParseJsonData("");
                //Console.WriteLine("定位无效");
            }
        }

    }    
}
