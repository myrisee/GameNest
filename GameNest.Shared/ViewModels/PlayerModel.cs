using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Shared.ViewModels
{
    public class PlayerModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public int Coin { get; set; }
        public int Cash { get; set; }
        public LoadoutModel? Loadout { get; set; }
        public List<ItemInstanceModel> Items { get; set; }
    }
}
