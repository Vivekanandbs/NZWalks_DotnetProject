using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;
using NZWalks.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Superadmin,Admin")]
    public class RegionController : ControllerBase
    {
        private readonly INzWalksRepo<Region> _regionRepo;
        private APIResponse _apiResponse;

        public RegionController(INzWalksRepo<Region> regionRepo)
        {
            _regionRepo = regionRepo;
            _apiResponse = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                var regionsDomain = await _regionRepo.GetAllAsync();

                if (regionsDomain.Count() == 0)
                    return NotFound();

                _apiResponse.Data = regionsDomain;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<APIResponse>> GetById(Guid id)
        {
            try
            {
                var regionDomain = await _regionRepo.GetByIdAsync(region => region.Id == id);

                if (regionDomain == null)
                    return NotFound();

                _apiResponse.Data = regionDomain;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<APIResponse>> Create(AddRegionRequestDto addRegionRequestDto)
        {
            try
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

                _apiResponse.Data = regionDto;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<APIResponse>> Update(RegionDto regionDto)
        {
            try
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
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpPatch("[action]")]
        public async Task<ActionResult<APIResponse>> UpdatePartial(Guid id, JsonPatchDocument<RegionDto> patchDocument)
        {
            try
            {
                if (patchDocument == null)
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

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                existingRecord.Name = regionsDto.Name;
                existingRecord.Code = regionsDto.Code;
                existingRecord.RegionImageUrl = regionsDto.RegionImageUrl;

                await _regionRepo.UpdatePartialAsync(existingRecord);

                return NoContent();
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<APIResponse>> Delete(Guid id)
        {
            try
            {
                var regionDomain = await _regionRepo.GetByIdAsync(region => region.Id == id);

                if (regionDomain == null)
                    return NotFound();

                await _regionRepo.DeleteAsync(regionDomain);
                _apiResponse.Data = true;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }
    }
}
