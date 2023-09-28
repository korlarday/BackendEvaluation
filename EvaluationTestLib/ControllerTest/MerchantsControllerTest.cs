using AutoMapper;
using Evaluation.Controllers;
using Evaluation.Dtos;
using Evaluation.Interfaces;
using Evaluation.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationTestLib.ControllerTest
{
    public class MerchantsControllerTest
    {
        private readonly IMerchantRepository _MerchantRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        public MerchantsControllerTest()
        {
            _MerchantRepository = A.Fake<IMerchantRepository>();
            _UnitOfWork = A.Fake<IUnitOfWork>();
            _Mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task MerchantController_GetMerchants_ReturnOk()
        {
            // Arrange
            var merchants = A.Fake<ICollection<MerchantDto>>();
            var merchantLists = A.Fake<List<MerchantDto>>();
            A.CallTo(() => _Mapper.Map<List<MerchantDto>>(merchants)).Returns(merchantLists);
            var controller = new MerchantsController(_MerchantRepository, _Mapper, _UnitOfWork);

            // Act
            var result = await controller.GetMerchants();

            // Assert
            var okResult = result as OkObjectResult;

            result.Should().NotBeNull();
            okResult.Should().NotBeNull();

            okResult.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task MerchantController_CreateMerchant_ReturnOk()
        {
            // Arrange
            var merchant = A.Fake<Merchant>();
            var merchantCreate = A.Fake<MerchantDto>();
            var merchants = A.Fake<ICollection<MerchantDto>>();
            var merchantList = A.Fake<List<MerchantDto>>();

            A.CallTo(() => _Mapper.Map<Merchant>(merchantCreate)).Returns(merchant);
            A.CallTo(() => _MerchantRepository.AddMerchant(merchant)).Returns(merchant);
            var controller = new MerchantsController(_MerchantRepository, _Mapper, _UnitOfWork);

            // Act
            var result = await controller.CreateMerchant(merchantCreate);

            // Assert
            var okResult = result as OkObjectResult;
            result.Should().NotBeNull();
            okResult.Should().NotBeNull();

            okResult.StatusCode.Should().Be(200);
        }
    }
}
