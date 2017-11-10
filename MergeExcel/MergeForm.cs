using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MergeExcel
{
    public partial class MergeForm : Form
    {
        private StringBuilder mAutoName = new StringBuilder();
        private string[] mTitleArray = { "序号", "线路名称", "检查时间", "桩号", "经度", "纬度", "左/右侧", "标志类型", "架设形式", "版面形式", "版面宽度", "版面高度", "照片名称" };

        public MergeForm()
        {
            InitializeComponent();
            this.listBox.Items.Clear();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fielNames = openFileDialog.FileNames;
                foreach (string filename in fielNames)
                {
                    if (this.listBox.Items.Contains(filename))
                    {
                        MessageBox.Show(String.Format("文件 \"{0}\" 已经添加 !", filename));
                        return;
                    }
                    this.listBox.Items.Add(filename);
                }
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (this.listBox.SelectedIndex != -1)
            {
                string filename = this.listBox.SelectedItem.ToString();
                string strText = String.Format("确定要移除文件 \"{0}\" 吗?", filename);
                if (MessageBox.Show(strText, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.listBox.Items.Remove(filename);
                }
            }
            else
                MessageBox.Show("请选择要移除的文件!");
        }

        private void button_Up_Click(object sender, EventArgs e)
        {
            int curIdx = this.listBox.SelectedIndex;
            if (curIdx != -1)
            {
                if (curIdx > 0)
                {
                    string strCurr = this.listBox.SelectedItem.ToString();
                    string strUp = this.listBox.Items[curIdx - 1].ToString();
                    //把当前选择行的值与上一行互换, 并将选择索引减1
                    this.listBox.Items[curIdx - 1] = strCurr;
                    this.listBox.Items[curIdx] = strUp;
                    this.listBox.SelectedIndex = curIdx - 1;
                }
            }
            else
                MessageBox.Show("请选择一项!");
        }

        private void button_Down_Click(object sender, EventArgs e)
        {
            int curIdx = this.listBox.SelectedIndex;
            if (curIdx != -1)
            {
                if (curIdx < this.listBox.Items.Count-1)
                {
                    string strCurr = this.listBox.SelectedItem.ToString();
                    string strDown = this.listBox.Items[curIdx + 1].ToString();
                    //把当前选择行的值与下一行互换, 并将选择索引加1
                    this.listBox.Items[curIdx + 1] = strCurr;
                    this.listBox.Items[curIdx] = strDown;
                    this.listBox.SelectedIndex = curIdx + 1;
                }
            }
            else
                MessageBox.Show("请选择一项!");
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this.listBox.Items.Count < 2)
            {
                MessageBox.Show("至少需要添加两个文件!");
                return;
            }
            string strValidation = CheckFileValidation();
            if (! strValidation.Equals(""))
            {
                MessageBox.Show(String.Format("文件 \"{0}\" 不合法!", strValidation));
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文档|*.xlsx";
            sfd.FileName = mAutoName.ToString().Substring(1);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName;
                if (! filename.Substring(filename.Length - 5).Equals(".xlsx"))
                    filename = filename + ".xlsx";
                MergeExcelFiles(filename);
            }
        }

        //所有文件都合法时返回空字符串，否则返回第一个不合法文件的文件名
        private string CheckFileValidation()
        {
            mAutoName.Clear();
            for (int i = 0; i < this.listBox.Items.Count; i++ )
            {
                string filename = this.listBox.Items[i].ToString();
                if (! CheckOneExcelFile(filename))
                    return filename;
                mAutoName.Append("-").Append(GetRoadName(filename));  
            }
            return "";
        }

        private string GetRoadName(string strPath)
        {
            string fileName = strPath.Substring(strPath.LastIndexOf("\\") + 1);
            return fileName.Split(new char[] { '@' })[0];
        }

        //文件合法返回true，否则返回false
        private bool CheckOneExcelFile(string strFileName)
        {            
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            if (excel == null)
            {
                MessageBox.Show("无法访问Excel文件!");
                return false;
            }
            excel.Visible = false; 
            excel.UserControl = true;

            // 以只读的形式打开EXCEL文件  
            Microsoft.Office.Interop.Excel._Workbook xBook = excel.Application.Workbooks.Open( strFileName, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
                                                                                                                                                Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //取得第一个工作薄
            Microsoft.Office.Interop.Excel._Worksheet xSheet = (Microsoft.Office.Interop.Excel._Worksheet)xBook.Worksheets.get_Item(1);
            int numRow = xSheet.UsedRange.Cells.Rows.Count;         //得到行数  
            int numCol = mTitleArray.Length;                                       //得到列数  

            for (int i = 0; i < numCol; i++)
            {
                if (!xSheet.Cells[1, i + 1].Text.ToString().Equals(mTitleArray[i]))
                {
                    excel.Quit();
                    return false;
                }
            }
            excel.Quit();
            return true;
        }

        private void MergeExcelFiles(string strFileName)
        {
            //打开待保存的文件
            Microsoft.Office.Interop.Excel.Application excel2Save = new Microsoft.Office.Interop.Excel.Application();
            if (excel2Save == null)
            {
                MessageBox.Show("无法访问Excel文件!");
                return;
            }
            Microsoft.Office.Interop.Excel._Workbook xBook2Save = excel2Save.Application.Workbooks.Add(Missing.Value);
            Microsoft.Office.Interop.Excel._Worksheet xSheet2Save = (Microsoft.Office.Interop.Excel._Worksheet)xBook2Save.ActiveSheet;
            //设置新Excel文件的标题栏
            for (int i = 0; i < mTitleArray.Length; i++)
                xSheet2Save.Cells[1, i + 1] = mTitleArray[i];

            //逐一保存Excel文件到新Excel文件中
            int rowNumber = 2;
            for (int i = 0; i < this.listBox.Items.Count; i++)
            {
                string strCurrFile = this.listBox.Items[i].ToString();
                Microsoft.Office.Interop.Excel.Application currExcel = new Microsoft.Office.Interop.Excel.Application();
                if (currExcel == null)
                {
                    excel2Save.Quit();
                    MessageBox.Show("无法访问Excel文件!");
                    return;
                }
                currExcel.Visible = false;
                currExcel.UserControl = true;

                // 以只读的形式打开EXCEL文件  
                Microsoft.Office.Interop.Excel._Workbook xBook = currExcel.Application.Workbooks.Open(strCurrFile, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                                                                                                                                    Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //取得第一个工作薄
                Microsoft.Office.Interop.Excel._Worksheet xSheet = (Microsoft.Office.Interop.Excel._Worksheet)xBook.Worksheets.get_Item(1);
                int numRow = xSheet.UsedRange.Cells.Rows.Count;         //得到行数  
                int numCol = mTitleArray.Length;                                       //得到列数
                for (int j = 0; j < numCol; j++)
                {
                    if (!xSheet.Cells[1, j + 1].Text.ToString().Equals(mTitleArray[j]))
                    {
                        currExcel.Quit();
                        excel2Save.Quit();
                        MessageBox.Show("错误, 数据格式不一致!");
                        return;
                    }
                }

                for (int k = 1; k < numRow; k++)
                {
                    string strIndex = xSheet.Cells[k + 1, 1].Text.ToString();
                    if (strIndex.Trim().Equals(""))
                        break;
                    xSheet2Save.Cells[rowNumber, 1] = "\'" + strIndex;
                    xSheet2Save.Cells[rowNumber, 2] = "\'" + xSheet.Cells[k + 1, 2].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 3] = "\'" + xSheet.Cells[k + 1, 3].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 4] = "\'" + xSheet.Cells[k + 1, 4].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 5] = "\'" + xSheet.Cells[k + 1, 5].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 6] = "\'" + xSheet.Cells[k + 1, 6].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 7] = "\'" + xSheet.Cells[k + 1, 7].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 8] = "\'" + xSheet.Cells[k + 1, 8].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 9] = "\'" + xSheet.Cells[k + 1, 9].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 10] = "\'" + xSheet.Cells[k + 1, 10].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 11] = "\'" + xSheet.Cells[k + 1, 11].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 12] = "\'" + xSheet.Cells[k + 1, 12].Text.ToString();
                    xSheet2Save.Cells[rowNumber, 13] = "\'" + xSheet.Cells[k + 1, 13].Text.ToString();
                    rowNumber++;
                }
                currExcel.Quit();
            }

            //保存Excel文件
            try
            {
                xSheet2Save.SaveAs(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                MessageBox.Show("文件合并成功!");
            }
            catch (System.Exception)
            {
                MessageBox.Show("文件合并失败!");
            }
            excel2Save.Quit();
        }

    }
}
