using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_DotNet7.Dtos.Character;
using SuperHeroAPI_DotNet7.Models;
using SuperHeroAPI_DotNet7.Services.CharacterService;

namespace SuperHeroAPI_DotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAll()
        {
            return Ok(await _characterService.GetAll());
        }

        [HttpGet("GetSingle/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newcharacter)
        {
            return Ok(await _characterService.AddCharacter(newcharacter));
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(int id, UpdateCharactersDto newcharacter)
        {
            var response = await _characterService.UpdateCharacter(id, newcharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
