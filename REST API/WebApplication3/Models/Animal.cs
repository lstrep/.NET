using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Services
{
    public class Animal
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Length cannod exceed 200")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MaxLength(200, ErrorMessage = "Length cannod exceed 200")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [MaxLength(200, ErrorMessage = "Length cannod exceed 200")]
        public string Area { get; set; }
    }
}