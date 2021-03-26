using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Core.Contracts
{
    using DAL.Entiies;
    using PhoneBook.Core;

    public interface IController
    {
        public string CreateUser(string name, string password);

        public string CreateContact(string name, string number, int userId);

        public string DeleteUser(string name);

        public string DeleteContact(string name);

        public List<User> Selectuser(string name);

        public List<Contacts> SelectAllContatcts();

        //string DeleteUSer(string name);

        public string UpdateUserPassword(string username, string password);

        public string UpdateContact(string name, string number);
    }
}
