using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;


namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultiesController : Controller
    {
        private readonly IDifficultyRepo _difficultyRepo;
        public DifficultiesController(IDifficultyRepo difficultyRepo)
        {
            _difficultyRepo = difficultyRepo;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var difficultiesDomain = await _difficultyRepo.GetAllAsync();

            var difficultyDto = new List<DifficultyDto>();
            foreach(var difficultieDomain in difficultiesDomain )
            {
                difficultyDto.Add(new DifficultyDto()
                {
                    Id = difficultieDomain.Id,
                    Name = difficultieDomain.Name
                });
            }

            return Ok(difficultyDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var difficultyDomain = await _difficultyRepo.GetByIdAsync(id);

            if (difficultyDomain == null)
                return NotFound();

            var difficultyDto = new DifficultyDto()
            { 
                Id = difficultyDomain.Id,
                Name = difficultyDomain.Name
            };

            return Ok(difficultyDto);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(DifficultyDto difficultyDto)
        {
            if (difficultyDto == null)
                return BadRequest();

            var existingRecord = await _difficultyRepo.GetByIdAsync(difficultyDto.Id);

            if (existingRecord == null)
                return NotFound();

            existingRecord.Name = difficultyDto.Name;

            await _difficultyRepo.UpdateAsync(existingRecord);

            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(AddDifficultyRequestDto addDifficultyDto)
        {
            var difficultyDomain = new Difficulty()
            {
                Name = addDifficultyDto.Name
            };

            await _difficultyRepo.CreateAsync(difficultyDomain);

            var difficultyDto = new DifficultyDto()
            {
                Id = difficultyDomain.Id,
                Name = difficultyDomain.Name
            };

            return Ok(difficultyDto);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var difficultyDomain = await _difficultyRepo.GetByIdAsync(id);

            if (difficultyDomain == null)
                return NotFound();

            await _difficultyRepo.DeleteAsync(difficultyDomain);

            return Ok(true);
        }
    }
}
