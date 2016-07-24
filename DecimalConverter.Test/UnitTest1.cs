using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecimalConverter.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConvertNumberStringToNumberInt()
        {
            var converter = new NumberStringConverter(16, 10);
            var result = converter.ConvertToInt("B1");

            Assert.AreEqual<int>(result, 177);
        }

        public void TestNumberStringDivision()
        {
            string hex = "B1";
            var converter = new NumberStringConverter(16,10);
            var result = converter.DivisionStep(hex);

            Assert.AreEqual<string>(result.DivisionResult,"177");
        }
    }
}
