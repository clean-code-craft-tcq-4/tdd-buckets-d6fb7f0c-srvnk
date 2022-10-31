using NUnit.Framework;
using System.Linq;
using Range;

namespace TestProject
{
    public class Tests
    {
        [Test]
        public void ValidInputWithDuplicates()
        {
            int[] arr = { 3, 3, 5, 4, 10, 11, 12 };
            var range = RangeMethods.SequenceGenerator(arr.Min(), arr.Max());
            Assert.AreEqual(10, range.Length);
        }

        [Test]
        public void ValidInputsToCaptureValuesCount()
        {
            int[] arr = { 4, 5 };
            var range = Range.CurrentRange.RangeDetector(arr);
            Assert.AreEqual(2, range[0].Count);
        }
        [Test]
        public void InputsToCheckSequenceNumber()
        {
            int[] arr = { 3, 3, 5, 4, 10, 11, 12 };
            int[] ExpectedArray = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var ActualArray = RangeMethods.SequenceGenerator(arr.Min(), arr.Max());
            Assert.AreEqual(ExpectedArray, ActualArray);
        }

        [Test]
        public void ValidInputsToCaptureWithCount2()
        {
            int[] arr = { 3, 3, 5, 4, 10, 11, 12 };
            var range = Range.CurrentRange.RangeDetector(arr);
            Assert.AreEqual(4, range[0].Count);
            Assert.AreEqual(3, range[1].Count);
        }

        [Test]
        public void ValidInputsToCaptureRange()
        {
            int[] arr = { 3, 3, 5, 4, 10, 11, 12 };
            var range = Range.CurrentRange.RangeDetector(arr);
            string str = (range[0].Min()).ToString() + "-" + (range[0].Max()).ToString();
            Assert.AreEqual("3-5", str);
            str = (range[1].Min()).ToString() + "-" + (range[1].Max()).ToString();
            Assert.AreEqual("10-12", str);
        }

    }
}