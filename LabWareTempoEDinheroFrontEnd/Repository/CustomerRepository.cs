using LabWareTempoEDinheroFrontEnd.Data;
using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly labwareContext _dbContext;

        public CustomerRepository(labwareContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer Creating(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.IdCustomer == id);
        }

        public Customer Update(Customer customer)
        {
            Customer customerDb = GetById(customer.IdCustomer);

            if (customerDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Agente/Projeto");
            }

            customerDb.NameCustomer = customer.NameCustomer;
            customerDb.AddressCustomer = customer.AddressCustomer;
            customerDb.TelephoneCustomer = customer.TelephoneCustomer;
            customerDb.StatusCustomer = customer.StatusCustomer;

            _dbContext.Customers.Update(customerDb);
            _dbContext.SaveChanges();

            return customerDb;
        }

        public bool Delete(int id)
        {
            Customer customerDb = GetById(id);

            if (customerDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do Agente/Projeto");
            }

            _dbContext.Customers.Remove(customerDb);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
