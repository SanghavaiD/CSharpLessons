using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMCPApp.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { set; get; }
        [StringLength(25, ErrorMessage = "Title must not have more than 25 chars")]
        [MinLength(3, ErrorMessage = "Title must have at least 3 chars")]
        [Required(ErrorMessage = "Title is Required")]
        public String AuthorName { set; get; }
        [Required(ErrorMessage = "Author Name is Required")]
        public DateTime AuthorDob { set; get; }
        public float NumberofBooks { set; get; }
        [StringLength(25, ErrorMessage = "Books must not have more than 25 chars")]
        [MinLength(3, ErrorMessage = "Books must have at least 3 chars")]
        [Required(ErrorMessage = "Books is Required")]
        public String RoyaltyCompany { set; get; }
    }
}


