using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]

        public ICollection<Product> Products { get; set; }

    }
}
