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
        public EmployeeRepository(HRSystemEntities context) : base(context)
        {
        }
    }
}