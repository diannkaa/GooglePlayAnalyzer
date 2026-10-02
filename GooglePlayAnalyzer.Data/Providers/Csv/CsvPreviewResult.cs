using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Data.Providers.Csv
{
    public class CsvPreviewResult
    {
        public List<string> Headers { get; set; } = new List<string>();
        public List<string[]> Rows { get; set; } = new List<string[]>();
        public int TotalRows { get; set; }
        public int ColumnCount { get; set; }
        public int EmptyValues { get; set; }
        public List<string> FieldTypes { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
    }
}
