namespace HybridWebView
{
    public class HybridWebViewRawMessageReceivedEventArgs : EventArgs
    {
        public HybridWebViewRawMessageReceivedEventArgs(string? message)
        {
            Message = message;
        }

        public string? Message { get; }
    }


    public class HybridWebViewNavigateCompletedEventArgs : EventArgs
    {
        public HybridWebViewNavigateCompletedEventArgs(string? message)
        {
            Message = message;
        }

        public string? Message { get; }
    }
}