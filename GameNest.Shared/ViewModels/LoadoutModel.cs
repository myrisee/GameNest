using MessagePack;

namespace GameNest.Shared.ViewModels
{
    [MessagePackObject(true)]
    public class LoadoutModel
    {
        public Guid Id { get; set; }
        public ItemInstanceModel Main { get; set; }
        public ItemInstanceModel Secondary { get; set; }
        public ItemInstanceModel Helmet { get; set; }
        public ItemInstanceModel Chest { get; set; }
    }
}
