﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingApi.Module.Domain;
using TrainingApi.Module.DTO;
using TrainingApi.Repositories;

namespace TrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;

        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();

            /* var regionsDTO = new List<Module.DTO.Region>();
 
             regions.ToList().ForEach(region =>
             {
                 var regionDTO = new Module.DTO.Region()
                 {
                     Id = region.Id,
                     Name = region.Name,
                     Code = region.Code,
                     Area = region.Area,
                     Lat = region.Lat,
                     Long = region.Long,
                     Population = region.Population,
 
                 };
 
                 regionsDTO.Add(regionDTO);
             });*/

            var regionsDTO = mapper.Map<List<Module.DTO.Region>>(regions);

            return Ok(regionsDTO);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Module.DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Module.DTO.AddRegionRequest addRegionRequest)
        {
            //Request to domain model
           var region = new Module.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population
            };
          // var region = mapper.Map<List<Module.Domain.Region>>(addRegionRequest);

            //Pass details to Repository
            region = await regionRepository.AddAsync(region);

            //Convert back to DTO
            var regionDTO = new Module.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long, 
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync),new {id = regionDTO.Id}, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //Get region from database
            var region = await regionRepository.DeleteAsync(id);

            //If null not found
            if (region == null)
            {
                return NotFound();
            }
            //Convert response back to DTO
            var regionDTO = new Module.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            //return ok response
            return Ok(regionDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id,
            [FromBody] Module.DTO.UpdateRegionRequest updateRegionRequest)
        {
            //Convert DTO to domain model
            var region = new Module.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population
            };

            //Update region using repository
            region = await regionRepository.UpdateAsync(id, region);

            //If null not found
            if (region == null)

            {
                return NotFound();
            }

            //Convert back to DTO
            var regionDTO = new Module.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            //Return ok response
            return Ok(regionDTO);
        }
    }
}
