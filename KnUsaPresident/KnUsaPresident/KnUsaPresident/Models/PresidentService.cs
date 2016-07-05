using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnUsaPresident.Models
{
    public class PresidentService
    {
        public static IList<President> GetPresidentList()
        {
            var pl = new President();
            var list = pl.PresidentList.OrderByDescending(x => x.Id).ToList();

            return list;
        }

        public static IList<President> Search (string key, string searchBy)
        {
            var pl = new President();
            var items = GetPresidentList();

            switch (searchBy)
            {
                case "Name":
                    items = items.Where(p => p.Name.IndexOf(key, StringComparison.CurrentCultureIgnoreCase) >=0).ToList();
                    break;
                case "Term":
                    items = searchByTerm(items, key);
                    break;
                case "Party":
                    items = items.Where(p => p.Party.IndexOf(key, StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();
                    break;
            }

            return items;
        }

        private static IList<President> searchByTerm(IList<President> presidents, string key)
        {
            IList<President> l = new List<President>();

            if (string.IsNullOrWhiteSpace(key))
                return GetPresidentList();

            foreach (var president in presidents)
            {
                var years = president.Term.Trim().Replace(" ","").Split(new char[] {'-'});
                var startYear = 0;
                var endYear = 0;
                var term = 0;

                if (years.Count() == 2)
                {
                    if (int.TryParse(years[0], out startYear) && int.TryParse(years[1], out endYear) && int.TryParse(key, out term))
                    {
                        if (term >= startYear && term <= endYear)
                        {
                            l.Add(president);
                        }
                    }
                }
                else if (years.Count() == 1)
                {
                    if (int.TryParse(key, out term))
                    {
                        if (term == startYear)
                        {
                            l.Add(president);
                        }
                    }
                }
                
             }

            return l;
        }
    }
}
