using HRSystem.Data.Repositories.Interface;
using HRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Data.Repositories.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private HRSystemEntities context;

        public EmployeeRepository(HRSystemEntities context) : base(context)
        {
            this.context = context;
        }

        public override void Update(Employee employee)
        {
            // Get existing data from database
            var existingEmployee = context.Employee.Include("Project").SingleOrDefault(e => e.EmployeeId == employee.EmployeeId);
            var newProjects = employee.Project.ToList();

            // Update employee
            context.Entry(existingEmployee).CurrentValues.SetValues(employee);

            // Clear all projects
            existingEmployee.Project.Clear();

            // Add selected projects
            foreach (var newProject in newProjects)
            {
                existingEmployee.Project.Add(newProject);
            }
        }
    }
}