namespace PhoneBook.IO
{
    using System;
    using PhoneBook.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
