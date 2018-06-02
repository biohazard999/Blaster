using System;
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
