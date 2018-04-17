using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSystem.Data.Repositories.Interface;
using HRSystem.Data.Repositories.Implementation;
using HRSystem.Models;

namespace HRSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRSystemEntities context;

        public UnitOfWork(HRSystemEntities context)
        {
            this.context = context;
            Departments = new DepartmentRepository(this.context);
            Projects = new ProjectRepository(this.context);
            Employees = new EmployeeRepository(this.context);
            Places = new PlaceRepository(this.context);
        }

        public IDepartmentRepository Departments { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IPlaceRepository Places { get; private set; }



        public int Complete()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}