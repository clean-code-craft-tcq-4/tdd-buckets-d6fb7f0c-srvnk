using System;
using System.Collections.Generic;

namespace Range
{
    public class _12BitA2DConvertor
    {
        public List<ValueToAmpsModel> ConvertToAmps(decimal[] input)
        {
            List<ValueToAmpsModel> convertedValues = new List<ValueToAmpsModel>();
            foreach (var bitNum in input)
            {
                ValueToAmpsModel values = new ValueToAmpsModel();
                decimal toAmps = 10 * bitNum / 4094;
                if (toAmps > 10)
                    values.ErrorValue = 1;
                else
                    values.ValueToAmps = Math.Round(toAmps);
                convertedValues.Add(values);
            }

            return convertedValues;
        }
    }
    public class ValueToAmpsModel
    {
        public decimal ValueToAmps;
        public int ErrorValue;
    }
}
