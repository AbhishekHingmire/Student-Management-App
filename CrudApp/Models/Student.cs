using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApp.Models
{
    public class Student
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Required")] // This is called as DataAnnotations used for data validation
        [DisplayName("Student Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Father's Name")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Contact")]
        public string Mobile { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        [NotMapped]
        public string Department { get; set; }//We'll get and bind this property from DEpt table by using DeptID

    }
}
