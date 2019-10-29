
using System.ComponentModel.DataAnnotations;
namespace Lexical.Models
{
    public class Word
    {
        public int WordId { get; set; }
        [Required]
        [StringLength (20)]
        public string Name { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "The rating must be between 1-5")]
        public double Rating {get; set ;}

        public int RatingCount { get; set; }
       
    }
}