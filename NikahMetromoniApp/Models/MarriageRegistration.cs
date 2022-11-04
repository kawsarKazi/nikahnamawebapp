using System;

namespace NikahMetromoniApp.Models
{
    public class MarriageRegistration
    {
        public long Id { get; set; }
        public string GroomName { get; set; }
        public string GroomFatherName { get; set; }
        public string GroomIdentity { get; set; }
        public string BrideName { get; set; }   
        public string BrideFatherName { get; set; }
        public string BrideIdentity { get; set; }
        public string RegisterVolumeNo { get; set; }    
        public string PageNo { get; set; }
        public string FilePath { get; set; }
        public string UserId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal AmountOfDower { get; set; }
        public string Address { get; set; }
        public int DownloadPermission { get; set; } 
    }
}