using System.ComponentModel.DataAnnotations;

namespace BornaCvitanicPortfolioWebapp.Models.Portfolio
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
