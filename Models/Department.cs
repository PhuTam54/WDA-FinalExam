using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models;

public class Department
{
    public int DepartmentId { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? DepartmentName { get; set; }

    [StringLength(50)]
    [Required]
    public string? DepartmentCode { get; set; }

    [StringLength(255)]
    [Required]
    public string? Location { get; set; }

    public int NumberOfEmployees { get; set; }

    public ICollection<User> Users { get; set; }
}