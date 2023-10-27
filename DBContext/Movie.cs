using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPITestBE.DBContext
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "The Title cannot be empty.")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description movie cannot be empty")]
        [StringLength(350)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rating cannot be empty")]
        public float Rating { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; }
    }
}
