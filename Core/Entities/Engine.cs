using PhoneBook.Core;
using PhoneBook.IO.Contracts;
using System;
using System.Collections.Generic;
using PhoneBook.Core.Contracts;
using PhoneBook.Core.Entities;


namespace PhoneBook.Core.Entities
{
    public class Engine
    {
        private readonly IController controller;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IController controller, IReader reader, IWriter writer)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = this.reader.ReadLine();

            while (command != "End")
            {
                try
                {
                    string[] input = command.Split();
                    var inputType = input[0];
                    string resultMessage = string.Empty;



                    if (inputType == "CreateUser")
                    {
                        resultMessage = this.controller.CreateUser(input[1], input[2]);
                    }

                    if (inputType == "CreateContact")
                    {
                        resultMessage = this.controller.CreateContact(input[1], input[2], int.Parse(input[3]));
                    }
                    if (inputType == "SelectUser")
                    {
                        var element = this.controller.Selectuser(input[1]);
                            foreach (var item in element)
                            {
                                this.writer.WriteLine($"user {item.Username} , password {item.Password}");
                            }
                    }
                    if(inputType == "SelectContact")
                    {
                        foreach (var item in this.controller.SelectAllContatcts() )
                        {
                            this.writer.WriteLine($"contact name {item.Name} , contact number {item.Number} , contact parent {item.UserId.Name}");
                        }
                    }
                    if (inputType == "DeleteUser")
                    {
                        this.controller.DeleteUser(input[1]);
                    }
                    if (inputType == "UpdateUser")
                    {
                        this.controller.UpdateUserPassword(input[1], input[2]);
                    }

                    if (inputType == "UpdateContact")
                    {
                        this.controller.UpdateContact(input[1], input[2]);
                    }

                    this.writer.WriteLine(resultMessage);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }

                command = this.reader.ReadLine();
            }
        }

    }
}
