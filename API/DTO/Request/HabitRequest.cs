using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace API.DTO.Request
{
    public class HabitRequest
    {
        public string Description { get; set; } = "";
        public int Count { get; set;}
        public int UserId { get; set; }
        internal static Habit ConvertToEntities(HabitRequest habit)
        {
            return new Habit
            {
                Description = habit.Description,
                Count = habit.Count,
                UserId = habit.UserId,
            };
        }
    }
}