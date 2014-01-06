using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace OFiX
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please tell me the filename to fix");
                Console.ReadKey();
            }
            else
            {
                try
                {
                    string InputFileName = string.Join(" ", args);
                    string OutputFileName = InputFileName + ".fixed.ofx";

                    Console.WriteLine("Reading " + InputFileName);
                    string InputText = File.ReadAllText(InputFileName);

                    Console.WriteLine("Fixing & with &amp;");
                    InputText = InputText.Replace("&amp;", "__amp__");
                    InputText = InputText.Replace("&", "&amp;");
                    InputText = InputText.Replace("__amp__", "&amp;");

                    Console.WriteLine("Writing " + OutputFileName);
                    File.WriteAllText(OutputFileName, InputText);

                    Console.WriteLine("Opening " + OutputFileName);
                    Process.Start(OutputFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("Unhandled Exception: \r\n\r\n" + ex.ToString());
                    Console.ReadKey();
                }
            }
        }
    }
}
