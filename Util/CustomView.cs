using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.IO;
using System.Threading.Tasks;

namespace OnlineCinema.Util
{
    public class CustomView : IView // Пользовательское представление
    {
        public string Path { get; set; }

        public CustomView(string pathView) { 
           Path = pathView;
        }

        public async Task RenderAsync(ViewContext context)
        { // чистает содержимое представления из файла, указанного в Path и записывает его в выходной поток context.Writer
          
            string content = "";

            using (StreamReader viewReader = new StreamReader(Path))
            {
                content = await viewReader.ReadToEndAsync();
            }
            await context.Writer.WriteAsync(content);
        }
    }
}
