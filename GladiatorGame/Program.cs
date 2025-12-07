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
			//make a function for attacking an npc
		}

	}
	
	class Program
	{
		static void Main(string[] args)
		{
			
		}
	}
};
