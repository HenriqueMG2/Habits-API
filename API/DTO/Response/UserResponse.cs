using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace API.DTO.Response
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }

        internal static UserResponse ConvertToResponse(User user)
        {
            return new UserResponse
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreateAt = user.CreateAt,
            };
        }
    }
}