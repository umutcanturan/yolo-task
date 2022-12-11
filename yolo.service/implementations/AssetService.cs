using GraphQL;
using GraphQL.Client.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.common.models;
using yolo.service.interfaces;

namespace yolo.service.implementations
{
    public class AssetService : IAssetService
    {
        private readonly IGraphQLClient _graphQLClient;
        public AssetService(IGraphQLClient graphQLClient) 
        { 
            _graphQLClient= graphQLClient;
        }

        public async Task<IEnumerable<Asset>> GetAssets(int limit = 20, int offset = 0)
        {
            var list = new List<Asset>();
            var query = new GraphQLRequest
            {
                
                Query = "query PageAssets {  assets(page: {    skip: "+ offset +",    limit: "+ limit +"  }, sort: [{marketCapRank: ASC}]) {    assetName    assetSymbol    marketCap  }}",
                Variables = null,
                OperationName= "PageAssets",
            };
            var response = await _graphQLClient.SendQueryAsync<PageAsset>(query);
            list = response.Data.Assets;
            return list;
        }
    }
}
