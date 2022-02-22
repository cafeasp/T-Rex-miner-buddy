using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleT_Rex_Miner_01
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Pool
    {
        public string pass { get; set; }
        public string url { get; set; }
        public string user { get; set; }
        public string worker { get; set; }
    }

    public class Config
    {
        public bool ab_indexing { get; set; }
        public string algo { get; set; }
        public string api_bind_http { get; set; }
        public bool api_https { get; set; }
        public string api_key { get; set; }
        public bool api_read_only { get; set; }
        public bool autoupdate { get; set; }
        public int back_to_main_pool_sec { get; set; }
        public string cclock { get; set; }
        public string coin { get; set; }
        public int cpu_priority { get; set; }
        public string cv { get; set; }
        public string dag_build_mode { get; set; }
        public string dataset_mode { get; set; }
        public string devices { get; set; }
        public string dns_https_server { get; set; }
        public bool exit_on_connection_lost { get; set; }
        public bool exit_on_cuda_error { get; set; }
        public int exit_on_high_power { get; set; }
        public string extra_dag_epoch { get; set; }
        public string fan { get; set; }
        public int gpu_init_mode { get; set; }
        public int gpu_report_interval { get; set; }
        public int gpu_report_interval_s { get; set; }
        public int hashrate_avr { get; set; }
        public bool hide_date { get; set; }
        public string intensity { get; set; }
        public bool keep_gpu_busy { get; set; }
        public string kernel { get; set; }
        public string lhr_algo { get; set; }
        public string lhr_autotune_interval { get; set; }
        public string lhr_autotune_mode { get; set; }
        public string lhr_autotune_step_size { get; set; }
        public string lhr_coin { get; set; }
        public bool lhr_low_power { get; set; }
        public string lhr_tune { get; set; }
        public string lock_cclock { get; set; }
        public string lock_cv { get; set; }
        public string log_path { get; set; }
        public string low_load { get; set; }
        public string mclock { get; set; }
        public object monitoring_page { get; set; }
        public string mt { get; set; }
        public bool no_color { get; set; }
        public bool no_hashrate_report { get; set; }
        public bool no_new_block_info { get; set; }
        public bool no_nvml { get; set; }
        public bool no_sni { get; set; }
        public bool no_strict_ssl { get; set; }
        public bool no_watchdog { get; set; }
        public string pl { get; set; }
        public List<Pool> pools { get; set; }
        public List<object> pools2 { get; set; }
        public bool protocol_dump { get; set; }
        public string proxy { get; set; }
        public string pstate { get; set; }
        public int reconnect_on_fail_shares { get; set; }
        public int retries { get; set; }
        public int retry_pause { get; set; }
        public string script_crash { get; set; }
        public string script_epoch_change { get; set; }
        public string script_exit { get; set; }
        public string script_low_hash { get; set; }
        public string script_start { get; set; }
        public bool send_stales { get; set; }
        public int sharerate_avr { get; set; }
        public string temperature_color { get; set; }
        public string temperature_color_mem { get; set; }
        public int temperature_limit { get; set; }
        public int temperature_start { get; set; }
        public int time_limit { get; set; }
        public int timeout { get; set; }
        public bool validate_shares { get; set; }
        public string watchdog_exit_mode { get; set; }
        public string worker { get; set; }
    }

    public class ShutdownResponse
    {
        public Config config { get; set; }
        public int success { get; set; }
    }


}
