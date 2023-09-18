using WalksAPI.Models.Domain;

namespace WalksAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
