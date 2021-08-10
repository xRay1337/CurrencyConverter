namespace ProductivityInside.Models
{
    public class Valute
    {
        //public string Id { get; set; }

        //public string NumCode { get; set; }

        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        //public double Previous { get; set; }

        public Valute(string charCode, int nominal, string name, double value)
        {
            CharCode = charCode;
            Nominal = nominal;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}