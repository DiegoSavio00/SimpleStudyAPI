using SimpleStudyAPI.DTO;

namespace SimpleStudyAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<IEnumerable<StudentDTO>> GetStudentByNameAsync(string name);
        Task<StudentDTO> GetByIdAsync(int id);
        Task CreateAsync(StudentDTO studentDTO);
        Task UpdateAsync(StudentDTO studentDTO);
        Task Remove(int id);
    }
}
