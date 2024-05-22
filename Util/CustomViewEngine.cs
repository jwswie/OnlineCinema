using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.IO;

namespace OnlineCinema.Util
{
    public class CustomViewEngine : IViewEngine // Пользовательский движок представлений
    {

        public ViewEngineResult GetView(string? executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, new string[] { });
        }

        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        { // Ищет представление по его имени и возвращает результат, содержащий путь к представлению и экземпляр CustomView, если представление найдено.
            string viewPath = $"Views/{viewName}.cshtml";

            if (string.IsNullOrEmpty(viewName))
            {
                viewPath = $"Views/{context.RouteData.Values["action"]}.cshtml";
            }

            if (File.Exists(viewPath))
            {
                return ViewEngineResult.Found(viewPath, new CustomView(viewPath));
            }
            else
            {
                return ViewEngineResult.NotFound(viewName, new string[] { viewPath });
            }
        }
    }
}
