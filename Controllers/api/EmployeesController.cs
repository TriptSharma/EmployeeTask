﻿using EmployeeTask.Models;
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
    public class EmployeesController : ApiController
    {
        private SqlUtility util;
        public EmployeesController()
        {
            util = new SqlUtility();
        }

        //GET api/employees
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            try
            {
                DataTable result = util.executeSproc("SP_Employee_ReadAll", new List<SqlParameter>() { });
                if (result.Rows.Count > 0)
                {
                    var employees = from DataRow row in result.Rows
                                   select new
                                   {
                                       EmployeeId = row["EmployeeId"],
                                       FirstName = row["FirstName"],
                                       LastName = row["LastName"],
                                       Gender = row["Gender"],
                                       Dob = row["Dob"],
                                       Doj = row["Doj"],
                                       QualificationId = row["QualificationId"],
                                       QualificationName = row["QualificationName"],
                                       DepartmentId = row["DepartmentId"],
                                       DepartmentName = row["DepartmentName"],
                                       DesignationId = row["DesignationId"],
                                       DesignationName = row["DesignationName"],
                                       ManagerId = row["ManagerId"],
                                       ManagerFirstName = row["ManagerFirstName"],
                                       ManagerLastName = row["ManagerLastName"],
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

        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>() { };
                parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Default, id));
                
                DataTable result = util.executeSproc("SP_Employee_Read", parameters);
                if (result.Rows.Count > 0)
                {
                    var employee = from DataRow row in result.Rows
                                    select new
                                    {
                                        EmployeeId = row["EmployeeId"],
                                        FirstName = row["FirstName"],
                                        LastName = row["LastName"],
                                        Gender = row["Gender"],
                                        Dob = row["Dob"],
                                        Doj = row["Doj"],
                                        QualificationId = row["QualificationId"],
                                        QualificationName = row["QualificationName"],
                                        DepartmentId = row["DepartmentId"],
                                        DepartmentName = row["DepartmentName"],
                                        DesignationId = row["DesignationId"],
                                        DesignationName = row["DesignationName"],
                                        ManagerId = row["ManagerId"],
                                        ManagerFirstName = row["ManagerFirstName"],
                                        ManagerLastName = row["ManagerLastName"],
                                    };
                    return Ok(new { result = employee });
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


        //POST api/employee
        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.FirstName));
                parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.LastName));
                parameters.Add(new SqlParameter("@Gender", SqlDbType.Bit, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Gender));
                parameters.Add(new SqlParameter("@Dob", SqlDbType.Date, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Dob));
                parameters.Add(new SqlParameter("@Doj", SqlDbType.Date, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Doj));
                parameters.Add(new SqlParameter("@QualificationId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.QualificationId));
                parameters.Add(new SqlParameter("@DepartmentId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.DepartmentId));
                parameters.Add(new SqlParameter("@ManagerId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.ManagerId));
                parameters.Add(new SqlParameter("@DesignationId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.DesignationId));

                var result = util.executeSproc("SP_Employee_Insert", parameters);

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
                parameters.Add(new SqlParameter("@EmployeeId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.EmployeeId));
                parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.FirstName));
                parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.LastName));
                parameters.Add(new SqlParameter("@Gender", SqlDbType.Bit, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Gender));
                parameters.Add(new SqlParameter("@Dob", SqlDbType.Date, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Dob));
                parameters.Add(new SqlParameter("@Doj", SqlDbType.Date, -1, ParameterDirection.Input, true, 2, 2, "", DataRowVersion.Current, employee.Doj));
                parameters.Add(new SqlParameter("@QualificationId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.QualificationId));
                parameters.Add(new SqlParameter("@DepartmentId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.DepartmentId));
                parameters.Add(new SqlParameter("@ManagerId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.ManagerId));
                parameters.Add(new SqlParameter("@DesignationId", SqlDbType.Int, -1, ParameterDirection.Input, false, 2, 2, "", DataRowVersion.Current, employee.DesignationId));

                var result = util.executeSproc("SP_Employee_Update", parameters);

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
