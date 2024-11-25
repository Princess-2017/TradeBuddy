using Microsoft.Extensions.Configuration;
using Nest;

public static class ElasticsearchClientFactory
{
    public static IElasticClient Create(IConfiguration configuration)
    {
        // خواندن تنظیمات از appsettings.json
        var uri = configuration["Elasticsearch:Uri"];
        var defaultIndex = configuration["Elasticsearch:DefaultIndex"];

        if (string.IsNullOrEmpty(uri))
        {
            throw new Exception("Elasticsearch Uri is not configured properly.");
        }

        // تنظیمات اتصال به Elasticsearch
        var settings = new ConnectionSettings(new Uri(uri))
            .DefaultIndex(defaultIndex);

        return new ElasticClient(settings);
    }
}
