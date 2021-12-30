﻿using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using XY56L7_HFT_2021221.Data;

using XY56L7_HFT_2021221.Models;


namespace XY56L7_HFT_2021221.Client
{
    
    class Program
    {
        static void Main(string[] args)
        {
            RestService ss = new RestService("http://localhost:15113");

       

            PhoneDbContext ctx = new PhoneDbContext();
            Console.WriteLine(ctx.Phones.Count());
            
         

 


        


            var menu = new ConsoleMenu()
                .Add(">> LIST ALL", () => ListAll(ss))
                .Add(">> GET BY ID", () => GetById(ss))
                 .Add(">> CREATE", () => Create(ss))
                 .Add(">> UPDATE", () => Update(ss))
                 .Add(">> DELETE", () => Delete(ss))
                 .Add(">> AVERAGE RATING AT PHONE", () => AVGRATING(ss))
                 .Add(">> AVERAGE RATING AT BRAND", () => AVGRATINGBRAND(ss))
                 .Add(">> BEST RATING AT BRAND", () => BestRatingBrand(ss))
                 .Add(">> WORST RATING AT BRAND", () => WorstRatingBrand(ss))
                 .Add(">> WORST TRUSTING LEVEL AT BRAND", () => WorstTrustingLevel(ss))
                 .Add(">> BEST RATING AT BRAND", () => BestRatingBrand(ss))
                 .Add(">> NUMBER OF BRANDs", () => Count(ss))
                .Add(">> EXIT", ConsoleMenu.Close);
            menu.Show();
        }
        private static void ListAll(RestService ss) 
        {
            Console.WriteLine("[1] BRAND [2] PHONE [3] OSYSTEM");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("\n:: ALL BRANDS::\n");
                foreach (var item in ss.Get<Brand>("brand"))
                {
                    Console.WriteLine(item.AllData);
                }
                Console.ReadLine();
            }
            else if (ans == 2)
            {
                Console.WriteLine("\n:: ALL PHONES::\n");
                foreach (var item in ss.Get<Phone>("phone"))
                {
                    Console.WriteLine(item.MainData);
                }
                Console.ReadLine();
            }
            else if (ans == 3)
            {
                Console.WriteLine("\n:: ALL OSYSTEM::\n");
                foreach (var item in ss.Get<OSYSTEM>("osystem"))
                {
                    Console.WriteLine(item.AllData);
                }
                Console.ReadLine();
            }

        }
        private static void GetById(RestService ss)
        {
            Console.WriteLine("[1] BRAND [2] OSYSTEM [3] PHONE");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("ENTER ID HERE: ");
                int id = int.Parse(Console.ReadLine());


                Console.WriteLine(ss.Get<Brand>(id, "brand").AllData);
                Console.WriteLine("\n:: SELECTED BRAND :: \n");

                Console.ReadLine();
            }
            else if (ans == 2)
            {
                Console.WriteLine("ENTER ID HERE: ");
                int id = int.Parse(Console.ReadLine());


                Console.WriteLine(ss.Get<OSYSTEM>(id, "osystem").AllData);
                Console.WriteLine("\n:: SELECTED BRAND :: \n");

                Console.ReadLine();
            }
            else if (ans == 3)
            {
                Console.WriteLine("ENTER ID HERE: ");
                int id = int.Parse(Console.ReadLine());


                Console.WriteLine(ss.Get<Phone>(id, "phone").MainData);
                Console.WriteLine("\n:: SELECTED PHONES :: \n");

                Console.ReadLine();
            }

        }
        private static void Create(RestService ss)
        {
            Console.WriteLine("[1] BRAND [2] PHONE [3] OSYSTEM");
            Console.WriteLine("From BrandID, CHOOSE FROM THESE: 22,33,44,55,66");
            Console.WriteLine("FROM OSID, CHOOSE FROM THESE: 100,101,102");
            int anss = int.Parse(Console.ReadLine());
            if (anss == 1)
            {
                Console.WriteLine("Category: ");
                string ans = Console.ReadLine();
                Console.WriteLine("Rating: ");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine("Trust level: ");
                int o = int.Parse(Console.ReadLine());
                Brand newbrand = new Brand() { Category = ans, Rating = z, trust_level = o };
                ss.Post<Brand>(newbrand, "brand");
                Console.WriteLine("\n:: ALL BRANDS::\n");
                foreach (var item in ss.Get<Brand>("brand"))
                {
                    Console.WriteLine(item.AllData);
                }
                Console.WriteLine("Mission Completed");
                Console.ReadLine();
            }
            else if (anss == 2)
            {


                Console.WriteLine("Break level: ");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine("BrandID: ");
                int o = int.Parse(Console.ReadLine());
                Console.WriteLine("OSID: ");
                int a = int.Parse(Console.ReadLine());
                Phone newphone = new Phone() { break_level = z,BrandId=o, OSId=a};
                ss.Post<Phone>(newphone, "phone");
                Console.WriteLine("\n:: ALL PHONES::\n");
                foreach (var item in ss.Get<Phone>("phone"))
                {
                    Console.WriteLine(item.MainData);
                }
                Console.WriteLine("Mission Completed");
                Console.ReadLine();
            }
            else if (anss == 3)
            {
                Console.WriteLine("Category: ");
                string ans = Console.ReadLine();
                Console.WriteLine("Rating: ");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine("Trust level: ");
                int o = int.Parse(Console.ReadLine());
                OSYSTEM newbrand = new OSYSTEM() { OS=ans,security_level=z};
                ss.Post<OSYSTEM>(newbrand, "osystem");
                Console.WriteLine("\n:: ALL OSYSTEMS::\n");
                foreach (var item in ss.Get<OSYSTEM>("osystem"))
                {
                    Console.WriteLine(item.AllData);
                }
                Console.WriteLine("Mission Completed");
                Console.ReadLine();
            }

        }
        private static void Delete(RestService ss) 
        {
            Console.WriteLine("[1] BRAND [2] PHONE [3] OSYSTEM");
            Console.WriteLine("From BrandID, CHOOSE FROM THESE: 22,33,44,55,66");
            Console.WriteLine("FROM OSID, CHOOSE FROM THESE: 100,101,102");
            int anss = int.Parse(Console.ReadLine());
            if (anss == 1)
            {
                Console.WriteLine("Enter an ID");
                int id = int.Parse(Console.ReadLine());
                ss.Delete(id, "brand");
                Console.WriteLine("Row has been deleted");
            }
            else if (anss == 2)
            {
                Console.WriteLine("Enter an ID");
                int id = int.Parse(Console.ReadLine());
                ss.Delete(id, "phone");
                Console.WriteLine("Row has been deleted");
            }
            else if (anss == 3)
            {
                Console.WriteLine("Enter an ID");
                int id = int.Parse(Console.ReadLine());
                ss.Delete(id, "osystem");
                Console.WriteLine("Row has been deleted");
            }


        }
        private static void Update(RestService ss) 
        {
            Console.WriteLine("[1] BRAND [2] PHONE [3] OSYSTEM");
            Console.WriteLine("From BrandID, CHOOSE FROM THESE: 22,33,44,55,66");
            Console.WriteLine("FROM OSID, CHOOSE FROM THESE: 100,101,102");
            int anss = int.Parse(Console.ReadLine());
            if (anss == 1)
            {
                Console.WriteLine("ID: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Category: ");
                string cat = Console.ReadLine();
                Console.WriteLine("Trust level: ");
                int tl = int.Parse(Console.ReadLine());
                Console.WriteLine("Rating");
                int r = int.Parse(Console.ReadLine());
                Brand cl = new Brand() { Category = cat, BrandId = a, trust_level = tl, Rating = r };
                ss.Put<Brand>(cl, "brand");
                Console.WriteLine("Mission Completed");
                Console.ReadLine();
            }
            else if (anss == 2)
            {

                Console.WriteLine("PhoneId: ");
                int e = int.Parse(Console.ReadLine());
                Console.WriteLine("Break level: ");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine("BrandID: ");
                int o = int.Parse(Console.ReadLine());
                Console.WriteLine("OSID: ");
                int a = int.Parse(Console.ReadLine());
                Phone newphone = new Phone() { PhoneId=e, break_level = z, BrandId = o, OSId = a };
                ss.Put<Phone>(newphone, "phone");
                Console.WriteLine("Mission Completed");
      
                Console.ReadLine();
            }
            else if (anss == 2)
            {

                Console.WriteLine("PhoneId: ");
                int e = int.Parse(Console.ReadLine());
                Console.WriteLine("Break level: ");
                int z = int.Parse(Console.ReadLine());
                Console.WriteLine("BrandID: ");
                int o = int.Parse(Console.ReadLine());
                Console.WriteLine("OSID: ");
                int a = int.Parse(Console.ReadLine());
                Phone newphone = new Phone() { PhoneId = e, break_level = z, BrandId = o, OSId = a };
                ss.Put<Phone>(newphone, "phone");
                Console.WriteLine("Mission Completed");

                Console.ReadLine();
            }
            else if (anss == 3)
            {
                Console.WriteLine("OS: ");
                string ans = Console.ReadLine();
                Console.WriteLine("OSID");
                int el = int.Parse(Console.ReadLine());
                Console.WriteLine("Security level: ");
                int o = int.Parse(Console.ReadLine());
                OSYSTEM newbrand = new OSYSTEM() { OSId=el, OS = ans, security_level = o };
                ss.Put<OSYSTEM>(newbrand, "osystem");
                Console.WriteLine("Mission Completed");
        
                Console.ReadLine();
            }



        }
        private static void AVGRATING(RestService ss) 
        {
            double date = ss.GetSingle<double>("stat/avgrating");
            Console.WriteLine($"Average rating at phones: {date}");
            Console.ReadLine();
            
        }
        private static void AVGRATINGBRAND(RestService ss)
        {
            double date = ss.GetSingle<double>("stat/avgratingbrand");
            Console.WriteLine($"Average rating at brands: {date}");
            Console.ReadLine();

        }
        private static void BestRatingBrand(RestService ss)
        {
            double date = ss.GetSingle<double>("stat/bestrating");
            Console.WriteLine($"Best rating at brands: {date}");
            Console.ReadLine();

        }
        private static void WorstRatingBrand(RestService ss)
        {
            double date = ss.GetSingle<double>("stat/worstrating");
            Console.WriteLine($"Worst rating at brands: {date}");
            Console.ReadLine();



        }
        
       
    }
}
