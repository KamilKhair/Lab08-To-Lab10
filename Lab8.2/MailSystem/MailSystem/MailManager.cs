using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        public void SimulateMailArrived()
        {
            // render page to printer...
            OnMailArrived(new MailArrivedEventArgs("title", "body"));
        }
        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            // C# 6:
            // MailArrived?.Invoke(this, e);

            if (MailArrived != null)
            {
                MailArrived(this, e);
            }
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
