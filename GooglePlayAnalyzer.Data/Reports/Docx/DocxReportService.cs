using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

    namespace GooglePlayAnalyzer.Data.Reports.Docx
    {
        public class DocxReportService
        {
            public void GenerateReport(string outputPath, IEnumerable<App> apps, string chartImagePath1 = null, string chartImagePath2 = null)
            {
                using var doc = DocX.Create(outputPath);

                doc.InsertParagraph("ЗВІТ З АНАЛІЗУ ДАНИХ GOOGLE PLAY")
                   .FontSize(18)
                   .Bold()
                   .Alignment = Alignment.center;

                doc.InsertParagraph($"Дата формування: {DateTime.Now:dd.MM.yyyy HH:mm}\n");

                doc.InsertParagraph("1. Загальні метрики датасету")
                   .FontSize(14)
                   .Bold();

                int totalApps = apps.Count();

                double avgRating = apps
                    .Where(a => a.Rating.HasValue)
                    .Select(a => a.Rating.Value)
                    .DefaultIfEmpty(0)
                    .Average();

                long totalInstalls = apps.Sum(a => a.Installs ?? 0);

                doc.InsertParagraph($"Загальна кількість додатків: {totalApps}");
                doc.InsertParagraph($"Середній рейтинг: {Math.Round(avgRating, 2)}");
                doc.InsertParagraph($"Загальна кількість встановлень: {totalInstalls}\n");

                doc.InsertParagraph("2. Топ-10 додатків за рейтингом")
                   .FontSize(14)
                   .Bold();

                var topApps = apps
                    .OrderByDescending(a => a.Rating ?? 0)
                    .Take(10)
                    .ToList();

                if (topApps.Count > 0)
                {
                    var table = doc.AddTable(topApps.Count + 1, 4);
                    table.Design = TableDesign.TableGrid;

                    table.Rows[0].Cells[0].Paragraphs[0].Append("Назва").Bold();
                    table.Rows[0].Cells[1].Paragraphs[0].Append("Рейтинг").Bold();
                    table.Rows[0].Cells[2].Paragraphs[0].Append("Відгуки").Bold();
                    table.Rows[0].Cells[3].Paragraphs[0].Append("Ціна ($)").Bold();

                    for (int i = 0; i < topApps.Count; i++)
                    {
                        var app = topApps[i];

                        table.Rows[i + 1].Cells[0].Paragraphs[0].Append(app.Name ?? "");
                        table.Rows[i + 1].Cells[1].Paragraphs[0].Append(app.Rating?.ToString("F1") ?? "0");
                        table.Rows[i + 1].Cells[2].Paragraphs[0].Append(app.ReviewsCount?.ToString() ?? "0");
                        table.Rows[i + 1].Cells[3].Paragraphs[0].Append(app.Price?.ToString("F2") ?? "0");
                    }

                    doc.InsertTable(table);
                }

                if (!string.IsNullOrEmpty(chartImagePath1) && System.IO.File.Exists(chartImagePath1))
                {
                    doc.InsertParagraph("\n3. Топ-7 категорій")
                       .FontSize(14)
                       .Bold();

                    var image1 = doc.AddImage(chartImagePath1);
                    var picture1 = image1.CreatePicture(500, 312);

                    doc.InsertParagraph()
                       .AppendPicture(picture1)
                       .Alignment = Alignment.center;
                }

                if (!string.IsNullOrEmpty(chartImagePath2) && System.IO.File.Exists(chartImagePath2))
                {
                    doc.InsertParagraph("\n4. Розподіл додатків за рейтингом")
                       .FontSize(14)
                       .Bold();

                    var image2 = doc.AddImage(chartImagePath2);
                    var picture2 = image2.CreatePicture(500, 312);

                    doc.InsertParagraph()
                       .AppendPicture(picture2)
                       .Alignment = Alignment.center;
                }

                doc.Save();
            }
        }
    }