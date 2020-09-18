using EmployeeTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTask.Controllers.api
{
    public class DepartmentsController : ApiController
    {
        private SqlUtility sqlUtlity;
        
        public DepartmentsController()
        {
            sqlUtlity = new SqlUtility();
        }

        //GET api/departments
        [HttpGet]
        public IHttpActionResult GetDepartment()
        {
            try
            {
                DataTable result = sqlUtlity.executeSproc("SP_Department_Read", new List<SqlParameter>() { });
                if (result.Rows.Count > 0)
                {
                    var departments = from DataRow row in result.Rows
                                      select new
                                      {
                                          departmentId = row["DepartmentId"],
                                          departmentName = row["DepartmentName"]
                                      };
                    return Ok(new { result = departments });
                }
                else
                {
                    return Ok(new { result = 0 });
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
