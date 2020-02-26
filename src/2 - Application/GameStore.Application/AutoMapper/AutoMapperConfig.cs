using AutoMapper;

namespace GameStore.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings() {
            return new MapperConfiguration( c => {
                c.AddProfile(new DomainToViewModelMappingProfile());
                c.AddProfile(new DTOToDomainMappingProfile());
            });
        }
    }
}