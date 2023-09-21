using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace PrimusSignalRHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string url = "http://localhost:8080";
            string url = "http://207.244.253.16:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}:{message}");
            Clients.All.addMessage(message);
        }
    }
}