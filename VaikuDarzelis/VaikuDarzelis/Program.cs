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

                //KindergartenList kindergartens = new KindergartenList(collection);

                //Console.WriteLine(kindergartens.BiggestChildrenAmount());
                
                var biggestAmount = BiggestChildrenAmount(collection);
                Console.WriteLine($"Biggest Children Amount: {biggestAmount}");
                PrintColection(FilterByChildrenAmount(collection, biggestAmount));

                var lowestAmount = LowestChildrenAmount(collection);
                Console.WriteLine($"Lowest Children Amount: {lowestAmount}");
                PrintColection(FilterByChildrenAmount(collection, lowestAmount));

    

                IList<string> languages = FilterByLanguages(collection);

                foreach (var language in languages)
                {
                    Console.WriteLine($"{language} :  { String.Format("{0:0.00 %}", Statistic(collection, language))}");
                }
                
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

        static int BiggestChildrenAmount(IList<Kindergarten> collection)
        {
            return collection.Max(r => r.CHILDS_COUNT);
        }
        static int LowestChildrenAmount(IList<Kindergarten> collection)
        {
            return collection.Min(r => r.CHILDS_COUNT);
        }

        static IList<Kindergarten> FilterByChildrenAmount(IList<Kindergarten> colection, int childrenAmount = 0)
        {
            var filteredList = new List<Kindergarten>();
            foreach (var element in colection)
            {
                if (element.CHILDS_COUNT == childrenAmount) filteredList.Add(element);
            }
            return filteredList;
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

        static IList<string> FilterByLanguages(IList<Kindergarten> colection)
        {
            var languages = new List<string>();
            foreach (var element in colection)
            {
                bool hasIt = false;
                foreach (var language in languages)
                {
                    if (element.LAN_LABEL == language)
                    {
                        hasIt = true;
                        break;
                    }
                }
                if (!hasIt) languages.Add(element.LAN_LABEL);
            }
            return languages;
        }

        static decimal Statistic(IList<Kindergarten> collection, string language)
        {
            decimal sum = 0;
            var count = 0;
            foreach (var element in collection)
            {
                if (element.LAN_LABEL == language)
                {
                    sum = sum + element.Ratio();
                    count++;
                }
            }
            return sum / count;
        }
    }
}
