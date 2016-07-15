using System;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        public void SimulateMailArrived()
        {
            OnMailArrived(new MailArrivedEventArgs("title", "body"));
        }
        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            if (MailArrived != null)
            {
                MailArrived(this, e);
            }
            // C# 6:
            // MailArrived?.Invoke(this, e);
        }
    }

    public class MailArrivedEventArgs : EventArgs
    {
        public readonly string Title;
        public readonly string Body;
        internal MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
