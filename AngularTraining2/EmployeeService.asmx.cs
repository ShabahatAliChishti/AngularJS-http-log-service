using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
//this namespace is use to convert data into json format
using System.Web.Script.Serialization;
using System.Configuration;

namespace AngularTraining2
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        //it only write employee data into json format thats why return type is void
        public void GetAllEmployees()
        {
            List<Employee> listemployees = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * From Employee", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(sdr["EmployeeID"]);
                    employee.EmailAdress = sdr["EmailAdress"].ToString();
                    employee.EmployeeName= sdr["EmployeeName"].ToString();
                    employee.MobileNumber = sdr["MobileNumber"].ToString();
                    listemployees.Add(employee);

                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listemployees));
        }
    }
}
