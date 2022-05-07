using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XY56L7_HFT_2021221.Models
{
    //class ToStringAttribute : Attribute
    //{

    //}
    //blog
    [Table("Brands")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        //What is the level on a scale of 10 that the phone will go bad in the future?
        //[ToString]
        public int trust_level { get; set; }

        [MaxLength(100)]
        //[ToString]
        public string Category { get; set; }
        [MaxLength(100)]
        //[ToString]
        public string BrandName { get; set; }

        //[NotMapped]
        //public string AllData => $"{BrandId} : {BrandName} : {Category}" +
        //    $" : {Rating} : {trust_level} : {Phones.Count()}";
        //[ToString]
        public int Rating { get; set; }
       
        [NotMapped]
        public virtual ICollection<Phone> Phones { get; set; }

        public Brand()
        {
            Phones = new HashSet<Phone>();
            Rating = 5;
            trust_level = 5;
            Category = "csodafon";
        }
        
        
    }
}
