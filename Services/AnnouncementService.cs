// Services/AnnouncementService.cs
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper _mapper;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAllAnnouncementsAsync()
        {
            var announcements = await _announcementRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnnouncementDto>>(announcements);
        }

        public async Task<AnnouncementDto> GetAnnouncementByIdAsync(int id)
        {
            var announcement = await _announcementRepository.GetByIdAsync(id);
            return _mapper.Map<AnnouncementDto>(announcement);
        }

        public async Task<bool> CreateAnnouncementAsync(CreateAnnouncementDto createAnnouncementDto)
        {
            var announcement = _mapper.Map<Announcement>(createAnnouncementDto);
            await _announcementRepository.AddAsync(announcement);
            return await _announcementRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAnnouncementAsync(int id, UpdateAnnouncementDto updateAnnouncementDto)
        {
            var existingAnnouncement = await _announcementRepository.GetByIdAsync(id);
            if (existingAnnouncement == null)
            {
                return false;
            }

            _mapper.Map(updateAnnouncementDto, existingAnnouncement);
            _announcementRepository.Update(existingAnnouncement);
            return await _announcementRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAnnouncementAsync(int id)
        {
            var announcementToDelete = await _announcementRepository.GetByIdAsync(id);
            if (announcementToDelete == null)
            {
                return false;
            }

            _announcementRepository.Delete(announcementToDelete);
            return await _announcementRepository.SaveChangesAsync();
        }
    }
}