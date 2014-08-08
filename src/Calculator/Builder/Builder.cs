using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator.Builder.Contracts;
using Calculator.Class;
using System.Text.RegularExpressions;
namespace Calculator.Builder
{
    public class Builder : IBuilder
    {
        public Agent GetAgents(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception("Empty string!!!");

            if (!(Regex.IsMatch(input, @"^[0-9/*/+///-]*$")))
                throw new Exception("Wrong format string!!!");

            if (!char.IsDigit(input.ToCharArray()[0]))
                throw new Exception("Wrong format string!!!");
            if (input.Contains("/0"))
                throw new Exception("Div by zero!!!");

            Agent result = getAgent(input);
            return result;
        }


        private Agent getAgent(string input)
        {
            List<AgentType> lst = Enum.GetValues(typeof(AgentType)).OfType<AgentType>()
                    .OrderByDescending(c => Enum.Parse(typeof(AgentType), c.ToString()))
                    .ToList();
            string delimiter = string.Empty;
            foreach (AgentType type in lst)
            {
                delimiter = getDelimiter(type);
                if (input.Contains(delimiter))
                {
                    Agent currentAgent = new Agent(type);

                    List<string> listOfMembers = input.Split(delimiter.ToCharArray()).ToArray().ToList();

                    currentAgent.members.AddRange(listOfMembers
                        .Select(c => new {value = c, IsNumber = Regex.IsMatch(c, "^[0-9]+$")})
                        .Select(c => new Member
                        {
                            memberType = c.IsNumber ? MemberType.Number : MemberType.Agent,
                            value = c.IsNumber ? (dynamic)c : getAgent(c.value)
                        }));
                    return currentAgent;
                }

            }
            return null;
        }
        
        private string getDelimiter(AgentType type)
        {

            switch (type)
            {
                case AgentType.Sum:
                    return "+";

                case AgentType.Sub:
                    return "-";

                case AgentType.Mult:
                    return "*";

                case AgentType.Div:
                    return "/";

                default:
                    return "";

            }

        }
    }
}
