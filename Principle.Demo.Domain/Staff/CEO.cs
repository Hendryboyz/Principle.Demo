using System;

namespace Principle.Demo.Domain.Staff
{
    public class CEO : IEmployee, IManager
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

        public CEO(string name, string address)
        {
            Name = name;
            Address = address;
        }


        public void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 150M;

            Salary = baseAmount * rank;
        }

        public string ReviewPreformance()
        {
            return "good job";
        }

        public void FireSomeone()
        {
            Console.WriteLine("You are fired");
        }
    }
}