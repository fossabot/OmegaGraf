using NUnit.Framework;
using System;
using OmegaGraf.Compose.MetaData;

namespace OmegaGraf.Compose.Tests
{
    public class Prometheus
    {
        [Test]
        public void Deploy()
        {
            var runner = new Runner();

            var config = new Config<Config.Prometheus.Prometheus>()
            {
                Path = @"C:/docker/prometheus/config/prometheus.yml",
                Data = Example.Prometheus.Config[0].Data
            };

            var uuid = runner.AddYamlConfig(config).Build(Example.Prometheus.BuildConfiguration);

            Console.WriteLine("docker container logs " + uuid);
            Console.WriteLine("docker container inspect " + uuid);
            Console.WriteLine("docker container stop " + uuid);
            Console.WriteLine("docker container rm " + uuid);

            Assert.Pass();
        }
    }
}