namespace CarCare
{
    public class Car
    {
        private string registrationNumber;
        private string brand;
        private string model;
        private string problem;
        private DateTime entryDate;

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Z0-9-]{1,10}$"))
                {
                    MessageBox.Show("Invalid registration number. It must be alphanumeric and up to 10 characters long.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                registrationNumber = value;
            }
        }

        public string Brand
        {
            get { return brand; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                {
                    MessageBox.Show("Brand must not be empty and should be less than or equal to 50 characters.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                brand = value;
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                {
                    MessageBox.Show("Model must not be empty and should be less than or equal to 50 characters.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                model = value;
            }
        }

        public string Problem
        {
            get { return problem; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 200)
                {
                    MessageBox.Show("Problem description must not be empty and should be less than or equal to 200 characters.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                problem = value;
            }
        }

        public DateTime EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }

        public override string ToString()
        {
            return $"{Brand} {Model} ({RegistrationNumber})";
        }
    }
}