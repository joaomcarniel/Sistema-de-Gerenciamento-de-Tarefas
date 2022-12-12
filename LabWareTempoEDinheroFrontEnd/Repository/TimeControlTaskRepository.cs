using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class TimeControlTaskRepository : ITimeControlTaskRepository
    {
        private readonly labwareContext _dbContext;

        public TimeControlTaskRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Timecontroltask Creating(Timecontroltask timeControlTask)
        {
            _dbContext.Timecontroltasks.Add(timeControlTask);
            _dbContext.SaveChanges();
            return timeControlTask;
        }

        public List<Timecontroltask> GetAll()
        {
            return _dbContext.Timecontroltasks.ToList();
        }

        public Timecontroltask GetById(int id)
        {
            return _dbContext.Timecontroltasks.FirstOrDefault(x => x.IdTimeControlTask == id);
        }

        public Timecontroltask Update(Timecontroltask timecontrolTask)
        {
            Timecontroltask timeControlTaskDb = GetById(timecontrolTask.IdTimeControlTask);

            if (timeControlTaskDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Registro de Tempo");
            }

            timeControlTaskDb.StartTime = timecontrolTask.StartTime;
            timeControlTaskDb.StopTime = timecontrolTask.StopTime;

            _dbContext.Timecontroltasks.Update(timeControlTaskDb);
            _dbContext.SaveChanges();

            return timeControlTaskDb;
        }

        public bool Delete(int id)
        {
            Timecontroltask timeControlTaskDb = GetById(id);

            if (timeControlTaskDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Registro de Tempo");
            }

            _dbContext.Timecontroltasks.Remove(timeControlTaskDb);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
