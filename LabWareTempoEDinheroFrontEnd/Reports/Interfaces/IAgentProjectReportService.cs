using LabWareTempoEDinheroFrontEnd.Models.ReportModels;

namespace LabWareTempoEDinheroFrontEnd.Reports.Interfaces
{
    public interface IAgentProjectReportService
    {
        List<ProjectsAgentsWorkingReportModel> GetAgentProjectReport();
        void GeneratePDF(List<ProjectsAgentsWorkingReportModel> projectAgentReport);
    }
}
