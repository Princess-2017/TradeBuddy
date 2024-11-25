using Microsoft.Extensions.Configuration;
using Nest;


namespace TradeBuddy.Business.Application.Service
{
    public class ElasticsearchService
    {
        private readonly IElasticClient _client;

        public ElasticsearchService(IConfiguration configuration)
        {
            var settings = new ConnectionSettings(new Uri(configuration["Elasticsearch:Uri"]))
                .DefaultIndex("businesses");

            _client = new ElasticClient(settings);
        }

        public IElasticClient GetClient() => _client;
    }
}
