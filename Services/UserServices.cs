using Microsoft.EntityFrameworkCore;
using mshop_api.Context;
using mshop_api.Models;
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
                return await _context.users.ToListAsync();
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
                return  await _context.users.SingleOrDefaultAsync(x => x.Id == id);
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
                return await _context.users.SingleOrDefaultAsync(x => x.Email == email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                User userExist = await GetUserByEmail(user.Email);
                if (userExist != null) throw new Exception("User already registered.");

                _context.users.Add(user);

                _context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                User userExist = await GetUserById(user.Id);
                if (userExist == null) throw new Exception("User not registered.");

                userExist.Name = user.Name;
                userExist.Password = user.Password;

                _context.SaveChanges();

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

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
