using DA_HoiThao.Data;
using DA_HoiThao.Models;
using DA_HoiThao.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DA_HoiThao.Repositories
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public EFStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Student = await _context.Students.FindAsync(id);
            _context.Students.Remove(Student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task UpdateAsync(Student Student)
        {
            _context.Students.Update(Student);
            await _context.SaveChangesAsync();
        }
    }
}
