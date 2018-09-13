using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaikuDarzelis
{
    class Program
    {
        static void Main(string[] args)
        {

            args = new[] { @"C:\Users\Paulius\Documents\GitHub\VaikuDarzelis\DarzelioVaikai.csv" };

            var transactions = ReadTransaction(args[0]);

            /*try
            {
                var text = File.ReadAllText(@"C:\Users\Paulius\Documents\GitHub\VaikuDarzelis\DarzelioVaikai.csv");
                Console.WriteLine(text);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }*/
            
        }

        static IList<Transaction> ReadTransaction(string path, bool hasHeader = true ) {

            var list = new List<Transaction>();
            foreach(var line in File.ReadLines(path).Skip(hasHeader ? 1 : 0))
            {
                list.Add(Transaction.Fromline());
            }
            return list;
        }
    }
} 
       