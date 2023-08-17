using AutoMapper;
using SimpleStudyAPI.DTO;
using SimpleStudyAPI.Models;
using SimpleStudyAPI.Repository;

namespace SimpleStudyAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(StudentDTO studentDTO)
        {
            var studentiEntity = _mapper.Map<Student>(studentDTO);
            await _studentRepository.CreateAsync(studentiEntity);
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            try
            {
                var studentEntity = await _studentRepository.GetAllAsync();
                var studentDto = _mapper.Map<IEnumerable<StudentDTO>>(studentEntity);
                return studentDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var studentEntity = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDTO>(studentEntity);
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentByNameAsync(string name)
        {
            var studentEntity = await _studentRepository.GetStudentByNameAsync(name);
            var studentDto = _mapper.Map<IEnumerable<StudentDTO>>(studentEntity);
            return studentDto;
        }

        public async Task Remove(int id)
        {
            var categoryEntity = _studentRepository.GetByIdAsync(id).Result;
            await _studentRepository.DeleteAsync(categoryEntity);
        }

        public async Task UpdateAsync(StudentDTO studentDTO)
        {
            var studentEntity = _mapper.Map<Student>(studentDTO);
            await _studentRepository.UpdateAsync(studentEntity);
        }
    }
}
