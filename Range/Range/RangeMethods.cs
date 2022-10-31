using System;
using System.Collections.Generic;
using System.Linq;

namespace Range
{
    public class RangeMethods
    {
        public static int[] GenerateSequence(int min, int max)
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

        public static int[] convertToArray(List<ConverterModel> convertedValues)
        {
            return convertedValues.Where(x => x.Error != 1).Select(x => Convert.ToInt32(x.AmpValue)).ToArray();
        }
    }
}
