using Microsoft.EntityFrameworkCore;
using SimpleStudyAPI.Data;
using SimpleStudyAPI.Models;

namespace SimpleStudyAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudentByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var students = await _context.Students.Where(n => n.Name.Contains(name)).ToListAsync();
                return students;
            }
            else
            {
                var students = await GetAllAsync();
                return students;
            }
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
