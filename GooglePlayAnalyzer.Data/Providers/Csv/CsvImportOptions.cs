using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Data.Providers.Csv
{
    public class CsvImportOptions
    {
        public char Delimiter { get; set; } = ',';
        public bool HasHeader { get; set; } = true;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string NumberFormat { get; set; } = "1.23";
        public string DateFormat { get; set; } = "yyyy-MM-dd";
    }
}
