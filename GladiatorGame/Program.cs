using System;

namespace GladiatorArena
{
	/*
	 GLADIATOR CLASS WITH FUNCTION FOR ATTACK
	 USES RNG SYSTEM WITH RANDOM
	 */
	class Gladiator
	{
		static Random rnd = new Random();
		public string Name;
		public int Health;
		public int Damage;

		public Gladiator(string incomingName, int incomingHealth, int incomingDamage)
		{
			Name = incomingName;
			Health = incomingHealth;
			Damage = incomingDamage;
		}
		public void Attack(Gladiator enemy)
		{
			int hitvalue = rnd.Next(Damage - 2, Damage + 2);
			int chance = rnd.Next(1, 101);
			
			if (chance > 0 && chance < 15)
			{
				hitvalue = 0;
				Console.WriteLine($"{Name} misses!");
			}
			else if (chance > 95 && chance <= 100)
			{
				hitvalue *= 2;
				enemy.Health -= hitvalue;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Critical hit!\n{Name} hits {enemy.Name} for {hitvalue} damage!");
			}
			else
			{
				enemy.Health -= hitvalue;
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine($"{Name} hits {enemy.Name} for {hitvalue} damage!");
			}
		}

	}
	
	/*
	 MAIN GAME FUNCTION
	 */
	class Program
	{
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
			Gladiator hero = new Gladiator(userName, 100, 10);
			Gladiator enemy = new Gladiator("Maximus", 100,10);
			
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
					Console.WriteLine("You have been defeated... Game Over.");
					break; 
				}
				
			}
		}
	}
};
