using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Department
    {
      
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        public int MaxEmployees { get; set; }
       
    }
}
