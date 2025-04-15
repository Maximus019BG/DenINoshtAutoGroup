using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace CarCare.Forms
{
    public partial class AdminSetupForm : Form
    {
        public AdminSetupForm()
        {
            InitializeComponent();
            ApplyRoundedCorners();
        }

        private void InitializeComponent()
        {
            panelTitleBar = new Panel();
            labelTitle = new Label();
            buttonClose = new Button();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonSave = new Button();

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(300, 400);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            panelTitleBar.BackColor = Color.FromArgb(45, 45, 45);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Height = 40;
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;

            labelTitle.Text = "Admin Setup";
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            labelTitle.Location = new Point(10, 10);
            labelTitle.AutoSize = true;

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

            buttonSave.Text = "Save";
            buttonSave.Location = new Point(20, 230);
            buttonSave.Width = 260;
            buttonSave.Height = 40;
            buttonSave.BackColor = Color.FromArgb(70, 130, 180);
            buttonSave.ForeColor = Color.White;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            buttonSave.Click += ButtonSave_Click;

            buttonSave.MouseEnter += (s, e) => buttonSave.BackColor = Color.FromArgb(100, 149, 237);
            buttonSave.MouseLeave += (s, e) => buttonSave.BackColor = Color.FromArgb(70, 130, 180);

            panelTitleBar.Controls.Add(labelTitle);
            panelTitleBar.Controls.Add(buttonClose);

            Controls.Add(panelTitleBar);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonSave);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }

            Auth.SaveAdmin(username, password);
            
            MessageBox.Show("Admin account set up successfully.");
            this.Close();
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
        private Button buttonClose;
        private Label labelUsername;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonSave;
    }
}