using Microsoft.EntityFrameworkCore;
using WalksAPI.Data;
using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly DataBaseContext _dbContext;
        public SQLRegionRepository(DataBaseContext dbContext) 
        { 
            this._dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.regions.ToListAsync();
        }
    }
}
