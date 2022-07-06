using AutoMapper;

namespace OldMutual.Scheme;

public class SchemeApplicationAutoMapperProfile : Profile
{
    public SchemeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Inbound_Mimo_Customer, Inbound_Mimo_CustomerDto>();
        //CreateMap<CreateCustomerSchemeDto, CustomerSchemeDto>();


    }
}
