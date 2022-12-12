using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface ITaskRepository
    {
        TaskModel Creating(TaskModel taskModel);
        List<TaskModel> GetAll();
        TaskModel GetById(int id);
        TaskModel Update(TaskModel taskModel);
        bool Delete(int id);
    }
}
