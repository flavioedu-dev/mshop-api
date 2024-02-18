using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using mshop_api.Context;
using mshop_api.Models;
using mshop_api.Models.DTO;
using mshop_api.Services.Interfaces;

namespace mshop_api.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                IEnumerable<User> users = await _context.users.ToListAsync();
                if (users == null) throw new Exception("Error finding users.");

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                User user = await _context.users.SingleOrDefaultAsync(x => x.Id == id);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                User user = await _context.users.SingleOrDefaultAsync(x => x.Email == email);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> CreateUser([FromBody] User user)
        {
            try
            {
                User userExist = await GetUserByEmail(user.Email);
                if (userExist != null) throw new Exception("User already registered.");


                var newUser = await _context.users.AddAsync(user);
                if (newUser == null) throw new Exception("Error creating user.");

                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateUser([FromBody] UserDTO user)
        {
            try
            {
                User userExist = await GetUserById(user.Id);
                if (userExist == null) throw new Exception("User not registered.");

                userExist.Name = user.Name;
                userExist.Password = user.Password;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                User userExist = await GetUserById(id);
                if (userExist == null) throw new Exception("User not registered.");

                _context.users.Remove(userExist);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
