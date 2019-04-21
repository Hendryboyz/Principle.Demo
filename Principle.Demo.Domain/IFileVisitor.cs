namespace Principle.Demo.Domain
{
    public interface IFileVisitor
    {
        void ExportReport();
        void ExportSummaryReport(IReport report);
    }
}