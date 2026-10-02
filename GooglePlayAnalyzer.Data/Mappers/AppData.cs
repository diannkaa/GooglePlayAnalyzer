using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Data.Mappers
{
    public class AppData
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double? Rating { get; set; }
        public int? ReviewsCount { get; set; }
        public double? Price { get; set; }
        public long? Installs { get; set; }
    }
}
