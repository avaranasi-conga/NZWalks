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

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = regionRepository.GetAll();

            var regionsDTO = new List<Module.DTO.Region>();

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
            });

            return Ok(regionsDTO);

        }
    }
}
