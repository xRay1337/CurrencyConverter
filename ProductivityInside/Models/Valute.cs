namespace ProductivityInside.Models
{
    public class Valute
    {
        public string CharCode { get; }

        public string Name { get; }

        public int Nominal { get; }

        public double Value { get; }

        public char IsSelected { get; set; } = ' ';


        public Valute(string charCode, string name, int nominal, double value)
        {
            CharCode = charCode;
            Name = name;
            Nominal = nominal;
            Value = value;
        }

        public double GetCost() => Value / Nominal;

        public override string ToString() => CharCode;
    }
}