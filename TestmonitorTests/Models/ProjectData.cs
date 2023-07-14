using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestmonitorTests.Models
{
    public class ProjectData
    {
        public int Id { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("description")] 
        public string Description { get; set; }

        [JsonPropertyName("symbol_id")] 
        public int SymbolId { get; set; }
    }
}
