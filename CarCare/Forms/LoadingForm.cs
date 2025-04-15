using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace CarCare
{
    public partial class LoadingForm : Form
    {
        private PictureBox pictureBoxLogo;
        private ProgressBar progressSpinner;
        private System.Windows.Forms.Timer loadingTimer;

        public LoadingForm()
        {
            InitializeComponent();
            ApplyRoundedCorners();
        }

        private void InitializeComponent()
        {
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(400, 300);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;

            pictureBoxLogo = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point((Width - 150) / 2, 40)
            };

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
            if (File.Exists(imagePath))
            {
                pictureBoxLogo.Image = Image.FromFile(imagePath);
            }

            progressSpinner = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(200, 10),
                Location = new Point((Width - 200) / 2, pictureBoxLogo.Bottom + 30),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White
            };

            loadingTimer = new System.Windows.Forms.Timer
            {
                Interval = 2000
            };
            loadingTimer.Tick += LoadingTimer_Tick;

            Controls.Add(pictureBoxLogo);
            Controls.Add(progressSpinner);

            Shown += (s, e) => loadingTimer.Start();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            loadingTimer.Stop();
            Hide();
            new LoginForm().Show();
        }

        private void ApplyRoundedCorners()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            Region = new Region(path);
        }
    }
}
