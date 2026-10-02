using CsvHelper;
using CsvHelper.Configuration;
using GooglePlayAnalyzer.Domain.Entities;
using GooglePlayAnalyzer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace GooglePlayAnalyzer.Data.Providers.Csv
{
    public class CsvDataProvider : IDataProvider<App>
    {
        public List<App> Read(string path)
        {
            return Load(path);
        }
        public List<App> Load(string path)
        {
            if (!ValidateFile(path))
                throw new Exception("Файл CSV не знайдено або вибрано неправильний формат.");

            return DataParser.ParseData(path).Apps;
        }
        public bool ValidateFile(string path)
        {
            return File.Exists(path) &&
                   Path.GetExtension(path).Equals(".csv", StringComparison.OrdinalIgnoreCase);
        }
        public string GetFileInfo(string path)
        {
            if (!File.Exists(path))
                return "Файл не знайдено.";

            FileInfo file = new FileInfo(path);
            return $"Назва: {file.Name}, Розмір: {file.Length / 1024} KB";
        }
        public void Write(string path, List<App> apps)
        {
            throw new NotImplementedException();
        }
    }
}