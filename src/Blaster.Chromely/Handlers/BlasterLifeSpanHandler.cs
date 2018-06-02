using Chromely.CefGlue.Winapi.ChromeHost;
using Chromely.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WinApi.Windows;
using Xilium.CefGlue;

namespace Blaster.Chromely.Handlers
{
    public class BlasterLifeSpanHandler : CefLifeSpanHandler
    {
        protected override void OnAfterCreated(CefBrowser browser)
        {
            base.OnAfterCreated(browser);

            var wi = CefWindowInfo.Create();
            var host = browser.GetHost();
            wi.SetAsPopup(IntPtr.Zero, "DevTools");
            host.ShowDevTools(wi, new DevToolsWebClient(), new CefBrowserSettings(), new CefPoint(0, 0));
        }

        /// <summary>
        /// The dev tools web client.
        /// </summary>
        private class DevToolsWebClient : CefClient
        {
        }
    }
}
