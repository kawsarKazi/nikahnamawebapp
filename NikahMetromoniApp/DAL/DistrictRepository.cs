using NikahMetromoniApp.Models;
using System.Data.Entity;

namespace NikahMetromoniApp.DAL
{
    public class DistrictRepository : Repository<District>
    {
        public DistrictRepository(DbContext context) : base(context)
        {
        }
    }
}