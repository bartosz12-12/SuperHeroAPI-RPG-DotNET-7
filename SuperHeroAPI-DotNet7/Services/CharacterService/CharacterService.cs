using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet7.Data;
using SuperHeroAPI_DotNet7.Dtos.Character;
using SuperHeroAPI_DotNet7.Models;

namespace SuperHeroAPI_DotNet7.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
        new Character(),
        new Character{ Id = 1, Name ="Sam"},
        };

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            _context.Character.Add(_mapper.Map<Character>(newCharacter));
            await _context.SaveChangesAsync();
            var dbCharacters = await _context.Character.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
                if (character == null)
                {
                    throw new Exception($"Character with Id '{id}' not found");
                }
                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
                var dbCharacters = await _context.Character.ToListAsync();
                serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Character.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharactersDto updateCharacters)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
                if (character == null)
                {
                    throw new Exception($"Character with Id '{id}' not found");
                }
                character.Name = updateCharacters.Name;
                character.HitPoinsts = updateCharacters.HitPoinsts;
                character.Strenght = updateCharacters.Strenght;
                character.Defense = updateCharacters.Defense;
                character.Intelliegence = updateCharacters.Intelliegence;
                character.RpgClass = updateCharacters.RpgClass;
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
