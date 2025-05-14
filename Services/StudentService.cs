// Services/StudentService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository; // To validate DepartmentID
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(string id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> GetStudentByEmailAsync(string email)
        {
            var student = await _studentRepository.GetByEmailAsync(email);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<bool> CreateStudentAsync(CreateStudentDto createStudentDto)
        {
            // Check if StudentID already exists
            if (await _studentRepository.GetByIdAsync(createStudentDto.StudentID) != null)
            {
                return false; // Student ID already exists
            }

            // Check if Email already exists
            if (await _studentRepository.GetByEmailAsync(createStudentDto.Email) != null)
            {
                return false; // Email already exists
            }

            // Validate DepartmentID
            var departmentExists = await _departmentRepository.GetByIdAsync(createStudentDto.DepartmentID);
            if (departmentExists == null)
            {
                return false; // Invalid DepartmentID
            }

            var student = _mapper.Map<Student>(createStudentDto);
            await _studentRepository.AddAsync(student);
            return await _studentRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateStudentAsync(string id, UpdateStudentDto updateStudentDto)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return false; // Student not found
            }

            // Check if the new email is different and already exists
            if (updateStudentDto.Email != null && updateStudentDto.Email != existingStudent.Email && await _studentRepository.GetByEmailAsync(updateStudentDto.Email) != null)
            {
                return false; // New email already exists
            }

            // Validate DepartmentID if it's being updated
            if (updateStudentDto.DepartmentID != null)
            {
                var departmentExists = await _departmentRepository.GetByIdAsync(updateStudentDto.DepartmentID);
                if (departmentExists == null)
                {
                    return false; // Invalid DepartmentID
                }
            }

            _mapper.Map(updateStudentDto, existingStudent);
            _studentRepository.Update(existingStudent);
            return await _studentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentAsync(string id)
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(id);
            if (studentToDelete == null)
            {
                return false; // Student not found
            }

            _studentRepository.Delete(studentToDelete);
            return await _studentRepository.SaveChangesAsync();
        }
    }
}