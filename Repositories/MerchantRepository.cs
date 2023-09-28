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

        public MerchantRepository(ApplicationDbContext dbContext)
        {
            _Context = dbContext;
        }


        public async Task<Merchant> AddMerchant(Merchant merchantdata)
        {
            try
            {
                _Context.Merchants.Add(merchantdata);
                await _Context.SaveChangesAsync();
                return merchantdata;
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
