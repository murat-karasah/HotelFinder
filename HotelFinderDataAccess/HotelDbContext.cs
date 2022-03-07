using HotelFinderEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderDataAccess
{
   public class HotelDbContext:DbContext
    {
        public DbSet<Hotel> Holtes{ get; set; }
    }
}
