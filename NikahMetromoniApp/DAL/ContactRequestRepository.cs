using System.Data.Entity;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.DAL
{
    public class ContactRequestRepository: Repository<ContactRequest>
    {
        public ContactRequestRepository(DbContext context) : base(context)
        {
        }
    }
}