#if __ANDROID__
using Android.Webkit;
using Microsoft.Maui.Platform;

#elif __IOS__ || __MACCATALYST__
using WebKit;
#endif
using Microsoft.Maui.Handlers;

namespace HybridWebView
{
    public partial class HybridWebViewHandler : WebViewHandler
    {
        public static IPropertyMapper<IWebView, IWebViewHandler> HybridWebViewMapper =
            new PropertyMapper<IWebView, IWebViewHandler>(Mapper)
            {
#if __ANDROID__
                [nameof(WebViewClient)] = MapHybridWebViewClient,

#elif __IOS__ || __MACCATALYST__
                [nameof(WKUIDelegate)] = MapWKUIDelegate2,
                [nameof(WKNavigationDelegate)] = MapHybridNavigationClient,


#endif
            };

        public HybridWebViewHandler() : base(HybridWebViewMapper, CommandMapper)
        {
        }

        public HybridWebViewHandler(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null)
            : base(mapper ?? HybridWebViewMapper, commandMapper ?? CommandMapper)
        {
        }
#if MACCATALYST || IOS
        public static void MapHybridNavigationClient(IWebViewHandler handler, IWebView webView)
        {
            handler.PlatformView.NavigationDelegate = new NavigationDelegate();
        }
#endif

#if ANDROID
        public static void MapHybridWebViewClient(IWebViewHandler handler, IWebView webView)
        {
            if (handler is HybridWebViewHandler platformHandler)
            {
                var webViewClient = new AndroidHybridWebViewClient(platformHandler);
                handler.PlatformView.SetWebViewClient(webViewClient);

                // TODO: There doesn't seem to be a way to override MapWebViewClient() in maui/src/Core/src/Handlers/WebView/WebViewHandler.Android.cs
                // in such a way that it knows of the custom MauiWebViewClient that we're creating. So, we use private reflection to set it on the
                // instance. We might end up duplicating WebView/BlazorWebView anyway, in which case we wouldn't need this workaround.
                var webViewClientField =
                    typeof(WebViewHandler).GetField("_webViewClient",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.FlattenHierarchy);

                // Starting in .NET 8.0 the private field is gone and this call isn't necessary, so we only set if it needed
                webViewClientField?.SetValue(handler, webViewClient);
            }
        }
#endif
    }
}