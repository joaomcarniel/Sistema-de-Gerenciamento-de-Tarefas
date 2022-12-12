using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly labwareContext _dbContext;

        public TaskRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TaskModel Creating(TaskModel taskModel)
        {
            _dbContext.Tasks.Add(taskModel);
            _dbContext.SaveChanges();
            return taskModel;
        }

        public List<TaskModel> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }

        public TaskModel GetById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(x => x.IdTask == id);
        }

        public TaskModel Update(TaskModel task)
        {
            TaskModel taskDb = GetById(task.IdTask);

            if (taskDb == null)
            {
                throw new System.Exception("Houve um erro na atualização da Tarefa");
            }

            taskDb.Objective = task.Objective;
            taskDb.StatusTask = task.StatusTask;

            _dbContext.Tasks.Update(taskDb);
            _dbContext.SaveChanges();

            return taskDb;
        }

        public bool Delete(int id)
        {
            TaskModel taskDb= GetById(id);

            if (taskDb == null)
            {
                throw new System.Exception("Houve um erro na atualização da Tarefa");
            }

            _dbContext.Tasks.Remove(taskDb);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
