using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY56L7_HFT_2021221.Models
{
    //blog
    [Table("Brands")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        
        

        [MaxLength(100)]
        public string Category { get; set; }

        [NotMapped]
        public string AllData => $"{BrandId}  : {Category}" +
            $" : {Rating} : {Phones.Count()}";
        
        public int? Rating { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
        public Brand()
        {
            Phones = new HashSet<Phone>();
        }

    }
}
