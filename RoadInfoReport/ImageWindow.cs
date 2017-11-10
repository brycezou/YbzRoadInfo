using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoadInfoReport
{
    public partial class ImageWindow : Form
    {
        private string m_ImageName = null;

        public ImageWindow()
        {
            InitializeComponent();
        }

        public ImageWindow(string strname)
        {
            InitializeComponent();
            m_ImageName = strname;
            this.ControlBox = false;
        }

        private void ImageWindow_Load(object sender, EventArgs e)
        {
            pictureBox.Image = Image.FromFile(m_ImageName);
        }
    }
}
