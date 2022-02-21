using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace consoleT_Rex_Miner_01
{
    class Program
    {
        public static TRexMinerHelper p { get; set; }
        static void Main(string[] args)
        {
                      
            if (GetProcess()>0)
            {

                double minHashRate = appConfig.Default.Min_Hashrate;
                int seconds = appConfig.Default.Check_Every_Sec;

                Console.WriteLine("Check temp every (seconds):{0}", seconds);
                Console.WriteLine();

                p = new TRexMinerHelper("http://127.0.0.1:4067", "summary");

                Console.WriteLine("#### Min hashrate {0} - restart if lower - ####",minHashRate);
                // loop here forever
                while (true)
                {
                    Console.WriteLine("------- {0} -------", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss:tt"));
                    p.GetSummary(minHashRate);

                    Thread.Sleep(seconds);

                }
            }
            else
            {
                Console.WriteLine("!!!! t-rex is not running !!!");
            }


            
            
        }
        static int GetProcess()
        {
            var process = Process.GetProcesses().Where(c=>c.ProcessName.StartsWith("t-rex"));
           
            return process.Count();
        }
        



    }
}
