using System;
using System.ComponentModel.DataAnnotations;

namespace NikahMetromoniApp.Models
{
    public class RegistrationViewModel
    {
        public string Id { get; set; }
        public string UserRole { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNo { get; set; }
        public string Address { get; set; } 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Religion { get; set; }
        public string Complexion { get; set; }
        public bool AnyDisability { get; set; }
        public string BloodGroup { get; set; }
        public string HigherDegree { get; set; }
        public string Profession { get; set; }
        public string Nationality { get; set; }
        public Division Division { get; set; }
        public int? DivisionId { get; set; }
        public District District { get; set; }
        public int? DistrictId { get; set; }
        public Upozila Upozila { get; set; }
        public int? UpozilaId { get; set; }
        public string Description { get; set; }
        public string Otp { get; set; }
        public string DivisionName { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
    }
}