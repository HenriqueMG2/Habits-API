using Entities.Context;
using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class HabitDAO(Context _Context) : IHabitDAO
    {
        private readonly Context DbContext = _Context;
        
        public async Task CreateHabit(Habit habit)
        {
            try
            {
                DbContext.Add(habit);
                await DbContext.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new Exception("Erro ao cadastrar hábito.");
            }
        }

        public async Task DeleteHabit(int id)
        {
            try
            {
                var habit = await GetHabitById(id);

                DbContext.Remove(habit);
                await DbContext.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new Exception("Erro ao deletar habito!.");
            }
        }

        public async Task<IEnumerable<Habit>> GetAllHabitByUser(int id)
        {
            try
            {
                var query = await (from HBT in DbContext.Habit
                                   where HBT.UserId == id
                                   select HBT
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
                
                return query;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao consultar as vendas.");
            }
        }

        public async Task<Habit> GetHabitById(int Id)
        {
            try
            {
                var query = await (from HBT in DbContext.Habit
                                   where HBT.HabitId == Id
                                   select HBT
                                  )
                                  .FirstOrDefaultAsync();

                return query;
            }
            catch(DbUpdateException)
            {
                throw new Exception("Usuário ou senha incorretos!.");
            }
        }

        public Task UpdateHabit(Habit original, Habit atualizada)
        {
            throw new NotImplementedException();
        }
    }
}