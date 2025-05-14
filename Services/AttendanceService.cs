// Services/AttendanceService.cs
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDto>> GetAllAttendancesAsync()
        {
            var attendances = await _attendanceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
        }

        public async Task<AttendanceDto> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            return _mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<IEnumerable<AttendanceDto>> GetAttendanceByEnrollmentAndDateAsync(int enrollmentId, DateTime date)
        {
            var attendances = await _attendanceRepository.GetByEnrollmentAndDateAsync(enrollmentId, date);
            return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
        }

        public async Task<bool> MarkAttendanceAsync(CreateAttendanceDto createAttendanceDto)
        {
            // Check if attendance for the same enrollment and date already exists
            var existingAttendance = await _attendanceRepository.GetByEnrollmentAndDateAsync(createAttendanceDto.EnrollmentID, createAttendanceDto.Date);
            if (existingAttendance.Any())
            {
                return false; // Or throw an exception indicating duplicate entry
            }

            var attendance = _mapper.Map<Attendance>(createAttendanceDto);
            await _attendanceRepository.AddAsync(attendance);
            return await _attendanceRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAttendanceAsync(int id, UpdateAttendanceDto updateAttendanceDto)
        {
            var existingAttendance = await _attendanceRepository.GetByIdAsync(id);
            if (existingAttendance == null)
            {
                return false;
            }

            _mapper.Map(updateAttendanceDto, existingAttendance);
            _attendanceRepository.Update(existingAttendance);
            return await _attendanceRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendanceToDelete = await _attendanceRepository.GetByIdAsync(id);
            if (attendanceToDelete == null)
            {
                return false;
            }

            _attendanceRepository.Delete(attendanceToDelete);
            return await _attendanceRepository.SaveChangesAsync();
        }
    }
}
