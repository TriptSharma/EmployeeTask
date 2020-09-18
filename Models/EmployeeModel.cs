using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTask.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Doj { get; set; }
        public int QualificationId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int ManagerId { get; set; }
    }
}