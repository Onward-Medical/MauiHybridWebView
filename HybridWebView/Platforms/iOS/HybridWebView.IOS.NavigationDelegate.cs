using Foundation;
using WebKit;

namespace HybridWebView
{
    public class NavigationDelegate : WKNavigationDelegate, INSUrlConnectionDataDelegate
    {
        public NavigationDelegate() : base()
        {
        }

        public override void DidReceiveAuthenticationChallenge(WKWebView webView,
            NSUrlAuthenticationChallenge challenge,
            Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler)
        {
            completionHandler(NSUrlSessionAuthChallengeDisposition.UseCredential,
                new NSUrlCredential(challenge.ProtectionSpace.ServerSecTrust));

            return;
        }
    }
}