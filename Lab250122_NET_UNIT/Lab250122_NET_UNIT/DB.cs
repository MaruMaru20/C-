using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab250122_NET_UNIT
{
    public class DB
    {

        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet ds;



        public DB()
        {
            conn = new SqlConnection(Lab250122_NET_UNIT.Properties.Settings.Default.DW);
            adapter = new SqlDataAdapter();
            ds = new DataSet();
        }
        public DataTable GetDataTable(string sql, string Viwer)
        {
            ds.Clear();
            adapter.SelectCommand = new SqlCommand(sql, conn);

            adapter.Fill(ds, Viwer);
            return ds.Tables[Viwer];
        }

        public DataTable GetDataTable(string SQLL, string pkey,string pvalue)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AdventureWorksDW2022;Integrated Security=True;TrustServerCertificate=True");
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = SQLL;
            cmd.Parameters.AddWithValue(pkey, pvalue);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataTable(string SQLL,Dictionary<string,string> Dic)
        {
            SqlConnection connn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True");
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connn;
            cmd.CommandText = SQLL;
            foreach (KeyValuePair<string,string> item in Dic)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);

            }
            //cmd.Parameters.AddWithValue(pkey, pvalue);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public Dictionary<string,string> GetDataTable(string userSQL) 
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AdventureWorksDW2022;Integrated Security=True;TrustServerCertificate=True");
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = userSQL;
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            Dictionary<string,string> dc = new Dictionary<string,string>();
            foreach (DataRow item in dt.Rows)
            {

                dc.Add(item.ItemArray[0].ToString(), item.ItemArray[1].ToString());
            }
            return dc;
        }


    }
}
