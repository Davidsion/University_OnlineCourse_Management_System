// Services/CourseService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository; // To validate DepartmentID

        public CourseService(ICourseRepository courseRepository, IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetCourseByIdAsync(string id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> GetCourseByCodeAsync(string courseCode)
        {
            var course = await _courseRepository.GetByCourseCodeAsync(courseCode);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<bool> CreateCourseAsync(CreateCourseDto createCourseDto)
        {
            if (await _courseRepository.GetByIdAsync(createCourseDto.CourseID) != null)
            {
                return false; // Course ID already exists
            }

            if (await _courseRepository.GetByCourseCodeAsync(createCourseDto.CourseCode) != null)
            {
                return false; // Course code already exists
            }

            var departmentExists = await _departmentRepository.GetByIdAsync(createCourseDto.DepartmentID);
            if (departmentExists == null)
            {
                return false; // Invalid DepartmentID
            }

            var course = _mapper.Map<Course>(createCourseDto);
            await _courseRepository.AddAsync(course);
            return await _courseRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateCourseAsync(string id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _courseRepository.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return false;
            }

            if (updateCourseDto.CourseCode != null && updateCourseDto.CourseCode != existingCourse.CourseCode && await _courseRepository.GetByCourseCodeAsync(updateCourseDto.CourseCode) != null)
            {
                return false; // New course code already exists
            }

            if (updateCourseDto.DepartmentID != null)
            {
                var departmentExists = await _departmentRepository.GetByIdAsync(updateCourseDto.DepartmentID);
                if (departmentExists == null)
                {
                    return false; // Invalid DepartmentID
                }
            }

            _mapper.Map(updateCourseDto, existingCourse);
            _courseRepository.Update(existingCourse);
            return await _courseRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCourseAsync(string id)
        {
            var courseToDelete = await _courseRepository.GetByIdAsync(id);
            if (courseToDelete == null)
            {
                return false;
            }

            _courseRepository.Delete(courseToDelete);
            return await _courseRepository.SaveChangesAsync();
        }
    }
}
