using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Forms;

namespace CarCare
{
    public partial class DashboardForm : Form
    {
        private List<Car> currentRepairs = new List<Car>();
        private Stack<Car> completedRepairs = new Stack<Car>();
        private Queue<Client> waitingClients = new Queue<Client>();
        private readonly string ordersFile = "orders.json";
        private readonly string clientsFile = "clients.json";
        private readonly string historyFile = "history.json";

        public DashboardForm()
        {
            InitializeComponent();
            ApplyRoundedCorners();
            LoadAllData();
            LoadTableData();
        }
        
        private void SaveAllData()
        {
            SaveOrdersToFile();
            SaveClientsToFile();
            SaveHistoryToFile();
        }

        private void SaveOrdersToFile()
        {
            File.WriteAllText(ordersFile, JsonSerializer.Serialize(currentRepairs, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void SaveClientsToFile()
        {
            File.WriteAllText(clientsFile, JsonSerializer.Serialize(waitingClients.ToList(), new JsonSerializerOptions { WriteIndented = true }));
        }

        private void SaveHistoryToFile()
        {
            File.WriteAllText(historyFile, JsonSerializer.Serialize(completedRepairs.ToList(), new JsonSerializerOptions { WriteIndented = true }));
        }

        private void LoadAllData()
        {
            LoadOrdersFromFile();
            LoadClientsFromFile();
            LoadHistoryFromFile();
        }

        private void LoadOrdersFromFile()
        {
            if (File.Exists(ordersFile))
                currentRepairs = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(ordersFile)) ?? new List<Car>();
        }
        private void LoadClientsFromFile()
        {
            if (File.Exists(clientsFile))
                waitingClients = new Queue<Client>(JsonSerializer.Deserialize<List<Client>>(File.ReadAllText(clientsFile)) ?? new List<Client>());
        }

        private void LoadHistoryFromFile()
        {
            if (File.Exists(historyFile))
                completedRepairs = new Stack<Car>(JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(historyFile)) ?? new List<Car>());
        }



        private void QuickSort(List<Car> list, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);
                QuickSort(list, left, pivot - 1);
                QuickSort(list, pivot + 1, right);
            }
        }

        private int Partition(List<Car> list, int left, int right)
        {
            Car pivot = list[right];
            int low = left - 1;
            for (int i = left; i < right; i++)
            {
                if (string.Compare(list[i].RegistrationNumber, pivot.RegistrationNumber) < 0)
                {
                    low++;
                    (list[low], list[i]) = (list[i], list[low]);
                }
            }
            (list[low + 1], list[right]) = (list[right], list[low + 1]);
            return low + 1;
        }

        private void LoadTableData()
        {
            LoadOrdersFromFile(); // load original data
            DisplayTableData();   // populate UI
        }
        
        private void DisplayTableData()
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

            if (dataGridView.Columns["Problem"] != null)
                dataGridView.Columns["Problem"].Width = 200;

            labelResults.Text = $"Results: {table.Rows.Count}";
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

                    txtSearch.Clear();
                    SaveAllData();
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

                if (waitingClients.Count > 0)
                    waitingClients.Dequeue();

                txtSearch.Clear();
                SaveAllData();
                LoadTableData();
            }
        }


        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
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
            labelResults.Text = $"Results: {table.Rows.Count}";
        }

        private void BtnViewQueue_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Phone");
            table.Columns.Add("Reg. Number");

            foreach (var client in waitingClients)
            {
                table.Rows.Add(client.Name, client.Phone, client.CarRegistrationNumber);
            }

            dataGridView.DataSource = table;
            labelResults.Text = $"Results: {table.Rows.Count}";
        }

        private void BtnViewCurrent_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadTableData();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            var dt = dataGridView.DataSource as DataTable;
            if (dt == null) return;

            if (string.IsNullOrEmpty(query))
            {
                // Sort currentRepairs using QuickSort
                QuickSort(currentRepairs, 0, currentRepairs.Count - 1);
                LoadTableData();
                return;
            }

            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item.ToString().ToLower().Contains(query))
                    {
                        filtered.Rows.Add(row.ItemArray);
                        break;
                    }
                }
            }

            dataGridView.DataSource = filtered;
            labelResults.Text = $"Results: {filtered.Rows.Count}";
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

        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void BtnSort_Click(object sender, EventArgs e)
        {
            if (comboSortType.SelectedItem == null) return;

            if (Enum.TryParse(comboSortType.SelectedItem.ToString(), out SortType selectedSort))
            {
                SortCurrentRepairs(selectedSort);
                DisplayTableData(); // ✅ now shows sorted list
            }
        }

        private void SortCurrentRepairs(SortType sortType)
        {
            currentRepairs = MergeSort(currentRepairs, sortType);
        }

        private List<Car> MergeSort(List<Car> list, SortType sortType)
        {
            if (list.Count <= 1) return list;

            int mid = list.Count / 2;
            var left = MergeSort(list.GetRange(0, mid), sortType);
            var right = MergeSort(list.GetRange(mid, list.Count - mid), sortType);

            return Merge(left, right, sortType);
        }

        private List<Car> Merge(List<Car> left, List<Car> right, SortType sortType)
        {
            List<Car> result = new List<Car>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                bool condition = sortType switch
                {
                    SortType.RegistrationNumber => string.Compare(left[i].RegistrationNumber, right[j].RegistrationNumber) <= 0,
                    SortType.Brand => string.Compare(left[i].Brand, right[j].Brand) <= 0,
                    SortType.Model => string.Compare(left[i].Model, right[j].Model) <= 0,
                    SortType.Problem => string.Compare(left[i].Problem, right[j].Problem) <= 0,
                    SortType.EntryDate => left[i].EntryDate <= right[j].EntryDate,
                    _ => true
                };

                result.Add(condition ? left[i++] : right[j++]);
            }

            while (i < left.Count) result.Add(left[i++]);
            while (j < right.Count) result.Add(right[j++]);

            return result;
        }
    }
}
