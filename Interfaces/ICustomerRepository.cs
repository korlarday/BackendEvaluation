﻿using Evaluation.Dtos;
using Evaluation.Models;
using System.Linq.Expressions;

namespace Evaluation.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> DeleteCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(int customerId);
    }
}
