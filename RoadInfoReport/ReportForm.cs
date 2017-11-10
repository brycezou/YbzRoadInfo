using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections;


namespace RoadInfoReport
{
    //执行JS脚本需要的权限
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)] 

    public partial class ReportForm : Form
    {
        //标志牌数据链表
        private List<MarkerInfo> m_markerInfoList = new List<MarkerInfo>();
        private AutoSizeForm m_asForm = null;
        private bool m_bCertainKeyPressed = false;
        private bool m_bReportMode = false;
        private delegate void DelegateClearAllMarks();
        private delegate void DelegateAddMarker(MarkerInfo markInfo);
        private delegate void DelegateUpdateUIControl();
        private bool m_bLoadImageAutomatically = false;
        private ArrayList m_img2ShowList = new ArrayList();
        private ArrayList m_form2ShowImageList = new ArrayList();

        public ReportForm()
        {
            m_asForm = new AutoSizeForm();
            m_form2ShowImageList.Clear();                       //显示图像的窗体链表
            m_img2ShowList.Clear();                                  //待显示的图像链表
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //初始化应用程序, 加载百度地图
        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadBaiduMap("\\Resources\\BaiduMap4Reporting.html");
            m_asForm.controllInitializeSize(this);
        }

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
        //从EXCEL文件中读入数据, 生成一个对象链表
        private void OpenExcel(string strFileName)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            if (excel == null)
            {
                MessageBox.Show("无法访问Excel文件!");
                return;
            }
            excel.Visible = false; 
            excel.UserControl = true;

            // 以只读的形式打开EXCEL文件  
            Microsoft.Office.Interop.Excel._Workbook xBook = excel.Application.Workbooks.Open( strFileName, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
                                                                                                                                                Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //取得第一个工作薄
            Microsoft.Office.Interop.Excel._Worksheet xSheet = (Microsoft.Office.Interop.Excel._Worksheet)xBook.Worksheets.get_Item(1);
            int numRow = xSheet.UsedRange.Cells.Rows.Count;         //得到行数  
            int numCol = xSheet.UsedRange.Cells.Columns.Count;       //得到列数  

            string[] strArray = { "序号", "线路名称", "检查时间", "桩号", "经度", "纬度", "左/右侧", "标志类型", "架设形式", "版面形式", "版面宽度", "版面高度", "照片名称" };
            int numCol2 = strArray.Length;
            //for (int i = 0; i < numCol; i++ )
            for (int i = 0; i < numCol2; i++)
            {
                if (!xSheet.Cells[1, i + 1].Text.ToString().Equals(strArray[i]))
                {
                    excel.Quit();
                    MessageBox.Show("错误, 数据格式不一致!");
                    return;
                }
            }

            m_markerInfoList.Clear();
            for (int i = 1; i < numRow; i++)
            {
                string strRoadName = xSheet.Cells[i + 1, 2].Text.ToString();
                if (strRoadName.Trim().Equals(""))
                    break;
                string strCheckTime = xSheet.Cells[i + 1, 3].Text.ToString();
                string strPointNumber = xSheet.Cells[i + 1, 4].Text.ToString();
                string strLongitude = xSheet.Cells[i + 1, 5].Text.ToString();
                string strLatitude = xSheet.Cells[i + 1, 6].Text.ToString();
                string strLeftRight = xSheet.Cells[i + 1, 7].Text.ToString();
                string strMarkType = xSheet.Cells[i + 1, 8].Text.ToString();
                string strlayStyle = xSheet.Cells[i + 1, 9].Text.ToString();
                string strPlateStyle = xSheet.Cells[i + 1, 10].Text.ToString();
                string strImageName = xSheet.Cells[i + 1, 13].Text.ToString();

                string strTitle = "道路" + strLeftRight + "侧, " + "桩号: " + strPointNumber;
                string strContent = "线路名称: " + strRoadName + "<br>检查时间: " + strCheckTime + "<br>标志类型: " + strMarkType + "<br>架设形式: " + strlayStyle + "<br>版面形式: " + strPlateStyle;
                string strLocation = Convert.ToDouble(strLongitude) / 1e6 + "|" + Convert.ToDouble(strLatitude) / 1e6;
                //每条记录生成一个对象
                MarkerInfo markInfo = new MarkerInfo(strTitle, strContent, strLocation, strImageName);
                m_markerInfoList.Add(markInfo);
            }
            excel.Quit();
            MessageBox.Show("数据加载完毕!");
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //打开选择文件对话框
        private void button_LoadXlsxFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fielName = openFileDialog.FileName;
                OpenExcel(fielName);
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //将每一个标志牌都以富标注的形式添加到百度地图上
        private void button_MarkPointOnce_Click(object sender, EventArgs e)
        {
            if (m_markerInfoList.Count == 0)
            {
                MessageBox.Show("请先加载EXCEL数据文件!");
                return;
            }
            //调用JS脚本完成删除和添加功能
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_clearAllMarker", new Object[] { });
            for (int i = 0; i < m_markerInfoList.Count; i++ )
            {
                MarkerInfo markInfo = (MarkerInfo)m_markerInfoList[i];
                webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_addMarker", new Object[] { markInfo.m_strTitle, markInfo.m_strContent, markInfo.m_strLocation, markInfo.m_strImageName });                
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //调用JS脚本, 清除百度地图上的所有标记点
        private void button_ClearAllMarkers_Click(object sender, EventArgs e)
        {
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_clearAllMarker", new Object[] { });
        }

        private void ReportForm_SizeChanged(object sender, EventArgs e)
        {
            m_asForm.controlAutoSize(this);
        }

        private void button_ReportMode_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text.Equals("进入汇报模式"))
            {
                if (m_markerInfoList.Count == 0)
                {
                    MessageBox.Show("请先加载EXCEL数据文件!");
                    return;
                }
                btn.Text = "退出汇报模式";
                m_bReportMode = true;   //进入汇报模式
                ThreadStart threadStart = new ThreadStart(reportModeRun);
                Thread thead = new Thread(threadStart);
                thead.Start();
            }
            else if (btn.Text.Equals("退出汇报模式"))
            {
                btn.Text = "进入汇报模式";
                m_bReportMode = false;   //退出汇报模式
            }
        }

        private void clearAllMarker_delegate()
        {
            //调用JS脚本完成删除功能
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_clearAllMarker", new Object[] { });
        }

        private void addMarker_delegate(MarkerInfo markInfo)
        {
            //调用JS脚本完成添加功能
            webBrowser_BaiduMap.Document.InvokeScript("CSharpCallJs_addMarker_ReportMode", new Object[] { markInfo.m_strTitle, markInfo.m_strContent, markInfo.m_strLocation, markInfo.m_strImageName });
        }

        private void updateUiControl_delegate()
        {
            this.button_ReportMode.Text = "进入汇报模式";
        }

        private void reportModeRun()
        {
            //委托删除和添加
            DelegateClearAllMarks dcam = new DelegateClearAllMarks(clearAllMarker_delegate);
            this.Invoke(dcam, new Object[] { });
            DelegateAddMarker dam = new DelegateAddMarker(addMarker_delegate);

            int i = 0;
            while (m_bReportMode && i < m_markerInfoList.Count)
            {
                if (m_bCertainKeyPressed)
                {
                    MarkerInfo markInfo = (MarkerInfo)m_markerInfoList[i];
                    this.Invoke(dam, new Object[] { markInfo });
                    Thread.Sleep(10);
                    m_bCertainKeyPressed = false;
                    i++;
                }
                else
                    Thread.Sleep(30);
            }
            m_bReportMode = false;
            DelegateUpdateUIControl duic = new DelegateUpdateUIControl(updateUiControl_delegate);
            this.Invoke(duic, new object[] { });
        }

        private void ReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                m_bCertainKeyPressed = true;
        }

        private void webBrowser_BaiduMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                m_bCertainKeyPressed = true;
        }

        private void checkBox_autoLoadImage_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkBox_autoLoadImage.CheckState == CheckState.Checked)
            {
                m_bLoadImageAutomatically = true;
            }
            else
            {
                m_bLoadImageAutomatically = false;
            }
        }

        //JS调用WinForm显示标志牌图像
        public void JsCallCSharp_ShowImage(string strImageName)
        {
            if (!m_bLoadImageAutomatically)
                return;

            JsCallCSharp_CloseImage();

            string strPrefix = strImageName.Split(new char[] { '_' })[0];
            foreach (string item in Directory.GetFiles("Photos", "*.jpg"))
            {
                if (item.Replace("Photos\\", "").StartsWith(strPrefix))
                    m_img2ShowList.Add(item);
            }

            foreach (string strpath in m_img2ShowList)
            {
                if (File.Exists(strpath))
                {
                    ImageWindow iw = new ImageWindow(strpath);
                    m_form2ShowImageList.Add(iw);
                }
                else
                    MessageBox.Show("  照片不存在!  \n\n  请确认Photos文件夹位于应用程序目录下!  ");
            }

            foreach (ImageWindow iw in m_form2ShowImageList)
            {
                iw.Show();
            }
        }

        //JS调用WinForm关闭标志牌图像
        public void JsCallCSharp_CloseImage()
        {
            for (int i = 0; i < m_form2ShowImageList.Count; i++)
            {
                if (m_form2ShowImageList[i] != null)
                {
                    ((ImageWindow)m_form2ShowImageList[i]).Close();
                    m_form2ShowImageList[i] = null;
                }
            }
            m_form2ShowImageList.Clear();
            m_img2ShowList.Clear();
        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bReportMode = false;
            Process[] process = Process.GetProcessesByName("RoadInfoReport");
            foreach (Process p in process)
            {
                p.Kill();
            }
        }

    }
}
