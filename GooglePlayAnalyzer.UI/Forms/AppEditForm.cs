using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GooglePlayAnalyzer.UI.Forms
{
    public partial class AppEditForm : Form
    {
        public App App { get; private set; }
        private App? editingApp;
        public AppEditForm()
        {
            InitializeComponent();
            SetupForm();
        }
        public AppEditForm(App app)
        {
            InitializeComponent();
            editingApp = app;
            SetupForm();
            LoadAppData(app);
        }
        private void SetupForm()
        {
            comboBoxType.Items.Clear();
            comboBoxType.Items.Add("Free");
            comboBoxType.Items.Add("Paid");
            comboBoxType.SelectedIndex = 0;

            buttonSave.Click += buttonSave_Click;
            buttonCancel.Click += buttonCancel_Click;

            if (editingApp == null)
                Text = "Додавання застосунку";
            else
                Text = "Редагування застосунку";
        }
        private void LoadAppData(App app)
        {
            textBoxName.Text = app.Name;
            textBoxCategory.Text = app.Category?.Name ?? "";
            textBoxRating.Text = app.Rating.HasValue ? app.Rating.Value.ToString(CultureInfo.InvariantCulture) : "";
            textBoxReviews.Text = app.ReviewsCount.HasValue ? app.ReviewsCount.Value.ToString() : "";
            textBoxSize.Text = app.Size;
            textBoxInstalls.Text = app.Installs.HasValue ? app.Installs.Value.ToString() : "";

            if (!string.IsNullOrWhiteSpace(app.Type))
                comboBoxType.Text = app.Type;

            textBoxPrice.Text = app.Price.HasValue ? app.Price.Value.ToString(CultureInfo.InvariantCulture) : "";
            textBoxContentRating.Text = app.ContentRating;
            textBoxGenres.Text = app.Genres;

            if (app.LastUpdated.HasValue)
                dateTimePickerLastUpdated.Value = app.LastUpdated.Value;
            else
                dateTimePickerLastUpdated.Value = DateTime.Now;

            textBoxCurrentVer.Text = app.CurrentVer;
            textBoxAndroidVer.Text = app.AndroidVer;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!TryReadData(out string name, out string categoryName, out double? rating, out int? reviews, out long? installs, out double? price))
                return;

            if (editingApp != null)
            {
                editingApp.Name = name;

                if (editingApp.Category == null)
                    editingApp.Category = new Category();

                editingApp.Category.Name = categoryName;
                editingApp.Rating = rating;
                editingApp.ReviewsCount = reviews;
                editingApp.Size = textBoxSize.Text.Trim();
                editingApp.Installs = installs;
                editingApp.Type = comboBoxType.Text;
                editingApp.Price = price;
                editingApp.ContentRating = textBoxContentRating.Text.Trim();
                editingApp.Genres = textBoxGenres.Text.Trim();
                editingApp.LastUpdated = dateTimePickerLastUpdated.Value;
                editingApp.CurrentVer = textBoxCurrentVer.Text.Trim();
                editingApp.AndroidVer = textBoxAndroidVer.Text.Trim();

                App = editingApp;
            }
            else
            {
                Category category = new Category
                {
                    Name = categoryName
                };

                App = new App
                {
                    Name = name,
                    Category = category,
                    Rating = rating,
                    ReviewsCount = reviews,
                    Size = textBoxSize.Text.Trim(),
                    Installs = installs,
                    Type = comboBoxType.Text,
                    Price = price,
                    ContentRating = textBoxContentRating.Text.Trim(),
                    Genres = textBoxGenres.Text.Trim(),
                    LastUpdated = dateTimePickerLastUpdated.Value,
                    CurrentVer = textBoxCurrentVer.Text.Trim(),
                    AndroidVer = textBoxAndroidVer.Text.Trim()
                };
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private bool TryReadData(out string name, out string categoryName, out double? rating, out int? reviews, out long? installs, out double? price)
        {
            name = textBoxName.Text.Trim();
            categoryName = textBoxCategory.Text.Trim();
            rating = null;
            reviews = null;
            installs = null;
            price = null;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Введіть назву застосунку.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show(
                    "Введіть категорію.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxCategory.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(textBoxRating.Text))
            {
                if (!TryParseDouble(textBoxRating.Text, out double ratingValue) || ratingValue < 0 || ratingValue > 5)
                {
                    MessageBox.Show(
                        "Рейтинг повинен бути числом від 0 до 5.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxRating.Focus();
                    return false;
                }

                rating = ratingValue;
            }

            if (!string.IsNullOrWhiteSpace(textBoxInstalls.Text))
            {
                if (!long.TryParse(textBoxInstalls.Text.Trim(), out long installsValue) || installsValue < 0)
                {
                    MessageBox.Show(
                        "Кількість встановлень повинна бути невід'ємним числом.",
                        "Помилка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    textBoxInstalls.Focus();
                    return false;
                }

                installs = installsValue;
            }

            if (!string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                if (!TryParseDouble(textBoxPrice.Text, out double priceValue) || priceValue < 0)
                {
                    MessageBox.Show("Ціна повинна бути невід'ємним числом.",
                        "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPrice.Focus();
                    return false;
                }

                price = priceValue;
            }

            return true;
        }
        private bool TryParseDouble(string text, out double value)
        {
            text = text.Trim();

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                return true;

            text = text.Replace(',', '.');

            return double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
