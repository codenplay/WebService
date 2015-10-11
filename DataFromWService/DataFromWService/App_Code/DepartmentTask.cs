using System.Data;

namespace DataFromWService
{
    public class DepartmentTask
    {
        DbAccess access = new DbAccess();
        public DataTable GetDepartments()
        {
            DataTable dt = new DataTable();
            access.Sql = "select * from department";
            dt = access.ExecuteCommand();
            return dt;
        }
    }
}