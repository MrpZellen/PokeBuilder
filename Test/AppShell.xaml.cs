namespace Test
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(), typeof());
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
