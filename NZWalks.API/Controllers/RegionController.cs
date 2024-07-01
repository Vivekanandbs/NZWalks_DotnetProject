using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;
using NZWalks.API.Models;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly INzWalksRepo<Region> _regionRepo;

        public RegionController(INzWalksRepo<Region> regionRepo)
        {
            _regionRepo = regionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepo.GetAllAsync();

            if(regionsDomain.Count() == 0)
                return NotFound();

            var regionDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            return Ok(regionDto);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var regionDomain = await _regionRepo.GetByIdAsync(region => region.Id == id);

            if (regionDomain == null)
                return NotFound();

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(AddRegionRequestDto addRegionRequestDto)
        {
            if (addRegionRequestDto.Name.Length == 0)
                return BadRequest("Name Field should have atleast one charecter");
            if (addRegionRequestDto.Code.Length == 0)
                return BadRequest("Region Code is required");

            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code.ToUpper(),
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            
            await _regionRepo.CreateAsync(regionDomainModel);

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(RegionDto regionDto)
        {
            if (regionDto == null)
                return BadRequest();

            var existingRecord = await _regionRepo.GetByIdAsync(region => region.Id == regionDto.Id);

            if (existingRecord == null)
                return NotFound();

            existingRecord.Name = regionDto.Name;
            existingRecord.Code = regionDto.Code;
            existingRecord.RegionImageUrl = regionDto.RegionImageUrl;

            await _regionRepo.UpdateAsync(existingRecord);

            return NoContent();
        }

        [HttpPatch("[action]")]
        public async Task<IActionResult> UpdatePartial(Guid id, JsonPatchDocument<RegionDto> patchDocument)
        {
            if(patchDocument == null)
                return BadRequest();

            var existingRecord = await _regionRepo.GetByIdAsync(region => region.Id == id);

            if (existingRecord == null)
                return NotFound();

            var regionsDto = new RegionDto
            {
                Id = existingRecord.Id,
                Name = existingRecord.Name,
                Code = existingRecord.Code,
                RegionImageUrl = existingRecord.RegionImageUrl
            };

            patchDocument.ApplyTo(regionsDto, ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            existingRecord.Name = regionsDto.Name;
            existingRecord.Code = regionsDto.Code;
            existingRecord.RegionImageUrl = regionsDto.RegionImageUrl;
            
            await _regionRepo.UpdatePartialAsync(existingRecord);

            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var regionDomain = await _regionRepo.GetByIdAsync(region => region.Id == id);

            if (regionDomain == null)
                return NotFound();

            await _regionRepo.DeleteAsync(regionDomain);

            return NoContent();
        }
    }
}
