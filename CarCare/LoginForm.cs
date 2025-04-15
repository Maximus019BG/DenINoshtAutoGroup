using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUsername = new System.Windows.Forms.Label();
            labelPassword = new System.Windows.Forms.Label();
            textBoxUsername = new System.Windows.Forms.TextBox();
            textBoxPassword = new System.Windows.Forms.TextBox();
            buttonLogin = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.ForeColor = System.Drawing.Color.White;
            labelUsername.Location = new System.Drawing.Point(20, 30);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(63, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.ForeColor = System.Drawing.Color.White;
            labelPassword.Location = new System.Drawing.Point(20, 120);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(60, 15);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BackColor = System.Drawing.Color.FromArgb(((int)((byte)50)), ((int)((byte)50)), ((int)((byte)50)));
            textBoxUsername.ForeColor = System.Drawing.Color.White;
            textBoxUsername.Location = new System.Drawing.Point(20, 60);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new System.Drawing.Size(260, 23);
            textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)((byte)50)), ((int)((byte)50)), ((int)((byte)50)));
            textBoxPassword.ForeColor = System.Drawing.Color.White;
            textBoxPassword.Location = new System.Drawing.Point(20, 150);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new System.Drawing.Size(260, 23);
            textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)((byte)70)), ((int)((byte)70)), ((int)((byte)70)));
            buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLogin.ForeColor = System.Drawing.Color.White;
            buttonLogin.Location = new System.Drawing.Point(20, 220);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new System.Drawing.Size(260, 23);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += ButtonLogin_Click;
            // 
            // LoginForm
            // 
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)30)), ((int)((byte)30)), ((int)((byte)30)));
            ClientSize = new System.Drawing.Size(300, 500);
            Controls.Add(labelUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (!File.Exists("admin.txt"))
            {
                MessageBox.Show("Admin account not set up.");
                return;
            }

            string[] credentials = File.ReadAllText("admin.txt").Split(':');
            if (credentials.Length == 2 && credentials[0] == username && credentials[1] == password)
            {
                MessageBox.Show("Login successful.");
                // Proceed to the next page or functionality
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private Label labelUsername;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Button buttonLogin;
    }
}