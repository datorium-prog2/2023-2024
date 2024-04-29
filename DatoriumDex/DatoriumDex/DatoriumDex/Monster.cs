namespace DatoriumDex
{
    public class Monster
    {
        public int Health { get; set; }
        public int BasicAttack { get; set; }
        public MonsterType MonsterType { get; set; }

        public virtual void GetDamaged(MonsterType monsterType, int damage)
        {
            Health = Health - damage;
        }

        public virtual void BasicAttackMonster(Monster monster)
        {
            monster.GetDamaged(MonsterType.Basic, BasicAttack);
        }

        public virtual void SpecialAttackMonster(Monster monster)
        {
            monster.GetDamaged(MonsterType, BasicAttack);
        }
    }
}
