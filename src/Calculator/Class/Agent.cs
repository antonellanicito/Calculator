using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Class
{
public class Agent
    {
        delegate double CalculationHandler(List<double> operands, AgentType type);
        public AgentType agentType { get; set; }
        public List<Member> members { get; set; }

        public Agent(AgentType type)
        {
            agentType = type;
            members = new List<Member>();
        }
        public double Calculate()
        {
            CalculationHandler handler =  new CalculationHandler(SumHandler);
            switch (agentType)
            {
                case AgentType.Sum:
                    handler = new CalculationHandler(SumHandler);
                    break;
                case AgentType.Sub:
                    handler = new CalculationHandler(SubHandler);
                    break;
                case AgentType.Mult:
                    handler = new CalculationHandler(MultHandler);
                    break;
                case AgentType.Div:
                    handler = new CalculationHandler(DivHandler);
                    break;
            }

            return handler(members
                        .Select(c => (c.memberType.Equals(MemberType.Number)) ? Convert.ToDouble((string)c.value.value) : (double) c.value.Calculate() )
                    
                .ToList(), this.agentType); 
            
        }
        private double SumHandler(List<double> operands, AgentType type)
        {
            return operands.Sum();
        }
        private double SubHandler(List<double> operands, AgentType type)
        {
            return operands.Select((c, i) => (i == 0 ? c : (-c))).Sum();
        }
        private double MultHandler(List<double> operands, AgentType type)
        {
            return operands.Aggregate((double) 1, (x, y) => (x * y));
        }  
        private double DivHandler(List<double> operands, AgentType type)
        {
            return operands.Select((c, i) => (i == 0 ? c : (1 / c))).Aggregate((double)1, (x, y) => (x * y));
        }
    }

    public class Member
    {
        public MemberType memberType { get; set; }
        public dynamic value { get; set; }
 
    }
    public enum AgentType
    {   
        Div = 1,
        Mult = 2,
        Sub = 3,
        Sum = 4 
    }
    public enum MemberType
    {
        Number = 1,
        Agent = 2
    }
}


