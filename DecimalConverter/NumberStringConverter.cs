using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalConverter
{
    public class NumberStringConverter
    {
        // private Dictionary<char, int> NumberDic { get; set; } = new Dictionary<char, int>();
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

            int index = ConvertToInt(divistionResult) ;
            return LetterMap[index] + result;
        }

        private bool IsEnoughDivision(string number)
        {
            int num = ConvertToInt(number);
            return num >= TargetDecimal;
        }

        public DivisionStorage DivisionStep(string number)
        {
            DivisionStorage divisionStorage = new DivisionStorage();

            foreach (char letter in number)
            {
                int num = ConvertToInt(divisionStorage.RemainderInTargetDecimal + letter);

                int result = num / TargetDecimal;
                divisionStorage.DivisionResultInOriginDecimal += LetterMap[result];
                int remainder = num % TargetDecimal;
                divisionStorage.RemainderInTargetDecimal = LetterMap[remainder].ToString();

            }

            return divisionStorage;
        }

        public int ConvertToInt(string number)
        {
            int positon = 0;
            int total = 0;
            while (positon < number.Length)
            {
                int index = LetterMap.IndexOf(number[positon]);

                total += (int)Math.Pow(OriginDecimal, (number.Length - positon - 1)) * index;

                positon++;
            }

            return total;
        }
    }
}
