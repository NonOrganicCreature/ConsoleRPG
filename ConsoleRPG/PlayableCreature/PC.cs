using System;
using System.Linq;

namespace ConsoleRPG.PlayableCreature
{
    public abstract class PC
    {
        private long _id;
        private string _name;
        private int _level;
        private float _exp;
        private PCStats _stats;
        private PCSkill[] _skills;
        private PCAttackType _pcAttackType;
        private PCItem _weapon;

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

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public float Exp
        {
            get => _exp;
            set => _exp = value;
        }

        public PCStats Stats
        {
            get => _stats;
            set => _stats = value;
        }

        public PCSkill[] Skills
        {
            get => _skills;
            set => _skills = value;
        }

        public PCAttackType PcAttackType
        {
            get => _pcAttackType;
            set => _pcAttackType = value;
        }

        public PCItem Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }
        
        protected PC(long id, string name, int level, float exp, PCStats stats, PCSkill[] skills)
        {
            _id = id;
            _name = name;
            _level = level;
            _exp = exp;
            _stats = stats;
            _skills = skills;
        }

        public void Attack(PC target)
        {
            target._stats.Hp -= _weapon.ItemStats.Attack;
            Console.WriteLine("{0} used attacked target with id: {1}", this._id, target._id);
        }

        public void UseSkill(PC target, int skillId)
        {
            PCSkill skillToUse = this._skills.Single(skill => skill.Id == skillId);
            skillToUse.SkillAffect(target);
            Console.WriteLine("{0} used skill with id: {1}", this._id, skillId);
        }
    }
}