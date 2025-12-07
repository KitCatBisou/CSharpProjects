using System;

namespace GladiatorArena
{
	class Gladiator
	{
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
			enemy.Health -= Damage;
			Console.WriteLine($"{Name} hits {enemy.Name} for {Damage} damage!");
		}

	}
	
	class Program
	{
		static void Main(string[] args)
		{
			Gladiator main = new Gladiator("Cratus", 100, 10);
		}
	}
};
