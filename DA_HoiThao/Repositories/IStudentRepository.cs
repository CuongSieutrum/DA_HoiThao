using DA_HoiThao.Models;
using System.Collections.Generic;
namespace DA_HoiThao.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int id);
    Task AddAsync(Student Student);
    Task UpdateAsync(Student Student);
    Task DeleteAsync(int id);
}
