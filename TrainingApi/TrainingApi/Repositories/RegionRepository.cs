using Microsoft.EntityFrameworkCore;
using TrainingApi.Data;
using TrainingApi.Module.Domain;

namespace TrainingApi.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly TrainingDBContext trainingDbContext;

        public RegionRepository(TrainingDBContext trainingDbContext)
        {
            this.trainingDbContext = trainingDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await trainingDbContext.AddAsync(region);
            await trainingDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await trainingDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }

            //Delete the region
            trainingDbContext.Regions.Remove(region);
            await trainingDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await trainingDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            var region = await trainingDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await trainingDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await trainingDbContext.SaveChangesAsync();

            return existingRegion; 

        }
    }
}
