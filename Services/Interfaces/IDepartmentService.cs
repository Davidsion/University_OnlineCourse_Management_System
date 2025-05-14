// Services/Interfaces/IDepartmentService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.DTO;

namespace University_OnlineCourse_Management_System.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentByIdAsync(string id);
        Task<bool> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task<bool> UpdateDepartmentAsync(string id, UpdateDepartmentDto updateDepartmentDto);
        Task<bool> DeleteDepartmentAsync(string id);
    }
}
