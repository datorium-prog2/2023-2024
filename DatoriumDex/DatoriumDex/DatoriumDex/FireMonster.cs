namespace DatoriumDex
{
    public class FireMonster : Monster
    {

        public FireMonster() {
            MonsterType = MonsterType.Fire;
            Health = 100;
            BasicAttack = 10;
        }

        public override void GetDamaged(MonsterType monsterType, int damage)
        {
            if (monsterType == MonsterType.Grass)
            {
                Health = Health - damage / 2;
                Console.WriteLine("tas bija loti neefektivi");

                return;
            }
            base.GetDamaged(monsterType, damage);
        }
    }
}
