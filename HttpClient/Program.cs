using Microsoft.AspNetCore.SignalR;

using System.Diagnostics;
namespace HttpClient {
    public class Program {
        /// <summary>
        /// sfsfafsadf 
        /// </summary>
        public static string?  HttpClinetId=null;//Worker��ı����ᵽ���ﲻ֪���в���,�У�����
        public static string?  HtmlId=null;
        public static IntPtr BrowserHandle=0;
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();
            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();
        }
    }

}
