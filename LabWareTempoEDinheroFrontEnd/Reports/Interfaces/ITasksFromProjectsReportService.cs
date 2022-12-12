using LabWareTempoEDinheroFrontEnd.Models.ReportModels;

namespace LabWareTempoEDinheroFrontEnd.Reports.Interfaces
{
    public interface ITasksFromProjectsReportService
    {
        List<TasksFromProjectReportModel> GetTasksProjectReport();
        void GeneratePDF(List<TasksFromProjectReportModel> taskProjectReport);
    }
}
