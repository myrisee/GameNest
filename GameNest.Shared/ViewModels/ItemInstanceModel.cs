using MessagePack;

namespace GameNest.Shared.ViewModels
{
    [MessagePackObject(true)]
    public class ItemInstanceModel
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public ItemModel Item { get; set; }
    }
}
