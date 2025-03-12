using System.Net.Http.Json;
using Test.Models;

namespace Test.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                _ = new User();
                var client = new HttpClient();
                string url = "https://localhost:7264/api/User/" + email + "/" + password;
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadFromJsonAsync<User>();
                    return await Task.FromResult(user!);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
                return null!;
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
