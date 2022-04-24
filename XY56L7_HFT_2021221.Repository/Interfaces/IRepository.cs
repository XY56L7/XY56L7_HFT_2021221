using System.Linq;

namespace XY56L7_HFT_2021221.Repository.GenericRepository
{
    public interface IRepository<T>
    {
        void Create(T item);
        void Delete(int id);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
    }
}