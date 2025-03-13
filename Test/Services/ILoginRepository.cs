using Test.Models;

namespace Test.Services
{
    internal interface ILoginRepository
    {
        Task<User> Login(string email, string password);
        void Register(User user);
    }
}
