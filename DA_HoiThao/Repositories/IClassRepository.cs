using DA_HoiThao.Models;

namespace DA_HoiThao.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class> GetByIdAsync(int id);
        Task AddAsync(Class Class);
        Task UpdateAsync(Class Class);
        Task DeleteAsync(int id);

    }
}
