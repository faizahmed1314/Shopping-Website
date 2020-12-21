using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Cart
    {
        public Cart()
        {
            CreatedDate = DateTime.Now;
            Items = new HashSet<CartItem>();
           
        }
        [Key]
        public int CartId { get; set; }
        public decimal Total { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
    }
}
