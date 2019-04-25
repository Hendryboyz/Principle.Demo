namespace Principle.Demo.Domain.Staff
{
    public abstract class BaseEmployee : IEmployee, IManaged
    {
        public IEmployee Manager { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

        public BaseEmployee(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void AssignManager(IEmployee manager)
        {
            Manager = manager;
        }

        public abstract void CalculatePerHourRate(int rank);
    }
}