using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsyc(Walk walk);
    }
}
