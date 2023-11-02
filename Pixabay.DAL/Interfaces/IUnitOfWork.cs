using Pixabay.DAL.Entities;

namespace Pixabay.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<MyImage> Images { get; }
        void Save();
    }
}
