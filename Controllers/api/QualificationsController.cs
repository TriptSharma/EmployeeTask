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
    public class QualificationsController : ApiController
    {
        private SqlUtility util;
        public QualificationsController()
        {
            util = new SqlUtility();
        }

        //GET api/qualifications
        [HttpGet]
        public IHttpActionResult GetQualifications()
        {
            try
            {
                DataTable result = util.executeSproc("SP_Qualification_Read", new List<SqlParameter>() { });
                if (result.Rows.Count > 0)
                {
                    var employees = from DataRow row in result.Rows
                                    select new
                                    {
                                        qualificationId = row["QualificationId"],
                                        qualificationName = row["QualificationName"]
                                    };
                    return Ok(new { result = employees });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
