namespace PhoneBook.IO
{
    using System;

    using PhoneBook.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
