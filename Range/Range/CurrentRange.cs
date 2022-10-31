using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Range
{
    public class CurrentRange
    {
        public static List<List<int>> DetectRange(int[] inputarray)
        {
            inputarray = inputarray.OrderBy(x => x).ToArray();
            var sequence = RangeMethods.GenerateSequence(inputarray.Min(), inputarray.Max());
            var NonIntersectedNumbers = sequence.Except(inputarray).ToArray();

            List<List<int>> lstRange = new List<List<int>>();
            List<int> list;
            int arrayIndex = 0;
            for (int i = 0; i < NonIntersectedNumbers.Length; i++)
            {
                list = new List<int>();
                for (int j = arrayIndex; j < inputarray.Length; j++)
                {
                    if (inputarray[j] < NonIntersectedNumbers[i])
                    {
                        list.Add(inputarray[j]);
                        continue;
                    }
                    arrayIndex = j;
                    break;
                }
                if (list.Count > 0)
                    lstRange.Add(list);
            }

            int cnt = 0;
            cnt = lstRange.Sum(x => x.Count);

            list = new List<int>();
            for (int j = cnt; j < inputarray.Length; j++)
                list.Add(inputarray[j]);

            lstRange.Add(list);

            lstRange = lstRange.Where(x => x.Count != 1).Select(x => x).ToList();
            return lstRange;
        }
    }
}
