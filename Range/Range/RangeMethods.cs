using System;
using System.Collections.Generic;
using System.Linq;

namespace Range
{
    public class RangeMethods
    {
        public static int[] SequenceGenerator(int min, int max)
        {
            int[] intarray = new int[max - min + 1];
            int index = 0;
            for (int i = min; i <= max; i++)
            {
                intarray[index] = i;
                index++;
            }
            return intarray;
        }

        public static int[] convertToArray(List<ValueToAmpsModel> convertedValues)
        {
            return convertedValues.Where(x => x.ErrorValue != 1).Select(x => Convert.ToInt32(x.ValueToAmps)).ToArray();
        }
    }
}
