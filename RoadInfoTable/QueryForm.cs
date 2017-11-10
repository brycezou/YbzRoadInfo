using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using MySql.Data.MySqlClient;


namespace RoadInfoTable
{
    public partial class QueryForm : Form
    {
        private MySqlConnection m_Conn = null;
        private string m_strRoadName = null;
        private string[] strTitleArray = { "序号", "线路名称", "检查时间", "桩号", "经度", "纬度", "左/右侧", 
                                                        "标志类型", "架设形式", "版面形式", "版面宽度", "版面高度", "照片名称" };

        //////////////////////////////////////////////////////////////////////////**********20141014
        //查询结果对话框的构造函数
        public QueryForm(MySqlConnection conn, string roadName)
        {
            InitializeComponent();
            m_Conn = conn;
            m_strRoadName = roadName;
            this.Text = "查询结果——" + m_strRoadName;
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //对话框加载时查询数据并填充到dataGridView控件
        private void QueryForm_Load(object sender, EventArgs e)
        {
            string strQuery = "SELECT idnumber AS \'序号\', roadName AS \'线路名称\', checkTime AS \'检查时间\', pointNumber AS \'桩号\', longitude AS \'经度\', latitude AS \'纬度\', leftRight AS \'左/右侧\', markType AS \'标志类型\', layStyle AS \'架设形式\', plateStyle AS \'版面形式\', width AS \'版面宽度\', height  AS \'版面高度\', photoName  AS \'照片名称\' FROM " + m_strRoadName;
            try
            {
                QueryDataFromTable(strQuery);
            }
            catch (System.Exception)
            {
                MessageBox.Show("数据库连接失败!");
                this.Close();
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //从表中查询数据并赋给dataGridView控件
        private void QueryDataFromTable(string strQuery)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(strQuery, m_Conn);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet, "dataSet");
            //if (dataSet.Tables[0].Rows.Count == 0){}
            this.dataGridView.DataSource = dataSet.Tables[0].DefaultView;
            m_Conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //从dataGridView中删除一行记录, 同时从数据库中删除对应的记录
        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("确定要删除这一条记录吗?   ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            string strDelete = String.Format("DELETE FROM {0} WHERE idnumber = {1}", m_strRoadName, dataGridView.SelectedRows[0].Cells[0].Value);
            try
            {
                DeleteDataFromTable(strDelete);
            }
            catch (System.Exception)
            {
                MessageBox.Show("数据库连接失败!");
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //从数据库中删除一条记录
        private void DeleteDataFromTable(string strDelete)
        {
            m_Conn.Open();
            MySqlCommand cmd = new MySqlCommand(strDelete, m_Conn);
            cmd.ExecuteNonQuery();
            m_Conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //处理鼠标点击单元格的事件, 用于显示标志牌图片
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                string strColName = this.dataGridView.CurrentCell.OwningColumn.Name;    //获取列名
                if (strColName.Equals("照片名称"))
                {
                    string strPhotoName = this.dataGridView.CurrentCell.Value.ToString();
                    if (File.Exists("..\\Photos\\"+strPhotoName))
                    {
                        PictureShowForm picForm = new PictureShowForm("..\\Photos\\" + strPhotoName);
                        picForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("  照片不存在!  \n\n  请确认Photos文件夹位于正确的目录!  ");
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////**********20141014
        //将单元格中的数据导出到EXCEL表中
        private void button_Save2File_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            if (excel == null)
            {
                MessageBox.Show("无法访问Excel文件!");
                return;
            }
            Microsoft.Office.Interop.Excel._Workbook xBook = excel.Application.Workbooks.Add(Missing.Value);
            Microsoft.Office.Interop.Excel._Worksheet xSheet = (Microsoft.Office.Interop.Excel._Worksheet)xBook.ActiveSheet;
            for (int i = 0; i < strTitleArray.Length; i++)
            {
                xSheet.Cells[1, i+1] = strTitleArray[i];
            }
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                for (int col = 0; col < dataGridView.ColumnCount; col++)
                {
                    xSheet.Cells[row+2 , col+1] = "\'" + dataGridView.Rows[row].Cells[col].Value.ToString();
                }
            }
            excel.Visible = true;
            if (!Directory.Exists("..\\XlsxFiles"))
            {
                Directory.CreateDirectory("..\\XlsxFiles");
            }
            string strFileName = System.Environment.CurrentDirectory + "\\..\\XlsxFiles\\" + m_strRoadName+ "@" + DateTime.Now.ToString().Replace('/', '-').Replace(':', '-').Replace(' ', '-') + ".xlsx";
            try
            {
                xSheet.SaveAs(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                MessageBox.Show("文件导出成功!");
            }
            catch (System.Exception)
            {
                MessageBox.Show("文件导出失败!");
            }
        }

    }
}
