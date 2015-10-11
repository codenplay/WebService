using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace DataFromWService
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int DepartmentId { get; set; }     
        }
        
        [WebMethod]
        public void LoadDepartments()
        {
            var dpt = new DepartmentTask();
            DataTable dt = dpt.GetDepartments();
            var departments = new List<Department>();

            foreach (DataRow dr in dt.Rows)
            {
                departments.Add(new Department()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Descr"].ToString()
                });
            }
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            Context.Response.Write(jscript.Serialize(departments));
            //return departments;
        }

        [WebMethod]
        public void LoadStudents(int departmentId)
        {
            var stu = new StudentTask();
            stu.DepartmentId = departmentId;
            DataTable dt = stu.GetStudents();
            var students = new List<Student>();

            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    DepartmentId = Convert.ToInt32(dr["DepartmentId"])
                });
            }
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            Context.Response.Write(jscript.Serialize(students));
        }



    }
}
