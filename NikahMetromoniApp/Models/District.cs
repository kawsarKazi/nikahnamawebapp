namespace NikahMetromoniApp.Models
{
    public class District
    {
        public int Id { get; set; }

        public Division Division { get; set; }
        public int DivisionId { get; set; }

        public string NameBangla { get; set; }
        public string NameEnglish { get; set; }

        public string Code { get; set; }
    }
}
