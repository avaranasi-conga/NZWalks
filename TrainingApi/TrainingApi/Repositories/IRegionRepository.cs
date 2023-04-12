using TrainingApi.Module.Domain;

namespace TrainingApi.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
