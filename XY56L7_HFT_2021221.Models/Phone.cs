using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XY56L7_HFT_2021221.Models
{
   
    //comment
    [Table("Phones")]

    public class Phone
    {
        [Key]
        

        public int PhoneId { get; set; }

        [Required]
        [ForeignKey(nameof(OSYSTEM))]
     
        public int OSId { get; set; }
        public string PhoneName { get;set; }
        //[NotMapped]
        //[JsonIgnore]
        //public string MainData => $"PhoneId: {PhoneId} : OsId: {OSId} : BrandId : {BrandId} : Break_level : {break_level}";
      
        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual OSYSTEM OSYSTEM { get; set; }

        [ForeignKey(nameof(Brand))]
       
        public int BrandId { get; set; }
        //What is the level on a scale of 10 that if u drop ur phone on the ground, it will break easily
       
        public int break_level { get; set; }

        
    }
}
