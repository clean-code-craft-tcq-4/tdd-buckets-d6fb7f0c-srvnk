using NUnit.Framework;
using Range;
using System.Linq;

namespace TestProject
{
    internal class _12BitA2DConvertorTest
    {

        [Test]
        public void Create_12BitA2DConvertorObject()
        {
            _12BitA2DConvertor obj = new _12BitA2DConvertor();
            Assert.IsNotNull(obj);

        }
        [Test]
        public void ErrorInput()
        {
            decimal[] arr = { 4095 };
            ICurrentSensor sensorObj = new _12BitA2DConvertor();
            var range = sensorObj.ConvertToAmp(arr);
            Assert.AreEqual(1, range[0].ErrorValue);
        }
        [Test]
        public void ValidInput()
        {
            decimal[] arr = { 1146 };
            ICurrentSensor sensorObj = new _12BitA2DConvertor();
            var range = sensorObj.ConvertToAmp(arr);
            Assert.AreEqual(3, range[0].ValueToAmps);
        }
        [Test]
        public void ValidAndInvalidInputs()
        {
            decimal[] arr = { 1146, 4095, 4094, 1614 };
            ICurrentSensor sensorObj = new _12BitA2DConvertor();
            var range = sensorObj.ConvertToAmp(arr);
            int[] arrs = RangeMethods.convertToArray(range);
            Assert.AreEqual(new[] { 3, 10, 4 }, arrs);
        }

        [Test]
        public void DetectRangeWithInputIgnoringErrorValue()
        {
            decimal[] arr = { 1146, 4095, 4094, 1614, 3880 };
            ICurrentSensor sensorObj = new _12BitA2DConvertor();
            var bitConvertedValue = sensorObj.ConvertToAmp(arr);
            int[] arrs = RangeMethods.convertToArray(bitConvertedValue);
            var ranges = Range.CurrentRange.RangeDetector(arrs);
            string str = (ranges[0].Min()).ToString() + "-" + (ranges[0].Max()).ToString();
            Assert.AreEqual("3-4", str);
            str = (ranges[1].Min()).ToString() + "-" + (ranges[1].Max()).ToString();
            Assert.AreEqual("9-10", str);
        }
    }
}
