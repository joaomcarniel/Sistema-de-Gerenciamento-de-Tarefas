using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class AgentProjectRepository : IAgentProjectRepository
    {
        private readonly labwareContext _dbContext;
        public AgentProjectRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Agentproject Creating(Agentproject agentProject)
        {
            _dbContext.Agentprojects.Add(agentProject);
            _dbContext.SaveChanges();
            return agentProject;
        }

        public List<Agentproject> GetAll()
        {
            return _dbContext.Agentprojects.ToList();
        }

        public Agentproject GetById(int id)
        {
            return _dbContext.Agentprojects.FirstOrDefault(x => x.IdAgentProject == id);
        }

        public Agentproject Update(Agentproject agentProject)
        {
            Agentproject agentPrjectDb = GetById(agentProject.IdAgentProject);

            if (agentPrjectDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Agente/Projeto");
            }

            agentPrjectDb.EndAction = agentProject.EndAction;

            _dbContext.Agentprojects.Update(agentPrjectDb);
            _dbContext.SaveChanges();

            return agentPrjectDb;
        }

        public bool Delete(int id)
        {
            Agentproject agentPrjectDb = GetById(id);

            if (agentPrjectDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Agente/Projeto");
            }

            _dbContext.Agentprojects.Remove(agentPrjectDb);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
