using AutoMapper;
using SuperHeroAPI_DotNet7.Dtos.Character;
using SuperHeroAPI_DotNet7.Models;

namespace SuperHeroAPI_DotNet7
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharactersDto, Character>();
        }
    }
}
