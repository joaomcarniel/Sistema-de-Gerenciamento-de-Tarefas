using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Models.ReportModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class TaskProjectRepository : ITaskProjectRepository
    {
        private readonly labwareContext dbContext;

        public TaskProjectRepository(labwareContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TasksFromProjectReportModel> GetTasksProjectReport()
        {
            return dbContext.TaskProjectModels.FromSqlRaw("SELECT t.idTask, t.objective, t.statusTask, p.nameProject, " +
                "p.descriptionProject from task t INNER JOIN agentproject ap ON t.idAgentProject = ap.idAgentProject " +
                "INNER JOIN project p ON ap.idProject = p.idProject; ").ToList();
        }
    }
}
