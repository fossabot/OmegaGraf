# OmegaGraf - Compose

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=OmegaGraf_Compose&metric=alert_status)](https://sonarcloud.io/dashboard?id=OmegaGraf_Compose)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=OmegaGraf_Compose&metric=coverage)](https://sonarcloud.io/dashboard?id=OmegaGraf_Compose)

This web service builds and configures docker containers.

Currently supported containers:

- Prometheus
- Telegraf
- Grafana
- [VCSim](https://github.com/OmegaGraf/docker-vcsim)

Requests tend to consist of two parts, a `BuildConfiguration` and a `Config`.

`BuildConfiguration` sets container parameters, such as name, image, bindings, etc.
`Config` is a combination of data to serialize, and the path where the data should be written.
There are a few additional calls for configuration, and they do not follow any standards.

```json
{
  "BuildConfiguration": {
    "Image": "macropower/name",
    "Tag": "latest",
    "Ports": [],
    "Binds": {},
    "Parameters": []
  },
  "Config": [
    {
      "Path": "C:/docker/...",
      "Data": {}
    }
  ]
}
```

**Comprehensive documentation can be found at `/swagger-ui`.**
