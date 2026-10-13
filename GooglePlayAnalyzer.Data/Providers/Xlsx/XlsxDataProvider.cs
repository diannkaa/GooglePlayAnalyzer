using GooglePlayAnalyzer.Domain.Entities;
using GooglePlayAnalyzer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace GooglePlayAnalyzer.Data.Providers.Xlsx
{
    public class XlsxDataProvider : IDataProvider<App>
    {
        public List<App> Load(string path)
        {
            List<App> apps = new List<App>();

            if (!ValidateFile(path))
                return apps;

            using (XLWorkbook workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheet(1);

                foreach (var row in worksheet.RangeUsed().RowsUsed().Skip(1))
                {
                    App app = new App
                    {
                        Name = row.Cell(1).GetValue<string>(),
                        Category = new Category
                        {
                            Name = row.Cell(2).GetValue<string>()
                        },
                        Rating = row.Cell(3).IsEmpty() ? null : row.Cell(3).GetValue<double?>(),
                        ReviewsCount = row.Cell(4).IsEmpty() ? null : row.Cell(4).GetValue<int?>(),
                        Size = row.Cell(5).GetValue<string>(),
                        Installs = row.Cell(6).IsEmpty() ? null : row.Cell(6).GetValue<long?>(),
                        Type = row.Cell(7).GetValue<string>(),
                        Price = row.Cell(8).IsEmpty() ? null : row.Cell(8).GetValue<double?>(),
                        ContentRating = row.Cell(9).GetValue<string>(),
                        Genres = row.Cell(10).GetValue<string>(),
                        CurrentVer = row.Cell(12).GetValue<string>(),
                        AndroidVer = row.Cell(13).GetValue<string>()
                    };

                    if (DateTime.TryParse(row.Cell(11).GetValue<string>(), out DateTime lastUpdated))
                        app.LastUpdated = lastUpdated;

                    apps.Add(app);
                }
            }

            return apps;
        }
        public bool ValidateFile(string path)
        {
            return File.Exists(path) && Path.GetExtension(path).Equals(".xlsx", StringComparison.OrdinalIgnoreCase);
        }
        public string GetFileInfo(string path)
        {
            if (!File.Exists(path))
                return "Файл не знайдено";

            FileInfo file = new FileInfo(path);

            return $"Назва: {file.Name}, Розмір: {file.Length / 1024} KB";
        }
        public void Export(string path, List<App> apps)
        {
            Write(path, apps);
        }

        public void Write(string path, List<App> apps)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Apps");

                string[] headers =
                {
                    "App",
                    "Category",
                    "Rating",
                    "Reviews",
                    "Size",
                    "Installs",
                    "Type",
                    "Price",
                    "Content Rating",
                    "Genres",
                    "Last Updated",
                    "Current Ver",
                    "Android Ver"
                };

                for (int i = 0; i < headers.Length; i++)
                    worksheet.Cell(1, i + 1).Value = headers[i];

                for (int i = 0; i < apps.Count; i++)
                {
                    App app = apps[i];
                    int row = i + 2;

                    if (app.Rating.HasValue)
                        worksheet.Cell(row, 3).Value = app.Rating.Value;
                    else
                        worksheet.Cell(row, 3).Value = Blank.Value;

                    if (app.ReviewsCount.HasValue)
                        worksheet.Cell(row, 4).Value = app.ReviewsCount.Value;
                    else
                        worksheet.Cell(row, 4).Value = Blank.Value;

                    if (app.Installs.HasValue)
                        worksheet.Cell(row, 6).Value = app.Installs.Value;
                    else
                        worksheet.Cell(row, 6).Value = Blank.Value;

                    if (app.Price.HasValue)
                        worksheet.Cell(row, 8).Value = app.Price.Value;
                    else
                        worksheet.Cell(row, 8).Value = Blank.Value;
                }

                workbook.SaveAs(path);
            }
        }
    }
}
