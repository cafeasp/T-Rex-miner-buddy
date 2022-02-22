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
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }
        public int RebootFlag { get; set; }
        public string SID { get; set; }
        public string Password { get; set; }

        public TRexMinerHelper(string baseUrl,string password)
        {
            BaseUrl = baseUrl;
           
            Password = password;

            Client = new RestClient(BaseUrl);

            RebootFlag = 0;
            
        }
        
        public async Task<string> Login()
        {
            Request = new RestRequest(string.Format("{0}/login?password={1}", BaseUrl,Password),Method.Get);
            var response = await Client.ExecuteAsync(Request);
  
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);
                //SID = loginResponse.sid;
                //Console.WriteLine(SID);
            return loginResponse.sid;

        }
        private async void Shutdown()
        {
            

            try
            {
                string resource = string.Format("{0}/control?command=shutdown&sid={1}", BaseUrl, SID);
                Console.WriteLine(resource);

                var req = new RestRequest(resource, Method.Get);
                var response = await Client.ExecuteAsync(req);

                Console.WriteLine(response.Content);

                ShutdownResponse shutdownResponse = JsonConvert.DeserializeObject<ShutdownResponse>(response.Content);

                if (shutdownResponse.success == 1)
                {
                    Console.WriteLine("Shutdown OK");
                    Environment.Exit(0);
                }
            }
            catch (Exception ee)
            {

                Console.WriteLine(ee);
                Console.ReadLine();
            }

        }
        public async void GetSummary(double minHashRate,string resource)
        {
            //Console.WriteLine(resource);
            if (string.IsNullOrEmpty(SID))
            {
                SID = await Login();
            }
            

            Request = new RestRequest(resource, Method.Get);

            Request.AddParameter("sid", SID);

            var response = await Client.ExecuteAsync(Request);
            //Console.WriteLine("summary " + response.Content);
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
                        
                        Console.WriteLine();
                        if(appConfig.Default.RebootAfter == RebootFlag)
                        {
                            Console.WriteLine("Shutdown Miner");
                            Shutdown();
                           
                            //Reboot();
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


        //DO NOT USE
        private void CloseAndReStartTRex()
        {
            try
            {
                var process = Process.GetProcessesByName("t-rex")[0];

                var path = process.MainModule.FileName;

                Console.WriteLine(path);
                process.Kill();

                process.WaitForExit();

                //Console.WriteLine("Closing t-rex app");
                //Console.WriteLine("");

                //Process.Start(path);

                //Console.WriteLine("Starting t-rex app");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
           


        }

    }
}
