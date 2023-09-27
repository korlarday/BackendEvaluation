using AutoMapper;
using Evaluation.Dtos;
using Evaluation.Interfaces;
using Evaluation.Models;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.Repositories
{
    public class MerchantRepository: IMerchantRepository
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;

        public MerchantRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _Context = dbContext;
            _Mapper = mapper;
        }


        public async Task<Merchant> AddMerchant(MerchantDto MerchantDto)
        {
            try
            {
                Merchant Merchant = _Mapper.Map<Merchant>(MerchantDto);
                _Context.Merchants.Add(Merchant);
                await _Context.SaveChangesAsync();
                return Merchant;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Merchant> DeleteMerchant(Merchant Merchant)
        {
            try
            {
                _Context.Merchants.Remove(Merchant);
                await _Context.SaveChangesAsync();
                return Merchant;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Merchant>> GetAllMerchants()
        {
            try
            {
                return await _Context.Merchants.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Merchant> GetMerchant(int MerchantId)
        {
            try
            {
                var Merchant = await _Context.Merchants.FindAsync(MerchantId);
                return Merchant;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
