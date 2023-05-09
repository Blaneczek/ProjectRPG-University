using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Heroes;

namespace ProjectRPG.Game
{
    public class Player 
    { 
        public Hero<Weapon,Armor> PlayerHero { get; set; }
        public Player() { }

        public void ChooseHero()
        {
            Console.WriteLine("Wybierz imie bohatera: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Wybierz klasę bohatera: \n1.Warrior \n2.Mage \n3.Ranger");
            string heroClass = Console.ReadLine();
            if (heroClass == "1")
            {
                Sword sword1 = new Sword("Miecz", "Legendarny", "Kozak majonez", 100);
                HeavyArmor armor1 = new HeavyArmor("Zbroja", "Legendarny", "Kozak majonez", 20, 20);
                PlayerHero = new Warrior(userName, sword1, armor1);
            }

            Console.WriteLine(PlayerHero.Attack);
        }
    }
}
