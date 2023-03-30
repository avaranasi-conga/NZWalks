using TrainingApi.Module.Domain;

namespace TrainingApi.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
    }
}
