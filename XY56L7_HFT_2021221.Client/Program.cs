using System;
using System.Collections.Generic;
using System.Linq;

using XY56L7_HFT_2021221.Models;



namespace XY56L7_HFT_2021221.Client
{
    
    class Program
    {
        static void Main(string[] args)
        {
            RestService ss = new RestService("http://localhost:15113");

            var brands = ss.Get<Brand>("brand");
            ;
            //PhoneDbContext db = new PhoneDbContext();
            //PhoneRepository phoneRepo = new PhoneRepository(db);
            //OSYSTEM Android = new Models.OSYSTEM() { OSId = 100, OS = "Android" };
            //Brand Samsung = new Brand() { BrandId = 33, Category = "Okos telefon", Rating = 6 };
            //Phone P40 = new Phone() {  OSId = Android.OSId, BrandId = Samsung.BrandId };
            //phoneRepo.Create(P40);
            //var dataz = phoneRepo.ReadAll();
            //BrandLogic cl = new BrandLogic(new BrandRepository(db));
            //var q = cl.AVGRating();
            //PhoneLogic cc = new PhoneLogic(new PhoneRepository(db));
            //var t = cc.AVGRating();
            ////var data = db.Phones.ToArray();
            

            

             

            //Console.ReadLine();

        }
    }
}
