using System.ComponentModel.DataAnnotations;
using VCinema.Data.Base;

namespace VCinema.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        // Relationships
        public List<Movie> Movies { get; set; }
    }
}
