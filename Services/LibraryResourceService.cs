using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;
using University_OnlineCourse_Management_System.Infrastructure.Repositories;
using University_OnlineCourse_Management_System.Models;
using University_OnlineCourse_Management_System.Services.Interfaces;

namespace University_OnlineCourse_Management_System.Services
{
    public class LibraryResourceService : ILibraryResourceService
    {
        private readonly ILibraryResourceRepository _libraryResourceRepository;
        private readonly IMapper _mapper;

        public LibraryResourceService(ILibraryResourceRepository libraryResourceRepository, IMapper mapper)
        {
            _libraryResourceRepository = libraryResourceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LibraryResourceDto>> GetAllLibraryResourcesAsync()
        {
            var libraryResources = await _libraryResourceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LibraryResourceDto>>(libraryResources);
        }

        public async Task<LibraryResourceDto> GetLibraryResourceByIdAsync(int id)
        {
            var libraryResource = await _libraryResourceRepository.GetByIdAsync(id);
            return _mapper.Map<LibraryResourceDto>(libraryResource);
        }

        public async Task<bool> CreateLibraryResourceAsync(CreateLibraryResourceDto createLibraryResourceDto)
        {
            var libraryResource = _mapper.Map<LibraryResource>(createLibraryResourceDto);
            await _libraryResourceRepository.AddAsync(libraryResource);
            return await _libraryResourceRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateLibraryResourceAsync(int id, UpdateLibraryResourceDto updateLibraryResourceDto)
        {
            var existingLibraryResource = await _libraryResourceRepository.GetByIdAsync(id);
            if (existingLibraryResource == null)
            {
                return false;
            }

            _mapper.Map(updateLibraryResourceDto, existingLibraryResource);
            _libraryResourceRepository.Update(existingLibraryResource);
            return await _libraryResourceRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteLibraryResourceAsync(int id)
        {
            var libraryResourceToDelete = await _libraryResourceRepository.GetByIdAsync(id);
            if (libraryResourceToDelete == null)
            {
                return false;
            }

            _libraryResourceRepository.Delete(libraryResourceToDelete);
            return await _libraryResourceRepository.SaveChangesAsync();
        }
    }
}