using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Domain.Entities
{
    public class Clan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid LeaderId { get; set; }
        public List<Account> Members { get; set; }
    }
}
