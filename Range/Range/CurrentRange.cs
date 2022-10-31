using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Range
{
    public class CurrentRange
    {
        public static List<List<int>> RangeDetector(int[] intarray)
        {
            intarray = intarray.OrderBy(x => x).ToArray();
            var sequence = RangeMethods.SequenceGenerator(intarray.Min(), intarray.Max());
            var NonIntersectedNumbers = sequence.Except(intarray).ToArray();

            List<List<int>> lstRange = new List<List<int>>();
            List<int> lst;
            int arrayIndex = 0;
            for (int i = 0; i < NonIntersectedNumbers.Length; i++)
            {
                lst = new List<int>();
                for (int j = arrayIndex; j < intarray.Length; j++)
                {
                    if (intarray[j] < NonIntersectedNumbers[i])
                    {
                        lst.Add(intarray[j]);
                        continue;
                    }
                    arrayIndex = j;
                    break;
                }
                if (lst.Count > 0)
                    lstRange.Add(lst);
            }

            int cnt = 0;
            cnt = lstRange.Sum(x => x.Count);

            lst = new List<int>();
            for (int j = cnt; j < intarray.Length; j++)
                lst.Add(intarray[j]);

            lstRange.Add(lst);

            lstRange = lstRange.Where(x => x.Count != 1).Select(x => x).ToList();
            return lstRange;
        }
    }
}
