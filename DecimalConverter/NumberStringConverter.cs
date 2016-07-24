using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalConverter
{
    public class NumberStringConverter
    {
        private string LetterMap { get; set; } = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private int OriginDecimal { get; set; }
        private int TargetDecimal { get; set; }

        public NumberStringConverter(int originDecimal, int targetDecimal)
        {
            OriginDecimal = originDecimal;
            TargetDecimal = targetDecimal;



        }

        public string Division(string number)
        {
            number = number.ToUpper();
            string result = string.Empty;
            DivisionStorage storage = DivisionStep(number);

            result = storage.RemainderInTargetDecimal + result;

            string divistionResult = storage.DivisionResultInOriginDecimal;
            while (IsEnoughDivision(divistionResult))
            {
                storage = DivisionStep(divistionResult);
                result = storage.RemainderInTargetDecimal + result;
                divistionResult = storage.DivisionResultInOriginDecimal;
            }

            int index = (int)ConvertToInt(divistionResult) ;
            return LetterMap[index] + result;
        }

        private bool IsEnoughDivision(string number)
        {
            double num = ConvertToInt(number);
            return num >= TargetDecimal;
        }

        public DivisionStorage DivisionStep(string number)
        {
            DivisionStorage divisionStorage = new DivisionStorage();

            foreach (char letter in number)
            {
                double num = ConvertToInt(divisionStorage.RemainderInTargetDecimal + letter);

                int result = (int)(num / TargetDecimal);
                divisionStorage.DivisionResultInOriginDecimal += LetterMap[result];
                int remainder = (int)(num % TargetDecimal);
                divisionStorage.RemainderInTargetDecimal = LetterMap[remainder].ToString();

            }

            return divisionStorage;
        }

        public double ConvertToInt(string number)
        {
            int positon = 0;
            double total = 0;
            while (positon < number.Length)
            {
                int index = LetterMap.IndexOf(number[positon]);

                total +=  Math.Pow(OriginDecimal, (number.Length - positon - 1)) * index;

                positon++;
            }

            return total;
        }
    }
}
