using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace CarCare
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
            this.labelUsername = new Label();
            this.labelPassword = new Label();
            this.textBoxUsername = new TextBox();
            this.textBoxPassword = new TextBox();
            this.buttonSave = new Button();
            this.SuspendLayout();
            // 
            // AdminSetupForm
            // 
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(300, 500);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonSave);
            this.Text = "Admin Setup";
            this.FormBorderStyle = FormBorderStyle.None;
            this.ResumeLayout(false);
            // 
            // labelUsername
            // 
            this.labelUsername.Text = "Username:";
            this.labelUsername.ForeColor = Color.White;
            this.labelUsername.Location = new Point(20, 30);
            this.labelUsername.AutoSize = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new Point(20, 60);
            this.textBoxUsername.Width = 260;
            this.textBoxUsername.BackColor = Color.FromArgb(50, 50, 50);
            this.textBoxUsername.ForeColor = Color.White;
            // 
            // labelPassword
            // 
            this.labelPassword.Text = "Password:";
            this.labelPassword.ForeColor = Color.White;
            this.labelPassword.Location = new Point(20, 120);
            this.labelPassword.AutoSize = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new Point(20, 150);
            this.textBoxPassword.Width = 260;
            this.textBoxPassword.BackColor = Color.FromArgb(50, 50, 50);
            this.textBoxPassword.ForeColor = Color.White;
            this.textBoxPassword.PasswordChar = '*';
            // 
            // buttonSave
            // 
            this.buttonSave.Text = "Save";
            this.buttonSave.Location = new Point(20, 220);
            this.buttonSave.Width = 260;
            this.buttonSave.BackColor = Color.FromArgb(70, 70, 70);
            this.buttonSave.ForeColor = Color.White;
            this.buttonSave.FlatStyle = FlatStyle.Flat;
            this.buttonSave.Click += ButtonSave_Click;
        }

        private void ApplyRoundedCorners()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
            path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
            path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
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

            File.WriteAllText("admin.txt", $"{username}:{password}");
            MessageBox.Show("Admin account saved successfully.");
            this.Close();
        }

        private Label labelUsername;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonSave;
    }
}