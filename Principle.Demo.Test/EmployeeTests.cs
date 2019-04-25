using FluentAssertions;
using NUnit.Framework;
using Principle.Demo.Domain.Staff;

namespace Principle.Demo.Test
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void CanCreateEmployee()
        {
            Employee employee = NewEmployee();
            employee.Should().NotBeNull();
            employee.Name.Should().Be("user");
            employee.Address.Should().Be("home");
        }

        private Employee NewEmployee()
        {
            return new Employee("user", "home");
        }


        [Test]
        public void GivenEmployee_WhenAssignManager_ThenManagerBeSetting()
        {
            Employee employee = NewEmployee();

            Employee manager = NewManager();
            employee.AssignManager(manager);

            employee.Manager.Should().NotBeNull();
            Employee destManager = employee.Manager;
            destManager.Name.Should().Be("manager");
            destManager.Address.Should().Be("company");
        }

        private Manager NewManager()
        {
            return new Manager("manager", "company");
        }

        [Test]
        public void GivenManager_WhenAssignManager_ThenManagerBeSetting()
        {
            Employee manager = NewManager();

            Employee ceo = NewCEO();
            manager.AssignManager(ceo);

            manager.Manager.Should().NotBeNull();
            Employee destManager = manager.Manager;
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
            Employee employee = NewEmployee();

            employee.CalculatePerHourRate(2);

            employee.Salary.Should().BeGreaterThan(0);
        }

        [Test]
        public void GivenManager_WhenCalculatePerHourRate_ThenPerHourRate()
        {
            Employee employee = NewManager();

            employee.CalculatePerHourRate(2);

            employee.Salary.Should().BeGreaterThan(0);
        }

        [Test]
        public void GivenCEO_WhenCalculatePerHourRate_ThenPerHourRate()
        {
            Employee employee = NewCEO();

            employee.CalculatePerHourRate(2);

            employee.Salary.Should().BeGreaterThan(0);
        }

        [Test]
        public void GivenManager_WhenReviewPerformance_ThenReturnComment()
        {
            Manager manager = NewManager();
            string comment = manager.ReviewPreformance();

            comment.Should().Contain("Everybody do the work very well.");
        }

        //[Test]
        public void GivenCEO_WhenAssignManager_ThenManagerBeSetting()
        {
            Employee ceo = NewCEO();

            Employee manager = NewManager();
            ceo.AssignManager(manager);

            ceo.Manager.Should().NotBeNull();
            Employee destManager = ceo.Manager;
            destManager.Name.Should().Be("manager");
            destManager.Address.Should().Be("company");
        }

        //[Test]
        public void GivenCEO_WhenReviewPerformance_ThenReturnComment()
        {
            Manager manager = NewCEO();
            string comment = manager.ReviewPreformance();

            comment.Should().Contain("Everybody do the work very well.");
        }
    }
}