using AutoMapper;
using NormasService.Application.Models;
using NormasService.Domain.Entities;

namespace NormasService.Application.Mapping
{
    public class NormaMap : Profile
    {
        public NormaMap()
        {
            CreateMap<Norma, NormaModel>();

            CreateMap<NormaModel, Norma>();
        }
    }
}
