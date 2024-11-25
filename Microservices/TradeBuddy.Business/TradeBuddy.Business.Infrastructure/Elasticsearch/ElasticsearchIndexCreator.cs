
using System.IO;
using System.Threading.Tasks;
using Elasticsearch.Net;
using global::Elasticsearch.Net;
using Nest;

namespace TradeBuddy.Business.Infrastructure.Elasticsearch
{

    public class ElasticsearchIndexCreator
    {
        private readonly IElasticClient _elasticClient;

        public ElasticsearchIndexCreator(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task CreateIndexIfNotExistsAsync()
        {
            const string indexName = "business-index";

            // بررسی وجود ایندکس
            var existsResponse = await _elasticClient.Indices.ExistsAsync(indexName);
            if (existsResponse.Exists)
                return;


            // مسیر فایل از دایرکتوری بیلد
            var mappingFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Elasticsearch", "business-index-mapping.json");

            // بررسی وجود فایل
            if (!File.Exists(mappingFilePath))
            {
                throw new FileNotFoundException($"Mapping file not found: {mappingFilePath}");
            }
            // خواندن محتوای فایل
            var mappingJson = await File.ReadAllTextAsync(mappingFilePath);

            // ارسال Mapping به Elasticsearch
            var response = await _elasticClient.LowLevel.Indices.CreateAsync<BytesResponse>(indexName, PostData.String(mappingJson));

            if (!response.Success)
            {
                throw new Exception($"Failed to create index: {response.DebugInformation}");
            }
        }
    }

}
