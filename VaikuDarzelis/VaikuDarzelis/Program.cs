using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace VaikuDarzelis
{
    class Program
    {
        static void Main()
        {

            var readFromFile = new ReadFromFile(ConfigurationManager.AppSettings["darzeliscsv"]);
            var collection = readFromFile.ReadTransaction();

            KindergartenList kindergartens = new KindergartenList(collection);

            WriteToFile writeToFile = new WriteToFile(ConfigurationManager.AppSettings["answer"]);

            var biggestAmount = kindergartens.BiggestChildrenAmount();

            Console.WriteLine($"Biggest Children Amount: {biggestAmount}");
            writeToFile.WriteLine($"Biggest Children Amount: {biggestAmount}");
            writeToFile.PrintColection(kindergartens.FilterByChildrenAmount(biggestAmount));

            var lowestAmount = kindergartens.LowestChildrenAmount();

            Console.WriteLine($"Lowest Children Amount: {lowestAmount}");
            writeToFile.WriteLine($"Lowest Children Amount: {lowestAmount}");
            writeToFile.PrintColection(kindergartens.FilterByChildrenAmount(lowestAmount));


            IList<string> languages = kindergartens.FilterByLanguages();

            foreach (var language in languages)
            {
                writeToFile.WriteLine($"{language} : { String.Format("{0:0.00 %}", kindergartens.Statistic(language))}");
            }

            writeToFile.WriteLine(string.Join("; ", kindergartens.SelectByFreePlaceAmount(2, 4)));
        }
    }
}
