using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using DAL.DataContext;
using DAL.Entiies;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Contracts;
using PhoneBook.Utilities.Messages;

namespace PhoneBook.Core
{
    public class Controller : IController
    {
        private PhoneDbContext context;
        string[] input;

        public Controller()
        {
            this.context = new PhoneDbContext();
        }

        public List<User> Selectuser(string name)
        {
            return this.context.Users.Include(x=> x.ContactID).ToList();
        }

        public List<Contacts> SelectAllContatcts()
        {
            return this.context.Contacts.ToList();
        }

        public string CreateUser(string username, string password)
        {
            var user = new User 
            { 
                Username = username,
                Password = password
            };
            this.context.Users.Add(user);
            this.context.SaveChanges();

            return string.Format(OutputMessages.UserIsCreated, username);
        }

        public string CreateContact(string name, string number, int userId)
        {
            Contacts contact = new Contacts 
            {
                Name = name,
                Number = number,
                UserId = this.context.Users.Where(x => x.ID == userId).FirstOrDefault()
            };
            this.context.Contacts.Add(contact);
            this.context.SaveChanges();

            return string.Format(OutputMessages.ContactIsCreated, name, number);
        }


        // insert , update,  delete 
        // select - Tolist , First , FirstOfDefault


        public string DeleteUser(string name)
        {
            User usertemp = this.context.Users.Where(x => x.Username == name).FirstOrDefault();
            if (usertemp is null)
            {
                return "User is not in our system";
            }
            this.context.Users.Remove(usertemp);
            this.context.SaveChanges();

            return "User is deleted";
            // delete from <table name> where <table.id>
        }

        public string DeleteContact(string name)
        {
            Contacts contacts = this.context.Contacts.Where(x => x.Name == name).FirstOrDefault();
            if(contacts == null)
            {
                return "Contact is not in phonebook";
            }
            this.context.Contacts.Remove(contacts);
            this.context.SaveChanges();

            return "Contact is deleted";
        }

        public string UpdateUserPassword(string username, string password)
        {
            User user_from_databse = this.context.Users.Where(x => x.Username == username).First();
            if (user_from_databse == null)
            {
                return string.Format(OutputMessages.UserIsMiss, username);
            }
            user_from_databse.Password = password;

            this.context.Users.Update(user_from_databse);
            this.context.SaveChanges();

            return "User is updated";
        }

        public string UpdateContact(string name, string number)
        {
            Contacts contactName = this.context.Contacts.Where(x => x.Name == name).First();

            if (contactName == null)
            {
                return string.Format(OutputMessages.ContactIsMiss, name);
            }

            contactName.Number = number;

            this.context.Contacts.Update(contactName);
            this.context.SaveChanges();

            return "Contact is updated";
        }
    }
}
