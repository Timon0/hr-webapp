using HRSystem.Data.Repositories.Interface;
using HRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Data.Repositories.Implementation
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(HRSystemEntities context) : base(context)
        {
        }
    }
}