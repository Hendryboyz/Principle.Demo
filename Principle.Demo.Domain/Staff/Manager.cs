namespace Principle.Demo.Domain.Staff
{
    public class Manager : Employee
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

        public virtual string ReviewPreformance()
        {
            return "Everybody do the work very well.";
        }
    }
}