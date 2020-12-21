using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Transaction
    {
        public Transaction()
        {
            CreatedDate = DateTime.Now;
            

        }
        [Key]
        public string TransactionId { get; set; }
        public string PaymentId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Status { get; set; }
   
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
