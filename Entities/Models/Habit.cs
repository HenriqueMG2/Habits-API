using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Habit
    {
        public int HabitId { get; set; }
        public string Description { get; set; } = "";
        public int Count { get; set;}
        public int UserId { get; set; }
        
    }
}