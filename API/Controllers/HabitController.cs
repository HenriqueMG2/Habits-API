using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Request;
using API.DTO.Response;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class HabitController(IHabitDAO _IHabitDAO) : Controller
    {
        private readonly IHabitDAO IHabitDAO = _IHabitDAO;

        [HttpPost]
        public async Task<ActionResult> Create(HabitRequest habit)
        {
            var Habit = HabitRequest.ConvertToEntities(habit);
            await IHabitDAO.CreateHabit(Habit);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await IHabitDAO.DeleteHabit(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitResponse>>> GetAllProduto(int userId)
        {
            var habits = await IHabitDAO.GetAllHabitByUser(userId);
            var habitsResponse = habits.Select(HabitResponse.ConvertToResponse);

            if (habitsResponse.Any())
                return Ok(habitsResponse);

            return NoContent();
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult> GetHabitById(int id)
        {

            var habit = await IHabitDAO.GetHabitById(id);

            if (habit is null)
                return NoContent();

            var habitResponse = HabitResponse.ConvertToResponse(habit);
            return Ok(habitResponse);
        }
    }
}