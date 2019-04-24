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
            Employee employee = new Employee("user", "home", 1000.0f);
            employee.Should().NotBeNull();
            employee.Name.Should().Be("user");
            employee.Address.Should().Be("home");
            employee.Salary.Should().Be(1000.0f);
        }

        
        [Test]
        public void GivenEmployee_WhenAssignManager_ThenManagerBeSetting()
        {
            Employee employee = new Employee("user", "home", 1000.0f);
            
            Employee manager = new Manager("manager", "company", 2000.0f);
            employee.AssignManager(manager);

            employee.Manager.Should().NotBeNull();
            Employee destManager = employee.Manager;
            destManager.Name.Should().Be("manager");
            destManager.Address.Should().Be("company");
            destManager.Salary.Should().Be(2000.0f);
        }

        [Test]
        public void GivenManager_WhenAssignManager_ThenManagerBeSetting()
        {
            Employee manager = new Manager("manager", "company", 2000.0f);
            
            Employee ceo = new CEO("ceo", "toilet", 3000.0f);
            manager.AssignManager(ceo);

            manager.Manager.Should().NotBeNull();
            Employee destManager = manager.Manager;
            destManager.Name.Should().Be("ceo");
            destManager.Address.Should().Be("toilet");
            destManager.Salary.Should().Be(3000.0f);
        }

        [Test]
        public void GivenCEO_WhenAssignManager_ThenManagerBeSetting()
        {
            Employee ceo = new CEO("ceo", "toilet", 3000.0f);

            Employee manager = new Manager("manager", "company", 2000.0f);
            ceo.AssignManager(manager);

            ceo.Manager.Should().NotBeNull();
            Employee destManager = ceo.Manager;
            destManager.Name.Should().Be("manager");
            destManager.Address.Should().Be("company");
            destManager.Salary.Should().Be(3000.0f);
        }
    }
}