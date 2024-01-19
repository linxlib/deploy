using DeployClient.Common;
using DeployClient.Modals;
using Linx.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace DeployClient
{
    internal static class Program
    {
        public static IHost? CurrentHost { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            CurrentHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    FlurlHttpClientExt.ConfigureGlobalHttp();
                    var options = new Options("app.json");
                    services.AddSingleton<Options>(options);
                    
                    if (args.Length > 0)
                    {
                        if (Uri.TryCreate(args[0], UriKind.Absolute, out var uri) &&
                    string.Equals(uri.Scheme, "deploy", StringComparison.OrdinalIgnoreCase))
                        {
                            var a = args[0].Replace("deploy://", "");
                           
                            if (!a.EndsWith("/api"))
                            {
                                if (a.EndsWith("/"))
                                {
                                    a += "api";
                                } else
                                {
                                    a += "/api";
                                }
                             
                            }
                            options.currentUrl = a;
                            options.From();
                            options.Save();
                        }

                    }

                    var nowBaseUri = options.currentUrl;
                    services.AddTransient<IAuthTokenStore, AuthTokenStore>();
                    services.AddTransient<AuthHeaderHandler>();

                    services.AddGlobalHttp(nowBaseUri);

                    //注册窗口
                    services.AddScoped(typeof(LoginForm));
                    services.AddScoped(typeof(MainForm));
                    services.AddScoped(typeof(DeployTaskForm));
                    services.AddScoped(typeof(UserModalForm));
                    services.AddScoped(typeof(ServiceModalForm));
                    services.AddScoped(typeof(UpdateModalForm));
                    services.AddScoped(typeof(RegisterForm));
                    services.AddScoped(typeof(ServerForm));
                    services.AddScoped(typeof(UpdateForm));
                    services.AddScoped(typeof(UserForm));
                    services.AddScoped(typeof(RemoteDirectorySelectModalForm));
                    services.AddScoped(typeof(AvailableServiceForm));
                    services.AddScoped<UpdateLatestModalForm>();



                })
               
                .Build();
            using IServiceScope serviceScope = CurrentHost.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            var mainForm = provider.GetRequiredService<LoginForm>();
            Application.Run(mainForm);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            var exBuilder = new StringBuilder();
            exBuilder.AppendLine("异常信息:");
            exBuilder.AppendLine(ex.Message);
            exBuilder.AppendLine("堆栈:");
            exBuilder.AppendLine(ex.StackTrace);
           if ( ex.InnerException != null && ex.InnerException.Message != null && ex.Message != ex.InnerException.Message)
            {
                exBuilder.AppendLine("内部异常信息:");
                exBuilder.AppendLine(ex.InnerException.Message);
                exBuilder.AppendLine("内部异常堆栈:");
                exBuilder.AppendLine(ex.InnerException.StackTrace);
            }


            MessageBox.Show(exBuilder.ToString());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            var exBuilder = new StringBuilder();
            exBuilder.AppendLine("异常信息:");
            exBuilder.AppendLine(ex.Message);
            exBuilder.AppendLine("堆栈:");
            exBuilder.AppendLine(ex.StackTrace);
            if (ex.InnerException != null && ex.InnerException.Message != null && ex.Message != ex.InnerException.Message)
            {
                exBuilder.AppendLine("内部异常信息:");
                exBuilder.AppendLine(ex.InnerException.Message);
                exBuilder.AppendLine("内部异常堆栈:");
                exBuilder.AppendLine(ex.InnerException.StackTrace);
            }


            MessageBox.Show(exBuilder.ToString());
        }
    }
}