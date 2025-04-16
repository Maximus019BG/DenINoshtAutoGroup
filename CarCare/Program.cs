using CarCare.Forms;

namespace CarCare
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Auth.IsAdminSetUp())
            {
                Application.Run(new AdminSetupForm());
                return;
            }

            var loadingForm = new LoadingForm();

            loadingForm.Show();
            loadingForm.Refresh();
            Thread.Sleep(2000); // Show loading form for 2 
            loadingForm.Close();


            Application.Run(new LoginForm());
        }
    }
}