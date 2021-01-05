using ConsoleRPG.PlayableCreature;

namespace ConsoleRPG.Player
{
    public class PlayerCStats : PCStats
    {
        public PlayerCStats(int hp, int mana, int stamina, int meleeDamage, int mageDamage, int rangeDamage) : 
            base(hp, mana, stamina, meleeDamage, mageDamage, rangeDamage)
        {
        }
    }
}