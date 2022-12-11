using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.common.models;

namespace yolo.service.interfaces
{
    public interface IAssetService
    {
        public Task<IEnumerable<Asset>> FetchAllAssets();

        public Task<IEnumerable<Market>> FetchMarketPrices();
    }
}
