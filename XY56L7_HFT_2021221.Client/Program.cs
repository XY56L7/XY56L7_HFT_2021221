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
            #region INIT
            Brand Iphone = new Brand() { Category = "Okos telefon", Rating = 8};

            Brand Samsung = new Brand() {Category = "Okos telefon",Rating = 6 };
            Brand Huawei = new Brand() { Category = "Okos telefon", Rating = 7 };
            Brand Motorola = new Brand() { Category = "Gombos telefon", Rating = 2 };
            db.Brands.Add(Iphone);
            db.Brands.Add(Samsung);
            db.Brands.Add(Huawei);
            db.Brands.Add(Motorola);
            #endregion

            //Minden elem listazas
            Console.WriteLine("\n:: ALL RECORDS ::\n");
            db.Brands
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.AllData}"));
        }
    }
}
