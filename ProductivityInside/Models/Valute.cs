namespace ProductivityInside.Models
{
    public class Valute
    {
        //public string Id { get; set; }

        //public string NumCode { get; set; }

        public string CharCode { get; }

        public int Nominal { get; }

        public string Name { get; }

        public double Value { get; }

        //public bool IsSelected { get; set; }

        //public double Previous { get; set; }

        public Valute(string charCode, int nominal, string name, double value)
        {
            CharCode = charCode;
            Nominal = nominal;
            Name = name;
            Value = value;
        }

        public double GetCost() => Value / Nominal;

        public override string ToString() => CharCode;
    }
}