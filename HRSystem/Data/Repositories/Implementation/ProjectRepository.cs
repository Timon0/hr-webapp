using HRSystem.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Data.Repositories.Implementation
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(HRSystemEntities context) : base(context)
        {
        }
    }
}