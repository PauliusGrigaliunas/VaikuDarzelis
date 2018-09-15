using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaikuDarzelis
{
    public class WriteToFile
    {
        private string _path;
        public string PathTxt
        {
            get { return _path; }
            set { _path = value; }
        }

        public WriteToFile(string path)
        {
            _path = path;
            using (StreamWriter writer = new StreamWriter(Path.Combine(_path), false)) {}
        }
        public void WriteLine(string text)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(_path), true))
            {
                writer.WriteLine(text);
            }
        }

        public void PrintColection(IList<Kindergarten> colection)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(_path), true))
            {
                foreach (var element in colection)
                {
                    writer.WriteLine($"{element.SCHOOL_NAME.Trim('"').Substring(0, 3)}_{element.TYPE_LABEL.Split(' ')[1]}-{element.TYPE_LABEL.Split(' ')[3]}_{element.LAN_LABEL.Substring(0, 4)}");
                }
            }
        }

    }
}
