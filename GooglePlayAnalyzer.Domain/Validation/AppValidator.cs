using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooglePlayAnalyzer.Domain.Entities;

namespace GooglePlayAnalyzer.Domain.Validation
{
    public static class AppValidator
    {
        public static List<string> Validate(App app)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(app.Name))

                if (app.Category == null || string.IsNullOrWhiteSpace(app.Category.Name))
                    errors.Add("Категорія не може бути порожньою.");

            if (app.Rating is < 0 or > 5)
                errors.Add("Рейтинг має бути від 0 до 5.");

            if (app.ReviewsCount < 0)
                errors.Add("Кількість відгуків не може бути від'ємною.");

            if (app.Installs < 0)
                errors.Add("Кількість встановлень не може бути від'ємною.");

            if (app.Price < 0)
                errors.Add("Ціна не може бути від'ємною.");

            return errors;
        }
    }
}