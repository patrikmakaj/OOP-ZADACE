using System;
using System.IO;

namespace DZ3
{
    public class Description
    {
        private int number;
        private TimeSpan lenght;
        private string name;

        public int Number { get => number; set => number = value; }
        public TimeSpan Lenght { get => lenght; set => lenght = value; }
        public String Name { get => name; set => name = value; }

        public Description(int number, TimeSpan lenght, string name)
        {
            this.number = number;
            this.lenght = lenght;
            this.name = name;
        }
        public Description() { }

        public override String ToString()
        {
            return $"{number},{lenght},{name}";
        }
        
    }
}
