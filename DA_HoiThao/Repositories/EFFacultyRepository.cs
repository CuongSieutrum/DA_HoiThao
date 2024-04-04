using DA_HoiThao.Data;
using DA_HoiThao.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace DA_HoiThao.Repositories
{
    public class EFFacultyRepository : IFacultyRepository
    {

        private readonly ApplicationDbContext _context;
        public EFFacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Faculty>> GetAllAsync()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<Faculty> GetByIdAsync(int id)
        {
            return await _context.Faculties.FindAsync(id);
        }

        public async Task UpdateAsync(Faculty Faculty)
        {
            _context.Faculties.Update(Faculty);
            await _context.SaveChangesAsync();
        }
    }
}
