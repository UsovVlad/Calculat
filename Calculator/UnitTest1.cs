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

        [TestCase("0,52", 0.52)]
        [TestCase("-0,0002", -0.0002)]
        [TestCase("1 / 0", double.NaN)] // Тест на деление на ноль
        [TestCase("4 * (2 + 3)", 20)]   // Тест с использованием скобок
        [TestCase("2 * 2 / 2", 2)]      // Тест с последовательностью операторов
        public void Calculator_WhenComplexExpression_CalculatesCorrectly(string exp, double expected)
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

                // Реализуйте логику для выполнения вычислений
                return Evaluate(tokens);
            }
        }

        static List<string> Tokenize(string input)
        {
            List<string> tokens = new List<string>();

            string pattern = @"\d+(\,\d+)?|\+|\-|\*|\/|\(|\)";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                tokens.Add(match.Value);
            }

            return tokens;
        }

        static double Evaluate(List<string> tokens)
        {
            Stack<double> values = new Stack<double>();
            Stack<string> operators = new Stack<string>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    values.Push(number);
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(token))
                    {
                        ApplyOperator(values, operators.Pop());
                    }
                    operators.Push(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        ApplyOperator(values, operators.Pop());
                    }
                    operators.Pop(); // Удаляем открывающую скобку
                }
            }

            while (operators.Count > 0)
            {
                ApplyOperator(values, operators.Pop());
            }

            return values.Pop();
        }

        static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        static int Precedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }

        static void ApplyOperator(Stack<double> values, string op)
        {
            double right = values.Pop();
            double left = values.Pop();

            // Добавляем проверку деления на ноль
            if (op == "/" && right == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }

            switch (op)
            {
                case "+":
                    values.Push(left + right);
                    break;
                case "-":
                    values.Push(left - right);
                    break;
                case "*":
                    values.Push(left * right);
                    break;
                case "/":
                    values.Push(left / right);
                    break;
            }
        }
        //    if (String.IsNullOrWhiteSpace(str))
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        List<string> tokens = Tokenize(str);

        //        return 
        //        // Ваш код для обработки токенов и выполнения вычислений

        //        throw new NotImplementedException();
        //    }

        //    //if (String.IsNullOrWhiteSpace(str))
        //    //{
        //    //    return 0;
        //    //}
        //    //else
        //    //{
        //    //    if (int.TryParse(str, out int int_result))
        //    //    {
        //    //        // Строка является числом, и результат хранится в переменной result
        //    //        return (int_result);
        //    //    }
        //    //    else if (double.TryParse(str, out double double_result))
        //    //    {
        //    //        return (double_result);
        //    //    }

        //    //    else
        //    //    {

        //    //    }
        //    //}

        //    //throw new NotImplementedException();
        //}

        //static List<string> Tokenize(string input)
        //{
        //    List<string> tokens = new List<string>();

        //    string pattern = @"\d+|\+|\-|\*|\/|\(|\)";
        //    MatchCollection matches = Regex.Matches(input, pattern);

        //    foreach (Match match in matches)
        //    {
        //        tokens.Add(match.Value);
        //    }

        //    return tokens;
        //}



        ////public double Calculat(string str)
        ////{
        ////    if (String.IsNullOrWhiteSpace(str))
        ////    {
        ////        return 0;
        ////    }
        ////    else
        ////    {
        ////        for (int i = 0; i < str.Length; i++)
        ////        {

        ////        }
        ////        string[] terms = str.Split('+');
        ////        double result = 0;

        ////        foreach (string term in terms)
        ////        {
        ////            if (double.TryParse(term, out double number))
        ////            {
        ////                result += number;
        ////            }
        ////            else
        ////            {
        ////                throw new NotImplementedException();
        ////            }
        ////        }

        ////        return result;
        ////    }
        ////}
    }
}
