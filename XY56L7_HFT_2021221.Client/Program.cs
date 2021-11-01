using System;
using System.Linq;
using XY56L7_HFT_2021221.Data;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            PhoneDbContext db = new PhoneDbContext();
            var sor = db.Phones.ToArray();
            ;
            

            
            
        }
    }
}
