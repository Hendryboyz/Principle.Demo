namespace Principle.Demo.Domain.Staff
{
    public class Manager : Employee
    {
        public Manager(string name, string address, float salary)
            : base(name, address, salary)
        {
        }
    }
}