// Services/EnrollmentService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository; // To validate StudentID
        private readonly ICourseRepository _courseRepository;   // To validate CourseID
        private readonly ISemesterRepository _semesterRepository; // To validate SemesterID (assuming you have one)
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository,
                                 IStudentRepository studentRepository,
                                 ICourseRepository courseRepository,
                                 ISemesterRepository semesterRepository,
                                 IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _semesterRepository = semesterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }

        public async Task<EnrollmentDto> GetEnrollmentByIdAsync(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            return _mapper.Map<EnrollmentDto>(enrollment);
        }

        public async Task<bool> CreateEnrollmentAsync(CreateEnrollmentDto createEnrollmentDto)
        {
            // Check if the enrollment already exists (based on the unique constraint)
            if (await _enrollmentRepository.GetByStudentCourseSemesterAsync(
                    createEnrollmentDto.StudentID,
                    createEnrollmentDto.CourseID,
                    createEnrollmentDto.SemesterID) != null)
            {
                return false; // Enrollment already exists
            }

            // Validate StudentID
            var studentExists = await _studentRepository.GetByIdAsync(createEnrollmentDto.StudentID);
            if (studentExists == null)
            {
                return false; // Invalid StudentID
            }

            // Validate CourseID
            var courseExists = await _courseRepository.GetByIdAsync(createEnrollmentDto.CourseID);
            if (courseExists == null)
            {
                return false; // Invalid CourseID
            }

            // Validate SemesterID
            var semesterExists = await _semesterRepository.GetByIdAsync(createEnrollmentDto.SemesterID);
            if (semesterExists == null)
            {
                return false; // Invalid SemesterID
            }

            var enrollment = _mapper.Map<Enrollment>(createEnrollmentDto);
            await _enrollmentRepository.AddAsync(enrollment);
            return await _enrollmentRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var enrollmentToDelete = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollmentToDelete == null)
            {
                return false; // Enrollment not found
            }

            _enrollmentRepository.Delete(enrollmentToDelete);
            return await _enrollmentRepository.SaveChangesAsync();
        }
    }
}