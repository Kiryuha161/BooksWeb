using System.ComponentModel.DataAnnotations;

namespace BooksWeb.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Поле \"Название\" обязательно к заполнению")]
        [Display(Name="Название")]
        public string Name { get; set; }
        [Display(Name="Порядковый номер")]
        [Range(1, 100, ErrorMessage = "Порядковый номер может находится только между 1 и 100")]
        [Required(ErrorMessage = "Поле \"Порядковый номер\" обязательно к заполнению")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateCategory { get; set; } = DateTime.Now;

    }
}
