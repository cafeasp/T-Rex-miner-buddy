using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace consoleT_Rex_Miner_01
{
    public class TRexMinerHelper
    {
        public string BaseUrl { get; set; }
        public string Resource { get; set; }
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }
        public int RebootFlag { get; set; }


        public TRexMinerHelper(string baseUrl,string resource)
        {
            BaseUrl = baseUrl;
            Resource = resource;

            Client = new RestClient(BaseUrl);

        }
        public async void GetSummary(double minHashRate)
        {
            Request = new RestRequest(Resource,Method.Get);

            var response = await Client.ExecuteAsync(Request);
            //Console.WriteLine(response.Content);
            if (response.IsSuccessful)
            {
                Root root = JsonConvert.DeserializeObject<Root>(response.Content);

                foreach (Gpu gpu in root.Gpus)
                {
                    Double dc = Math.Round((Double)(gpu.Hashrate / 1000000.00), 2);

                    string readOut = string.Format("Fand Speed:{0} Power:{1}",
                        gpu.FanSpeed, gpu.Power);

                    Console.WriteLine(readOut);

                    readOut = string.Format("Hash Rate:{0} MH/s Temp:{1}", dc, gpu.Temperature);

                    Console.WriteLine(readOut);

                    if (dc < minHashRate)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(dc);

                        Console.WriteLine(string.Format("Low hashrate {0}", (char)31));
                        Console.ResetColor();
                        CloseAndReStartTRex();
                        
                        Console.WriteLine();
                        if(RebootFlag >= appConfig.Default.RebootAfter)
                        {
                            Reboot();
                        }
                        RebootFlag++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format("[ OK ] {0}", (char)2));
                        Console.ResetColor();
                        Console.WriteLine();
                    }

                }
            }
            else
            {
                Console.WriteLine("API Error");
            }

        }
        private void Reboot()
        {
            var cmd = new System.Diagnostics.ProcessStartInfo("shutdown.exe", "-r -t 0");
            cmd.CreateNoWindow = true;
            cmd.UseShellExecute = false;
            cmd.ErrorDialog = false;
            System.Diagnostics.Process.Start(cmd);
        }

        public void Test()
        {
            Console.WriteLine("TEST");
        }

        private void CloseAndReStartTRex()
        {
            var process = Process.GetProcessesByName("t-rex")[0];

            var path = process.MainModule.FileName;

            process.Kill();

            Console.WriteLine("Closing t-rex app");
            Console.WriteLine("");

            Process.Start(path);

            Console.WriteLine("Starting t-rex app");


        }

    }
}
