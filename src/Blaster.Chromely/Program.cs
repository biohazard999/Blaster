using System;
using Blaster.Chromely.Handlers;
using Chromely.CefGlue.Winapi;
using Chromely.CefGlue.Winapi.ChromeHost;
using Chromely.Core;
using Chromely.Core.Helpers;
using WinApi.Windows;

namespace Blaster.Chromely
{
    class Program
    {
        static int Main(string[] args)
        {
            HostHelpers.SetupDefaultExceptionHandlers();
            
            var startUrl = $"http://blaster.local/index.html";

            ChromelyConfiguration config = ChromelyConfiguration
                                          .Create()
                                          .RegisterSchemeHandler("http", "blaster.local", new BlasterSchemeHandlerFactory("http://blaster.local", "_dist/netstandard2.0/publish/Blaster.Blazor/dist/"))
                                          .WithAppArgs(args)
                                          
                                          .WithHostSize(1000, 600)
                                          //.WithDependencyCheck(true)
                                          // The single process should only be used for debugging purpose.
                                          // For production, this should not be needed when the app is published 

                                          // Alternate approach for multi-process, is to add a subprocess application
                                          //.WithCustomSetting(CefSettingKeys.BrowserSubprocessPath, path_to_sunprocess)
                                          .RegisterCustomHandler(CefHandlerKey.LifeSpanHandler, typeof(BlasterLifeSpanHandler))
                                          .WithCustomSetting(CefSettingKeys.SingleProcess, true)
                                          .WithStartUrl(startUrl);

            var factory = WinapiHostFactory.Init();
            
            using (var window = factory.CreateWindow(() => new CefGlueBrowserHost(config),
                  "baster", constructionParams: new FrameWindowConstructionParams()))
            {
                window.RegisterSchemeHandlers();

                //window.RegisterUrlScheme(new UrlScheme("https://github.com/mattkol/Chromely", true));
                //window.RegisterServiceAssembly(Assembly.GetExecutingAssembly());
                
                window.SetSize(config.HostWidth, config.HostHeight);
                window.CenterToScreen();
                window.Show();
                return new EventLoop().Run(window);
            }
        }
    }

}
