using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonLTTQ
{
    class DatabaseProcess
    {
        string strConnect = "Data Source=laptop-4ic7347m;Initial Catalog=QLHSCap1;Integrated Security=True";
        SqlConnection sqlConnect = null;
        void openConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if(sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        void closeConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        public DataTable DataReader(string sqlSelect)
        {
            DataTable tblData = new DataTable();
            openConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConnect);
            sqlData.Fill(tblData);
            closeConnect();
            return tblData;
        }
        public void DataChange(string sqlcmd)
        {
            SqlCommand command = new SqlCommand();
            openConnect();
            command.Connection = sqlConnect;
            command.CommandText = sqlcmd;
            command.ExecuteNonQuery();
            closeConnect();
        }
    }
}
