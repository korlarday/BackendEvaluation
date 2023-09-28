using AutoMapper;
using Evaluation.Controllers;
using Evaluation.Dtos;
using Evaluation.Interfaces;
using Evaluation.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace EvaluationTestLib.ControllerTest
{
    public class CustomersControllerTest
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public CustomersControllerTest()
        {
            _CustomerRepository = A.Fake<ICustomerRepository>();
            _UnitOfWork = A.Fake<IUnitOfWork>();
            _Mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task CustomerController_GetCustomers_ReturnOk()
        {
            // Arrange
            var customers = A.Fake<ICollection<CustomerDto>>();
            var customerLists = A.Fake<List<CustomerDto>>();
            A.CallTo(() => _Mapper.Map<List<CustomerDto>>(customers)).Returns(customerLists);
            var controller = new CustomersController(_CustomerRepository, _Mapper, _UnitOfWork);

            // Act
            var result = await controller.GetCustomers();

            // Assert
            var okResult = result as OkObjectResult;

            result.Should().NotBeNull();
            okResult.Should().NotBeNull();

            okResult.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task CustomerController_CreateCustomer_ReturnOk()
        {
            // Arrange
            var customer = A.Fake<Customer>();
            var customerCreate = A.Fake<CustomerDto>();
            var customers = A.Fake<ICollection<CustomerDto>>();
            var customerList = A.Fake<List<CustomerDto>>();

            A.CallTo(() => _Mapper.Map<Customer>(customerCreate)).Returns(customer);
            A.CallTo(() => _CustomerRepository.AddCustomer(customer)).Returns(customer);
            var controller = new CustomersController(_CustomerRepository, _Mapper, _UnitOfWork);

            // Act
            var result = await controller.CreateCustomer(customerCreate);

            // Assert
            var okResult = result as OkObjectResult;
            result.Should().NotBeNull();
            okResult.Should().NotBeNull();

            okResult.StatusCode.Should().Be(200);
        }





    }
}
