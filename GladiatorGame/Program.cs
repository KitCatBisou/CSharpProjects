using System;

namespace GladiatorArena
{
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
				Console.WriteLine($"Critical hit!\n{Name} hits {enemy.Name} for {hitvalue} damage!");
			}
			else
			{
				enemy.Health -= hitvalue;
				Console.WriteLine($"{Name} hits {enemy.Name} for {hitvalue} damage!");
			}
		}

	}
	
	class Program
	{
		static void Main(string[] args)
		{
			Gladiator hero = new Gladiator("Cratus", 100, 10);
			Gladiator enemy = new Gladiator("Maximus", 100, 8);

			while (hero.Health > 0 && enemy.Health > 0)
			{
				hero.Attack(enemy);

				if (enemy.Health <= 0)
				{
					Console.WriteLine("Victory!");
					break;
				}
				enemy.Attack(hero);
				
				
			}
			Console.WriteLine("Game over!");
		}
	}
};
