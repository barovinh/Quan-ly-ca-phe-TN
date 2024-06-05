using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class DbContext
    {
        string constr = "Data Source = .\\SQLEXPRESS;database = DB_CAFETRUNGNGUYEN;Integrated Security = true";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader reader;
        public DbContext()
        {
            Con.ConnectionString = constr;
            Con.Open();
            Cmd = Con.CreateCommand();
        }
        public void open()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Cmd.Parameters.Clear();
                Con.Open();
            }
        }

        public void close()
        {
            if (con.State == ConnectionState.Open)
                Con.Close();
        }

        public SqlCommand Cmd { get => cmd; set => cmd = value; }
        public SqlConnection Con { get => con; set => con = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }

        public DataTable getDatatable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Con);
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                return null;
            }
         
        }
        public int ExcuteNonQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, Con);
            int kq = cmd.ExecuteNonQuery();
            close();
            return kq;
        }

        public SqlDataReader ExcuteQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        public object ExcuteScalar(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, Con);
            object kq = cmd.ExecuteScalar();
            close();
            return kq;
        }
        public int UpdateData(string sql,DataTable dt)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(sql, Con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kt = da.Update(dt);
            return kt;
        }

    }
}
