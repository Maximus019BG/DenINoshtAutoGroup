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
            set { registrationNumber = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Problem
        {
            get { return problem; }
            set { problem = value; }
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