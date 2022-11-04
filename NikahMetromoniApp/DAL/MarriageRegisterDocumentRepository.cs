using System.Data.Entity;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.DAL
{
    public class MarriageRegisterDocumentRepository: Repository<MarriageRegisterDocument>
    {
        public MarriageRegisterDocumentRepository(DbContext context) : base(context)
        {
        }
    }
}