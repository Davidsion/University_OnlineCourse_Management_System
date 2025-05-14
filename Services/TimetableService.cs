// Services/TimetableService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly IMapper _mapper;

        public TimetableService(ITimetableRepository timetableRepository, IMapper mapper)
        {
            _timetableRepository = timetableRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TimetableDto>> GetAllTimetablesAsync()
        {
            var timetables = await _timetableRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TimetableDto>>(timetables);
        }

        public async Task<TimetableDto> GetTimetableByIdAsync(int id)
        {
            var timetable = await _timetableRepository.GetByIdAsync(id);
            return _mapper.Map<TimetableDto>(timetable);
        }

        public async Task<bool> CreateTimetableAsync(CreateTimetableDto createTimetableDto)
        {
            var timetable = _mapper.Map<Timetable>(createTimetableDto);
            await _timetableRepository.AddAsync(timetable);
            return await _timetableRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateTimetableAsync(int id, UpdateTimetableDto updateTimetableDto)
        {
            var existingTimetable = await _timetableRepository.GetByIdAsync(id);
            if (existingTimetable == null)
            {
                return false;
            }

            _mapper.Map(updateTimetableDto, existingTimetable);
            _timetableRepository.Update(existingTimetable);
            return await _timetableRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteTimetableAsync(int id)
        {
            var timetableToDelete = await _timetableRepository.GetByIdAsync(id);
            if (timetableToDelete == null)
            {
                return false;
            }

            _timetableRepository.Delete(timetableToDelete);
            return await _timetableRepository.SaveChangesAsync();
        }
    }
}
