using GooglePlayAnalyzer.Domain.Entities;
using GooglePlayAnalyzer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Globalization;
using System.Xml.Linq;

namespace GooglePlayAnalyzer.Data.Providers.Xml
{
    public class XmlDataProvider : IDataProvider<App>
    {
        public List<App> Read(string path)
        {
            return Load(path);
        }
        public List<App> Load(string path)
        {
            if (!ValidateFile(path))
                throw new Exception("XML-файл не знайдено або вибрано неправильний формат.");

            XDocument document = XDocument.Load(path);
            XElement root = document.Root;

            if (root == null || root.Name != "Apps")
                throw new Exception("Неправильна структура XML. Очікується кореневий елемент <Apps>.");

            return root.Elements("App").Select(ParseApp).ToList();
        }
        public bool ValidateFile(string path)
        {
            return File.Exists(path) &&
                   Path.GetExtension(path).Equals(".xml", StringComparison.OrdinalIgnoreCase);
        }
        public string GetFileInfo(string path)
        {
            if (!File.Exists(path))
                return "Файл не знайдено";

            FileInfo file = new FileInfo(path);

            return $"Назва: {file.Name}, Розмір: {file.Length / 1024} KB";
        }
        public void Write(string path, List<App> apps)
        {
            XElement root = new XElement(
                "Apps", apps.Select(CreateAppElement));

            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);

            document.Save(path);
        }
        private static App ParseApp(XElement element)
        {
            int categoryId = GetInt(element.Element("CategoryId"));

            Category category = new Category
            {
                Id = categoryId,
                Name = element.Element("Category")?.Element("Name")?.Value ?? ""
            };

            return new App
            {
                Id = GetInt(element.Element("Id")),
                Name = GetString(element.Element("Name")),
                CategoryId = categoryId,
                Category = category,
                Rating = GetNullableDouble(element.Element("Rating")),
                ReviewsCount = GetNullableInt(element.Element("ReviewsCount")),
                Size = GetString(element.Element("Size")),
                Installs = GetNullableLong(element.Element("Installs")),
                Type = GetString(element.Element("Type")),
                Price = GetNullableDouble(element.Element("Price")),
                ContentRating = GetString(element.Element("ContentRating")),
                Genres = GetString(element.Element("Genres")),
                LastUpdated = GetNullableDate(element.Element("LastUpdated")),
                CurrentVer = GetString(element.Element("CurrentVer")),
                AndroidVer = GetString(element.Element("AndroidVer"))
            };
        }
        private static XElement CreateAppElement(App app)
        {
            return new XElement(
                "App",
                new XElement("Id", app.Id),
                new XElement("Name", app.Name),
                new XElement("CategoryId", app.CategoryId),
                new XElement("Category", new XElement("Name", app.Category?.Name ?? "")),
                new XElement("Rating", app.Rating),
                new XElement("ReviewsCount", app.ReviewsCount),
                new XElement("Size", app.Size),
                new XElement("Installs", app.Installs),
                new XElement("Type", app.Type),
                new XElement("Price", app.Price),
                new XElement("ContentRating", app.ContentRating),
                new XElement("Genres", app.Genres),
                new XElement("LastUpdated", app.LastUpdated),
                new XElement("CurrentVer", app.CurrentVer),
                new XElement("AndroidVer", app.AndroidVer)
            );
        }
        private static string GetString(XElement element)
        {
            return element?.Value.Trim() ?? "";
        }
        private static int GetInt(XElement element)
        {
            return int.TryParse(element?.Value, out int value) ? value : 0;
        }
        private static int? GetNullableInt(XElement element)
        {
            if (string.IsNullOrWhiteSpace(element?.Value))
                return null;

            return int.TryParse(element.Value, out int value) ? value : null;
        }
        private static long? GetNullableLong(XElement element)
        {
            if (string.IsNullOrWhiteSpace(element?.Value))
                return null;

            return long.TryParse(element.Value, out long value) ? value : null;
        }
        private static double? GetNullableDouble(XElement element)
        {
            if (string.IsNullOrWhiteSpace(element?.Value))
                return null;

            return double.TryParse( element.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double value) ? value : null;
        }
        private static DateTime? GetNullableDate(XElement element)
        {
            if (string.IsNullOrWhiteSpace(element?.Value))
                return null;

            return DateTime.TryParse(element.Value, out DateTime value) ? value : null;
        }
    }
}