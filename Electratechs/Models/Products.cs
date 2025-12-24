using System.ComponentModel.DataAnnotations.Schema;

namespace Electratechs.Models
{
    [Table("products")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("categoryid")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Column("brandid")]
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        // many-to-many
        public ICollection<ProductAccessory> ProductAccessories { get; set; } = new List<ProductAccessory>();
    }
}
