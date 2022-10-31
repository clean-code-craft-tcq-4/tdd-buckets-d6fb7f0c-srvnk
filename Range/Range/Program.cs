using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{
    public class Program
    {
        static void Main(string[] args)
        {
            CurrentRangeTest currentRangeTest = new CurrentRangeTest();
            currentRangeTest.ValidDuplicateInputs();
            currentRangeTest.CaptureValuesCount();
            currentRangeTest.CheckSequenceNumber();
            currentRangeTest.CaptureWithCount();
            currentRangeTest.CaptureRange();

            A2DConvertorTest a2DConvertorTest = new A2DConvertorTest();
            a2DConvertorTest.CreateConvertorObject();
            a2DConvertorTest.ValidateErrorInput();
            a2DConvertorTest.ValidateInput();
            a2DConvertorTest.ValidateInvalidInputs();
            a2DConvertorTest.DetectRangeIgnoringErrorValue();
        }
    }    
}
