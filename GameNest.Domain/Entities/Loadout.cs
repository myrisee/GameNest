using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Domain.Entities
{
    public class Loadout
    {
        public Guid Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual ItemInstance Main { get; set; }
    }
}
