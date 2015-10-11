using System.Data;

namespace DataFromWService
{
    public class StudentTask
    {
        public int DepartmentId { get; set; }
        
        DbAccess access = new DbAccess();
        public DataTable GetStudents()
        {
            DataTable dt = new DataTable();
            access.Sql = "select * from Student where DepartmentId = " + DepartmentId;
            dt = access.ExecuteCommand();
            return dt;
        }

    }
}