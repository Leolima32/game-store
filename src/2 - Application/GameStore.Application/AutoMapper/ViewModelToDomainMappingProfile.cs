using AutoMapper;
using GameStore.Application.DTOS.Companies;
using GameStore.Application.DTOS.Games;
using GameStore.Application.DTOS.Genres;
using GameStore.Application.DTOS.Platforms;
using GameStore.Application.ViewModels;
using GameStore.Domain.Entities;

namespace GameStore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;

            //DTOS only for post
            //thats why should be translated only from a viewmodel to a entity
            //never outerwise.
            CreateMap<AddOrUpdateGameDTO,Game>();
            CreateMap<AddOrUpdateCompanyDTO, Company>();
            CreateMap<AddOrUpdateGenreDTO, Genre>();
            CreateMap<AddOrUpdatePlatformDTO, Platform>();
        }
    }
}