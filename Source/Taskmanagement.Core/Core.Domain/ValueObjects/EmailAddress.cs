using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.ValueObjects
{
    public class EmailAddress
    {
        public string Value { get; private set; }

        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email address", nameof(value));

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
