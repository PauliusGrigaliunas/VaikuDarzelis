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
            try
            {
                var collection = ReadTransaction(ConfigurationManager.AppSettings["darzeliscsv"]);

                KindergartenList kindergartens = new KindergartenList(collection);

                Console.WriteLine();

                var biggestAmount = kindergartens.BiggestChildrenAmount();
                Console.WriteLine($"Biggest Children Amount: {biggestAmount}");
                PrintColection(kindergartens.FilterByChildrenAmount(biggestAmount));

                var lowestAmount = kindergartens.LowestChildrenAmount();
                Console.WriteLine($"Lowest Children Amount: {lowestAmount}");
                PrintColection(kindergartens.FilterByChildrenAmount(lowestAmount));



                IList<string> languages = kindergartens.FilterByLanguages();

                foreach (var language in languages)
                {
                    Console.WriteLine($"{language} :  { String.Format("{0:0.00 %}", kindergartens.Statistic(language))}");
                }

                var selected = kindergartens.SelectByFreePlaceAmount(2, 4);

                Console.WriteLine(string.Join("\n", selected));


            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static IList<Kindergarten> ReadTransaction(string path, bool hasHeader = true)
        {
            var list = new List<Kindergarten>();
            using (var reader = new StreamReader(path))
            {
                if (hasHeader) reader.ReadLine();
                while (!reader.EndOfStream)
                    list.Add(new Kindergarten(reader.ReadLine()));
            }
            return list;
        }


        static void PrintAllColection(IList<Kindergarten> colection)
        {
            foreach (var element in colection)
            {
                Console.WriteLine($"{element.DARZ_ID.ToString()}, {element.SCHOOL_NAME}, {element.TYPE_ID.ToString()}, {element.TYPE_LABEL}, {element.LAN_ID.ToString()}, {element.LAN_LABEL}, {element.CHILDS_COUNT.ToString()}, {element.FREE_SPACE.ToString()}");
            }
        }
        static void PrintColection(IList<Kindergarten> colection)
        {
            foreach (var element in colection)
            {
                Console.WriteLine($"{element.SCHOOL_NAME.Trim('"').Substring(0, 3)}_{element.TYPE_LABEL.Split(' ')[1]}-{element.TYPE_LABEL.Split(' ')[3]}_{element.LAN_LABEL.Substring(0, 4)}");
            }
        }
    }
}
