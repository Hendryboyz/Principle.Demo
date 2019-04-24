using System;

namespace Principle.Demo.Domain.Staff
{
    public class CEO : Employee
    {
        public CEO(string name, string address, float salary) 
            : base(name, address, salary)
        {
        }

        public override void AssignManager(Employee manager)
        {
            throw new InvalidOperationException("I don't need a manager");           
        }
    }
}