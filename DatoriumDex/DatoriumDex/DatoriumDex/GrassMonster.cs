using DatoriumDex;

public class GrassMonster : Monster
{
    public GrassMonster()
    {
        MonsterType = MonsterType.Grass;
        Health = 85;
        BasicAttack = 12;
    }

    public override void GetDamaged(MonsterType monsterType, int damage)
    {
        if (monsterType == MonsterType.Fire)
        {
            Health -= (int)Math.Round(damage * 1.2); ;
            Console.WriteLine("TAS BIJA SUPER EFEKTIVS");
            return;
        }
        base.GetDamaged(monsterType, damage);
    }
}