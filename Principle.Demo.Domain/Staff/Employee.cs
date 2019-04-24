namespace Principle.Demo.Domain.Staff
{
    public class Employee
    {

        public Employee(string name, string address, float salary)
        {
            Name = name;
            Address = address;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public Employee Manager { get; private set; } = null;

        public virtual void AssignManager(Employee manager)
        {
            Manager = manager;            
        }
    }
}