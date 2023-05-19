using System;
using ConsoleTools;
using System.Collections.Generic;
using System.Linq;

using QBU9QL_HFT_2022231.Models;


namespace QBU9QL_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;
        static RestService rrest;
        static void Create(string entity)
        {
            if (entity == "Rider")
            {
                Console.WriteLine("Enter Rider Name: ");
                string name = Console.ReadLine();
                rest.Post(new Rider() { Name = name }, "rider");
            }
            else if (entity == "Motorcycle")
            {
                Console.WriteLine("Enter Motorcycle Model: ");
                string name = Console.ReadLine();
                rest.Post(new Moto() { Model = name }, "motorcycle");
            }
            else if (entity == "Brand")
            {
                Console.WriteLine("Enter Brand Name: ");
                string name = Console.ReadLine();
                rest.Post(new Rider() { Name = name }, "brand");
            }


        }
        static void List(string entity)
        {
            if (entity == "Rider")
            {
                List<Rider> riders = rest.Get<Rider>("rider");
                foreach (var item in riders)
                {
                    Console.WriteLine(item.RiderId + ": " + item.Name);
                }
            }
            else if (entity == "Motorcycle")
            {
                List<Moto> motos = rest.Get<Moto>("motorcycle");
                foreach (var item in motos)
                {
                    Console.WriteLine(item.MotoId + ": " + item.Model);
                }
            }
            else if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (var item in brands)
                {
                    Console.WriteLine(item.BrandId + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Rider")
            {
                Console.Write("Enter Rider's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Rider one = rest.Get<Rider>(id, "rider");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "rider");
            }
            else if (entity == "Motorcycle")
            {
                Console.Write("Enter Motorcycle's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Moto one = rest.Get<Moto>(id, "motorcycle");
                Console.Write($"New name [old: {one.Model}]: ");
                string name = Console.ReadLine();
                one.Model = name;
                rest.Put(one, "motorcycle");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand one = rest.Get<Brand>(id, "brand");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "brand");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Rider")
            {
                Console.Write("Enter Rider's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "rider");
            }
            else if (entity == "Motorcycle")
            {
                Console.Write("Enter Motorcycle's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "motorcycle");
            }
            else if (entity == "Brand")
            {
                Console.Write("Enter Brand's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "brand");
            }
        }
        static void HasMz(string endpoint)
        {

            Console.WriteLine("These Rider(s) have/has Mz motorcycle");
            var datas = rest.Get<object>($"Stat/{endpoint}");
            foreach (var item in datas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void MaxSoldCompany(string endpoint)
        {
            Console.WriteLine("Bikes with the most popular brand ");
            var datas = rest.Get<object>($"Stat/{endpoint}");
            foreach (var item in datas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void HasThisBrand(string endpoint)
        {
            Console.WriteLine("These riders have this brand of motorcycle: ");
            var datas = rest.Get<object>($"Stat/{endpoint}");
            foreach (var item in datas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void HasMoreThan800ccmBike(string endpoint)
        {
            Console.WriteLine("These riders have bikes over 800 engine capacity:  ");
            var datas = rest.Get<object>($"Stat/{endpoint}");
            foreach (var item in datas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void CompanyOlderThan70(string endpoint)
        {
            Console.WriteLine("These bike's company is older than 70 years old");
            var datas = rest.Get<object>($"Stat/{endpoint}");
            foreach (var item in datas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:34767/", "rider");

            var ridersNonC = new ConsoleMenu(args, level: 2)
                .Add("Who has Mz?", () => HasMz("HasETZModel"))
                .Add("Who has bike over 800 ccm?", () => HasMoreThan800ccmBike("GetHasMoreThan800ccmMoto"))
                .Add("Who has this brand?", () => HasThisBrand("HasAprilia"))
                .Add("Exit", ConsoleMenu.Close);
            var motosNonC = new ConsoleMenu(args, level: 2)
                .Add("Motorcycle's company which older than 70 yo", () => CompanyOlderThan70("GetCompanyOlderThan70"))
                .Add("Bikes from the most popular brand", () => MaxSoldCompany("GetMaxSoldCompany"))
                .Add("Exit", ConsoleMenu.Close);

            var riderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rider"))
                .Add("Create", () => Create("Rider"))
                .Add("Delete", () => Delete("Rider"))
                .Add("Update", () => Update("Rider"))
                .Add("Non-Cruds", () => ridersNonC.Show())
                .Add("Exit", ConsoleMenu.Close);

            var motorcycleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Motorcycle"))
                .Add("Create", () => Create("Motorcycle"))
                .Add("Delete", () => Delete("Motorcycle"))
                .Add("Update", () => Update("Motorcycle"))
                .Add("Non-Cruds", () => motosNonC.Show())
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);



            var menu = new ConsoleMenu(args, level: 0)
                .Add("Riders", () => riderSubMenu.Show())
                .Add("Motorcycle", () => motorcycleSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
