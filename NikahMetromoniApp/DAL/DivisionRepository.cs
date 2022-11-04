using NikahMetromoniApp.Models;
using System.Data.Entity;

namespace NikahMetromoniApp.DAL
{
    public class DivisionRepository : Repository<Division>
    {
        public DivisionRepository(DbContext context) : base(context)
        {
        }
    }
}