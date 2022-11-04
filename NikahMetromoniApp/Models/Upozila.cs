namespace NikahMetromoniApp.Models
{
    public class Upozila
    {
        public int Id { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; }

        public string NameBangla { get; set; }
        public string NameEnglish { get; set; }

        public string Code { get; set; }
    }
}