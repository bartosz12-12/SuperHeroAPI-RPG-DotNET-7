using SuperHeroAPI_DotNet7.Dtos.Character;
using SuperHeroAPI_DotNet7.Models;

namespace SuperHeroAPI_DotNet7.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAll();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharactersDto updateCharacters);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}

