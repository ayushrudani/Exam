using System.ComponentModel.DataAnnotations;

namespace APIDemo.Models
{

    public class EmployeeModel
    {
        public int? EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmpCode { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Salary { get; set; }

    }
}
