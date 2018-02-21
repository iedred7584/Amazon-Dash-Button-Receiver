using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace Amazon_Dash_Button_Receiver
{
    class Program
    {
        private static string IP = "Amazon Dash Button の IPアドレス";
        private static bool flag = true;
        private static Ping ping = new Ping();
        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH: mm:ss")}|Amazon Dash Button Reciever Start.");
            while (true)
            {
                try
                {
                    PingReply reply = ping.Send(IP, 500);
                    if (reply.Status == IPStatus.Success)
                    {
                        // 一回の押下で複数回動作しないようにするフラグ
                        if (flag)
                        {
                            flag = false;
                            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")}|Pushed.");
                        }
                    }
                    else flag = true;
                    Thread.Sleep(300);
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
        }
    }
}