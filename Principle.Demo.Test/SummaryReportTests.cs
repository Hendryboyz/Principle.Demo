using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Principle.Demo.Domain;

namespace Principle.Demo.Test
{
    [TestFixture]
    public class SummaryReportTests
    {
        private SummaryReport report;

        [Test]
        public void CanCreate()
        {
            report = new SummaryReport();
            report.Should().BeAssignableTo<IReport>();
            report.Should().NotBeNull();
        }


        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }


        [Test]
        public void GivenIVisitor_WhenAccept_ThenExportSummaryReportWillBeCall()
        {
            IFileVisitor fileVistor = Substitute.For<IFileVisitor>();

            report.accept(fileVistor);

            fileVistor.Received().ExportSummaryReport(Arg.Any<SummaryReport>());
        }
    }
}