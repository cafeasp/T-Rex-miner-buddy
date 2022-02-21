using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleT_Rex_Miner_01
{
    
    public class ActivePool
    {
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("dns_https_server")]
        public string DnsHttpsServer { get; set; }

        [JsonProperty("last_submit_ts")]
        public int LastSubmitTs { get; set; }

        [JsonProperty("ping")]
        public int Ping { get; set; }

        [JsonProperty("proxy")]
        public string Proxy { get; set; }

        [JsonProperty("retries")]
        public int Retries { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("worker")]
        public string Worker { get; set; }
    }

    public class Shares
    {
        [JsonProperty("accepted_count")]
        public int AcceptedCount { get; set; }

        [JsonProperty("invalid_count")]
        public int InvalidCount { get; set; }

        [JsonProperty("last_share_diff")]
        public double LastShareDiff { get; set; }

        [JsonProperty("last_share_submit_ts")]
        public int LastShareSubmitTs { get; set; }

        [JsonProperty("max_share_diff")]
        public double MaxShareDiff { get; set; }

        [JsonProperty("max_share_submit_ts")]
        public int MaxShareSubmitTs { get; set; }

        [JsonProperty("rejected_count")]
        public int RejectedCount { get; set; }

        [JsonProperty("solved_count")]
        public int SolvedCount { get; set; }
    }

    public class Gpu
    {
        [JsonProperty("cclock")]
        public int Cclock { get; set; }

        [JsonProperty("dag_build_mode")]
        public int DagBuildMode { get; set; }

        [JsonProperty("device_id")]
        public int DeviceId { get; set; }

        [JsonProperty("efficiency")]
        public string Efficiency { get; set; }

        [JsonProperty("fan_speed")]
        public int FanSpeed { get; set; }

        [JsonProperty("gpu_id")]
        public int GpuId { get; set; }

        [JsonProperty("gpu_user_id")]
        public int GpuUserId { get; set; }

        [JsonProperty("hashrate")]
        public int Hashrate { get; set; }

        [JsonProperty("hashrate_day")]
        public int HashrateDay { get; set; }

        [JsonProperty("hashrate_hour")]
        public int HashrateHour { get; set; }

        [JsonProperty("hashrate_instant")]
        public int HashrateInstant { get; set; }

        [JsonProperty("hashrate_minute")]
        public int HashrateMinute { get; set; }

        [JsonProperty("intensity")]
        public double Intensity { get; set; }

        [JsonProperty("lhr_tune")]
        public double LhrTune { get; set; }

        [JsonProperty("low_load")]
        public bool LowLoad { get; set; }

        [JsonProperty("mclock")]
        public int Mclock { get; set; }

        [JsonProperty("mtweak")]
        public int Mtweak { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paused")]
        public bool Paused { get; set; }

        [JsonProperty("pci_bus")]
        public int PciBus { get; set; }

        [JsonProperty("pci_domain")]
        public int PciDomain { get; set; }

        [JsonProperty("pci_id")]
        public int PciId { get; set; }

        [JsonProperty("potentially_unstable")]
        public bool PotentiallyUnstable { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("power_avr")]
        public int PowerAvr { get; set; }

        [JsonProperty("shares")]
        public Shares Shares { get; set; }

        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }
    }

    public class DownloadStatus
    {
        [JsonProperty("downloaded_bytes")]
        public int DownloadedBytes { get; set; }

        [JsonProperty("last_error")]
        public string LastError { get; set; }

        [JsonProperty("time_elapsed_sec")]
        public double TimeElapsedSec { get; set; }

        [JsonProperty("total_bytes")]
        public int TotalBytes { get; set; }

        [JsonProperty("update_in_progress")]
        public bool UpdateInProgress { get; set; }

        [JsonProperty("update_state")]
        public string UpdateState { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Updates
    {
        [JsonProperty("download_status")]
        public DownloadStatus DownloadStatus { get; set; }

        [JsonProperty("md5sum")]
        public string Md5sum { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("notes_full")]
        public string NotesFull { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class WatchdogStat
    {
        [JsonProperty("built_in")]
        public bool BuiltIn { get; set; }

        [JsonProperty("startup_ts")]
        public int StartupTs { get; set; }

        [JsonProperty("total_restarts")]
        public int TotalRestarts { get; set; }

        [JsonProperty("uptime")]
        public int Uptime { get; set; }

        [JsonProperty("wd_version")]
        public string WdVersion { get; set; }
    }

    public class Root
    {
        [JsonProperty("accepted_count")]
        public int AcceptedCount { get; set; }

        [JsonProperty("active_pool")]
        public ActivePool ActivePool { get; set; }

        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("api")]
        public string Api { get; set; }

        [JsonProperty("build_date")]
        public string BuildDate { get; set; }

        [JsonProperty("coin")]
        public string Coin { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("driver")]
        public string Driver { get; set; }

        [JsonProperty("gpu_total")]
        public int GpuTotal { get; set; }

        [JsonProperty("gpus")]
        public List<Gpu> Gpus { get; set; }

        [JsonProperty("hashrate")]
        public int Hashrate { get; set; }

        [JsonProperty("hashrate_day")]
        public int HashrateDay { get; set; }

        [JsonProperty("hashrate_hour")]
        public int HashrateHour { get; set; }

        [JsonProperty("hashrate_minute")]
        public int HashrateMinute { get; set; }

        [JsonProperty("invalid_count")]
        public int InvalidCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("paused")]
        public bool Paused { get; set; }

        [JsonProperty("rejected_count")]
        public int RejectedCount { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("sharerate")]
        public double Sharerate { get; set; }

        [JsonProperty("sharerate_average")]
        public double SharerateAverage { get; set; }

        [JsonProperty("solved_count")]
        public int SolvedCount { get; set; }

        [JsonProperty("success")]
        public int Success { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("updates")]
        public Updates Updates { get; set; }

        [JsonProperty("uptime")]
        public int Uptime { get; set; }

        [JsonProperty("validate_shares")]
        public bool ValidateShares { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("watchdog_stat")]
        public WatchdogStat WatchdogStat { get; set; }
    }


}
