using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Project Creating(Project project);
        List<Project> GetAll();
        Project GetById(int id);
        Project Update(Project project);
        bool Delete(int id);
    }
}
