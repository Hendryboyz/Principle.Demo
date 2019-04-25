using System;

namespace Principle.Demo.Domain.Staff
{
    public class CEO : Manager
    {
        public CEO(string name, string address) 
            : base(name, address)
        {
        }

        public override void AssignManager(Employee manager)
        {
            throw new InvalidOperationException("I don't need a manager");           
        }


        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 150M;

            Salary = baseAmount * rank;
        }

        public override string ReviewPreformance()
        {
            throw new InvalidOperationException("this is not my business");
        }
    }
}