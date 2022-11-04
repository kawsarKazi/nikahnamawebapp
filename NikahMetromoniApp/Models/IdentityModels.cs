using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NikahMetromoniApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string RequestId { get; set; }       
        public string UserRole { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Complexion { get; set; }
        public bool AnyDisability { get; set; }
        public string BloodGroup { get; set; }
        public string HigherDegree { get; set; }
        public string Profession { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public Division Division { get; set; }
        public int? DivisionId { get; set; }
        public District District { get; set; }
        public int? DistrictId { get; set; }
        public Upozila Upozila { get; set; }
        public int? UpozilaId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public string DivisionName { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }

        public string Address { get; set; }
        public string LicenseNo { get; set; }   


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<MarriageRegisterDocument> MarriageRegisterDocuments { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<MarriageRegistration> MarriageRegistrations { get; set; }
        public DbSet<DivorceRegistration> DivorceRegistrations { get; set; }    
    }
}