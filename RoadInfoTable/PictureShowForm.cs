using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RoadInfoTable
{
    public partial class PictureShowForm : Form
    {
        private string m_PhotoName = null;

        public PictureShowForm()
        {
            InitializeComponent();
        }

        public PictureShowForm(string strPhotoName)
        {
            InitializeComponent();
            m_PhotoName = strPhotoName;
        }

        private void PictureShowForm_Load(object sender, EventArgs e)
        {
            pictureBox.Image = Image.FromFile(m_PhotoName);
        }

    }
}
