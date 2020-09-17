using EmployeeTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTask.Controllers
{
    public class EmployeeController : ApiController
    {
        private SqlUtility util;
        public EmployeeController()
        {
            util = new SqlUtility();
        }

        //GET api/employee
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            try
            {
                DataTable result = util.executeSproc("SP_Employee_ReadAll", new List<SqlParameter>() { });
                if (result.Rows.Count > 0)
                {
                    var employees = from DataRow row in result.Rows
                                   select new
                                   {
                                       eId = row["EmployeeId"],
                                       eFirstName = row["FirstName"],
                                       eLastName = row["LastName"],
                                       eGender = row["Gender"],
                                       eDob = row["Dob"],
                                       eDoj = row["Doj"],
                                       eQualificationId = row["QualificationId"],
                                       eQualificationName = row["QualificationName"],
                                       eDepartmentId = row["DepartmentId"],
                                       eDepartmentName = row["DepartmentName"],
                                       eDesignation = row["Designation"],
                                       emId = row["ManagerId"],
                                       emFirstName = row["ManagerFirstName"],
                                       emLastName = row["ManagerLastName"],
                                   };
                    return Ok(new { result = employees });
                }
                else
                {
                    return Ok(new { result = 0 });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /*//GET api/patientMasters/1
        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Default, id));

                var result = util.executeSproc("SP_Employee_Read", parameters);

                if (result.Rows.Count > 0)
                {
                    var employee = from DataRow row in result.Rows
                                   select new
                                   {
                                       eId = row["EmployeeId"],
                                       eFirstName = row["FirstName"],
                                       eLastName = row["LastName"],
                                       eGender = row["Gender"],
                                       eDob = row["Dob"],
                                       eDoj = row["Doj"],
                                       eQualificationId = row["QualificationId"],
                                       eQualificationName = row["QualificationName"],
                                       eDepartmentId = row["DepartmentId"],
                                       eDepartmentName = row["DepartmentName"],
                                       eDesignation = row["Designation"],
                                       emId = row["ManagerId"],
                                       emFirstName = row["ManagerFirstName"],
                                       emLastName = row["ManagerLastName"],
                                  };
                    return Ok(new { result = employee });
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }*/

        //POST api/employee
        [HttpPost]
        public IHttpActionResult CreatePatient(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.FirstName));
                parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.LastName));
                parameters.Add(new SqlParameter("@Gender", SqlDbType.Bit, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Gender));

                var result = util.executeSproc("SP_Empployee_Insert", parameters);

                return Created("patientMasters/" + employee.EmployeeId, new { results = "Created" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //PUT api/employee
        [HttpPut]
        public IHttpActionResult UpdatePatient(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@PatientId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Default, masterParam.PatientId));
                parameters.Add(new SqlParameter("@PatientName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, masterParam.PatientName));
                parameters.Add(new SqlParameter("@PatientAddress", SqlDbType.VarChar, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, masterParam.PatientAddress));

                var result = util.executeSproc("SP_PatientMaster_Update", parameters);

                return Ok(new { results = employee });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //DELETE api/patientMasters/3
        [HttpDelete]
        public IHttpActionResult DeletePatient(int id)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, id));
                var result = util.executeSproc("SP_Employee_Delete", parameters);
                return Ok(new { result = "Deleted" });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
