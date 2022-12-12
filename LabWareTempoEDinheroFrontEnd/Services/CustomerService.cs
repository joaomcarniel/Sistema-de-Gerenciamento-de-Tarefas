using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Creating(Customer customer)
        {
            return customerRepository.Creating(customer);
        }

        public List<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);
        }

        public Customer Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }

        public void Delete(int id)
        {
            try
            {
                customerRepository.Delete(id);
            }
            catch (Exception e)
            {

            }
        }
    }
}
