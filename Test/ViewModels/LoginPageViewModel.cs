using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Test.Models;
using Test.Services;

namespace Test.ViewModels
{

    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

        readonly ILoginRepository loginService = new LoginService();

        [RelayCommand]
        public async void SignIn()
        {
            //if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)

            try
            {
                if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {
                    User user = await loginService.Login(Email, Password);
                    if (user != null)
                    {
                        if (Preferences.ContainsKey(nameof(App.user)))
                        {
                            Preferences.Remove(nameof(App.user));
                        }
                        string userDetails = JsonConvert.SerializeObject(user);
                        Preferences.Set(nameof(App.user), userDetails);
                        App.user = user;
                        // Go To Website Page
                        //await Shell.Current.GoToAsync(nameof())
                    }

                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}
