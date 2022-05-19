using PM.Core.Caching;
using PM.Domain.Customers;
using PM.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM.Services.Customers
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerService : ICustomerService
    {
        private readonly ICacheService _cache;
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(ICacheService cache, IRepository<Customer> customerRepository)
        {
            _cache = cache;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Inserts a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            await _customerRepository.AddAsync(customer);
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            await _customerRepository.UpdateAsync(customer);
        }

        /// <summary>
        /// Delete the customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            await _customerRepository.RemoveAsync(customer);
        }

        /// <summary>
        /// Delete customer by id
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task DeleteCustomerById(int customerId)
        {
            if (customerId < 0)
                throw new ArgumentNullException("customerId");

            var entity = await _customerRepository.GetByIdAsync(customerId);
            if (entity == null)
                throw new Exception("Not found customer");

            await _customerRepository.RemoveAsync(entity);
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Customer>> GetAllCustomers(bool showHidden = false)
        {
            if (showHidden)
            {
                return await _customerRepository.FindAsync(row => row.Active);
            }
            else
            {
                return await _customerRepository.GetAllAsync();
            }
        }

        /// <summary>
        /// Gets a customer 
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer</returns>
        public virtual async Task<Customer> GetCustomerById(int customerId)
        {
            if (customerId <= 0)
                return null;

            return await _customerRepository.GetByIdAsync(customerId);
        }
    }
}
