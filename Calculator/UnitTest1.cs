using System.ComponentModel;
using System;
using System.Linq.Expressions;
using NUnit.Framework;

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

        [TestCase("2+2*-2", -2)]
        [TestCase("-2+4", 2)]
        [TestCase("-1-5", -6)]
        [TestCase("2*34-4*3/5", 65.6)]
        [TestCase("1/1", 1)]
        [TestCase("8/-3", -2.67)]
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
            int digit = 0;
            if (String.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (char.IsDigit(str[i]))
                    {
                        digit++;
                    }
                }
                if (str.Length == digit) {
                }
            }


            double res;
            int intCount = 0;

            if (str.Length == intCount)  
            {  
                return Int32.Parse(str); 
            } 
            if (double.TryParse(str, out res))
            {
            return res;
            }

            try
            {
                var result = new System.Data.DataTable().Compute(str, null);
                return Math.Round(Convert.ToDouble(result), 2);
            }
            catch (Exception)
            {
                return double.NaN;
            }


            throw new NotImplementedException(); 
        } 
    } 
}