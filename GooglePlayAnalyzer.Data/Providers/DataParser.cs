using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GooglePlayAnalyzer.Domain.Validation;

    namespace GooglePlayAnalyzer.Data.Providers.Csv
    {
        public static class DataParser
        {
            private static readonly string[] ExpectedHeaders =
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
            public static CsvImportResult ParseData(string path)
            {
                return ParseData(path, new CsvImportOptions());
            }
            public static CsvImportResult ParseData(string path, CsvImportOptions options)
            {
                var result = new CsvImportResult();

                if (!File.Exists(path))
                {
                    result.Errors.Add("Файл не знайдено.");
                    return result;
                }

            try
            {
                string[] lines = File.ReadAllLines(path, options.Encoding);

                if (lines.Length == 0)
                {
                    result.Errors.Add("Файл порожній.");
                    return result;
                }

                int startRow = 0;

                if (options.HasHeader)
                {
                    if (!ValidateHeaders(lines[0], options.Delimiter, result))
                        return result;

                    startRow = 1;
                }

                for (int i = startRow; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i]))
                        continue;

                    try
                    {
                        string[] fields = ParseCsvLine(lines[i], options.Delimiter);

                        if (fields.Length < ExpectedHeaders.Length)
                        {
                            result.Errors.Add($"Рядок {i + 1}: недостатньо полів.");
                            continue;
                        }

                        result.Apps.Add(ParseApp(fields, options));
                    }
                    catch (Exception ex)
                    {
                        result.Errors.Add($"Рядок {i + 1}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Не вдалося прочитати CSV-файл. " + $"Перевірте кодування, роздільник та формат даних. " + $"Деталі: {ex.Message}");
            }
                return result;
            }
            private static bool ValidateHeaders(string headerLine, char delimiter, CsvImportResult result)
            {
                string[] headers = ParseCsvLine(headerLine, delimiter);

                if (headers.Length != ExpectedHeaders.Length)
                {
                    result.Errors.Add("Неправильна кількість колонок у заголовку. " + "Перевірте вибраний роздільник.");
                    return false;
                }

                for (int i = 0; i < ExpectedHeaders.Length; i++)
                {
                    if (!headers[i].Trim().Equals(ExpectedHeaders[i],StringComparison.OrdinalIgnoreCase))
                    {
                        result.Errors.Add($"Неправильний заголовок колонки №{i + 1}. " + $"Очікується: {ExpectedHeaders[i]}.");
                        return false;
                    }
                }
                return true;
            }
            private static App ParseApp(string[] fields, CsvImportOptions options)
            {
                Category category = new Category
                {
                    Name = fields[1].Trim()
                };

                return new App
                {
                    Name = fields[0].Trim(),
                    Category = category,
                    Rating = ParseDouble(fields[2], options),
                    ReviewsCount = ParseInt(fields[3]),
                    Size = fields[4].Trim(),
                    Installs = ParseLong(fields[5]),
                    Type = fields[6].Trim(),
                    Price = ParsePrice(fields[7], options),
                    ContentRating = fields[8].Trim(),
                    Genres = fields[9].Trim(),
                    LastUpdated = ParseDate(fields[10], options),
                    CurrentVer = fields[11].Trim(),
                    AndroidVer = fields[12].Trim()
                };
            }
            private static string[] ParseCsvLine(string line, char delimiter)
            {
                var fields = new List<string>();
                var current = new StringBuilder();
                bool insideQuotes = false;

                foreach (char character in line)
                {
                    if (character == '"')
                    {
                        insideQuotes = !insideQuotes;
                        continue;
                    }

                    if (character == delimiter && !insideQuotes)
                    {
                        fields.Add(current.ToString());
                        current.Clear();
                    }
                    else
                    {
                        current.Append(character);
                    }
                }

                fields.Add(current.ToString());

                return fields.ToArray();
            }
            private static double? ParseDouble(string value, CsvImportOptions options)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;

                CultureInfo culture = GetCulture(options);
                value = value.Trim();

                if (double.TryParse(value, NumberStyles.Any, culture, out double result))
                {
                    if (double.IsNaN(result) || double.IsInfinity(result))
                        return null;

                    if (result < 0 || result > 5)
                        throw new Exception("Рейтинг повинен бути від 0 до 5.");

                    return result;
                }

                throw new Exception($"Неправильний формат числа: {value}");
            }
            private static int? ParseInt(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;

                value = value
                    .Trim()
                    .Replace(",", "")
                    .Replace(" ", "");

                if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
                {
                    if (result < 0)
                        throw new Exception("Кількість відгуків не може бути від'ємною.");

                    return result;
                }

                throw new Exception($"Неправильне ціле число: {value}");
            }
            private static long? ParseLong(string value)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;

                value = value
                    .Trim()
                    .Replace(",", "")
                    .Replace("+", "")
                    .Replace(" ", "");

                if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long result))
                {
                    if (result < 0)
                        throw new Exception("Кількість встановлень не може бути від'ємною.");

                    return result;
                }

                throw new Exception($"Неправильне ціле число: {value}");
            }
            private static double? ParsePrice(string value,CsvImportOptions options)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;

                value = value
                    .Trim()
                    .Replace("$", "")
                    .Trim();

                if (double.TryParse(value, NumberStyles.Any, GetCulture(options), out double result))
                    return result;

                throw new Exception($"Неправильний формат ціни: {value}");
            }
            private static DateTime? ParseDate(string value, CsvImportOptions options)
            {
                if (string.IsNullOrWhiteSpace(value))
                    return null;

                value = value.Trim();

                if (DateTime.TryParseExact(value, options.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    return result;

                string[] formats =
                {
                "MMMM d, yyyy",
                "MMM d, yyyy",
                "yyyy-MM-dd",
                "dd.MM.yyyy",
                "MM/dd/yyyy"
            };

                if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;

                throw new Exception($"Неправильний формат дати: {value}");
            }
            public static CsvPreviewResult GetPreview(string path, CsvImportOptions options, int maxRows = 100)
            {
                var result = new CsvPreviewResult();

                if (!File.Exists(path))
                {
                    result.Errors.Add("Файл не знайдено.");
                    return result;
                }

                try
                {
                    string[] lines = File.ReadAllLines(path, options.Encoding);

                    if (lines.Length == 0)
                    {
                        result.Errors.Add("Файл порожній.");
                        return result;
                    }

                    int startRow = 0;

                    if (options.HasHeader)
                    {
                        result.Headers.AddRange(
                            ParseCsvLine(lines[0], options.Delimiter));

                        startRow = 1;
                    }

                    int totalRows = 0;

                    for (int i = startRow; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i]))
                            continue;

                        totalRows++;

                        string[] fields = ParseCsvLine(lines[i], options.Delimiter);

                        if (result.ColumnCount == 0)
                        {
                            result.ColumnCount = fields.Length;

                            if (!options.HasHeader)
                            {
                                for (int column = 0; column < fields.Length; column++)
                                    result.Headers.Add($"Колонка {column + 1}");
                            }
                        }

                        foreach (string field in fields)
                        {
                            if (string.IsNullOrWhiteSpace(field))
                                result.EmptyValues++;
                        }

                        if (result.Rows.Count < maxRows)
                            result.Rows.Add(fields);
                    }

                    result.TotalRows = totalRows;

                    if (result.ColumnCount == 0 && result.Headers.Count > 0)
                        result.ColumnCount = result.Headers.Count;

                    result.FieldTypes = DetectFieldTypes(result.Rows, result.ColumnCount, options);
                }
                catch (Exception ex)
                {
                    result.Errors.Add("Не вдалося прочитати файл. " + "Перевірте кодування та роздільник.\n" + ex.Message);
                }

                return result;
            }
            private static List<string> DetectFieldTypes(List<string[]> rows, int columnCount, CsvImportOptions options)
            {
                var types = new List<string>();

                for (int column = 0; column < columnCount; column++)
                {
                    string type = "string";

                    foreach (string[] row in rows)
                    {
                        if (column >= row.Length)
                            continue;

                        string value = row[column].Trim();

                        if (string.IsNullOrWhiteSpace(value))
                            continue;

                        if (IsDate(value, options))
                        {
                            type = "DateTime";
                            break;
                        }

                        if (IsInteger(value))
                        {
                            type = "int";
                            continue;
                        }

                        if (IsNumber(value, options))
                        {
                            type = "double";
                            continue;
                        }

                        type = "string";
                        break;
                    }

                    types.Add(type);
                }

                return types;
            }
            private static bool IsInteger(string value)
            {
                value = value
                    .Replace(",", "")
                    .Replace(" ", "")
                    .Replace("+", "");

                return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
            }
            private static bool IsNumber(string value, CsvImportOptions options)
            {
                value = value
                    .Replace("$", "")
                    .Trim();

                return double.TryParse(value, NumberStyles.Any, GetCulture(options), out _);
            }
            private static bool IsDate(string value, CsvImportOptions options)
            {
                return DateTime.TryParseExact(value, options.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
            }
            private static CultureInfo GetCulture(CsvImportOptions options)
            {
                return options.NumberFormat == "1,23" ? new CultureInfo("uk-UA") : CultureInfo.InvariantCulture;
            }
        }
    }

