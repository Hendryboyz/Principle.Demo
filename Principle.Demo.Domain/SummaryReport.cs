namespace Principle.Demo.Domain
{
    public class SummaryReport : IReport
    {
        public void accept(IFileVisitor fileVisitor)
        {
            fileVisitor.ExportSummaryReport(this);
        }
    }
}