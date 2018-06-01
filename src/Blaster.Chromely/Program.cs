using Chromely.CefGlue.Winapi;
using Chromely.CefGlue.Winapi.ChromeHost;
using Chromely.Core;
using Chromely.Core.Helpers;
using Chromely.Core.Infrastructure;
using System;
using System.Reflection;
using WinApi.Windows;

namespace Blaster.Chromely
{
    class Program
    {
        static int Main(string[] args)
        {
            HostHelpers.SetupDefaultExceptionHandlers();

            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //var startUrl = $"file:///{appDirectory}_dist/netstandard2.0/dist/index.html";
            //var startUrl = "file:///C:/F/git/ChromelyDoodle/src/Blaster.Chromely/_dist/netstandard2.0/publish/Blaster.Blazor/dist/index.html";
            var startUrl = "https://www.google.at";

            ChromelyConfiguration config = ChromelyConfiguration
                                          .Create()
                                          .RegisterMessageRouterHandler(new ChromelyMesssageRouter)
                                          .WithAppArgs(args)
                                          .WithHostSize(1000, 600)
                                          //.WithDependencyCheck(true)
                                          // The single process should only be used for debugging purpose.
                                          // For production, this should not be needed when the app is published 

                                          // Alternate approach for multi-process, is to add a subprocess application
                                          //.WithCustomSetting(CefSettingKeys.BrowserSubprocessPath, path_to_sunprocess)
                                          .WithCustomSetting(CefSettingKeys.SingleProcess, true)
                                          .WithStartUrl(startUrl);

            var factory = WinapiHostFactory.Init();
            using (var window = factory.CreateWindow(() => new CefGlueBrowserHost(config),
                  "chromely", constructionParams: new FrameWindowConstructionParams()))
            {
                window.RegisterUrlScheme(new UrlScheme("https://github.com/mattkol/Chromely", true));
                window.RegisterServiceAssembly(Assembly.GetExecutingAssembly());

                window.SetSize(config.HostWidth, config.HostHeight);
                window.CenterToScreen();
                window.Show();
                return new EventLoop().Run(window);
            }
        }
    }

}
