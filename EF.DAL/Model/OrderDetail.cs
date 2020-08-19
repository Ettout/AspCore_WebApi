using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.DAL.Model
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ItemID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int OrderID { get; set; }

        [Range(1, 100)]
        public int Count { get; set; }

        public decimal SalePrice { get; set; }

        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
    }
}
