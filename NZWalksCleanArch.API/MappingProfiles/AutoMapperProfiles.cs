using AutoMapper;
using NZWalksCleanArch.DataService.Enums;
using NZWalksCleanArch.Entities.DbSet;
using NZWalksCleanArch.Entities.Dtos.Difficulties.Responses;
using NZWalksCleanArch.Entities.Dtos.Regions.Requests;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;
using NZWalksCleanArch.Entities.Dtos.Walks.Requests;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.MappingProfiles;

public sealed class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //Regions
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<CreateRegionRequest, Region>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Status.Live))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateRegionRequest, Region>()
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        //Walks
        CreateMap<Walk, WalkDto>().ReverseMap();
        CreateMap<CreateWalkRequest, Walk>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateWalkRequest, Walk>()
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        //Difficulty
        CreateMap<Difficulty, DifficultyDto>().ReverseMap();
    }
}
