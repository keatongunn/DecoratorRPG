using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new PlayerOne();
            Console.WriteLine("Press 1 for Burn, Press 2 for Lightning, Press 3 for Freeze");

            int num = int.Parse(Console.ReadLine());
            if(num == 1)
            {
                player = new AddOnBurnAbility(player);
                Console.WriteLine(player.WeaponAbility());
            }
            if(num == 2)
            {
                player = new AddOnLightningAbility(player);
                Console.WriteLine(player.WeaponAbility());
            }
            if(num == 3)
            {
                player = new AddOnFreezeAbility(player);
                Console.WriteLine(player.WeaponAbility());
            }
            Console.ReadLine();

        }
    }

    public abstract class Player
    {
        protected string _name { get; set; }
        protected int _power { get; set; }

        protected string _weaponAbility { get; set; }

        public virtual string Name()
        {
            return _name;
        }

        public virtual int Power()
        {
            return _power;
        }

        public virtual string WeaponAbility()
        {
            return _weaponAbility;
        }
    }

    public abstract class Enemy
    {
        protected string _name { get; set; }
        protected int _power { get; set; }

        public virtual string Name()
        {
            return _name;
        }

        public virtual int Power()
        {
            return _power;
        }
    }

    public class PlayerOne : Player
    {
        public PlayerOne()
        {
            _name = "Keaton";
            _power = 10;
            _weaponAbility = "";
        }
    }

    public class Mob : Enemy
    {
        public Mob()
        {
            _name = "Grunt";
            _power = 5;
        }
    }

    public class StrongMob : Enemy
    {
        public StrongMob()
        {
            _name = "Brute";
            _power = 10;
        }
    }

    public class UnderBoss : Enemy
    {
        public UnderBoss()
        {
            _name = "MiniBoss";
            _power = 20;
        }
    }

    public class FinalBoss : Enemy
    {
        public FinalBoss()
        {
            _name = "Final Boss";
            _power = 30;
        }
    }

    public abstract class AddOnDecorator : Player
    {
        public Player Player { get; set; }
        public abstract override string Name();
        public abstract override int Power();
        public abstract override string WeaponAbility();

    }

    public class AddOnBurnAbility : AddOnDecorator
    {
        public AddOnBurnAbility(Player player)
        {
            Player = player;
        }

        public override string Name()
        {
            return Player.Name();
        }

        public override int Power()
        {
            return Player.Power() + 5;
        }

        public override string WeaponAbility()
        {
            return Player.WeaponAbility() + "Player Has been granted the Burn special ability. Add 5 points to players power. Useful againts Brutes.";

        }

    }

    public class AddOnLightningAbility : AddOnDecorator
    {
        public AddOnLightningAbility(Player player)
        {
            Player = player;
        }
        public override string Name()
        {
            return Player.Name();
        }

        public override int Power()
        {
            return Player.Power() + 15;
        }

        public override string WeaponAbility()
        {
            return Player.WeaponAbility() + "Player Has been granted the Lightning special ability. Add 15 points to players power. Useful against Mini-Bosses.";
        }

    }

    public class AddOnFreezeAbility : AddOnDecorator
    {
        public AddOnFreezeAbility(Player player)
        {
            Player = player;
        }

        public override string Name()
        {
            return Player.Name();
        }

        public override int Power()
        {
            return Player.Power() + 20;
        }

        public override string WeaponAbility()
        {
            return Player.WeaponAbility() + "Player Has been granted the Freeze special ability. Add 20 points to players power. Useful against all Bosses and the Final Boss.";
        }
    }
}
