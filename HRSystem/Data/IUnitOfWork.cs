using HRSystem.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        IProjectRepository Projects { get; }
        IPlaceRepository Places { get; }

        int Complete();
    }
}