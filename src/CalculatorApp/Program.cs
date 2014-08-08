using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator;
using Calculator.Builder;
using Calculator.Builder.Contracts;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String input = args[0];
                IBuilder builder = new Builder();
                CalculatorEngine engine = new CalculatorEngine(builder);
                double result = engine.Calculate(input);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            { Console.WriteLine("Error = " + ex.Message); }
        }
    }
}
