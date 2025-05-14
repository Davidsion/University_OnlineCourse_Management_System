// Update Profiles/MappingProfile.cs
using AutoMapper;
using Microsoft.Extensions.Configuration;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();

            // Student Mappings
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();

            // Instructor Mappings
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<CreateInstructorDto, Instructor>();
            CreateMap<UpdateInstructorDto, Instructor>();

            // Enrollment Mappings
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<CreateEnrollmentDto, Enrollment>();
            CreateMap<UpdateEnrollmentDto, Enrollment>();

            // Mapping configurations for Assignment
            CreateMap<Assignment, AssignmentDto>().ReverseMap();
            CreateMap<CreateAssignmentDto, Assignment>();
            CreateMap<UpdateAssignmentDto, Assignment>();

            // Mapping configurations for Submission
            CreateMap<Submission, SubmissionDto>().ReverseMap();
            CreateMap<CreateSubmissionDto, Submission>();
            CreateMap<UpdateSubmissionDto, Submission>();

            // Mapping configurations for Announcement
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            CreateMap<CreateAnnouncementDto, Announcement>();
            CreateMap<UpdateAnnouncementDto, Announcement>();


            // Mapping configurations for Exam
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<CreateExamDto, Exam>();
            CreateMap<UpdateExamDto, Exam>();

            // Mapping configurations for Grade
            CreateMap<Grade, GradeDto>().ReverseMap();
            CreateMap<CreateGradeDto, Grade>();
            CreateMap<UpdateGradeDto, Grade>();

            // Mapping configurations for Timetable
            CreateMap<Timetable, TimetableDto>().ReverseMap();
            CreateMap<CreateTimetableDto, Timetable>();
            CreateMap<UpdateTimetableDto, Timetable>();

            // Mapping configurations for LibraryResource
            CreateMap<LibraryResource, LibraryResourceDto>().ReverseMap();
            CreateMap<CreateLibraryResourceDto, LibraryResource>();
            CreateMap<UpdateLibraryResourceDto, LibraryResource>();

            // Mapping configurations for Attendance
            CreateMap<Attendance, Attendance>().ReverseMap();
            CreateMap<CreateAttendanceDto, Attendance>();
            CreateMap<UpdateAttendanceDto, Attendance>();

            // Mapping configurations for Payment
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();
        }
    }
}