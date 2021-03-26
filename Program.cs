using DAL.DataContext;
using DAL.Entiies;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core;
using PhoneBook.Core.Contracts;
using PhoneBook.Core.Entities;
using PhoneBook.IO;
using PhoneBook.IO.Contracts;
using System;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        //static  PhoneDbContext _context = new PhoneDbContext();
        static void Main(string[] args)
        {
            using var db = new PhoneDbContext();
            
            db.Database.Migrate();
            IController controller = new Controller();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(controller, reader, writer);
            engine.Run();

            //var user = db.Users.FirstOrDefault();
            //var us = new User
            //{
            //    Username = "admin",
            //    Password = "asdasdad"
            //};


            //db.SaveChanges();
            //Add();

        }
        static void Add()
        {
            //_context.Database.Migrate();

            //_context.SaveChanges();


        }
    }
}
