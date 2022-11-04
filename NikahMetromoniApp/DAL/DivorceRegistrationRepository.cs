using System.Data.Entity;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.DAL
{
    public class DivorceRegistrationRepository: Repository<DivorceRegistration>
    {
        public DivorceRegistrationRepository(DbContext context) : base(context)
        {
        }
    }
}