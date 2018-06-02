using System;
using Xilium.CefGlue;

namespace Blaster.Chromely.Handlers
{
    public class BlasterSchemeHandlerFactory : CefSchemeHandlerFactory
    {
        readonly string _baseUri;
        readonly string _appDirectory;
        
        public BlasterSchemeHandlerFactory(string baseUri, string appDirectory)
        {
            _baseUri = baseUri;
            _appDirectory = appDirectory;
        }

        protected override CefResourceHandler Create(CefBrowser browser, CefFrame frame, string schemeName, CefRequest request)
        {
            return new BlasterResourceSchemeHandler(_baseUri, _appDirectory);
        }
    }
}
