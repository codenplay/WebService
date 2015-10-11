using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataFromWService
{
    public class DbAccess
    {
        public string ConnectionString = null;
        public string Sql { private get; set; }
        public DbAccess()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
        }

        public DataTable ExecuteCommand()
        {
            using (SqlConnection conn =new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Sql, conn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        dataAdapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}