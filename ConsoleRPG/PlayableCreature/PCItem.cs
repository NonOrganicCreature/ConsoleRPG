namespace ConsoleRPG.PlayableCreature
{
    public class PCItem
    {
        private PCAttackType _itemType;
        private PCItemStats _itemStats;

        public PCAttackType ItemType
        {
            get => _itemType;
            set => _itemType = value;
        }

        public PCItemStats ItemStats
        {
            get => _itemStats;
            set => _itemStats = value;
        }

        public PCItem(PCAttackType itemType, PCItemStats itemStats)
        {
            _itemType = itemType;
            _itemStats = itemStats;
        }
    }
}