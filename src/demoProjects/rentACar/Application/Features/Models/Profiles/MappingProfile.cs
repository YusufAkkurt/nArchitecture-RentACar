using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Model, ModelListDto>()
			.ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name))
			.ReverseMap();

		CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
	}
}