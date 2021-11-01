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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneId { get; set; }

        [ForeignKey(nameof(OSYSTEM))]
        public int OSId { get; set; }
        [NotMapped]
        public string AllData => $"BrandID:{BrandId},  PhoneID: {PhoneId}" +
            $"OSId : {OSYSTEM} ";
        [NotMapped]
        public virtual Brand Brand { get; set; }
        public virtual OSYSTEM OSYSTEM { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
    }
}
