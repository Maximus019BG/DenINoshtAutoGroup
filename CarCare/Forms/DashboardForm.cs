using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CarCare
{
  public partial class DashboardForm : Form
    {
        private List<Car> currentRepairs = new List<Car>();
        private Stack<Car> completedRepairs = new Stack<Car>();
        private Queue<Client> waitingClients = new Queue<Client>();

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

            panelTitleBar.BackColor = Color.FromArgb(45, 45, 45);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Height = 40;
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;

            labelTitle.Text = "Car Service Manager";
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

            panelTitleBar.Controls.Add(labelTitle);
            panelTitleBar.Controls.Add(buttonMinimize);
            panelTitleBar.Controls.Add(buttonClose);

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

            Button btnAddCar = new Button
            {
                Text = "Add Car",
                Location = new Point(20, 470),
                Size = new Size(120, 30)
            };
            btnAddCar.Click += BtnAddCar_Click;

            Button btnFinishRepair = new Button
            {
                Text = "Finish Repair",
                Location = new Point(150, 470),
                Size = new Size(130, 30)
            };
            btnFinishRepair.Click += BtnFinishRepair_Click;

            Button btnViewHistory = new Button
            {
                Text = "History",
                Location = new Point(290, 470),
                Size = new Size(100, 30)
            };
            btnViewHistory.Click += BtnViewHistory_Click;

            Button btnViewQueue = new Button
            {
                Text = "Waiting Queue",
                Location = new Point(400, 470),
                Size = new Size(100, 30)
            };
            btnViewQueue.Click += BtnViewQueue_Click;

            Button btnViewCurrent = new Button
            {
                Text = "Current Repairs",
                Location = new Point(510, 470),
                Size = new Size(130, 30)
            };
            btnViewCurrent.Click += (s, e) => LoadTableData();

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(800, 520);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(panelTitleBar);
            this.Controls.Add(dataGridView);
            this.Controls.Add(btnAddCar);
            this.Controls.Add(btnFinishRepair);
            this.Controls.Add(btnViewHistory);
            this.Controls.Add(btnViewQueue);
            this.Controls.Add(btnViewCurrent);
        }

        private void BtnAddCar_Click(object sender, EventArgs e)
        {
            using (var form = new AddCarForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var car = form.Car;
                    var client = form.Client;

                    currentRepairs.Add(car);
                    waitingClients.Enqueue(client);
                    LoadTableData();
                }
            }
        }

        private void BtnFinishRepair_Click(object sender, EventArgs e)
        {
            if (currentRepairs.Count > 0)
            {
                Car car = currentRepairs[0];
                currentRepairs.RemoveAt(0);
                completedRepairs.Push(car);
                LoadTableData();
            }
        }

        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Reg. Number");
            table.Columns.Add("Brand");
            table.Columns.Add("Model");
            table.Columns.Add("Problem");
            table.Columns.Add("Date");

            foreach (var car in completedRepairs)
            {
                table.Rows.Add(car.RegistrationNumber, car.Brand, car.Model, car.Problem, car.EntryDate.ToShortDateString());
            }

            dataGridView.DataSource = table;
        }

        private void BtnViewQueue_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Phone");
            table.Columns.Add("Reg. Number");

            foreach (var client in waitingClients)
            {
                table.Rows.Add(client.Name, client.Phone, client.CarRegistrationNumber);
            }

            dataGridView.DataSource = table;
        }

        private void LoadTableData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Reg. Number");
            table.Columns.Add("Brand");
            table.Columns.Add("Model");
            table.Columns.Add("Problem");
            table.Columns.Add("Date");

            foreach (var car in currentRepairs)
            {
                table.Rows.Add(car.RegistrationNumber, car.Brand, car.Model, car.Problem, car.EntryDate.ToShortDateString());
            }

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

    public class AddCarForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Car Car { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Client Client { get; private set; }

        private TextBox txtReg, txtBrand, txtModel, txtProblem, txtName, txtPhone;
        private Button btnOK;

        public AddCarForm()
        {
            this.Text = "Add Car";
            this.Size = new Size(300, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            var lblReg = new Label { Text = "Reg. Number", Top = 20, Left = 10 };
            txtReg = new TextBox { Top = 40, Left = 10, Width = 260 };
            var lblBrand = new Label { Text = "Brand", Top = 70, Left = 10 };
            txtBrand = new TextBox { Top = 90, Left = 10, Width = 260 };
            var lblModel = new Label { Text = "Model", Top = 120, Left = 10 };
            txtModel = new TextBox { Top = 140, Left = 10, Width = 260 };
            var lblProblem = new Label { Text = "Problem", Top = 170, Left = 10 };
            txtProblem = new TextBox { Top = 190, Left = 10, Width = 260 };
            var lblName = new Label { Text = "Client Name", Top = 220, Left = 10 };
            txtName = new TextBox { Top = 240, Left = 10, Width = 260 };
            var lblPhone = new Label { Text = "Phone", Top = 270, Left = 10 };
            txtPhone = new TextBox { Top = 290, Left = 10, Width = 260 };

            btnOK = new Button { Text = "OK", Top = 320, Left = 100, Width = 80 };
            btnOK.Click += BtnOK_Click;

            this.Controls.AddRange(new Control[]
            {
                lblReg, txtReg, lblBrand, txtBrand, lblModel, txtModel,
                lblProblem, txtProblem, lblName, txtName, lblPhone, txtPhone, btnOK
            });
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Car = new Car
            {
                RegistrationNumber = txtReg.Text,
                Brand = txtBrand.Text,
                Model = txtModel.Text,
                Problem = txtProblem.Text,
                EntryDate = DateTime.Now
            };

            Client = new Client
            {
                Name = txtName.Text,
                Phone = txtPhone.Text,
                CarRegistrationNumber = txtReg.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}