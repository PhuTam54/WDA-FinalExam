using FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam.Models.DepartmentViewModels
{
    public class DepartmentIndexData
{
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}