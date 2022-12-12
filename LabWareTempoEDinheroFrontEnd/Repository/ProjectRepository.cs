using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly labwareContext _dbContext;

        public ProjectRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Project Creating(Project project)
        {
            project.StartDate= DateTime.Now;
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project;
        }

        public List<Project> GetAll()
        {
            return _dbContext.Projects.ToList();
        }

        public Project GetById(int id)
        {
            return _dbContext.Projects.FirstOrDefault(x => x.IdProject == id);
        }

        public Project Update(Project project)
        {
            Project projectDb = GetById(project.IdProject);

            if (projectDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Projeto");
            }

            projectDb.StatusProject = project.StatusProject;
            projectDb.NameProject = project.NameProject;
            projectDb.LeaderProject = project.LeaderProject;
            projectDb.EndDate = project.EndDate;
            projectDb.DescriptionProject = project.DescriptionProject;

            _dbContext.Projects.Update(projectDb);
            _dbContext.SaveChanges();

            return projectDb;
        }

        public bool Delete(int id)
        {
            Project projectDb = GetById(id);

            if (projectDb == null)
            {
                throw new System.Exception("Houve um erro na deleção do Projeto");
            }

            _dbContext.Projects.Remove(projectDb);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
