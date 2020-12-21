using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Order
    {
        public Order()
        {
            CreatedDate = DateTime.Now;
            Items = new HashSet<OrderItem>();

        }
        [Key]
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Customer { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string ContactNo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Status { get; set; }
       
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string ShippingAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
