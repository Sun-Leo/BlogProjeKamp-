using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace BlogProjeKampı.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool WriterStatus { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }



    }
}
