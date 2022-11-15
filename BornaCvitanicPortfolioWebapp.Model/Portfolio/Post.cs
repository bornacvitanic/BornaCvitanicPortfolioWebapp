using System.ComponentModel.DataAnnotations;

namespace BornaCvitanicPortfolioWebapp.Model.Portfolio
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
