using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;


namespace RoadInfoTable
{
    public static class DatabaseUtil
    {
        //////////////////////////////////////////////////////////////////////////**********20151103
        //执行SQL指令
        public static void DoCmd(string strCmd, MySqlConnection conn)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(strCmd, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //////////////////////////////////////////////////////////////////////////**********20151103
        //从表中查询数据并赋给ComboBox控件
        public static void QueryData2ComboBox(string strQuery, MySqlConnection conn, string strKey, ComboBox combox)
        {
            MySqlDataAdapter mda = new MySqlDataAdapter(strQuery, conn);
            DataSet dataSet = new DataSet();
            mda.Fill(dataSet, "dataSet");
            combox.DisplayMember = strKey;
            combox.ValueMember = strKey;
            combox.DataSource = dataSet.Tables[0].DefaultView;
            conn.Close();
        }
    
    }
}
