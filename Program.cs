using System;
using System.Collections.Generic;
using System.Text;

namespace LosownikPrezentowy
{
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine("###### Witaj w Losowniku Prezentowym Jeziora! #####");
            var run = new Run();
            List<string> listOfNames = run.GetListOfNames();
            run.ShuffleList(listOfNames);
            StringBuilder tableOfResults = run.GetTableOfResults(listOfNames);
            Console.WriteLine("");
            Console.WriteLine(tableOfResults.ToString());
            run.SaveToTxtFile(tableOfResults.ToString());
            Console.ReadKey();
        }
    }
}
