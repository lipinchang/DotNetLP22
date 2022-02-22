﻿using GatewayAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace GatewayAPI.Services
{
    public class ManageUser : IManageUser<UserDTO>
    {
        private readonly UserContext _context;
        private readonly IGenerateToken<UserDTO> _token;

        public ManageUser(UserContext context, IGenerateToken<UserDTO> token)
        {
            _context = context;
            _token = token;
        }
        public async Task<UserDTO> Add(UserDTO user)
        {
            using var hmac = new HMACSHA512();
            var user1 = new User()
            {
                Username = user.Username,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordHash = hmac.Key,
                Role = "Shopper"

            };
            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
            user.Password = "";
            return new UserDTO() { Username = user.Username, Token = _token.CreateToken(user), Role = "Shopper" };
        }

        public async Task<UserDTO> Login(UserDTO user)
        {
            user.Role = "";
            var myUser = _context.Users.SingleOrDefault(u=>u.Username == user.Username);
            if (myUser == null)
                return null;
            using var hmac = new HMACSHA512(myUser.PasswordHash);
            var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            for (int i = 0; i < userPass.Length; i++)
            {
                if (userPass[i] != myUser.Password[i])
                    return null;
            }
            if(myUser.Role == "Shopper")
                return new UserDTO() { Username = user.Username, Token = _token.CreateToken(user), Role = "Shopper" };
            user.Password = "";   //clean the passworrd before returning
            return new UserDTO() { Username = user.Username, Token = _token.CreateToken(user), Role = "Admin" };




            //should alwyas use try catch 
        }

       


    }
}
