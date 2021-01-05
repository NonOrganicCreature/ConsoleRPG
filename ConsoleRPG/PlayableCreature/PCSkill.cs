using System;

namespace ConsoleRPG.PlayableCreature
{
    public class PCSkill
    {
        private long _id;
        private string _name;
        private Action<PC> _skillAffect;

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Action<PC> SkillAffect
        {
            get => _skillAffect;
            set => _skillAffect = value;
        }

        public PCSkill(long id, string name, Action<PC> skillAffect)
        {
            _id = id;
            _name = name;
            _skillAffect = skillAffect;
        }
    }
}