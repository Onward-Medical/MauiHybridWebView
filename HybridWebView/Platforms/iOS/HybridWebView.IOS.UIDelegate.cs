using System.Runtime.Versioning;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
using WebKit;

namespace HybridWebView;

public class MauiWebViewUIDelegate2 : MauiWebViewUIDelegate
{
    public MauiWebViewUIDelegate2(IWebViewHandler handler) : base(handler)
    {
    }

    [SupportedOSPlatform("maccatalyst13.1")]
    [SupportedOSPlatform("ios13.0")]
    [UnsupportedOSPlatform("macos")]
    [UnsupportedOSPlatform("tvos")]
    public override void SetContextMenuConfiguration(WKWebView webView, WKContextMenuElementInfo elementInfo,
        Action<UIContextMenuConfiguration> completionHandler)
    {
        bool completionHandlerIsInvoked = false;

        base.SetContextMenuConfiguration(webView, elementInfo, cfg =>
        {
            completionHandlerIsInvoked = true;

            completionHandler(cfg);
        });

        if (completionHandlerIsInvoked == false)
            completionHandler(null!);
    }
}