using System;
using System.Collections.Generic;
using System.Linq;
using XY56L7_HFT_2021221.Data;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.Repository;


namespace XY56L7_HFT_2021221.Client
{
    
    class Program
    {
        static void Main(string[] args)
        {

            PhoneDbContext db = new PhoneDbContext();
            PhoneRepository phoneRepo = new PhoneRepository(db);
            OSYSTEM Android = new Models.OSYSTEM() { OSId = 100, OS = "Android" };
            Brand Samsung = new Brand() { BrandId = 33, Category = "Okos telefon", Rating = 6 };
            Phone P40 = new Phone() { PhoneId = 6, OSId = Android.OSId, BrandId = Samsung.BrandId };
            phoneRepo.Create(P40);
            var dataz = phoneRepo.ReadAll();
            
            //var data = db.Phones.ToArray();
            ;

            

             

            Console.ReadLine();

        }
    }
}
