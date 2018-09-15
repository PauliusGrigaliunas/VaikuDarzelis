using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaikuDarzelis
{
    public class KindergartenList
    {

        private IList<Kindergarten> _collection;
        public IList<Kindergarten> Collection {
            get { return _collection; }
            set { _collection = value; }
        }


        public KindergartenList(IList<Kindergarten> collection)
        {
            _collection = collection;
        }

        public int BiggestChildrenAmount()
        {
            return _collection.Max(r => r.CHILDS_COUNT);
        }
        public int LowestChildrenAmount()
        {
            return _collection.Min(r => r.CHILDS_COUNT);
        }

        public IList<Kindergarten> FilterByChildrenAmount(int childrenAmount = 0)
        {
            var filteredList = new List<Kindergarten>();
            foreach (var element in _collection)
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
            foreach (var element in _collection)
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
            foreach (var element in _collection)
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
            return
                            from element in _collection
                            where element.FREE_SPACE >= min && element.FREE_SPACE <= max
                            orderby element.SCHOOL_NAME descending
                            group element by element.SCHOOL_NAME into elementGroup
                            orderby elementGroup.Key descending
                            select elementGroup.Key;
        }
    }
}
