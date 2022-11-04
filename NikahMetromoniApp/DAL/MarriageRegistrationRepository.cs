using System.Data.Entity;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.DAL
{
    public class MarriageRegistrationRepository: Repository<MarriageRegistration>
    {
        public MarriageRegistrationRepository(DbContext context) : base(context)
        {
        }
    }
}