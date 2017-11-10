using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoadInfoManager
{
    public partial class ImageShowForm : Form
    {
        private string m_PhotoName = null;

        public ImageShowForm()
        {
            InitializeComponent();
        }

        public ImageShowForm(string strImageName)
        {
            InitializeComponent();
            m_PhotoName = strImageName;
            this.ControlBox = false;
        }

        private void ImageShowForm_Load(object sender, EventArgs e)
        {
            pictureBox.Image = Image.FromFile(m_PhotoName);
        }
    }
}
