using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "akbar",
                    Code = "1234",
                }
            };    
        }
    }
}
