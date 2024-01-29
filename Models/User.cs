using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models
{
    public class User
    {
        public int ID { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }
        [StringLength(255)]
        public string EmployeeCode { get; set; }

        [StringLength(50)]
        public string Rank { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstMidName + " " + LastName;
            }
        }

        public Department Department { get; set; }
    }
}