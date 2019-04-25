namespace Principle.Demo.Domain.Staff
{
    public class Manager : BaseEmployee, IManager
    {
        public Manager(string name, string address)
            : base(name, address)
        {
        }

        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 19.75M;

            Salary = baseAmount + (rank * 4);
        }

        public string ReviewPreformance()
        {
            return "Everybody do the work very well.";
        }
    }
}