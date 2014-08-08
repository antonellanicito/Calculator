using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator.Class;

namespace Calculator.Builder.Contracts
{
    public interface IBuilder
    {
        Agent GetAgents(string input);
    }
}
