using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DZ3
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
