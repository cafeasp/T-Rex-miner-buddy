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
            string trexPwd = "somepassword123";
            string apiPwd = "bwAAAAAAAAAdfasdfasdfasdfasfasdfasfasdfasdfadfasdf";
            //t-rex --api-generate-key your_password
            //{"sid":"ueeeeeValueSomething","success":1}
            //http://127.0.0.1:4067/control?command=shutdown&sid=ueeeeeValueSomething

            //t-rex.exe -a ethash -o stratum+tcp://eth.2miners.com:2020 -u your_wallet -p rigPasword -w worker_name --api-key somepassword123
            try
            {
               trex(trexPwd);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                
            }


            Console.ReadLine();
        }
        static int GetProcess()
        {
            var process = Process.GetProcesses().Where(c=>c.ProcessName.StartsWith("t-rex"));
           
            return process.Count();
        }
        
        static void trex(string password)
        {

            if (GetProcess() > 0)
            {

                double minHashRate = appConfig.Default.Min_Hashrate;
                int seconds = appConfig.Default.Check_Every_Sec;

                Console.WriteLine("Check temp every (seconds):{0}", seconds);
                Console.WriteLine();

                p = new TRexMinerHelper("http://127.0.0.1:4067",password);

               

                Console.WriteLine("#### Min hashrate {0} - restart if lower - ####", minHashRate);
                // loop here forever
                while (true)
                {
                    Console.WriteLine("------- {0} -------", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss:tt"));

                    p.GetSummary(minHashRate,string.Format("{0}/summary",p.BaseUrl));

                    Thread.Sleep(seconds);

                }
            }
            else
            {
                Console.WriteLine("!!!! t-rex is not running !!!");
            }



        }

        static void ReStartTRex()
        {
            try
            {
                var process = Process.GetProcessesByName("t-rex")[0];

                var path = process.MainModule.FileName;

                Console.WriteLine(path);
                process.Kill();

                process.WaitForExit();

                Console.WriteLine("Closing t-rex app");
                Console.WriteLine("");
               
                Console.WriteLine("Starting t-rex app");

                Process.Start(string.Format("{0}\\VP-ETH-2miners.bat",path));

                Console.WriteLine("t-rex running...");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                //Console.ReadLine();
            }



        }
    }
}
