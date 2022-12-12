using LabWareTempoEDinheroFrontEnd.Models.ReportModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface ITaskProjectRepository
    {
        List<TasksFromProjectReportModel> GetTasksProjectReport();
    }
}
