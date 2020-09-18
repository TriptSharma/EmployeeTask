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
    public class DesignationsController : ApiController
    {
        private SqlUtility sqlUtility;
        public DesignationsController()
        {
            sqlUtility = new SqlUtility();
        }

        //Get api/desingations
        [HttpGet]
        public IHttpActionResult GetDesignation()
        {
            try
            {
                DataTable result = sqlUtility.executeSproc("SP_Designation_Read", new List<SqlParameter>() { });
                if (result.Rows.Count > 0)
                {
                    var designations = from DataRow row in result.Rows
                                       select new
                                       {
                                           designationId = row["DesignationId"],
                                           designationName = row["DesingationName"]
                                       };
                    return Ok(new { result = designations });
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
