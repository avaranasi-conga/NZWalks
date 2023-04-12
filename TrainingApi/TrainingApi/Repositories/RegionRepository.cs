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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await trainingDbContext.Regions.ToListAsync();
        }
    }
}
