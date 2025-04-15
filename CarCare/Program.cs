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
        // Show Admin Setup Form
        Application.Run(new AdminSetupForm());

        // Show Login Form
        Application.Run(new LoginForm());
    }
}