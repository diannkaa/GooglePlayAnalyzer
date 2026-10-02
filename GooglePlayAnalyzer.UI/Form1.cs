using ClosedXML.Excel;
using GooglePlayAnalyzer.Data.Logging;
using GooglePlayAnalyzer.Data.Providers.Csv;
using GooglePlayAnalyzer.Data.Providers.Json;
using GooglePlayAnalyzer.Data.Providers.Xlsx;
using GooglePlayAnalyzer.Data.Providers.Xml;
using GooglePlayAnalyzer.Data.Reports.Docx;
using GooglePlayAnalyzer.Data.Reports.Xlsx;
using GooglePlayAnalyzer.Domain.Entities;
using GooglePlayAnalyzer.Domain.Interfaces;
using GooglePlayAnalyzer.UI.Charts;
using GooglePlayAnalyzer.UI.Forms;
using GooglePlayAnalyzer.UI.ViewModels;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace GooglePlayAnalyzer.UI
{
    public partial class Form1 : Form
    {
        private List<App> apps = new List<App>();
        private List<App> _filteredApps = new List<App>();

        private string? _currentCsvFilePath;
        private string? _currentSortType = null;
        private bool _sortAscending = false;

        public Form1()
        {
            InitializeComponent();

            dataGridViewApps.AutoGenerateColumns = true;
            dataGridViewApps.ReadOnly = true;
            dataGridViewApps.AllowUserToAddRows = false;
            dataGridViewApps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            labelResultsCount.Text = "Знайдено: 0";
        }
        public void LoadData(List<App> loadedApps)
        {
            apps = loadedApps ?? new List<App>();

            _currentSortType = null;
            _sortAscending = false;

            UpdateSortButtonTexts();
            ApplySearchAndFilters();

            FileLogger.LogInfo($"Завантажено записів: {apps.Count}");
        }

        private void exportToXlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog { Filter = "Excel Files|*.xlsx" };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    XlsxDataProvider provider = new XlsxDataProvider();
                    provider.Export(sfd.FileName, _filteredApps);

                    MessageBox.Show(
                        "Експорт успішно виконано!",
                        "Успіх",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                FileLogger.LogError("Помилка при експорті в XLSX", ex);

                MessageBox.Show(
                    $"Помилка запису файлу (можливо, він відкритий в іншій програмі): {ex.Message}",
                    "Помилка I/O",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void exportToDocxReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var sfd = new SaveFileDialog { Filter = "Word Document|*.docx" };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string tempChartPath = "temp_chart.png";

                    if (formsPlot1 != null)
                        ChartService.SaveChartToImage(formsPlot1, tempChartPath);

                    DocxReportService reportService = new DocxReportService();
                    reportService.GenerateReport(sfd.FileName, _filteredApps, tempChartPath);

                    MessageBox.Show(
                        "Аналітичний звіт Word створено!",
                        "Успіх",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                FileLogger.LogError("Помилка створення Word звіту", ex);

                MessageBox.Show(
                    $"Помилка: {ex.Message}",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ApplySearchAndFilters();
        }
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            ApplySearchAndFilters();
        }
        private void ApplySearchAndFilters()
        {
            string searchText = textBoxSearch?.Text?.Trim() ?? "";
            string minRatingText = textBoxMinRating?.Text?.Trim() ?? "";
            string maxPriceText = textBoxMaxPrice?.Text?.Trim() ?? "";

            double minRating = 0;
            double maxPrice = 0;

            if (!string.IsNullOrEmpty(minRatingText))
            {
                if (!double.TryParse(minRatingText, NumberStyles.Any, CultureInfo.CurrentCulture, out minRating) &&
                    !double.TryParse(minRatingText, NumberStyles.Any, CultureInfo.InvariantCulture, out minRating))
                {
                    MessageBox.Show(
                        "Введіть коректний мінімальний рейтинг.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (minRating < 0 || minRating > 5)
                {
                    MessageBox.Show(
                        "Рейтинг має бути від 0 до 5.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            if (!string.IsNullOrEmpty(maxPriceText))
            {
                if (!double.TryParse(maxPriceText, NumberStyles.Any, CultureInfo.CurrentCulture, out maxPrice) &&
                    !double.TryParse(maxPriceText, NumberStyles.Any, CultureInfo.InvariantCulture, out maxPrice))
                {
                    MessageBox.Show(
                        "Введіть коректну максимальну ціну.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (maxPrice < 0)
                {
                    MessageBox.Show(
                        "Ціна не може бути від'ємною.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            _filteredApps = apps.Where(app =>
            {
                bool matchesName = string.IsNullOrWhiteSpace(searchText) ||
                    (app.Name ?? "").Contains(searchText, StringComparison.OrdinalIgnoreCase);

                bool matchesRating = string.IsNullOrEmpty(minRatingText) ||
                    (app.Rating.HasValue && app.Rating.Value >= minRating);

                bool matchesPrice = string.IsNullOrEmpty(maxPriceText) ||
                    (app.Price.HasValue && app.Price.Value <= maxPrice);

                return matchesName && matchesRating && matchesPrice;
            }).ToList();

            if (_currentSortType != null)
            {
                switch (_currentSortType)
                {
                    case "rating":
                        _filteredApps = _sortAscending
                            ? _filteredApps.OrderBy(app => app.Rating ?? 0).ToList()
                            : _filteredApps.OrderByDescending(app => app.Rating ?? 0).ToList();
                        break;

                    case "reviews":
                        _filteredApps = _sortAscending
                            ? _filteredApps.OrderBy(app => app.ReviewsCount ?? 0).ToList()
                            : _filteredApps.OrderByDescending(app => app.ReviewsCount ?? 0).ToList();
                        break;

                    case "price":
                        _filteredApps = _sortAscending
                            ? _filteredApps.OrderBy(app => app.Price ?? 0).ToList()
                            : _filteredApps.OrderByDescending(app => app.Price ?? 0).ToList();
                        break;
                }
            }

            dataGridViewApps.DataSource = null;
            dataGridViewApps.AutoGenerateColumns = true;

            dataGridViewApps.DataSource = _filteredApps.Select(a => new AppGridViewModel
            {
                App = a.Name,
                Category = a.Category?.Name ?? string.Empty,
                Rating = a.Rating,
                Reviews = a.ReviewsCount,
                Size = a.Size,
                Installs = a.Installs,
                Type = a.Type,
                Price = a.Price,
                ContentRating = a.ContentRating,
                Genres = a.Genres,
                LastUpdated = a.LastUpdated?.ToString("yyyy-MM-dd") ?? string.Empty,
                CurrentVer = a.CurrentVer,
                AndroidVer = a.AndroidVer
            }).ToList();

            if (labelResultsCount != null)
                labelResultsCount.Text = $"Знайдено: {_filteredApps.Count} із {apps.Count}";

            if (formsPlot1 != null)
                ChartService.RenderCategoryChart(formsPlot1, _filteredApps);

            if (formsPlot2 != null)
                ChartService.RenderRatingDistributionChart(formsPlot2, _filteredApps);

            UpdateStatistics();
        }
        private void UpdateStatistics()
        {
            if (_filteredApps == null || _filteredApps.Count == 0)
            {
                labelTotalApps.Text = "Всього застосунків: 0";
                labelAverageRating.Text = "Середній рейтинг: 0";
                labelMaxRating.Text = "Максимальний рейтинг: 0";
                labelAveragePrice.Text = "Середня ціна: $0.00";
                labelFreeApps.Text = "Безкоштовних: 0";
                labelPaidApps.Text = "Платних: 0";

                return;
            }

            int totalApps = _filteredApps.Count;

            var ratings = _filteredApps
                .Where(app => app.Rating.HasValue &&
                              !double.IsNaN(app.Rating.Value) &&
                              !double.IsInfinity(app.Rating.Value))
                .Select(app => app.Rating.Value)
                .ToList();

            double averageRating = ratings.Any() ? ratings.Average() : 0;
            double minRating = ratings.Any() ? ratings.Min() : 0;
            double maxRating = ratings.Any() ? ratings.Max() : 0;

            var prices = _filteredApps
                .Where(app => app.Price.HasValue &&
                              !double.IsNaN(app.Price.Value) &&
                              !double.IsInfinity(app.Price.Value))
                .Select(app => app.Price.Value)
                .ToList();

            double averagePrice = prices.Any() ? prices.Average() : 0;
            double totalPrice = prices.Any() ? prices.Sum() : 0;

            int freeApps = _filteredApps.Count(app => string.Equals(app.Type, "Free", StringComparison.OrdinalIgnoreCase));
            int paidApps = _filteredApps.Count(app => string.Equals(app.Type, "Paid", StringComparison.OrdinalIgnoreCase));

            labelTotalApps.Text = $"Всього застосунків: {totalApps}";
            labelAverageRating.Text = $"Рейтинг: середній {averageRating:F2}, мін. {minRating:F2}, макс. {maxRating:F2}";
            labelMaxRating.Text = $"Сума цін: ${totalPrice:F2}";
            labelAveragePrice.Text = $"Середня ціна: ${averagePrice:F2}";
            labelFreeApps.Text = $"Безкоштовних: {freeApps}";
            labelPaidApps.Text = $"Платних: {paidApps}";
        }

        private void menuItemExportXlsxReport_Click_1(object sender, EventArgs e)
        {
            if (_filteredApps == null || !_filteredApps.Any())
            {
                MessageBox.Show(
                    "Спочатку завантажте дані з CSV!",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = "GooglePlay_Report.xlsx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XlsxReportService reportService = new XlsxReportService();
                        reportService.GenerateSummaryReport(sfd.FileName, _filteredApps);

                        MessageBox.Show(
                            "XLSX-звіт успішно створено!",
                            "Успіх",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Помилка при створенні XLSX: {ex.Message}",
                            "Помилка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void menuItemExportDocxReport_Click_1(object sender, EventArgs e)
        {
            if (_filteredApps == null || !_filteredApps.Any())
            {
                MessageBox.Show(
                    "Спочатку завантажте дані з CSV!",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Word Document|*.docx",
                FileName = "GooglePlay_Report.docx"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string tempChartPath1 = Path.Combine(Path.GetTempPath(), "google_play_categories.png");
                        string tempChartPath2 = Path.Combine(Path.GetTempPath(), "google_play_ratings.png");

                        if (formsPlot1 != null)
                            ChartService.SaveChartToImage(formsPlot1, tempChartPath1);

                        if (formsPlot2 != null)
                            ChartService.SaveChartToImage(formsPlot2, tempChartPath2);
                        DocxReportService reportService = new DocxReportService();
                        reportService.GenerateReport(sfd.FileName, _filteredApps, tempChartPath1, tempChartPath2);

                        if (File.Exists(tempChartPath1))
                            File.Delete(tempChartPath1);

                        if (File.Exists(tempChartPath2))
                            File.Delete(tempChartPath2);

                        MessageBox.Show(
                            "DOCX-звіт із двома графіками успішно створено!",
                            "Успіх",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Помилка при створенні DOCX: {ex.Message}",
                            "Помилка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            textBoxMinRating.Clear();
            textBoxMaxPrice.Clear();

            ApplySearchAndFilters();
        }
        private void SortApps(string sortType)
        {
            if (_filteredApps == null || _filteredApps.Count == 0)
            {
                MessageBox.Show(
                    "Спочатку завантажте дані.",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_currentSortType == sortType)
                _sortAscending = !_sortAscending;
            else
            {
                _currentSortType = sortType;
                _sortAscending = sortType == "price";
            }

            ApplyCurrentSort();
            UpdateSortButtonTexts();
        }
        private void ApplyCurrentSort()
        {
            if (_filteredApps == null || _filteredApps.Count == 0 || _currentSortType == null)
                return;

            switch (_currentSortType)
            {
                case "rating":
                    _filteredApps = _sortAscending
                        ? _filteredApps.OrderBy(app => app.Rating.HasValue ? 0 : 1).ThenBy(app => app.Rating ?? 0).ToList()
                        : _filteredApps.OrderBy(app => app.Rating.HasValue ? 0 : 1).ThenByDescending(app => app.Rating ?? 0).ToList();
                    break;

                case "reviews":
                    _filteredApps = _sortAscending
                        ? _filteredApps.OrderBy(app => app.ReviewsCount.HasValue ? 0 : 1).ThenBy(app => app.ReviewsCount ?? 0).ToList()
                        : _filteredApps.OrderBy(app => app.ReviewsCount.HasValue ? 0 : 1).ThenByDescending(app => app.ReviewsCount ?? 0).ToList();
                    break;

                case "price":
                    _filteredApps = _sortAscending
                        ? _filteredApps.OrderBy(app => app.Price.HasValue ? 0 : 1).ThenBy(app => app.Price ?? 0).ToList()
                        : _filteredApps.OrderBy(app => app.Price.HasValue ? 0 : 1).ThenByDescending(app => app.Price ?? 0).ToList();
                    break;
            }

            dataGridViewApps.DataSource = null;
            dataGridViewApps.AutoGenerateColumns = true;
            dataGridViewApps.DataSource = _filteredApps.Select(a => new AppGridViewModel
            {
                App = a.Name,
                Category = a.Category?.Name ?? string.Empty,
                Rating = a.Rating,
                Reviews = a.ReviewsCount,
                Size = a.Size,
                Installs = a.Installs,
                Type = a.Type,
                Price = a.Price,
                ContentRating = a.ContentRating,
                Genres = a.Genres,
                LastUpdated = a.LastUpdated?.ToString("yyyy-MM-dd") ?? string.Empty,
                CurrentVer = a.CurrentVer,
                AndroidVer = a.AndroidVer
            }).ToList();

            UpdateStatistics();
        }
        private void UpdateSortButtonTexts()
        {
            buttonSortRating.Text = "Рейтинг";
            buttonSortReviews.Text = "Відгуки";
            buttonSortPrice.Text = "Ціна";

            if (_currentSortType == null)
                return;

            string arrow = _sortAscending ? " ?" : " ?";

            switch (_currentSortType)
            {
                case "rating":
                    buttonSortRating.Text = "Рейтинг" + arrow;
                    break;

                case "reviews":
                    buttonSortReviews.Text = "Відгуки" + arrow;
                    break;

                case "price":
                    buttonSortPrice.Text = "Ціна" + arrow;
                    break;
            }
        }
        private void ExportXml()
        {
            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "XML файли (*.xml)|*.xml";
            dialog.FileName = "apps.xml";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                XmlDataProvider provider = new XmlDataProvider();
                provider.Write(dialog.FileName, apps);

                MessageBox.Show(
                    "XML успішно експортовано.",
                    "Експорт",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка експорту XML:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ExportJson()
        {
            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "JSON файли (*.json)|*.json";
            dialog.FileName = "apps.json";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                JsonDataProvider provider = new JsonDataProvider();
                provider.Write(dialog.FileName, apps);

                MessageBox.Show(
                    "JSON успішно експортовано.",
                    "Експорт",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка експорту JSON:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ExportXlsx()
        {
            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Excel файли (*.xlsx)|*.xlsx";
            dialog.FileName = "apps.xlsx";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using XLWorkbook workbook = new XLWorkbook();

                var sheet = workbook.Worksheets.Add("Apps");

                sheet.Cell(1, 1).Value = "Name";
                sheet.Cell(1, 2).Value = "Category";
                sheet.Cell(1, 3).Value = "Rating";
                sheet.Cell(1, 4).Value = "Reviews";
                sheet.Cell(1, 5).Value = "Installs";
                sheet.Cell(1, 6).Value = "Type";
                sheet.Cell(1, 7).Value = "Price";

                for (int i = 0; i < apps.Count; i++)
                {
                    App app = apps[i];
                    int row = i + 2;

                    sheet.Cell(row, 1).Value = app.Name;
                    sheet.Cell(row, 2).Value = app.CategoryName;
                    sheet.Cell(row, 3).Value = app.Rating;
                    sheet.Cell(row, 4).Value = app.ReviewsCount;
                    sheet.Cell(row, 5).Value = app.Installs;
                    sheet.Cell(row, 6).Value = app.Type;
                    sheet.Cell(row, 7).Value = app.Price;
                }

                sheet.Columns().AdjustToContents();
                workbook.SaveAs(dialog.FileName);

                MessageBox.Show(
                    "XLSX успішно експортовано.",
                    "Експорт",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка експорту XLSX:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void SaveAppsToCsv()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_currentCsvFilePath))
                {
                    MessageBox.Show(
                        "Спочатку імпортуйте CSV-файл.",
                        "Помилка збереження",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!Path.GetExtension(_currentCsvFilePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Збереження змін доступне тільки для CSV-файлів.",
                        "Помилка збереження",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string filePath = _currentCsvFilePath;

                using StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);


                writer.WriteLine("App,Category,Rating,Reviews,Size,Installs,Type,Price,Content Rating,Genres,Last Updated,Current Ver,Android Ver");

                foreach (App app in apps)
                {
                    writer.WriteLine(string.Join(",",
                        CsvValue(app.Name),
                        CsvValue(app.CategoryName),
                        app.Rating?.ToString(CultureInfo.InvariantCulture) ?? "",
                        app.ReviewsCount?.ToString() ?? "",
                        CsvValue(app.Size),
                        app.Installs?.ToString() ?? "",
                        CsvValue(app.Type),
                        app.Price?.ToString(CultureInfo.InvariantCulture) ?? "",
                        CsvValue(app.ContentRating),
                        CsvValue(app.Genres),
                        app.LastUpdated?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) ?? "",
                        CsvValue(app.CurrentVer),
                        CsvValue(app.AndroidVer)));
                }

                FileLogger.LogInfo($"Зміни збережено у файл: {filePath}");
            }
            catch (Exception ex)
            {
                FileLogger.LogError("Помилка збереження змін у CSV", ex);

                MessageBox.Show(
                    $"Не вдалося зберегти зміни:\n{ex.Message}",
                    "Помилка збереження",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ExportCsv()
        {
            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "CSV файли (*.csv)|*.csv";
            dialog.FileName = "apps.csv";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8);

                writer.WriteLine("App,Category,Rating,Reviews,Size,Installs,Type,Price,Content Rating,Genres,Last Updated,Current Ver,Android Ver");

                foreach (App app in apps)
                {
                    writer.WriteLine(string.Join(",",
                        CsvValue(app.Name),
                        CsvValue(app.CategoryName),
                        app.Rating?.ToString() ?? "",
                        app.ReviewsCount?.ToString() ?? "",
                        CsvValue(app.Size),
                        app.Installs?.ToString() ?? "",
                        CsvValue(app.Type),
                        app.Price?.ToString() ?? "",
                        CsvValue(app.ContentRating),
                        CsvValue(app.Genres),
                        app.LastUpdated?.ToString("MMMM d, yyyy") ?? "",
                        CsvValue(app.CurrentVer),
                        CsvValue(app.AndroidVer)));
                }

                MessageBox.Show(
                    "CSV успішно експортовано.",
                    "Експорт",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Помилка експорту CSV:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private string CsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
        private void buttonSortRating_Click(object sender, EventArgs e)
        {
            SortApps("rating");
        }

        private void buttonSortReviews_Click(object sender, EventArgs e)
        {
            SortApps("reviews");
        }
        private void buttonSortPrice_Click(object sender, EventArgs e)
        {
            SortApps("price");
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (AppEditForm editForm = new AppEditForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    apps.Add(editForm.App);

                    SaveAppsToCsv();
                    LoadData(apps);

                    MessageBox.Show(
                        "Запис успішно додано.",
                        "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewApps.CurrentRow == null)
            {
                MessageBox.Show(
                    "Спочатку виберіть запис для редагування.",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string appName = dataGridViewApps.CurrentRow.Cells["App"].Value?.ToString() ?? "";

            App? selectedApp = apps.FirstOrDefault(app => app.Name == appName);

            if (selectedApp == null)
            {
                MessageBox.Show(
                    "Не вдалося знайти вибраний запис.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            using (AppEditForm editForm = new AppEditForm(selectedApp))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    SaveAppsToCsv();
                    LoadData(apps);

                    MessageBox.Show(
                        "Запис успішно відредаговано.",
                        "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewApps.CurrentRow == null)
            {
                MessageBox.Show(
                    "Спочатку виберіть запис для видалення.",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string appName = dataGridViewApps.CurrentRow.Cells["App"].Value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(appName))
            {
                MessageBox.Show(
                    "Не вдалося визначити вибраний запис.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            App? selectedApp = apps.FirstOrDefault(app => app.Name == appName);

            if (selectedApp == null)
            {
                MessageBox.Show(
                    "Не вдалося знайти вибраний запис.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Ви дійсно хочете видалити застосунок:\n\n{selectedApp.Name}?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            apps.Remove(selectedApp);

            SaveAppsToCsv();
            LoadData(apps);

            MessageBox.Show(
                "Запис успішно видалено.",
                "Готово",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ExportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportXml();
        }

        private void ExportJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportJson();
        }

        private void ExportXLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportXlsx();
        }

        private void ExportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportCsv();
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImportForm importForm = new ImportForm())
            {
                if (importForm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(importForm.SelectedFilePath) &&
                        Path.GetExtension(importForm.SelectedFilePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                        _currentCsvFilePath = importForm.SelectedFilePath;
                    else
                        _currentCsvFilePath = null;

                    LoadData(importForm.ImportedApps);

                    textBoxSearch?.Clear();
                    textBoxMinRating?.Clear();
                    textBoxMaxPrice?.Clear();

                    MessageBox.Show(
                        $"Успішно завантажено записів: {importForm.ImportedApps.Count}",
                        "Імпорт завершено",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        }
    }
}

