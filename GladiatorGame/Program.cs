/*
 This is an auto battle sim about gladiator fights
 */

/*
 TODO:
 -Add more weapons and armor
 -implement the attack and defense bonuses on the gameplay
 -At the end of each fight player gets a choice between an armor or a weapon
 -maybe big lists with rng percentages for each item?
 -fighters get stronger each level
 */

using System;

namespace GladiatorArena
{
	/*
	 Weapon and Armor classes and constructors
	 */

	class Weapon
	{
		public string Name;
		public int DamageBonus;

		public Weapon(string name, int damageBonus)
		{
			Name = name;
			DamageBonus = damageBonus;
		}
	}

	class Armor
	{
		public string Name;
		public int DefenseBonus;

		public Armor(string name, int defenseBonus)
		{
			Name = name;
			DefenseBonus = defenseBonus;
		}
	}
	
	
	/*
	 GLADIATOR CLASS WITH FUNCTION FOR ATTACK
	 USES RNG SYSTEM
	 */
	
	class Gladiator
	{
		static Random rnd = new Random();
		public string Name;
		public int Health;
		public int Damage;
		public int Defense;
		
		
		//Gladiator Constructor
		public Gladiator(string incomingName, int incomingHealth, int incomingDamage, int incomingDefense)
		{
			Name = incomingName;
			Health = incomingHealth;
			Damage = incomingDamage;
			Defense = incomingDefense;
		}
		
		public void Attack(Gladiator enemy)
		{
			int hitvalue = rnd.Next(Damage - 2, Damage + 2);
			int chance = rnd.Next(1, 101);
			
			if (chance > 0 && chance < 15)
			{
				Console.WriteLine($"{Name} misses!");
			}
			else if (chance > 95 && chance <= 100)
			{
				hitvalue *= 2;
				enemy.Health = enemy.Health - (hitvalue - Defense);
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Critical hit!\n{Name} hits {enemy.Name} for {hitvalue} damage!");
			}
			else
			{
				enemy.Health = enemy.Health - (hitvalue - Defense);
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine($"{Name} hits {enemy.Name} for {hitvalue} damage!");
			}
		}

	}
	
	
	/*
	 MAIN GAME CLASS
	 */
	
	class Program
	{
		
		/*
	 HELPER METHODS TO BUILD WEAPONS AND ARMOR LISTS
	 */
	
		static List<Weapon> InitializeWeapons()
		{
			List<Weapon> weapons = new List<Weapon>();
			
			weapons.Add(new Weapon("Wooden Club", 1));
			weapons.Add(new Weapon("Iron Dagger", 2));
			weapons.Add(new Weapon("Iron Sickle", 3));
			weapons.Add(new Weapon("Spiked Club", 4));
			weapons.Add(new Weapon("Rusty Sword", 5));
			weapons.Add(new Weapon("Iron Spear", 6));
			weapons.Add(new Weapon("Iron Shortsword", 7));
			weapons.Add(new Weapon("Steel Shortsword", 8));
			weapons.Add(new Weapon("Steel War Axe", 9));
			weapons.Add(new Weapon("Ebony Dagger", 10));
			weapons.Add(new Weapon("Steel Longsword", 11));
			weapons.Add(new Weapon("Claymore", 12));
			weapons.Add(new Weapon("Eastern Sword", 13));
			weapons.Add(new Weapon("Dwarven Battle Axe", 14));
			weapons.Add(new Weapon("Ebony Claymore",15));
			
			return weapons;
		}

		static List<Armor> InitializeArmor()
		{
			List<Armor> armors = new List<Armor>();
			
			armors.Add(new Armor("Ragged Cloth", 1));
			armors.Add(new Armor("Leather Armor", 2));
			armors.Add(new Armor("Nordic Bearskin Armor", 3));
			armors.Add(new Armor("Chain Armor", 3));
			armors.Add(new Armor("Iron Armor", 4));
			armors.Add(new Armor("Imperial Leather Armor", 5));
			armors.Add(new Armor("Steel Armor", 6));
			armors.Add(new Armor("Nordic Trollbone Armor", 7));
			armors.Add(new Armor("Imperial Silver Armor", 8));
			armors.Add(new Armor("Imperial Templar Knight Armor", 9));
			armors.Add(new Armor("Dwarven Armor", 10));
			armors.Add(new Armor("Ebony Armor", 11));

			return armors;
		}
		
		
		/*
		 DISPLAY HEALTH FUNCTION
		 */
		static void DrawHealth(Gladiator g1, Gladiator g2)
		{
			if (g1.Health < 0)
			{
				g1.Health = 0;
			}

			if (g2.Health < 0)
			{
				g2.Health = 0;
			}
			Console.WriteLine($"--- STATUS ---");
			Console.WriteLine($"{g1.Name}: {g1.Health} HP");
			Console.WriteLine($"{g2.Name}: {g2.Health} HP");
			Console.WriteLine("--------------");
		}
		static void Main(string[] args)
		{
			// STARTING CODE TO NAME CHARACTER
			
			Console.Title = "Gladiator Arena";
			Console.WriteLine("Name your fighter: ");
			string userName = Console.ReadLine();
			Gladiator hero = new Gladiator(userName, 100, 10, 0);
			Gladiator enemy = new Gladiator("Maximus", 100,10, 0);
			
			//GAME BEGINS
			
			Console.WriteLine("--------------\nLet the game begin:");

			while (hero.Health > 0 && enemy.Health > 0)
			{
				// PLAYER TURN
				hero.Attack(enemy);
				DrawHealth(hero, enemy);

				if (enemy.Health <= 0)
				{
					Console.WriteLine("Victory!");
					break;
				}
				
				System.Threading.Thread.Sleep(1000);
				
				// ENEMY TURN
				enemy.Attack(hero);
				DrawHealth(hero, enemy);
				System.Threading.Thread.Sleep(1000);
				
				if (hero.Health <= 0)
				{
					Console.WriteLine("You have been vanquished in the arena.");
					break; 
				}
			}
		}
	}
};
