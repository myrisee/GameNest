namespace GameNest.Domain.Entities
{
    public class Loadout
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public Guid? MainId { get; set; }
        public virtual ItemInstance? Main { get; set; }
        public Guid? SecondaryId { get; set; }
        public virtual ItemInstance? Secondary { get; set; }
        public Guid? HelmetId { get; set; }
        public virtual ItemInstance? Helmet { get; set; }
        public Guid? ChestId { get; set; }
        public virtual ItemInstance? Chest { get; set; }
    }
}
