using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.common.models
{
    public class Asset
    {
        public string AssetName { get; set; }
        public string AssetSymbol { get; set; }
        public long? MarketCap { get; set; }
    }
}
