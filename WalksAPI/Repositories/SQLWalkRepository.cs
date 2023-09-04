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

       

        public async Task<Walk> CreateAsyc(Walk walk)
        {
            await dbContext.walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
