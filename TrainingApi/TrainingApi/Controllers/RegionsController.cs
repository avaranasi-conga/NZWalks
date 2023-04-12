using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingApi.Module.Domain;
using TrainingApi.Repositories;

namespace TrainingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;

        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
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
    }
}
