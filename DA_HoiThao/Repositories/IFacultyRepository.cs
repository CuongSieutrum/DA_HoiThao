using DA_HoiThao.Models;

namespace DA_HoiThao.Repositories
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetAllAsync();
        Task<Faculty> GetByIdAsync(int id);
        Task AddAsync(Faculty Faculty);
        Task UpdateAsync(Faculty Faculty);
        Task DeleteAsync(int id);
    }
}
