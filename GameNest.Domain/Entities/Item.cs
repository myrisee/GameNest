using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Domain.Entities
{
    public class Item
    {
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; } = "Default Item";
        public string Description { get; set; } = "Default Description";
        public uint Rarity { get; set; } = 0;
        public uint Level { get; set; } = 1;
        public uint CoinPrice { get; set; } = 0;
        public uint CashPrice { get; set; } = 0;
    }
}
