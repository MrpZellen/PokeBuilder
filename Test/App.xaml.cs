using Test.Models;

namespace Test
{
    public partial class App : Application
    {
        // why cant I make this static or public?
        public static User user;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

    }
}
