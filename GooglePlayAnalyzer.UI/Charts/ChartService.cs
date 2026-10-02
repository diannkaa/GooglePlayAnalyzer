using GooglePlayAnalyzer.Domain.Entities;
using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.UI.Charts
{
    public class ChartService
    {
        public static void RenderCategoryChart(FormsPlot formsPlot, IEnumerable<App> apps)
        {
            if (formsPlot == null || apps == null) 
                return;

            var categoryCounts = apps
                .Where(a => a.Category != null && !string.IsNullOrEmpty(a.Category.Name))
                .GroupBy(a => a.Category.Name)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(7)
                .ToList();

            formsPlot.Plot.Clear();

            if (!categoryCounts.Any())
            {
                formsPlot.Refresh();
                return;
            }

            List<Bar> bars = new List<Bar>();

            for (int i = 0; i < categoryCounts.Count; i++)
                bars.Add(new Bar { Position = i, Value = categoryCounts[i].Count });

            formsPlot.Plot.Add.Bars(bars);

            Tick[] ticks = categoryCounts
                .Select((c, i) => new Tick(i, c.Category))
                .ToArray();

            formsPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            formsPlot.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
            formsPlot.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
            formsPlot.Plot.Axes.Margins(bottom: 0.35);

            formsPlot.Plot.Title("Топ-7 категорій за кількістю");
            formsPlot.Plot.YLabel("Кількість");

            formsPlot.Refresh();
        }

        public static void RenderRatingDistributionChart(FormsPlot formsPlot, IEnumerable<App> apps)
        {
            if (formsPlot == null || apps == null)
                return;

            var ratedApps = apps
                .Where(a => a.Rating.HasValue &&
                            !double.IsNaN(a.Rating.Value) &&
                            !double.IsInfinity(a.Rating.Value))
                .ToList();

            var groups = new Dictionary<string, int>
            {
                { "1.0 - 2.9", ratedApps.Count(a => a.Rating >= 1.0 && a.Rating < 3.0) },
                { "3.0 - 3.9", ratedApps.Count(a => a.Rating >= 3.0 && a.Rating < 4.0) },
                { "4.0 - 4.4", ratedApps.Count(a => a.Rating >= 4.0 && a.Rating < 4.5) },
                { "4.5 - 5.0", ratedApps.Count(a => a.Rating >= 4.5 && a.Rating <= 5.0) }
            };

            formsPlot.Plot.Clear();

            List<Bar> bars = new List<Bar>();

            for (int i = 0; i < groups.Count; i++)
            {
                bars.Add(new Bar
                {
                    Position = i,
                    Value = groups.ElementAt(i).Value
                });
            }

            formsPlot.Plot.Add.Bars(bars);
            formsPlot.Plot.Axes.AutoScale();

            Tick[] ticks = groups
                .Select((g, i) => new Tick(i, g.Key))
                .ToArray();

            formsPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            formsPlot.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
            formsPlot.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;

            formsPlot.Plot.Axes.Margins(bottom: 0.2);

            formsPlot.Plot.Title("Розподіл додатків за рейтингом");
            formsPlot.Plot.YLabel("Кількість");

            formsPlot.Refresh();
        }

        public static string SaveChartToImage(FormsPlot formsPlot, string filePath)
        {
            formsPlot.Plot.SavePng(filePath, 800, 500);
            return filePath;
        }
    }
}


