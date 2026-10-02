using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Data.Providers.Csv
{
    public class CsvImportResult
    {
        public List<App> Apps { get; set; } = new List<App>();
        public List<string> Errors { get; set; } = new List<string>();
    }
}
