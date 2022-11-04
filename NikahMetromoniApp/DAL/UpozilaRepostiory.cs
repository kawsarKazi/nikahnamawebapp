using NikahMetromoniApp.Models;
using System.Data.Entity;

namespace NikahMetromoniApp.DAL
{
    public class UpozilaRepostiory : Repository<Upozila>
    {
        public UpozilaRepostiory(DbContext context) : base(context)
        {
        }
    }
}