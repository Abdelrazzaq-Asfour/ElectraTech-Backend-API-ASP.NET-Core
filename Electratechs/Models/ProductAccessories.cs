using System.ComponentModel.DataAnnotations.Schema;

namespace Electratechs.Models
{
    [Table("productaccessories")]
    public class ProductAccessory
    {
        [Column("productid")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Column("accessoryid")]
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
    }
}
