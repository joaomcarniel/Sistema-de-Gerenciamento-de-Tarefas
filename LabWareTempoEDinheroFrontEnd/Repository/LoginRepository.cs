using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.Authorization;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly labwareContext _dbContext;

        public LoginRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User FindActiveUser(User user)
        {
            var userDb = _dbContext.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password && x.Status == 1);
            if(userDb == null)
            {
                return new User();
            }
            return userDb;
        } 
    }
}
