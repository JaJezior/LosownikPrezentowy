using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LosownikPrezentowy
{
    public class Run
    {
        internal List<string> GetListOfNames()
        {
            Console.WriteLine("Stwórz listę osób biorących udział w losowaniu. Wpisuj imiona osób i zatwierdzaj klawiszem 'Enter'.");
            List<string> listOfNames = new List<string>();
            bool isListFinished = false;
            while (isListFinished == false)
            {
                Console.WriteLine("Podaj imię osoby, lub wpisz 'q' aby zakończyć listę:");
                string name = Console.ReadLine();
                if(name == "q")
                {
                    if (listOfNames.Count < 2)
                    {
                        Console.WriteLine("Lista musi zawierać przynajmniej dwie pozycje!");
                    }
                    else
                    {
                        Console.WriteLine($"Zakończono tworzenie listy, liczba osób na liście wynosi {listOfNames.Count}.");
                        isListFinished = true;
                    }
                }
                else
                {
                    listOfNames.Add(name);
                    Console.WriteLine($"{name} - imię dodano do listy, liczba osób na liście wynosi {listOfNames.Count}.");
                }
                    
            }
            return listOfNames;
        }

        internal void SaveToTxtFile(string text)
        {
            File.WriteAllText("WynikiLosowania.txt", text);
            Console.WriteLine("Wyniki zapisano w pliku 'WynikiLosowania.txt'.");
        }

        internal List<string> ShuffleList(List<string> list)
        {
            Random rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }


            return list;
        }
        internal StringBuilder GetTableOfResults(List<string> shuffledListOfNames)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Losowanko zakończone! Oto wyniki:");

            for (int i = 0; i < shuffledListOfNames.Count - 1; i++)
            {
                stringBuilder.AppendLine($"{shuffledListOfNames[i].ToUpper()} przygotowuje prezent dla osoby o imieniu {shuffledListOfNames[i+1].ToUpper()}");
            }
            stringBuilder.AppendLine($"{shuffledListOfNames.Last().ToUpper()} przygotowuje prezent dla osoby o imieniu {shuffledListOfNames[0].ToUpper()}");
            stringBuilder.AppendLine("Wylosowano Losownikiem Prezentowym Jeziora");

            return stringBuilder;
        }

    }
}
