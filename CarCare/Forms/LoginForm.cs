using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CarCare
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ApplyRoundedCorners();
        }

        private void InitializeComponent()
        {
            panelTitleBar = new Panel();
            labelTitle = new Label();
            buttonMinimize = new Button();
            buttonClose = new Button();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(300, 400);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            panelTitleBar.BackColor = Color.FromArgb(45, 45, 45);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Height = 40;
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;

            labelTitle.Text = "Login";
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            labelTitle.Location = new Point(10, 10);
            labelTitle.AutoSize = true;

            buttonMinimize.Text = "–";
            buttonMinimize.FlatStyle = FlatStyle.Flat;
            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMinimize.Font = new Font("Segoe UI", 10);
            buttonMinimize.Size = new Size(30, 30);
            buttonMinimize.Location = new Point(230, 5);
            buttonMinimize.ForeColor = Color.White;
            buttonMinimize.BackColor = Color.Transparent;
            buttonMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            buttonClose.Text = "X";
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.Font = new Font("Segoe UI", 10);
            buttonClose.Size = new Size(30, 30);
            buttonClose.Location = new Point(260, 5);
            buttonClose.ForeColor = Color.White;
            buttonClose.BackColor = Color.Transparent;
            buttonClose.Click += (s, e) => this.Close();

            labelUsername.Text = "Username";
            labelUsername.ForeColor = Color.White;
            labelUsername.Location = new Point(20, 60);
            labelUsername.AutoSize = true;

            textBoxUsername.Location = new Point(20, 85);
            textBoxUsername.Width = 260;
            textBoxUsername.BackColor = Color.FromArgb(50, 50, 50);
            textBoxUsername.ForeColor = Color.White;
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;

            labelPassword.Text = "Password";
            labelPassword.ForeColor = Color.White;
            labelPassword.Location = new Point(20, 135);
            labelPassword.AutoSize = true;

            textBoxPassword.Location = new Point(20, 160);
            textBoxPassword.Width = 260;
            textBoxPassword.BackColor = Color.FromArgb(50, 50, 50);
            textBoxPassword.ForeColor = Color.White;
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.PasswordChar = '●';

            buttonLogin.Text = "Login";
            buttonLogin.Location = new Point(20, 230);
            buttonLogin.Width = 260;
            buttonLogin.Height = 40;
            buttonLogin.BackColor = Color.FromArgb(180, 30, 30);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            buttonLogin.Click += ButtonLogin_Click;

            buttonLogin.MouseEnter += (s, e) => buttonLogin.BackColor = Color.FromArgb(180, 30, 10);
            buttonLogin.MouseLeave += (s, e) => buttonLogin.BackColor = Color.FromArgb(180, 30, 10);

            panelTitleBar.Controls.Add(labelTitle);
            panelTitleBar.Controls.Add(buttonMinimize);
            panelTitleBar.Controls.Add(buttonClose);

            this.Controls.Add(panelTitleBar);
            this.Controls.Add(labelUsername);
            this.Controls.Add(textBoxUsername);
            this.Controls.Add(labelPassword);
            this.Controls.Add(textBoxPassword);
            this.Controls.Add(buttonLogin);
        }

        private void ApplyRoundedCorners()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (Auth.ValidateLogin(username, password))
            {
                MessageBox.Show("Login successful.");
                //Redirect to dashboard
                this.Hide();
                new DashboardForm().Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private Panel panelTitleBar;
        private Label labelTitle;
        private Button buttonMinimize;
        private Button buttonClose;
        private Label labelUsername;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonLogin;
    }
}