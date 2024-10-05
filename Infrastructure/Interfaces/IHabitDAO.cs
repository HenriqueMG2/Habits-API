using Entities.Models;

namespace Infrastructure.Interfaces
{
    public interface IHabitDAO
    {
        public Task<Habit> GetHabitById(int Id);
        public Task<IEnumerable<Habit>> GetAllHabitByUser(int id);
        public Task CreateHabit(Habit habit);
        public Task UpdateHabit(Habit original, Habit atualizada);
        public Task DeleteHabit(int id);
    }
}