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
            set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string CarRegistrationNumber
        {
            get { return carRegistrationNumber; }
            set { carRegistrationNumber = value; }
        }

        public override string ToString()
        {
            return $"{Name} - {CarRegistrationNumber}";
        }
    }
}