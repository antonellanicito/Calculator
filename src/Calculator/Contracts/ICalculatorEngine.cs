﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Contracts
{
    public interface ICalculatorEngine
    {
        double Calculate(string input);
    }
}
