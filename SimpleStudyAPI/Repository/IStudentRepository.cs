using SimpleStudyAPI.Models;

namespace SimpleStudyAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<Student>> GetStudentByNameAsync(string name);
        Task<Student> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<Student> DeleteAsync(Student student);
    }
}
