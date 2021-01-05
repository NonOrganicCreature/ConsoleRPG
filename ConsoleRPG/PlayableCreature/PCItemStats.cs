namespace ConsoleRPG.PlayableCreature
{
    public class PCItemStats
    {
        private int _attack;

        public int Attack
        {
            get => _attack;
            set => _attack = value;
        }

        public PCItemStats(int attack)
        {
            _attack = attack;
        }
    }
}