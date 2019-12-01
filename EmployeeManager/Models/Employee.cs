using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string EmployeeFirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmployeeEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [DisplayName("Employee DOB")]
        public DateTime EmployeeBirthDate { get; set; } = DateTime.Now;

        [Required]
        public string EmployeeDepartment { get; set; }
    }
}
