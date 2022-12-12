using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.ReportModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly labwareContext dbContext;

        public ReportRepository(labwareContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ProjectsAgentsWorkingReportModel> GetAgentProjectReport()
        {
            return dbContext.ProAgentWorkModels.FromSqlRaw("select a.idAgent, a.nameAgent, p.idProject, p.nameProject, p.descriptionProject, " +
                "p.statusProject from agent a inner join agentProject ap on a.idAgent = ap.idAgent inner join project p on ap.idProject = p.idProject;").ToList();
        }
    }
}
