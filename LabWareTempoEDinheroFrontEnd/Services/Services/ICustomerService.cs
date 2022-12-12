using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface ICustomerService
    {
        Customer Creating(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer Update(Customer customer);
        void Delete(int id);
    }
}
