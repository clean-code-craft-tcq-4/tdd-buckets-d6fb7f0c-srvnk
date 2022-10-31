using Range;
using System.Diagnostics;
using System.Linq;

namespace Range
{
    internal class A2DConvertorTest
    {

        public void CreateConvertorObject()
        {
            A2DConvertor obj = new A2DConvertor();
            Debug.Assert(obj != null);

        }
        
        public void ValidateErrorInput()
        {
            decimal[] inputArr = { 4095 };
            A2DConvertor sensorObj = new A2DConvertor();
            var range = sensorObj.ConvertToAmp(inputArr);
            Debug.Assert(range[0].Error == 1);
        }
        
        public void ValidateInput()
        {
            decimal[] inputArr = { 1146 };
            A2DConvertor sensorObj = new A2DConvertor();
            var range = sensorObj.ConvertToAmp(inputArr);
            Debug.Assert(range[0].AmpValue == 3);
        }
        
        public void ValidateInvalidInputs()
        {
            decimal[] inputArr = { 1146, 4095, 4094, 1614 };
            A2DConvertor sensorObj = new A2DConvertor();
            var range = sensorObj.ConvertToAmp(inputArr);
            int[] arrs = RangeMethods.convertToArray(range);
            Debug.Assert(arrs == new[] { 3, 10, 4 } );
        }

        
        public void DetectRangeIgnoringErrorValue()
        {
            decimal[] inputArr = { 1146, 4095, 4094, 1614, 3880 };
            A2DConvertor sensorObj = new A2DConvertor();
            var bitConvertedValue = sensorObj.ConvertToAmp(inputArr);
            int[] arrs = RangeMethods.convertToArray(bitConvertedValue);
            var ranges = CurrentRange.DetectRange(arrs);
            string str = (ranges[0].Min()).ToString() + "-" + (ranges[0].Max()).ToString();
            Debug.Assert(str == "3-4");
            str = (ranges[1].Min()).ToString() + "-" + (ranges[1].Max()).ToString();
            Debug.Assert(str == "9-10");
        }
    }
}
