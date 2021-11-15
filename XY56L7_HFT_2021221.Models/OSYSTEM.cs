using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XY56L7_HFT_2021221.Models
{
    [Table("OSYSTEM")]
    public class OSYSTEM
    {
        [Key]
        
        public int OSId { get; set; }
        
       
        [MaxLength(120)]
        public string OS { get; set; }
        //What is the level on a scale of 10 to hack the phone?

        public int security_level { get; set; }

        [NotMapped]
        public string AllData => $"OSID:{OSId},  OS: {OS}" +
            $"  ";
        public virtual ICollection<Phone> Phones_OS { get; set; }
        public OSYSTEM()
        {
            Phones_OS = new HashSet<Phone>();
        }


    }
}
