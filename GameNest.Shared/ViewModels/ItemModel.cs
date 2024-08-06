using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Shared.ViewModels
{
    public class ItemModel
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Rarity { get; set; }
        public uint Level { get; set; }
        public uint CoinPrice { get; set; }
        public uint CashPrice { get; set; }
    }
}
