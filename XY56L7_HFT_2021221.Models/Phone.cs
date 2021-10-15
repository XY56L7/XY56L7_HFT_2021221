using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY56L7_HFT_2021221.Models
{
    //comment
    [Table("Phones")]
    public class Phone
    {
        [Key]
        public int CommentId { get; set; }
        
        [MaxLength(120)]
        public string Content { get; set; }
        
        [NotMapped]
        public virtual Brand Brand { get; set; }
        
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
    }
}
