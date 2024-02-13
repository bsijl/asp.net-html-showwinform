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

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(
                    builder => {//�����������
                        builder.WithOrigins("https://127.0.0.1:5239")
                            .AllowAnyHeader()
                            .WithMethods("GET","POST")
                            .AllowCredentials();
                        //.WithExposedHeaders("x-custom-header");
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapControllers();
            app.MapHub<Worker>("/signalr");
            app.Run();
            //string path = System.Environment.CurrentDirectory;//ʵ�����в���
            //string path = @"D:\Web\htmlpopWin\HttpClient\bin\Debug";
            //Process.Start(path+"HttpClient.exe");//����֮����Զ���HttpClient�������ӣ������䷢��һ����Ϣ StartOK
        }
    }

}
