using System.ComponentModel.DataAnnotations.Schema;

namespace Electratechs.Models
{
    [Table("brands")]
    public class Brand
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("logo")]
        public string? Logo { get; set; }

        // one-to-many
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
