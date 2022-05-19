using PM.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Customers
{
    public partial interface ICustomerService
    {
        Task InsertCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task DeleteCustomerById(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomers(bool showHidden = false);
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> GetCustomerByUsername(string username);
    }
}
