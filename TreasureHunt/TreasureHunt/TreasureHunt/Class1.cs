namespace TreasureHunt
{
    public class PickableObjects
    {
        public char Symbol { get; set; } // Simbols uz kartes
        public string Name { get; set; }

        public virtual void ActionOnPickup()
        {

        }
    }

    public class Treasure : PickableObjects
    {
        public int Points { get; set; }
        public override void ActionOnPickup()
        {
            Console.WriteLine($"Tu atradi {Name}, saņēmi {Points} dālderus! TESTESTETEST");
        }
    }

    public class Trap : PickableObjects
    {
        public int Damage { get; set; }

        public override void ActionOnPickup()
        {
            Console.WriteLine($"Tu iekāpi {Name}, tev tika atņemtas {Damage} dzīvības!");
        }
    }


    public class Mob
    {
        public string Name { get; set; }
        public Boolean IsNPC { get; set; }
    }

    public class Enemy : Mob
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int AttackSpeed { get; set; }
        public int SpecialAttackCooldown { get; set; }
        public int ProjectileSpeed { get; set; }
        public virtual void SpecialAttack()
        {

        }
    }

    public class Goblin : Enemy
    {
        public Goblin()
        {
            Health = 100;
            Damage = 100;
            AttackSpeed = 100;
        }
        public override void SpecialAttack()
        {
            //Goblins palecas un griežas uz riņķi
        }
    }

    public class Bebrs : Enemy
    {
        public override void SpecialAttack()
        {
            //Juggernauts ierokas zemē
        }
    }
}
