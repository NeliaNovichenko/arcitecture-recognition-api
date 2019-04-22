using System.Threading.Tasks;

namespace ArchitectureRecognition.Services.Data.Abstract
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}
