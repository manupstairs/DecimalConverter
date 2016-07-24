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

      
        [TestMethod]
        public void TestDivision16To10()
        {
            var test = "6f1";
            var converter = new NumberStringConverter(16, 10);
            var result = converter.Division(test);
            Assert.AreEqual<string>(result, "1777");
        }

        [TestMethod]
        public void TestDivision10To16()
        {
            var test = "177";
            var converter = new NumberStringConverter(10, 16);
            var result = converter.Division(test);
            Assert.AreEqual<string>(result, "B1");

            test = "1777";
            converter = new NumberStringConverter(10, 16);
            result = converter.Division(test);
            Assert.AreEqual<string>(result, "6F1");
        }

        [TestMethod]
        public void TestDivision10To36()
        {
            var test = "4095";
            var converter = new NumberStringConverter(10, 36);
            var result = converter.Division(test);
            Assert.AreEqual<string>(result, "35R");

            test = "FFF";
            converter = new NumberStringConverter(16, 36);
            result = converter.Division(test);
            Assert.AreEqual<string>(result, "35R");
        }
    }
}
