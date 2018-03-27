using HRSystem.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Data.Repositories.Implementation
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HRSystemEntities context) : base(context)
        {
        }
    }
}