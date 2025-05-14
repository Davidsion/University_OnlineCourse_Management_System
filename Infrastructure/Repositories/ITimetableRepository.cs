// Infrastructure/Repositories/ITimetableRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using University_OnlineCourse_Management_System.Models;

namespace University_OnlineCourse_Management_System.Infrastructure.Repositories
{
    public interface ITimetableRepository
    {
        Task<IEnumerable<Timetable>> GetAllAsync();
        Task<Timetable> GetByIdAsync(int id);
        Task AddAsync(Timetable timetable);
        void Update(Timetable timetable);
        void Delete(Timetable timetable);
        Task<bool> SaveChangesAsync();
    }
}
