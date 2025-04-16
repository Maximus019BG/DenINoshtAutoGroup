using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CarCare
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            ApplyRoundedCorners();
            LoadTableData();
        }

        private void InitializeComponent()
        {
            panelTitleBar = new Panel();
            labelTitle = new Label();
            buttonMinimize = new Button();
            buttonClose = new Button();
            dataGridView = new DataGridView();

            // Form settings
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title bar
            panelTitleBar.BackColor = Color.FromArgb(45, 45, 45);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Height = 40;
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;

            labelTitle.Text = "Dashboard";
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            labelTitle.Location = new Point(10, 10);
            labelTitle.AutoSize = true;

            buttonMinimize.Text = "–";
            buttonMinimize.FlatStyle = FlatStyle.Flat;
            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMinimize.Font = new Font("Segoe UI", 10);
            buttonMinimize.Size = new Size(30, 30);
            buttonMinimize.Location = new Point(720, 5);
            buttonMinimize.ForeColor = Color.White;
            buttonMinimize.BackColor = Color.Transparent;
            buttonMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            buttonClose.Text = "X";
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.Font = new Font("Segoe UI", 10);
            buttonClose.Size = new Size(30, 30);
            buttonClose.Location = new Point(750, 5);
            buttonClose.ForeColor = Color.White;
            buttonClose.BackColor = Color.Transparent;
            buttonClose.Click += (s, e) => this.Close();

            // DataGridView
            dataGridView.Location = new Point(20, 60);
            dataGridView.Size = new Size(760, 400);
            dataGridView.BackgroundColor = Color.FromArgb(50, 50, 50);
            dataGridView.GridColor = Color.Gray;
            dataGridView.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;

            panelTitleBar.Controls.Add(labelTitle);
            panelTitleBar.Controls.Add(buttonMinimize);
            panelTitleBar.Controls.Add(buttonClose);

            this.Controls.Add(panelTitleBar);
            this.Controls.Add(dataGridView);
        }

        private void LoadTableData()
        {
            // Example dummy data
            DataTable table = new DataTable();
            table.Columns.Add("Service ID");
            table.Columns.Add("Customer Name");
            table.Columns.Add("Vehicle");
            table.Columns.Add("Date");
            table.Columns.Add("Status");

            table.Rows.Add("SVC001", "John Doe", "Toyota Camry", "2025-04-17", "Completed");
            table.Rows.Add("SVC002", "Jane Smith", "Honda Accord", "2025-04-16", "Pending");
            table.Rows.Add("SVC003", "Michael Johnson", "Ford Mustang", "2025-04-15", "In Progress");

            dataGridView.DataSource = table;
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
        private Button buttonMinimize;
        private Button buttonClose;
        private DataGridView dataGridView;
    }
}