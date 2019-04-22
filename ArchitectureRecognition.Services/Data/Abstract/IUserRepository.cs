using System.Threading.Tasks;

namespace ArchitectureRecognition.Services.Data.Abstract
{
    public interface IUserRepository
    {
        void Add(Entities.User user);

        Task<Entities.User> GetByIdAsync(string id);
    }
}
