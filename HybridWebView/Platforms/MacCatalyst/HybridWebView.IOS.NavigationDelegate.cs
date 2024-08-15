using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using WebKit;

namespace HybridWebView
{
    public class NavigationDelegate : WKNavigationDelegate
    {
        public override void DidReceiveAuthenticationChallenge(WKWebView webView,
            NSUrlAuthenticationChallenge challenge,
            Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler)
        {
            completionHandler.Invoke(NSUrlSessionAuthChallengeDisposition.PerformDefaultHandling, null);
        }


        //[Export("webView: DidReceiveAuthenticationChallenge:")]
        //[SupportedOSPlatform("ios11.0")]
        //public async void DidReceiveAuthenticationChallenge(WKWebView webView, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler)
        //{

        //    await Task.CompletedTask;
        //}
    }
}