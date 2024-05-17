using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medico.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string iMGuRL { get; set; }
        public string ImgUrl { get; internal set; }
        [NotMapped]
        public IFormFile ImgFile
        {
            get; set;
        }
    }
}
