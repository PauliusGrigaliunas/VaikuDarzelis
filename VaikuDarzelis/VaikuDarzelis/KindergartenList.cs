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

        public IList<string> FilterByLanguages()
        {
            var languages = new List<string>();
            foreach (var element in Collection)
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

        public decimal Statistic(string language)
        {
            decimal sum = 0;
            var count = 0;
            foreach (var element in Collection)
            {
                if (element.LAN_LABEL == language)
                {
                    sum = sum + element.Ratio();
                    count++;
                }
            }
            return sum / count;
        }

        public IEnumerable<string> SelectByFreePlaceAmount(int min = 2, int max = 4)
        {

            var custQuery =
                from element in Collection
                where element.FREE_SPACE >= min && element.FREE_SPACE <= max
                orderby element.SCHOOL_NAME descending
                group element by element.SCHOOL_NAME into custGroup
                orderby custGroup.Key descending
                select custGroup.Key;

            return custQuery;
        }
    }
}
