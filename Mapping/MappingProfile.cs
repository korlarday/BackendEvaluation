using AutoMapper;
using Evaluation.Dtos;
using Evaluation.Models;

namespace Evaluation.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // From Domain object to Resource

            CreateMap<Customer, CustomerDto>();
            CreateMap<Merchant, MerchantDto>();



            // From Resource to Domain object
            CreateMap<CustomerDto, Customer>()
                .ForMember(p => p.CustomerNumber, opt => opt.Ignore());

            CreateMap<MerchantDto, Merchant>()
                .ForMember(p => p.MerchantNumber, opt => opt.Ignore());


        }

    }
}
