using ConsoleRPG.PlayableCreature;

namespace ConsoleRPG.Player
{
    public class PlayerC: PC, IConnectable
    {
        private AuthenticationData _authenticationData;
        public PlayerC(
            long id,
            string name,
            int level,
            float exp,
            PCStats stats,
            PCSkill[] skills,
            AuthenticationData authData
        ) 
        : base(id, name, level, exp, stats, skills)

        {
            _authenticationData = authData;
        }

        public bool ValidateCredentials(AuthenticationData authenticationData)
        {
            return authenticationData == _authenticationData;
        }
    }
}