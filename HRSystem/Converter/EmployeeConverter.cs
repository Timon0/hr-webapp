using HRSystem.Models;
using HRSystem.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Converter
{
    public class EmployeeConverter
    {
        public EmployeeConverter()
        {

        }

        /// <summary>
        /// Convert Employee into EmployeeDto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>EmployeeDto to display on the view</returns>
        public Employee fromDto(EmployeeDto dto)
        {
            if(dto == null)
            {
                return null;
            }

            var employee = new Employee();
            employee.EmployeeId = dto.EmployeeId;
            employee.Firstname = dto.Firstname;
            employee.Lastname = dto.Lastname;
            employee.Birthday = dto.Birthday;
            employee.Salary = dto.Salary;
            employee.Address = dto.Address;
            employee.FkDepartment = dto.FkDepartment;
            employee.FkPlace = dto.FkPlace;
            employee.FkBoss = dto.FkBoss;
            employee.Department = dto.Department;
            employee.Employee1 = dto.Employees;
            employee.Employee2 = dto.Boss;
            employee.Place = dto.Place;
            employee.Project = dto.Project.Where(project => dto.FkProject.Contains(project.ProjectId)).ToList();
            return employee;
        }

        /// <summary>
        /// Convert EmployeeDto into Employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Employee to write to database</returns>
        public EmployeeDto toDto(Employee entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = new EmployeeDto();
            dto.EmployeeId = entity.EmployeeId;
            dto.Firstname = entity.Firstname;
            dto.Lastname = entity.Lastname;
            dto.Birthday = entity.Birthday;
            dto.Salary = entity.Salary;
            dto.Address = entity.Address;
            dto.FkDepartment = entity.FkDepartment;
            dto.FkPlace = entity.FkPlace;
            dto.FkBoss = entity.FkBoss;
            dto.Department = entity.Department;
            dto.Employees = entity.Employee1;
            dto.Boss = entity.Employee2;
            dto.Place = entity.Place;
            dto.Project = entity.Project;
            dto.FkProject = entity.Project.Select(project => project.ProjectId).ToList();
            return dto;
        }
    }
}