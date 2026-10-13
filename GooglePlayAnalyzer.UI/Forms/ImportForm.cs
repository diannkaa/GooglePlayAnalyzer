using GooglePlayAnalyzer.Data.Providers.Csv;
using GooglePlayAnalyzer.Data.Providers.Xml;
using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GooglePlayAnalyzer.UI.Forms
{
    public partial class ImportForm : Form
    {
        private readonly CsvDataProvider csvProvider = new CsvDataProvider();
        private readonly XmlDataProvider xmlProvider = new XmlDataProvider();
        private string selectedFilePath = string.Empty;
        public string SelectedFilePath { get; private set; } = string.Empty;
        public List<App> ImportedApps { get; private set; } = new List<App>();

        public ImportForm()
        {
            InitializeComponent();

            SetupCsvSettings();

            buttonPreview.Click += buttonPreview_Click;

            dataGridViewApps.AutoGenerateColumns = false;
            dataGridViewApps.ReadOnly = true;
            dataGridViewApps.AllowUserToAddRows = false;
            dataGridViewApps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridViewErrors.AutoGenerateColumns = true;
            dataGridViewErrors.ReadOnly = true;
            dataGridViewErrors.AllowUserToAddRows = false;
            dataGridViewErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            SetupDataGridView();

            buttonImport.Enabled = false;

            labelFile.Text = "Файл не вибрано";
            labelInfo.Text = "";
            labelResult.Text = "";
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "CSV файли (*.csv)|*.csv|" + "XML файли (*.xml)|*.xml|" + "Усі файли (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SelectedFilePath = dialog.FileName;
            selectedFilePath = SelectedFilePath;

            labelFile.Text = $"Файл: {Path.GetFileName(selectedFilePath)}";

            string extension = Path.GetExtension(selectedFilePath).ToLowerInvariant();

            if (extension == ".csv")
                labelInfo.Text = csvProvider.GetFileInfo(selectedFilePath);
            else if (extension == ".xml")
                labelInfo.Text = xmlProvider.GetFileInfo(selectedFilePath);

            buttonImport.Enabled = true;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = Path.GetExtension(selectedFilePath).ToLowerInvariant();

                if (extension == ".csv")
                    ImportCsv();
                else if (extension == ".xml")
                    ImportXml();
                else
                {
                    MessageBox.Show(
                        "Підтримуються тільки CSV та XML файли.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Не вдалося імпортувати файл.\n\n{ex.Message}",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ImportCsv()
        {
            CsvImportOptions options = GetCsvImportOptions();
            CsvImportResult result = DataParser.ParseData(selectedFilePath, options);

            ImportedApps = result.Apps;

            dataGridViewApps.DataSource = null;
            dataGridViewApps.AutoGenerateColumns = false;
            dataGridViewApps.DataSource = ImportedApps;

            ShowFileInformation(ImportedApps);
            ShowImportErrors(result.Errors);

            labelResult.Text =
                $"Завантажено: {result.Apps.Count}. " +
                $"Помилок: {result.Errors.Count}.";

            MessageBox.Show(
                $"Імпорт CSV завершено.\n\n" +
                $"Успішно завантажено: {result.Apps.Count}\n" +
                $"Помилок: {result.Errors.Count}",
                "Результат імпорту",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void ImportXml()
        {
            ImportedApps = xmlProvider.Load(selectedFilePath);

            dataGridViewApps.DataSource = null;
            dataGridViewApps.AutoGenerateColumns = false;
            dataGridViewApps.DataSource = ImportedApps;

            ShowFileInformation(ImportedApps);

            dataGridViewErrors.DataSource = null;

            labelResult.Text =
                $"Завантажено: {ImportedApps.Count}. " +
                "Помилок: 0.";

            MessageBox.Show(
                $"Імпорт XML завершено.\n\n" +
                $"Успішно завантажено: {ImportedApps.Count}",
                "Результат імпорту",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void ShowImportErrors(List<string> errors)
        {
            dataGridViewErrors.DataSource = null;

            if (errors.Count == 0)
                return;

            dataGridViewErrors.DataSource = errors
                .Select(error => new
                {
                    Помилка = error
                })
                .ToList();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (ImportedApps.Count > 0)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;

            Close();
        }

        private void ShowFileInformation(List<App> apps)
        {
            if (apps == null || apps.Count == 0)
            {
                labelRowCount.Text = "Рядків: 0";
                labelColumnCount.Text = "Колонок: 0";
                labelFieldTypes.Text = "Типи полів: немає даних";
                labelEmptyValues.Text = "Порожніх значень: 0";
                return;
            }
            labelRowCount.Text = "Рядків: " + apps.Count;

            int columnCount = dataGridViewApps.Columns.Count;
            labelColumnCount.Text = "Колонок: " + columnCount;

            string fieldTypes = "Типи полів:\n";

            fieldTypes += "App — string\n";
            fieldTypes += "Category — string\n";
            fieldTypes += "Rating — double?\n";
            fieldTypes += "Reviews — int?\n";
            fieldTypes += "Size — string\n";
            fieldTypes += "Installs — long?\n";
            fieldTypes += "Type — string\n";
            fieldTypes += "Price — double?\n";
            fieldTypes += "Content Rating — string\n";
            fieldTypes += "Genres — string\n";
            fieldTypes += "Last Updated — DateTime?\n";
            fieldTypes += "Current Ver — string\n";
            fieldTypes += "Android Ver — string\n";

            labelFieldTypes.Text = fieldTypes;

            int emptyValues = 0;

            foreach (var app in apps)
            {
                foreach (var property in typeof(App).GetProperties())
                {
                    object value = property.GetValue(app);

                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                        emptyValues++;
                }
            }

            labelEmptyValues.Text = "Порожніх значень: " + emptyValues;
        }
        private void SetupDataGridView()
        {
            dataGridViewApps.Columns.Clear();

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "App",
                DataPropertyName = "Name"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "CategoryName"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Rating",
                HeaderText = "Rating",
                DataPropertyName = "Rating"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReviewsCount",
                HeaderText = "Reviews",
                DataPropertyName = "ReviewsCount"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Size",
                HeaderText = "Size",
                DataPropertyName = "Size"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Installs",
                HeaderText = "Installs",
                DataPropertyName = "Installs"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                HeaderText = "Type",
                DataPropertyName = "Type"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DataPropertyName = "Price"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContentRating",
                HeaderText = "Content Rating",
                DataPropertyName = "ContentRating"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Genres",
                HeaderText = "Genres",
                DataPropertyName = "Genres"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastUpdated",
                HeaderText = "Last Updated",
                DataPropertyName = "LastUpdated"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CurrentVer",
                HeaderText = "Current Ver",
                DataPropertyName = "CurrentVer"
            });

            dataGridViewApps.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AndroidVer",
                HeaderText = "Android Ver",
                DataPropertyName = "AndroidVer"
            });

            foreach (DataGridViewColumn column in dataGridViewApps.Columns)
                column.ReadOnly = true;
        }
        private void SetupCsvSettings()
        {
            comboBoxDelimiter.Items.Clear();
            comboBoxDelimiter.Items.Add(",");
            comboBoxDelimiter.Items.Add(";");
            comboBoxDelimiter.Items.Add("TAB");
            comboBoxDelimiter.Items.Add("|");
            comboBoxDelimiter.SelectedIndex = 0;

            comboBoxEncoding.Items.Clear();
            comboBoxEncoding.Items.Add("UTF-8");
            comboBoxEncoding.Items.Add("Windows-1251");
            comboBoxEncoding.Items.Add("Unicode");
            comboBoxEncoding.SelectedIndex = 0;

            comboBoxNumberFormat.Items.Clear();
            comboBoxNumberFormat.Items.Add("1.23");
            comboBoxNumberFormat.Items.Add("1,23");
            comboBoxNumberFormat.SelectedIndex = 0;

            comboBoxDateFormat.Items.Clear();
            comboBoxDateFormat.Items.Add("yyyy-MM-dd");
            comboBoxDateFormat.Items.Add("dd.MM.yyyy");
            comboBoxDateFormat.Items.Add("MM/dd/yyyy");
            comboBoxDateFormat.Items.Add("MMMM d, yyyy");
            comboBoxDateFormat.SelectedIndex = 3;

            checkBoxHasHeader.Checked = true;
        }
        private CsvImportOptions GetCsvImportOptions()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            char delimiter = comboBoxDelimiter.SelectedItem?.ToString() switch
            {
                ";" => ';',
                "TAB" => '\t',
                "|" => '|',
                _ => ','
            };

            Encoding encoding = comboBoxEncoding.SelectedItem?.ToString() switch
            {
                "Windows-1251" => Encoding.GetEncoding(1251),
                "Unicode" => Encoding.Unicode,
                _ => Encoding.UTF8
            };

            string numberFormat = comboBoxNumberFormat.SelectedItem?.ToString() ?? "1.23";
            string dateFormat = comboBoxDateFormat.SelectedItem?.ToString() ?? "yyyy-MM-dd";

            return new CsvImportOptions
            {
                Delimiter = delimiter,
                HasHeader = checkBoxHasHeader.Checked,
                Encoding = encoding,
                NumberFormat = numberFormat,
                DateFormat = dateFormat
            };
        }
        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedFilePath))
            {
                MessageBox.Show(
                    "Спочатку виберіть CSV-файл.",
                    "Попередній перегляд",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                CsvImportOptions options = GetCsvImportOptions();

                CsvPreviewResult preview = DataParser.GetPreview(selectedFilePath, options, 100);

                if (preview.Errors.Count > 0)
                {
                    MessageBox.Show(
                        string.Join(Environment.NewLine, preview.Errors),
                        "Помилка попереднього перегляду",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                ShowPreview(preview);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не вдалося виконати попередній перегляд.\n\n" +
                    ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ShowPreview(CsvPreviewResult preview)
        {
            DataTable table = new DataTable();

            for (int i = 0; i < preview.ColumnCount; i++)
            {
                string columnName = i < preview.Headers.Count ? preview.Headers[i] : $"Колонка {i + 1}";

                if (table.Columns.Contains(columnName))
                    columnName += $"_{i + 1}";

                table.Columns.Add(columnName);
            }

            foreach (string[] row in preview.Rows)
            {
                DataRow dataRow = table.NewRow();

                for (int i = 0; i < row.Length && i < table.Columns.Count; i++)
                    dataRow[i] = row[i];

                table.Rows.Add(dataRow);
            }

            dataGridViewApps.DataSource = null;
            dataGridViewApps.Columns.Clear();
            dataGridViewApps.AutoGenerateColumns = true;
            dataGridViewApps.DataSource = table;

            labelRowCount.Text = $"Рядків: {preview.TotalRows}";
            labelColumnCount.Text = $"Колонок: {preview.ColumnCount}";
            labelEmptyValues.Text = $"Порожніх значень: {preview.EmptyValues}";

            string fieldTypes = "Типи полів:\n";

            for (int i = 0; i < preview.FieldTypes.Count; i++)
            {
                string fieldName = i < preview.Headers.Count ? preview.Headers[i] : $"Колонка {i + 1}";

                fieldTypes += $"{fieldName} — {preview.FieldTypes[i]}\n";
            }

            labelFieldTypes.Text = fieldTypes;

            labelResult.Text = $"Попередній перегляд: перші " + $"{preview.Rows.Count} рядків із " + $"{preview.TotalRows}.";
        }
    }
}
