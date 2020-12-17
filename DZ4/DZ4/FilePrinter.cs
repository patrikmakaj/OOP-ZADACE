using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DZ4
{
    public class FilePrinter : IPrinter
    {
        string outputFileName;

        public FilePrinter(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }

        public void Print(string output)
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.Write(output);
            }
        }
    }
}
