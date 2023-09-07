using Microsoft.EntityFrameworkCore;
using WalksAPI.Data;
using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly DataBaseContext dbContext;

        public SQLWalkRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

       

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.walks.Include("Difficulity").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.walks.Include("Difficulity").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
