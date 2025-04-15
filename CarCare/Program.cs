namespace CarCare;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetCompatibleTextRenderingDefault(false);
        if (!Auth.IsAdminSetUp())
        {
            Application.Run(new AdminSetupForm());
        }

        Application.Run(new LoginForm());
    }
}