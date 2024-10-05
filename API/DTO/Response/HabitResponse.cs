using Entities.Models;

namespace API.DTO.Response
{
    public class HabitResponse
    {
        public int HabitId { get; set; }
        public string Description { get; set; } = "";
        public int Count { get; set;}
        public int UserId { get; set; }
        internal static object ConvertToResponse(Habit habit)
        {
            return new HabitResponse
            {
                HabitId = habit.HabitId,
                Description = habit.Description,
                Count = habit.Count,
                UserId = habit.UserId
            };
        }
    }
}