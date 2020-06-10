using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest.Models
{
    public class Employee
    {
        [Key]
        public int EID { set; get; }
        [Required]
        [MaxLength(50)]
        [Display(Name="First Name")]
        [MinLength(4,ErrorMessage = "At Least 5 Character")]
        public String First_Name { set; get; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [MinLength(4,ErrorMessage ="At Least 5 Character")]
        public String Last_Name { set; get; }
        [Required]
        [MaxLength(10)]
        public String Designation { set; get; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Join Date")]
        public String Join_Date { set; get; }
        [Display(Name = "Current Salary")]
        public Double Current_Salary { set; get; }
        [Required]
        [MaxLength(10)]
        public String Department { set; get; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Next Review Date")]
        public String Next_Review_Date { set; get; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Date Of Birth")]
        public String Date_Of_Birth { set; get; }
        [Required]
        [MaxLength(10)]
        public String Gender { set; get; }

        /// <summary>
        /// If You Want to Add a New Field Cut The [NotMapped] Attribute And Run The Migration Command Again
        /// </summary>

        [NotMapped]
        [MaxLength(20)]
        public String NewFiled { set; get; }

    }
}
