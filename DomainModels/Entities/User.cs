using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            Roles = new HashSet<Role>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName="varchar")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string ContactNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }


    }
}
