using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaikuDarzelis
{
    public class KindergartenList
    {

        public IList<Kindergarten> Collection; 

        public KindergartenList(IList<Kindergarten> collection)
        {
            Collection = collection;
        }

        public int BiggestChildrenAmount()
        {
            return Collection.Max(r => r.CHILDS_COUNT);
        }
        public int LowestChildrenAmount()
        {
            return Collection.Min(r => r.CHILDS_COUNT);
        }

        public IList<Kindergarten> FilterByChildrenAmount(int childrenAmount = 0)
        {
            var filteredList = new List<Kindergarten>();
            foreach (var element in Collection)
            {
                if (element.CHILDS_COUNT == childrenAmount) filteredList.Add(element);
            }
            return filteredList;
        }

        public IList<string> FilterByLanguages(IList<Kindergarten> collection)
        {
            var languages = new List<string>();
            foreach (var element in collection)
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

        public void PrintCollection()
        {
            foreach (var element in Collection)
            {
                Console.WriteLine($"{element.SCHOOL_NAME.Trim('"').Substring(0, 3)}_{element.TYPE_LABEL.Split(' ')[1]}-{element.TYPE_LABEL.Split(' ')[3]}_{element.LAN_LABEL.Substring(0, 4)}");
            }
        }
    }
}
