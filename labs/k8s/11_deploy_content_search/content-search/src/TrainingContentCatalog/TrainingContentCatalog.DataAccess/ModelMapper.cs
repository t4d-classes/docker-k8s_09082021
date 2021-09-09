using AutoMapper;
using MongoDB.Bson;

using TrainingContentCatalog.DataAccess.Models;
using TrainingContentCatalog.Models;

using PersonModel = TrainingContentCatalog.Models.Person;
using PersonDataModel = TrainingContentCatalog.DataAccess.Models.Person;
using OrganizationModel = TrainingContentCatalog.Models.Organization;
using OrganizationDataModel = TrainingContentCatalog.DataAccess.Models.Organization;

namespace TrainingContentCatalog.DataAccess
{

  public static class ModelMapper
  {
    public static IMapper CreateMapper()
    {
        MapperConfiguration config = new(cfg => {
          
          cfg.CreateMap<CatalogItem, ContentItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
          cfg.CreateMap<ContentItem, CatalogItem>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

          cfg.CreateMap<PersonDataModel, PersonModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
          cfg.CreateMap<PersonModel, PersonDataModel>()
            .ForSourceMember(src => src.FullName, opt => opt.DoNotValidate())
            .ForSourceMember(src => src.DisplayName, opt => opt.DoNotValidate())
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id == null
              ? ObjectId.GenerateNewId()
              : new ObjectId(src.Id)));

          cfg.CreateMap<OrganizationDataModel, OrganizationModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
          cfg.CreateMap<OrganizationModel, OrganizationDataModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id == null
              ? ObjectId.GenerateNewId()
              : new ObjectId(src.Id)));

        });

        return config.CreateMapper();      
    }
  } 

}