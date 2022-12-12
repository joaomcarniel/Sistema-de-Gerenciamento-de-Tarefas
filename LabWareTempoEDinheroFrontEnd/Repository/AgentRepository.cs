using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly labwareContext _dbContext;

        public AgentRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Agent Creating(Agent agent)
        {
            _dbContext.Agents.Add(agent);
            _dbContext.SaveChanges();
            return agent;
        }

        public List<Agent> GetAll()
        {
            return _dbContext.Agents.ToList();
        }

        public Agent GetById(int id)
        {
            return _dbContext.Agents.FirstOrDefault(x => x.IdAgent == id);
        }

        public Agent Update(Agent agent)
        {
            Agent agentDb = GetById(agent.IdAgent);

            if (agentDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Agente/Projeto");
            }

            agentDb.NameAgent = agent.NameAgent;
            agentDb.StatusAgent = agent.StatusAgent;

            _dbContext.Agents.Update(agentDb);
            _dbContext.SaveChanges();

            return agentDb;
        }

        public bool Delete(int id)
        {
            Agent agentDb = GetById(id);

            if (agentDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Agente/Projeto");
            }

            _dbContext.Agents.Remove(agentDb);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
