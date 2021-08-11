using System;
using System.Collections.Generic;

namespace ProductivityInside.Models
{
    public class CbrResponse
    {
        public DateTime Date { get; set; }

        public DateTime PreviousDate { get; set; }

        public Uri PreviousURL { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public Dictionary<string, Valute> Valute { get; set; }
    }
}