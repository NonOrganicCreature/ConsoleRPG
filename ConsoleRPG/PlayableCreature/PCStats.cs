namespace ConsoleRPG.PlayableCreature
{
    public abstract class PCStats
    {
        private int _hp;
        private int _mana;
        private int _stamina;

        private int _meleeDamage;
        private int _mageDamage;
        private int _rangeDamage;

        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }

        public int Mana
        {
            get => _mana;
            set => _mana = value;
        }

        public int Stamina
        {
            get => _stamina;
            set => _stamina = value;
        }

        public int MeleeDamage
        {
            get => _meleeDamage;
            set => _meleeDamage = value;
        }

        public int MageDamage
        {
            get => _mageDamage;
            set => _mageDamage = value;
        }

        public int RangeDamage
        {
            get => _rangeDamage;
            set => _rangeDamage = value;
        }

        protected PCStats(int hp, int mana, int stamina, int meleeDamage, int mageDamage, int rangeDamage)
        {
            _hp = hp;
            _mana = mana;
            _stamina = stamina;
            _meleeDamage = meleeDamage;
            _mageDamage = mageDamage;
            _rangeDamage = rangeDamage;
        }
    }
}