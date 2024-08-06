using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Shared.ViewModels
{
    public class LoadoutModel
    {
        public Guid Id { get; set; }
        public PlayerModel Player { get; set; }
        public ItemInstanceModel Main { get; set; }
    }
}
