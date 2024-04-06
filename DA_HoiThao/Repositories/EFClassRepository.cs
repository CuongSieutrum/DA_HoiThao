using DA_HoiThao.Data;
using DA_HoiThao.Models;
using Microsoft.EntityFrameworkCore;

namespace DA_HoiThao.Repositories
{
    public class EFClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public EFClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Class Class)
        {
            _context.Classes.Add(Class);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Class = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(Class);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task UpdateAsync(Class Class)
        {
            _context.Classes.Update(Class);
            await _context.SaveChangesAsync();
        }
    }
}
