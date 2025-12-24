using System.ComponentModel.DataAnnotations.Schema;

namespace Electratechs.Models
{
    [Table("accessories")]
    public class Accessory
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        // many-to-many
        public ICollection<ProductAccessory> ProductAccessories { get; set; } = new List<ProductAccessory>();
    }
}
