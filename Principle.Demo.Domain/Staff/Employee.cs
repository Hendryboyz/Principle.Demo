namespace Principle.Demo.Domain.Staff
{
    public class Employee
    {
        public Employee(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public Employee Manager { get; private set; } = null;

        public virtual void AssignManager(Employee manager)
        {
            Manager = manager;            
        }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 12.50M;

            Salary = baseAmount + (rank * 2);
        }
    }
}