using AutoMapper;
using Evaluation.Dtos;
using Evaluation.Interfaces;
using Evaluation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        public IMerchantRepository _MerchantRepository { get; set; }
        private readonly IMapper _Mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public MerchantsController(IMerchantRepository merchantRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _MerchantRepository = merchantRepository;
            _Mapper = mapper;
            _UnitOfWork = unitOfWork;
        }


        [HttpGet("GetMerchants")]
        public async Task<IActionResult> GetMerchants()
        {
            try
            {
                var merchants = await _MerchantRepository.GetAllMerchants();
                var merchantsDto = _Mapper.Map<List<Merchant>, List<MerchantDto>>(merchants);
                return Ok(merchantsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetMerchant/{merchantId}")]
        public async Task<IActionResult> GetMerchant(int merchantId)
        {
            try
            {
                var merchant = await _MerchantRepository.GetMerchant(merchantId);
                if (merchant == null) return NotFound();

                var merchantDto = _Mapper.Map<Merchant, MerchantDto>(merchant);
                return Ok(merchantDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateMerchant")]
        public async Task<IActionResult> CreateMerchant(MerchantDto merchantDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(merchantDto);
                }
                if(merchantDto.IsBusinessDateLessThanAYear())
                {
                    return BadRequest("Business age is less than a year");
                }
                var merchantObj = _Mapper.Map<MerchantDto, Merchant>(merchantDto);

                var merchant = await _MerchantRepository.AddMerchant(merchantObj);

                var merchantResponse = _Mapper.Map<Merchant, MerchantDto>(merchant);
                return Ok(merchantResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpdateMerchant/{merchantId}")]
        public async Task<IActionResult> UpdateMerchant(MerchantDto merchantDto, int merchantId)
        {
            try
            {
                var merchant = await _MerchantRepository.GetMerchant(merchantId);
                if (merchant == null) return NotFound();

                _Mapper.Map<MerchantDto, Merchant>(merchantDto, merchant);
                await _UnitOfWork.CompleteAsync();
                return Ok(merchantDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("DeleteMerchant/{merchantId}")]
        public async Task<IActionResult> DeleteMerchant(int merchantId)
        {
            try
            {
                var merchant = await _MerchantRepository.GetMerchant(merchantId);
                if (merchant == null) return NotFound();

                await _MerchantRepository.DeleteMerchant(merchant);
                return Ok(merchantId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
