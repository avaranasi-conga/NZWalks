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
        public IEnumerable<Region> GetAll()
        {
            return trainingDbContext.Regions.ToList();
        }
    }
}
