using FluentAssertions;
using NUnit.Framework;
using Principle.Demo.Domain;
using Principle.Demo.Domain.Staff;

namespace Principle.Demo.Test
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void CanCreateEmployee()
        {
            IEmployee employee = NewEmployee();
            employee.Should().NotBeNull();
            employee.Name.Should().Be("user");
            employee.Address.Should().Be("home");
        }

        private BaseEmployee NewEmployee()
        {
            return new Employee("user", "home");
        }


        [Test]
        public void GivenEmployee_WhenAssignManager_ThenManagerBeSetting()
        {
            IManaged employee = NewEmployee();

            IEmployee manager = new Manager("manager", "company");
            employee.AssignManager(manager);

            employee.Manager.Should().NotBeNull();
            IEmployee destManager = employee.Manager;
            destManager.Name.Should().Be("manager");
            destManager.Address.Should().Be("company");
        }


        [Test]
        public void GivenManager_WhenAssignManager_ThenManagerBeSetting()
        {
            IManaged manager = new Manager("manager", "company");

            IEmployee ceo = NewCEO();
            manager.AssignManager(ceo);

            manager.Manager.Should().NotBeNull();
            IEmployee destManager = manager.Manager;
            destManager.Name.Should().Be("ceo");
            destManager.Address.Should().Be("toilet");
        }

        private CEO NewCEO()
        {
            return new CEO("ceo", "toilet");
        }

        [Test]
        public void GivenEmployee_WhenCalculatePerHourRate_ThenPerHourRate()
        {
            IEmployee employee = NewEmployee();

            employee.CalculatePerHourRate(2);

            employee.Salary.Should().BeGreaterThan(0);
        }

        [Test]
        public void GivenManager_WhenCalculatePerHourRate_ThenPerHourRate()
        {
            IEmployee employee = new Manager("manager", "company");

            employee.CalculatePerHourRate(2);

            employee.Salary.Should().BeGreaterThan(0);
        }

        [Test]
        public void GivenCEO_WhenCalculatePerHourRate_ThenPerHourRate()
        {
            IEmployee employee = NewCEO();

            employee.CalculatePerHourRate(2);

            employee.Salary.Should().BeGreaterThan(0);
        }

        [Test]
        public void GivenManager_WhenReviewPerformance_ThenReturnComment()
        {
            IManager manager = new Manager("manager", "company");
            string comment = manager.ReviewPreformance();

            comment.Should().Contain("Everybody do the work very well.");
        }

        //[Test]
        public void GivenCEO_WhenReviewPerformance_ThenReturnComment()
        {
            IManager manager = NewCEO();
            string comment = manager.ReviewPreformance();

            comment.Should().Contain("Good Job.");
        }
    }
}