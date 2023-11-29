using System.Text.RegularExpressions;

namespace Calculator
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [TestCase("1", 1)]
        [TestCase("-1", -1)]
        [TestCase(" ", 0)]
        [TestCase("0,52", 0.52)]
        [TestCase("-0,0002", -0.0002)]
        public void Calculator_WhenNumberOrVoid_OneNumber(string exp, double expected)
        {
            double result = _calculator.Calculat(exp);
            Assert.AreEqual(expected, result);
        }

        [TestCase("2+2", 4)]
        [TestCase("-2+4", 2)]
        [TestCase("-1-5", -6)]
        [TestCase("234-435", -201)]
        [TestCase("1+1", 2)]
        [TestCase("8+3", 11)]
        public void Calculator_WhenIntNambers_OneNumber(string exp, double expected)
        {
            double result = _calculator.Calculat(exp);
            Assert.AreEqual(expected, result);
        }

        [TestCase("0,41+4,31", 4.72)]
        [TestCase("-0,26-6,51", -6.77)]
        public void Calculator_WhenTwoDoubleNambers_OneNumber(string exp, double expected)
        {
            double result = _calculator.Calculat(exp);
            Assert.AreEqual(expected, result);
        }
    }

    class Calculator
    {
        public double Calculat(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            else
            {
                List<string> tokens = Tokenize(str);

                // Ваш код для обработки токенов и выполнения вычислений

                throw new NotImplementedException();
            }

            //if (String.IsNullOrWhiteSpace(str))
            //{
            //    return 0;
            //}
            //else
            //{
            //    if (int.TryParse(str, out int int_result))
            //    {
            //        // Строка является числом, и результат хранится в переменной result
            //        return (int_result);
            //    }
            //    else if (double.TryParse(str, out double double_result))
            //    {
            //        return (double_result);
            //    }

            //    else
            //    {

            //    }
            //}

            //throw new NotImplementedException();
        }

        static List<string> Tokenize(string input)
        {
            List<string> tokens = new List<string>();

            string pattern = @"\d+|\+|\-|\*|\/|\(|\)";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                tokens.Add(match.Value);
            }

            return tokens;
        }



        //public double Calculat(string str)
        //{
        //    if (String.IsNullOrWhiteSpace(str))
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < str.Length; i++)
        //        {

        //        }
        //        string[] terms = str.Split('+');
        //        double result = 0;

        //        foreach (string term in terms)
        //        {
        //            if (double.TryParse(term, out double number))
        //            {
        //                result += number;
        //            }
        //            else
        //            {
        //                throw new NotImplementedException();
        //            }
        //        }

        //        return result;
        //    }
        //}
    }
}
