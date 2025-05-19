using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarCare
{
    public partial class AddCarForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Car Car { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Client Client { get; private set; }

        public AddCarForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate Registration Number
            if (string.IsNullOrWhiteSpace(txtReg.Text) ||
                !System.Text.RegularExpressions.Regex.IsMatch(txtReg.Text.Trim(), @"^[A-Z0-9-]{1,10}$"))
            {
                MessageBox.Show("Invalid registration number. It must be alphanumeric and up to 10 characters long.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Brand
            if (string.IsNullOrWhiteSpace(txtBrand.Text) || txtBrand.Text.Trim().Length > 50)
            {
                MessageBox.Show("Brand must not be empty and should be less than or equal to 50 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Model
            if (string.IsNullOrWhiteSpace(txtModel.Text) || txtModel.Text.Trim().Length > 50)
            {
                MessageBox.Show("Model must not be empty and should be less than or equal to 50 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Problem
            if (string.IsNullOrWhiteSpace(txtProblem.Text) || txtProblem.Text.Trim().Length > 200)
            {
                MessageBox.Show("Problem description must not be empty and should be less than or equal to 200 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Client Name
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Trim().Length > 50)
            {
                MessageBox.Show("Client name must not be empty and should be less than or equal to 50 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Client Phone
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Trim().Length > 15)
            {
                MessageBox.Show("Client phone must not be empty and should be less than or equal to 15 characters.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If all validations pass, create Car and Client objects
            Car = new Car
            {
                RegistrationNumber = txtReg.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Problem = txtProblem.Text.Trim(),
                EntryDate = DateTime.Now
            };

            Client = new Client
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                CarRegistrationNumber = txtReg.Text.Trim()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}