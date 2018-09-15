using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaikuDarzelis
{
    public class ReadFromFile
    {

        private string _path;
        public string PathCsv
        {
            get { return _path; }
            set { _path = value; }
        }

        public ReadFromFile(string path) {
            _path = path;
        }

        public IList<Kindergarten> ReadTransaction(bool hasHeader = true)
        {
            var list = new List<Kindergarten>();
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    if (hasHeader) reader.ReadLine();
                    while (!reader.EndOfStream)
                        list.Add(new Kindergarten(reader.ReadLine()));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
    }
}
