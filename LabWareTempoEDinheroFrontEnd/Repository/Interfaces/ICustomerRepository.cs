using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Customer Creating(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer Update(Customer customer);
        bool Delete(int id);
    }
}
