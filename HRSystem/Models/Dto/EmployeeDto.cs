using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRSystem.Models.Dto
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            this.FkProject = new HashSet<int>();
            this.Project = new HashSet<Project>();
        }

        public int EmployeeId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime Birthday { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Address { get; set; }
        [Required]
        public int FkDepartment { get; set; }
        [Required]
        public int FkPlace { get; set; }
        public Nullable<int> FkBoss { get; set; }
        public ICollection<int> FkProject { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        [Display(Name = "Boss")]
        public virtual Employee Boss { get; set; }
        public virtual Place Place { get; set; }
        [Display(Name = "Projects")]
        public virtual IEnumerable<Project> Project { get; set; }
    }
}