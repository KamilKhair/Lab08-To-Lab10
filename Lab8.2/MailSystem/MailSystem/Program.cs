
using System;
using System.Threading;

namespace MailSystem
{
    internal class Program
    {
        private static MailManager _m;
        internal static void Main()
        {
            var mailManager = new MailManager();

            // connecting to the MailArrived event
            mailManager.MailArrived += Handler;
            
            mailManager.SimulateMailArrived();

            // Creating a new System.Threading.TimerCallback delegate object
            var timerCallback = new TimerCallback(TimerTask);

            // Saving the object globally
            SetMailManager(mailManager);

            // Creating a new System.Threading.Timer object
            using (new Timer(timerCallback, null, 1000, 1000))
            {
                Thread.Sleep(10000);
            }

            // Alternatively: Implementing the timer callback using a lambda expression:
            // var timer = new Timer(o => mailManager.SimulateMailArrived(), null, 1000, 1000);
        }

        private static void Handler(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine("New Mail has been arrived:");
            Console.WriteLine($"Title = {e.Title}, Body = {e.Body}");
            Console.WriteLine();
        }

        private static void TimerTask(object o)
        {
            _m.SimulateMailArrived();
        }

        private static void SetMailManager(MailManager m2)
        {
            _m = m2;
        }
    }
}
