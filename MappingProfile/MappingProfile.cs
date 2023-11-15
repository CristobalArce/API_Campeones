using API_Campeones.ContextBD;
using API_Campeones.Dto;
using AutoMapper;

namespace API_Campeones.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tbcampeon, CampeonDto>()
                    .ForMember(x => x.Dificultad, y => y.MapFrom(z => z.IdDificultadNavigation))
                    .ForMember(x => x.Rol, y => y.MapFrom(z => z.IdRolNavigation));
        }
    }
}
