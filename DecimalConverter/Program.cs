using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //var converter = new NumberStringConverter(16, 10);
            //var result = converter.ConvertToInt("B1");

            string hex = "6F1";
            var converter = new NumberStringConverter(16, 10);
            var result = converter.Division(hex);

            //string numString = "177";
            //var converter = new NumberStringConverter(10, 16);
            //var result = converter.DivisionStep(numString);

            converter = new NumberStringConverter(10, 16);
            result = converter.Division("1777");

            converter = new NumberStringConverter(16, 36);
            result = converter.Division("8BB3CCDA252644596D87918B488002A3");

            converter = new NumberStringConverter(16, 36);
            result = converter.Division("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
        }
    }
}
