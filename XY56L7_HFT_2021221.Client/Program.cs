using ConsoleTools;
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
            //RestService ss = new RestService("http://localhost:15113");

            //var brands = ss.Get<Brand>("brand");
            //;

            PhoneDbContext ctx = new PhoneDbContext();
            Console.WriteLine(ctx.Phones.Count());
            
            BrandRepository repo = new BrandRepository(ctx);
            BrandLogic logic = new BrandLogic(repo);



            var menu = new ConsoleMenu()
                .Add(">> LIST ALL", () => ListAll(logic))
                .Add(">> GET BY ID", () => GetById(logic))
                
                .Add(">> EXIT", ConsoleMenu.Close);
            menu.Show();
        }
        private static void ListAll(BrandLogic logic) 
        {
            Console.WriteLine("\n:: ALL PHONES::\n");
            logic.ReadAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x.AllData));
            Console.ReadLine();
        }
        private static void GetById(BrandLogic logic)
        {
            Console.WriteLine("ENTER ID HERE: ");
            int id = int.Parse(Console.ReadLine());

            var q = logic.Read(id);

            Console.WriteLine("\n:: SELECTED PHONE :: \n");
            Console.WriteLine(q);
            Console.ReadLine();
        }
       
    }
}
