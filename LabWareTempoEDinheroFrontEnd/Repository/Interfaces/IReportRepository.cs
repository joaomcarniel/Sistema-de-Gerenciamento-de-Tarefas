using LabWareTempoEDinheroFrontEnd.Models.ReportModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface IReportRepository
    {
        List<ProjectsAgentsWorkingReportModel> GetAgentProjectReport();
    }
}
