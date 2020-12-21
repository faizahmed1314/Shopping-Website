using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Product
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
            
        }
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Name { get; set; }

        

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string ImageName { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}
