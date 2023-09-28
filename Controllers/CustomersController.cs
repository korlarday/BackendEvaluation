using AutoMapper;
using Evaluation.Dtos;
using Evaluation.Interfaces;
using Evaluation.Models;
using Evaluation.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerRepository _CustomerRepository { get; set; }
        private readonly IMapper _Mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _CustomerRepository = customerRepository;
            _Mapper = mapper;
            _UnitOfWork = unitOfWork;
        }


        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _CustomerRepository.GetAllCustomers();
                var customersDto = _Mapper.Map<List<Customer>, List<CustomerDto>>(customers);
                return Ok(customersDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetCustomer/{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            try
            {
                var customer = await _CustomerRepository.GetCustomer(customerId);
                if(customer == null) return NotFound();

                var customerDto = _Mapper.Map<Customer, CustomerDto>(customer);
                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(customerDto);
                }
                var customerObj = _Mapper.Map<CustomerDto, Customer>(customerDto);

                var customer = await _CustomerRepository.AddCustomer(customerObj);

                var customerResponse = _Mapper.Map<Customer, CustomerDto>(customer);
                return Ok(customerResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpdateCustomer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto, int customerId)
        {
            try
            {
                var customer = await _CustomerRepository.GetCustomer(customerId);
                if(customer == null) return NotFound();

                _Mapper.Map<CustomerDto, Customer>(customerDto, customer);
                await _UnitOfWork.CompleteAsync();
                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("DeleteCustomer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
                var customer = await _CustomerRepository.GetCustomer(customerId);
                if (customer == null) return NotFound();

                await _CustomerRepository.DeleteCustomer(customer);
                return Ok(customerId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
    }

    
}