using MessagePack;

namespace GameNest.Shared.ViewModels
{
    [MessagePackObject(true)]
    public class LoadoutModel
    {
        public Guid Id { get; set; }
        public AccountModel Account { get; set; }
        public ItemInstanceModel Main { get; set; }
    }
}
