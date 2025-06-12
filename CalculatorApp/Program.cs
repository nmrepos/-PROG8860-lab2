using System;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("5 + 3 = " + calc.Add(5, 3));
            Console.WriteLine("5 - 3 = " + calc.Subtract(5, 3));
            Console.WriteLine("5 * 3 = " + calc.Multiply(5, 3));
            Console.WriteLine("5 / 3 = " + calc.Divide(5, 3));
        }
    }
}
