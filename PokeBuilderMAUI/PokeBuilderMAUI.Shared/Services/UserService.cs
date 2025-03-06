using PokeBuilderMAUI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly UserStorageDBContext _dbContext;
        public UserService(UserStorageDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.OrderBy(u => u.Id).ToList().AsEnumerable<User>();
        }
        public User? GetUser(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }
        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_dbContext.ChangeTracker.DebugView.LongView);

            _dbContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            var updatedUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (updatedUser != null)
            {
                updatedUser.Username = user.Username;
                updatedUser.Password = user.Password;
                _dbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_dbContext.ChangeTracker.DebugView.LongView);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
        public void DeleteUser(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.ChangeTracker.DetectChanges();
                Console.WriteLine(_dbContext.ChangeTracker.DebugView.LongView);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
