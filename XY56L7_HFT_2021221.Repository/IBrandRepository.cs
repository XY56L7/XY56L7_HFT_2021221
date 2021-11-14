using System.Linq;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
    }
}