using System.ComponentModel.DataAnnotations;

namespace AshutoshTest.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Short Name is required")]
        public string ShortName { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public string Gender { get; set; }
        //public string LanguageKnown { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public bool EnglishKnown { get; set; }
        public bool HindiKnown { get; set; }
        public bool GujaratiKnown { get; set; }
    }
}
