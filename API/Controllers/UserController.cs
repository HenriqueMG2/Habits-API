using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.Request;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class UserController(IUserDAO _IUserDAO) : Controller
    {
        private readonly IUserDAO IUserDAO = _IUserDAO;

        [HttpPost]
        public async Task<ActionResult> Create(UserRequest user)
        {
            var User = UserRequest.ConvertToEntities(user);
            await IUserDAO.SignIn(User);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}