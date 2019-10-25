using System.Collections.Generic;
using OmegaGraf.Compose.Config.Prometheus;
using OmegaGraf.Compose.Config.Telegraf;

namespace OmegaGraf.Compose.MetaData
{
    public static class Example
    {
        public static Input<Prometheus> Prometheus = new Input<Prometheus>()
        {
            BuildConfiguration = new BuildConfiguration()
            {
                Image = "prom/prometheus",
                Tag   = "latest",
                Ports = new List<int>(){
                    9090
                },
                Binds = new Dictionary<string, string>()
                {
                    {
                        "C:/docker/prometheus/config", "/etc/prometheus"
                    },
                    {
                        "C:/docker/prometheus/data",   "/prometheus"
                    }
                },
                Parameters = new List<string>()
                {
                    "--config.file=/etc/prometheus/prometheus.yml",
                    "--storage.tsdb.path=/prometheus"
                }
            },
            Config = new Config<Prometheus>[]
            {
                new Config<Prometheus>()
                {
                    Path = "C:/docker/prometheus/config/prometheus.yml",
                    Data = new Prometheus()
                    {
                        Global = new Global()
                        {
                            ScrapeInterval = "5s"
                        },
                        ScrapeConfigs = new List<ScrapeConfigs>()
                        {
                            new ScrapeConfigs()
                            {
                                JobName        = "prometheus",
                                ScrapeInterval = "5s",
                                StaticConfigs  = new List<StaticConfigs>()
                                {
                                    new StaticConfigs()
                                    {
                                        Targets = new string[] {
                                            "localhost:9090"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };

        public static Input<Telegraf> Telegraf = new Input<Telegraf>()
        {
            BuildConfiguration = new BuildConfiguration()
            {
                Image = "telegraf",
                Tag   = "latest",
                Ports = new List<int>(){
                    8125, 8092, 8094
                },
                Binds = new Dictionary<string, string>()
                {
                    {
                        "C:/docker/telegraf", "/etc/telegraf"
                    }
                }
            },
            Config = new Config<Telegraf>[]
            {
                new Config<Telegraf>()
                {
                    Path = "C:/docker/telegraf/telegraf.conf",
                    Data = new Telegraf(){
                        Inputs = new Inputs()
                        {
                            VSphere = new List<VSphere>()
                            {
                                new VSphere()
                                {
                                    VCenters = new List<string>(){
                                        "localhost:10000"
                                    },
                                    Username = "test",
                                    Password = "password"
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}