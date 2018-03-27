using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSystem.Data.Repositories.Interface;
using HRSystem.Data.Repositories.Implementation;

namespace HRSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRSystemEntities context;

        public UnitOfWork(HRSystemEntities context)
        {
            this.context = context;
            Departments = new DepartmentRepository(this.context);
        }

        public IDepartmentRepository Departments { get; private set; }

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