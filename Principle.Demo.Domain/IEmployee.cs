namespace Principle.Demo.Domain
{
    public interface IEmployee
    {
        string Name { get; set; }
        string Address { get; set; }
        decimal Salary { get; set; }

        void CalculatePerHourRate(int rank);
    }
}