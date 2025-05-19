namespace CarCare
{
    public class Client
    {
        private string name;
        private string phone;
        private string carRegistrationNumber;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 100)
                {
                    MessageBox.Show("Name must not be empty and should be less than or equal to 100 characters.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                name = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, @"^\+?[0-9]{10,15}$"))
                {
                    MessageBox.Show("Phone number must be valid and contain 10 to 15 digits.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                phone = value;
            }
        }

        public string CarRegistrationNumber
        {
            get { return carRegistrationNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Z0-9-]{1,10}$"))
                {
                    MessageBox.Show("Car registration number must be alphanumeric and up to 10 characters long.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                carRegistrationNumber = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {CarRegistrationNumber}";
        }
    }
}