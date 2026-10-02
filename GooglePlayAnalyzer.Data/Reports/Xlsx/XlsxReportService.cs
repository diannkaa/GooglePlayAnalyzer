using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace GooglePlayAnalyzer.Data.Reports.Xlsx
{
    public class XlsxReportService
    {
        public void GenerateSummaryReport(string outputPath, IEnumerable<App> apps)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Аналітика категорій");

            ws.Cell(1, 1).Value = "Категорія";
            ws.Cell(1, 2).Value = "Кількість додатків";
            ws.Cell(1, 3).Value = "Середній рейтинг";
            ws.Cell(1, 4).Value = "Сумарні встановлення";

            var grouped = apps
                .GroupBy(a => a.Category?.Name ?? "Без категорії")
                .Select(g =>
                {
                    var ratedApps = g.Where(a => a.Rating.HasValue && !double.IsNaN(a.Rating.Value)).ToList();
                    double avgRating = ratedApps.Any() ? ratedApps.Average(a => a.Rating.Value) : 0.0;

                    return new
                    {
                        Category = g.Key,
                        Count = g.Count(),
                        AvgRating = double.IsNaN(avgRating) || double.IsInfinity(avgRating) ? 0.0 : avgRating,
                        TotalInstalls = g.Sum(a => a.Installs ?? 0)
                    };
                })
                .OrderByDescending(x => x.Count)
                .ToList();

            int row = 2;

            foreach (var item in grouped)
            {
                ws.Cell(row, 1).Value = item.Category;
                ws.Cell(row, 2).Value = item.Count;
                ws.Cell(row, 3).Value = Math.Round(item.AvgRating, 2);
                ws.Cell(row, 4).Value = item.TotalInstalls;
                row++;
            }

            ws.Columns().AdjustToContents();
            workbook.SaveAs(outputPath);
        }
    }
}

