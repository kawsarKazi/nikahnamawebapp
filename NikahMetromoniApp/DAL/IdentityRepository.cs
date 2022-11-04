using NikahMetromoniApp.Models;
using System.Collections.Generic;
using System.Data;
using NikahMetromoniApp.ViewModels;

namespace NikahMetromoniApp.DAL
{
    public class IdentityRepository
    {
        private readonly GenericRepository _genericRepository;
        private readonly ApplicationDbContext _dbContext;

        public IdentityRepository()
        {
            _genericRepository = new GenericRepository();
            _dbContext = new ApplicationDbContext();
        }


        // Role
        public bool UpdateRole(string id, string name, string description)
        {
            var query = "UPDATE AspNetRoles SET Name ='" + name + "', Description ='" + description + "' WHERE Id = '" + id + "'";
            var rowAffected = _genericRepository.ExecuteNonQuery(query, GenericRepository.ConnectionString());
            return rowAffected > 0;
        }

        // User
        public bool UpdateUser(string id, RegistrationViewModel model)
        {

            var query = "Update AspNetUsers set BirthDate='" + model.BirthDate + "', MaritalStatus='" + model.MaritalStatus + "', Age='" + model.Age + "',Height='" + model.Age + "', " +
                        "Complexion='" + model.Complexion + "', AnyDisability='" + model.AnyDisability + "', BloodGroup='" + model.BloodGroup + "',HigherDegree='" + model.HigherDegree + "', " +
                        "Profession='" + model.Profession + "', Nationality='" + model.Nationality + "', DistrictId=" + model.DistrictId + ", DivisionId=" + model.DivisionId + ", UpozilaId=" + model.UpozilaId + ", " +
                        "Description='" + model.Description + "' where Id='" + id + "'";
            var rowAffected = _genericRepository.ExecuteNonQuery(query, GenericRepository.ConnectionString());
            return rowAffected > 0;
        }

        // User
        public bool UpdateUserStatus(string id, int status)
        {

            var query = "Update AspNetUsers set Status='" + status + "' where Id='" + id + "'";
            var rowAffected = _genericRepository.ExecuteNonQuery(query, GenericRepository.ConnectionString());
            return rowAffected > 0;
        }

        public bool UpdateMarriageRegister(string id, MarriageRegisterEditViewModel model)
        {

            var query = "UPDATE AspNetUsers SET FirstName='"+model.FirstName+ "', LastName='" + model.LastName + "', Gender='" + model.Gender + "', PhoneNumber='" + model.ContactNo + "', Religion='" + model.Religion + "', DivisionName='" + model.DivisionName + "', CityName='" + model.CityName + "', AreaName='" + model.AreaName + "' where Id='" + id + "'";
            var rowAffected = _genericRepository.ExecuteNonQuery(query, GenericRepository.ConnectionString());
            return rowAffected > 0;
        }

        public bool De_ActiveUser(string id)
        {
            var query = "UPDATE AspNetUsers SET Status=" + 0 + " WHERE Id= '" + id + "'";
            var rowAffected = _genericRepository.ExecuteNonQuery(query, GenericRepository.ConnectionString());
            return rowAffected > 0;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return (IEnumerable<ApplicationUser>)_dbContext.Users;
        }

        // User Role
        public DataTable GetUserRole()
        {
            const string query = "SELECT ur.UserId, ur.RoleId, u.UserName, r.Name AS RoleName FROM AspNetUserRoles ur " +
                                 "LEFT JOIN AspNetUsers u ON u.Id= ur.UserId LEFT JOIN AspNetRoles r ON r.Id= ur.RoleId";
            var dataAdapter = _genericRepository.ExecuteAdapter(query, GenericRepository.ConnectionString());
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        
    }
}