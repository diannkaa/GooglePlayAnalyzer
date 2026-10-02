using GooglePlayAnalyzer.Domain.Entities;
using GooglePlayAnalyzer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Data.Providers.Json
{
    public class JsonDataProvider : IDataProvider<App>
    {
        public List<App> Read(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<App>>(json) ?? new List<App>();
        }
        public List<App> Load(string path)
        {
            return Read(path);
        }
        public bool ValidateFile(string path)
        {
            return File.Exists(path) &&
                   Path.GetExtension(path).Equals(".json", StringComparison.OrdinalIgnoreCase);
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
            string json = JsonSerializer.Serialize(apps, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }
    }
}