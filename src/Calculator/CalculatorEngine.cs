using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator.Contracts;
using Calculator.Class;
using Calculator.Builder;
using Calculator.Builder.Contracts;
namespace Calculator
{
    public class CalculatorEngine : ICalculatorEngine
    {
        readonly IBuilder _Builder;

        public CalculatorEngine(IBuilder builder)
        {
            _Builder = builder;
        }
        public double Calculate(string input)
        {
            try
            {
                Agent agent = _Builder.GetAgents(input);

                return agent.Calculate();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
