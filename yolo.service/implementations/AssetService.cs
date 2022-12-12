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

        public async Task<IEnumerable<Asset>> FetchAllAssets()
        {
            var query = new GraphQLRequest
            {
                Query = "query PageAssets {  assets(sort: [{marketCapRank: ASC}]) {    assetName    assetSymbol    marketCap  }}",
                Variables = null,
                OperationName= "PageAssets",
            };
            //page: {    skip: "+ offset +",    limit: "+ limit +"  }
            var response = await _graphQLClient.SendQueryAsync<PageAssetQuery>(query);
            if (response.Data == null)
            {
                throw new Exception(string.Concat(response.Errors.Select(p => p.Message)));
            }
            return response.Data.Assets;
        }

        public async Task<IEnumerable<Market>> FetchMarketPrices()
        {
            int offset = 20;
            int count = 0;
            var assets = await FetchAllAssets();
            var list = new List<Market>();
            while(count < assets.Count())
            {
                int batchCount = count + offset <= assets.Count() ? offset : assets.Count() - count;
                var symbols = string.Join(",", assets.Skip(count).Take(batchCount).Select(p => "\"" + p.AssetSymbol + "\""));
                var query = new GraphQLRequest
                {
                    Query = "query price {markets(filter: {baseSymbol: {_in: [" + symbols + "]}, quoteSymbol: {_eq: \"EUR\"}, exchangeSymbol: {_eq: \"Binance\"}}) {marketSymbol ticker {lastPrice}}}",
                    Variables = null,
                    OperationName = "price"
                };
                var response = await _graphQLClient.SendQueryAsync<PriceQuery>(query);
                if(response.Data == null)
                {
                    throw new Exception(string.Concat(response.Errors.Select(p => p.Message)));
                }
                list.AddRange(response.Data.Markets);

                if(count + offset > assets.Count())
                {
                    count = assets.Count();
                }else
                {
                    count += offset;
                }
            }
            return list;
        }
    }
}
