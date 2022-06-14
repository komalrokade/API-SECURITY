using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Core_API.Models
{
    public partial class Employee
    {
        [Required(ErrorMessage = "EmpNO is Mandatory")]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is Mandatory")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Mnimum 5 Characters are Required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is Mandatory")]

        public string Designation { get; set; }
        [Required(ErrorMessage = "Salary is Mandatory")]

        public int Salary { get; set; }
        [Required(ErrorMessage = "DeptNo is Mandatory")]

        public int DeptNo { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
    }
}
