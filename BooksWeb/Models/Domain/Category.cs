using System.ComponentModel.DataAnnotations;

namespace BooksWeb.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateCategory { get; set; } = DateTime.Now;

    }
}
