using AutoMapper;
using Evaluation.Dtos;
using Evaluation.Interfaces;
using Evaluation.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ApplicationDbContext _Context;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _Context = dbContext;
        }


        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {
                _Context.Customers.Add(customer);
                await _Context.SaveChangesAsync();
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            try
            {
                _Context.Customers.Remove(customer);
                await _Context.SaveChangesAsync();
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                return await _Context.Customers.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            try
            {
                var customer = await _Context.Customers.FindAsync(customerId);
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
