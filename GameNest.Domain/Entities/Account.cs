using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
        public int Coin { get; set; }
        public int Cash { get; set; }
        public Guid? LoadoutId { get; set; }
        public int? ClanId { get; set; }
        public List<ItemInstance> Items { get; set; }

        #region References
        public Loadout? Loadout { get; set; }
        public Clan? Clan { get; set; }
        #endregion
    }
}
