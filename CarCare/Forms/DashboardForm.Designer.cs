namespace CarCare
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTitleBar;
        private Label labelTitle;
        private Button buttonMinimize;
        private Button buttonClose;
        private DataGridView dataGridView;
        private Button btnAddCar;
        private Button btnFinishRepair;
        private Button btnViewHistory;
        private Button btnViewQueue;
        private Button btnViewCurrent;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label labelResults;
        private ComboBox comboSortType;
        private Button btnSort;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTitleBar = new Panel();
            this.labelTitle = new Label();
            this.buttonMinimize = new Button();
            this.buttonClose = new Button();
            this.dataGridView = new DataGridView();
            this.btnAddCar = new Button();
            this.btnFinishRepair = new Button();
            this.btnViewHistory = new Button();
            this.btnViewQueue = new Button();
            this.btnViewCurrent = new Button();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.labelResults = new Label();

            // Panel Title Bar
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

            // DataGridView
        dataGridView.Location = new Point(20, 60);
            dataGridView.Size = new Size(760, 400);
            dataGridView.BackgroundColor = Color.FromArgb(30, 30, 30); // Dark background
            dataGridView.GridColor = Color.FromArgb(50, 50, 50); // Darker grid lines
            dataGridView.ForeColor = Color.White; // White text
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45); // Dark header background
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // White header text
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70); // Header selection background
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White; // Header selection text
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40); // Dark cell background
            dataGridView.DefaultCellStyle.ForeColor = Color.White; // White cell text
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70); // Cell selection background
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White; // Cell selection text
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;

             // Buttons
            btnAddCar.Text = "Add Car";
            btnAddCar.Location = new Point(20, 470);
            btnAddCar.Size = new Size(100, 30);
            btnAddCar.BackColor = Color.FromArgb(45, 45, 45);
            btnAddCar.ForeColor = Color.White;
            btnAddCar.FlatStyle = FlatStyle.Flat;
            btnAddCar.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnAddCar.Click += BtnAddCar_Click;
            
            btnFinishRepair.Text = "Finish Repair";
            btnFinishRepair.Location = new Point(125, 470);
            btnFinishRepair.Size = new Size(110, 30);
            btnFinishRepair.BackColor = Color.FromArgb(45, 45, 45);
            btnFinishRepair.ForeColor = Color.White;
            btnFinishRepair.FlatStyle = FlatStyle.Flat;
            btnFinishRepair.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnFinishRepair.Click += BtnFinishRepair_Click;
            
            btnViewHistory.Text = "History";
            btnViewHistory.Location = new Point(240, 470);
            btnViewHistory.Size = new Size(90, 30);
            btnViewHistory.BackColor = Color.FromArgb(45, 45, 45);
            btnViewHistory.ForeColor = Color.White;
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnViewHistory.Click += BtnViewHistory_Click;
            
            btnViewQueue.Text = "Waiting Queue";
            btnViewQueue.Location = new Point(335, 470);
            btnViewQueue.Size = new Size(110, 30);
            btnViewQueue.BackColor = Color.FromArgb(45, 45, 45);
            btnViewQueue.ForeColor = Color.White;
            btnViewQueue.FlatStyle = FlatStyle.Flat;
            btnViewQueue.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnViewQueue.Click += BtnViewQueue_Click;
            
            btnViewCurrent.Text = "Current Repairs";
            btnViewCurrent.Location = new Point(450, 470);
            btnViewCurrent.Size = new Size(120, 30);
            btnViewCurrent.BackColor = Color.FromArgb(45, 45, 45);
            btnViewCurrent.ForeColor = Color.White;
            btnViewCurrent.FlatStyle = FlatStyle.Flat;
            btnViewCurrent.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnViewCurrent.Click += BtnViewCurrent_Click;
            
            txtSearch.Location = new Point(580, 470);
            txtSearch.Size = new Size(120, 30);
            txtSearch.BackColor = Color.FromArgb(45, 45, 45);
            txtSearch.ForeColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            
            btnSearch.Text = "Search";
            btnSearch.Location = new Point(705, 470);
            btnSearch.Size = new Size(75, 30);
            btnSearch.BackColor = Color.FromArgb(45, 45, 45);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnSearch.Click += BtnSearch_Click;
            
            labelResults.Text = "Results: 0";
            labelResults.ForeColor = Color.White;
            labelResults.BackColor = Color.FromArgb(45, 45, 45);
            labelResults.Location = new Point(20, 505);
            labelResults.Size = new Size(200, 15);
    
            comboSortType = new ComboBox();
            comboSortType.Location = new Point(580, 505);
            comboSortType.Size = new Size(120, 25);
            comboSortType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSortType.BackColor = Color.FromArgb(45, 45, 45);
            comboSortType.ForeColor = Color.White;
            comboSortType.FlatStyle = FlatStyle.Flat;
            comboSortType.Items.AddRange(Enum.GetNames(typeof(SortType)));
            comboSortType.SelectedIndex = 0;

            // Sort Button
            btnSort = new Button();
            btnSort.Text = "Sort A-Z";
            btnSort.Location = new Point(705, 505);
            btnSort.Size = new Size(75, 25);
            btnSort.BackColor = Color.FromArgb(45, 45, 45);
            btnSort.ForeColor = Color.White;
            btnSort.FlatStyle = FlatStyle.Flat;
            btnSort.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            btnSort.Click += BtnSort_Click;

            // Add to Controls
            this.Controls.Add(comboSortType);
            this.Controls.Add(btnSort);



            // Form
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(800, 530);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(panelTitleBar);
            this.Controls.Add(dataGridView);
            this.Controls.Add(btnAddCar);
            this.Controls.Add(btnFinishRepair);
            this.Controls.Add(btnViewHistory);
            this.Controls.Add(btnViewQueue);
            this.Controls.Add(btnViewCurrent);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(labelResults);
        }
    }
}
