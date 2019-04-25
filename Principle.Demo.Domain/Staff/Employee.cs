namespace Principle.Demo.Domain.Staff
{
    public class Employee : BaseEmployee
    {
        public Employee(string name, string address) 
            : base(name, address)
        {
            
        }

        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 12.50M;

            Salary = baseAmount + (rank * 2);
        }
    }
}