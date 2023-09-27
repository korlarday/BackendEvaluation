using Evaluation.Dtos;
using Evaluation.Models;

namespace Evaluation.Interfaces
{
    public interface IMerchantRepository
    {
        Task<Merchant> AddMerchant(MerchantDto merchantDto);
        Task<Merchant> DeleteMerchant(Merchant merchant);
        Task<List<Merchant>> GetAllMerchants();
        Task<Merchant> GetMerchant(int merchantId);
    }
}
