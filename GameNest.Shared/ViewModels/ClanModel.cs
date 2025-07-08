
using MessagePack;

namespace GameNest.Shared.ViewModels
{
    [MessagePackObject(true)]
    public class ClanModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid LeaderId { get; set; }
        public List<AccountModel> Members { get; set; }
    }
}
