using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoadInfoManager
{
    class AutoSizeForm
    {
        //声明结构,只记录窗体和其控件的初始位置和大小
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }

        private List<controlRect> oldCtrl = new List<controlRect>();
        private int m_ctrlNumber = 0;

        public AutoSizeForm()
        {
            m_ctrlNumber = 0;
        }

        //记录窗体和其控件的初始位置和大小
        public void controllInitializeSize(Control mForm)
        {
            controlRect cR;
            cR.Left = mForm.Left; 
            cR.Top = mForm.Top; 
            cR.Width = mForm.Width; 
            cR.Height = mForm.Height;
            oldCtrl.Add(cR);            //第一个为"窗体本身", 只加入一次即可                
            AddControl(mForm);      //窗体内其余控件还可能嵌套控件(比如panel),要单独抽出, 递归调用
        }

        private void AddControl(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                controlRect objCtrl;
                objCtrl.Left = c.Left; 
                objCtrl.Top = c.Top; 
                objCtrl.Width = c.Width; 
                objCtrl.Height = c.Height;
                oldCtrl.Add(objCtrl);
                //先记录控件本身，后记录控件的子控件
                if (c.Controls.Count > 0)
                    AddControl(c);
            }
        }

        //控件自适应大小,
        public void controlAutoSize(Control mForm)
        {
            if (m_ctrlNumber == 0)
            { 
                controlRect cR;
                cR.Left = mForm.Left; 
                cR.Top = mForm.Top; 
                cR.Width = mForm.Width; 
                cR.Height = mForm.Height;
                oldCtrl.Add(cR);             //第一个为"窗体本身", 只加入一次即可
                AddControl(mForm);      //窗体内其余控件还可能嵌套控件(比如panel),要单独抽出, 递归调用
            }

            //新旧窗体之间的比例, 与最早的旧窗体
            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;    
            float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;
            m_ctrlNumber = 1;     //进入m_ctrlNumber=1, 第0个为窗体本身, 窗体内的控件, 从序号1开始

            AutoScaleControl(mForm, wScale, hScale);    //窗体内其余控件还可能嵌套控件(比如panel), 要单独抽出, 递归调用
        }

        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            foreach (Control c in ctl.Controls)
            {
                ctrLeft0 = oldCtrl[m_ctrlNumber].Left;
                ctrTop0 = oldCtrl[m_ctrlNumber].Top;
                ctrWidth0 = oldCtrl[m_ctrlNumber].Width;
                ctrHeight0 = oldCtrl[m_ctrlNumber].Height;
                c.Left = (int)((ctrLeft0) * wScale);
                c.Top = (int)((ctrTop0) * hScale);
                //只与最初的大小相关, 所以不能与现在的宽度相乘
                c.Width = (int)(ctrWidth0 * wScale); 
                c.Height = (int)(ctrHeight0 * hScale);
                m_ctrlNumber++;
                //先缩放控件本身, 后缩放控件的子控件
                if (c.Controls.Count > 0)
                    AutoScaleControl(c, wScale, hScale);
            }
        }

    }

}

