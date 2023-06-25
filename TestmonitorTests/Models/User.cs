using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestmonitorTests.Models
{
    public record User
    {
        public string? Username { get; init; } = string.Empty;
        public string? Password { get; init; } = string.Empty;
    }
}
