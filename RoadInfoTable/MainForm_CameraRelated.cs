using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Threading;


namespace RoadInfoTable
{
    partial class MainForm
    {
        private const double RESIZE_SCALE = 0.5;

        private Capture m_Capture = null;

        private bool m_Is2Preview = true;                                 //是否视频预览
        private bool m_IsPhotoTaken = false;                             //是否按下了拍照按钮
        private string m_strSavedPhotoName = null;                  //存储需要保存的照片的名称


        //////////////////////////////////////////////////////////////////////////**********20151102
        //初始化摄像头
        private int InitialCamera()
        {
            int camIndex = 0;
            try
            {
                camIndex = Convert.ToInt32(ParseConfigFile.GetAppConfig("camera_index"));
            }
            catch (System.Exception)
            {
                return -1;
            }
            try
            {
                m_Capture = new Capture(camIndex);
                m_Capture.ImageGrabbed += ProcessSingleFrame;
            }
            catch (System.Exception)
            {
                m_Capture = null;
                return -2;
            }
            return 0;
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //摄像头视频预览; 在点击"拍照"按钮后, 保存图片
        private void ProcessSingleFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> frame = m_Capture.RetrieveBgrFrame();
            this.imageBox.Image = frame;
            if (m_IsPhotoTaken)     //如果按下了"拍照"按钮
            {
                m_IsPhotoTaken = false;
                if (this.textBox_PhotoName.Text.Equals(""))
                    MessageBox.Show("  未能获取有效照片名, 不能保存!  \n  请检查GPS设备!");
                else
                {
                    m_strSavedPhotoName = this.textBox_PhotoName.Text;
                    if (!Directory.Exists("..\\Photos"))
                        Directory.CreateDirectory("..\\Photos");
                    frame.ToBitmap().Save("..\\Photos\\" + m_strSavedPhotoName);
                    this.imageBox_Small.Image = frame;
                }
            }
            frame.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////**********20151104
        //控制摄像头是否进行视频预览
        private void button_StartPreview_Click(object sender, EventArgs e)
        {
            string strRoadName = this.comboBox_RoadNames.Text;
            if (strRoadName.Equals("$请选择线路"))
            {
                MessageBox.Show(" 请先选择一条线路! ");
                return;
            }
            if (m_Capture != null)
            {
                if (m_Is2Preview)       //开始预览
                {
                    this.button_StartPreview.Text = "停止采集";
                    m_Capture.Start();
                    m_Is2Preview = false;
                }
                else                              //停止预览
                {
                    this.button_StartPreview.Text = "开始采集";
                    m_Capture.Pause();
                    m_Is2Preview = true;
                }
            }
        }
        
        //////////////////////////////////////////////////////////////////////////**********20141029
        //确保摄像头正常关闭, 确保正在书写的视频流和文本流能正常关闭
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Capture != null)
            {
                m_Capture.Stop();
                m_Capture.Dispose();
                m_Capture = null;
            }
        }
        
    }
}
