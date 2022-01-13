using System;

namespace CamelGame
{
	class Program
	{
		private static void Choices()
		{
			Console.WriteLine(" ");
			Console.WriteLine("A. Drink from your canteen.");
			Console.WriteLine("B. Ahead moderate speed.");
			Console.WriteLine("C. Ahead full speed.");
			Console.WriteLine("D. Stop and rest.");
			Console.WriteLine("E. Status check.");
			Console.WriteLine("Q. Quit.");
			Console.WriteLine(" ");
		}
		private static void DistanceTraveled(int camelMovement)
		{
			Console.WriteLine(" ");
			Console.WriteLine("You traveled " + camelMovement + " miles.");
		}
		private static void ChoiceA(ref int thirst, ref int drinks)
		{
			if (drinks > 0)
			{
				drinks -= 1;
				thirst = 0;
			}
			else Console.WriteLine("You are out of water.");
		}
		private static void ChoiceB(ref int milesTraveled, ref int thirst, ref int camelTiredness, ref int drinks, ref int nativeDistance, Random random)
		{
			int camelMovement = random.Next(5, 12);
			int nativeMovement = random.Next(7, 14);
			milesTraveled += camelMovement;
			thirst += 1;
			camelTiredness += 1;
			nativeDistance += nativeMovement;
			int oasisFound = random.Next(1, 20);
			if (oasisFound == 1)
			{
				Oasis(out thirst, out camelTiredness, out drinks);
			}
			DistanceTraveled(camelMovement);
		}
		private static void ChoiceC(ref int milesTraveled, ref int thirst, ref int camelTiredness, ref int drinks, ref int nativeDistance, Random random)
		{
			int camelMovement = random.Next(10, 20);
			int nativeMovement = random.Next(7, 14);
			int addTiredness = random.Next(1, 3);
			milesTraveled += camelMovement;
			thirst += 1;
			camelTiredness += addTiredness;
			nativeDistance += nativeMovement;
			int oasisFound = random.Next(1, 20);
			if (oasisFound == 1)
			{
				Oasis(out thirst, out camelTiredness, out drinks);
			}
			DistanceTraveled(camelMovement);
		}
		private static void ChoiceD(ref int nativeDistance, ref int camelTiredness, Random random)
		{
			Console.WriteLine("The Camel is happy");
			int nativeMovement = random.Next(7, 14);
			nativeDistance += nativeMovement;
			camelTiredness = 0;
		}
		private static void ChoiceE(int milesTraveled, int drinks, int nativeDistance)
		{
			Console.WriteLine("Miles traveled: " + milesTraveled);
			Console.WriteLine("Drinks in canteen: " + drinks);
			Console.WriteLine("The natives are " + (milesTraveled - nativeDistance) + " miles behind you.");
		}
		private static void Oasis(out int thirst, out int camelTiredness, out int drinks)
		{
			Console.WriteLine("You found an oasis!");
			Console.WriteLine("The camel is rested and your thirst and canteen are replenished.");
			thirst = 0;
			drinks = 3;
			camelTiredness = 0;
		}
		static void Main(string[] args)
		{
			int milesTraveled = 0;
			int thirst = 0;
			int camelTiredness = 0;
			int drinks = 3;
			int nativeDistance = -20;
			string choice;
			string playAgain;
			bool done = false;
			Random random = new Random();

			Console.WriteLine("Welcome to Camel!");
			Console.WriteLine("You have stolen a camel to make your way across the great Mobi desert.");
			Console.WriteLine("The natives want their camel back and are chasing you down! Survive your desert trek and out run the natives.");

			while (!done)
			{
				Choices();
				Console.Write("Enter Choice: ");
				choice = Console.ReadLine();
				if (string.Equals("Q", choice.ToUpper()))
				{
					done = true;
				}

				else if (string.Equals("A", choice.ToUpper()))
				{
					ChoiceA(ref thirst, ref drinks);
				}

				else if (string.Equals("B", choice.ToUpper()))
				{
					ChoiceB(ref milesTraveled, ref thirst, ref camelTiredness, ref drinks, ref nativeDistance, random);
				}

				else if (string.Equals("C", choice.ToUpper()))
				{
					ChoiceC(ref milesTraveled, ref thirst, ref camelTiredness, ref drinks, ref nativeDistance, random);
				}

				else if (string.Equals("D", choice.ToUpper()))
				{
					ChoiceD(ref nativeDistance, ref camelTiredness, random);
				}

				else if (string.Equals("E", choice.ToUpper()))
				{
					ChoiceE(milesTraveled, drinks, nativeDistance);
				}

				if (thirst > 6)
				{
					Console.WriteLine("You died of thirst.");
					done = true;
				}

				else if (thirst > 4)
				{
					Console.WriteLine("You are thirsty.");
				}

				if (camelTiredness > 8 & !done)
				{
					Console.WriteLine("Your camel is dead.");
					done = true;
				}

				else if (camelTiredness > 5)
				{
					Console.WriteLine("Your camel is getting tired.");
				}

				if (milesTraveled - nativeDistance <= 0 & !done)
				{
					Console.WriteLine("The natives caught you!");
					done = true;
				}

				else if (milesTraveled - nativeDistance <= 15)
				{
					Console.WriteLine("The natives are getting close!");
				}

				if (milesTraveled >= 200 & !done)
				{
					Console.WriteLine("You escaped the natives!");
					done = true;
				}

				if (done)
				{
					Console.Write("Play Again? (Y/N) ");
					playAgain = Console.ReadLine();
					if (string.Equals("Y", playAgain.ToUpper()))
					{
						done = false;
					}
					else if (string.Equals("N", playAgain.ToUpper()))
					{
						Console.WriteLine("Thanks for playing!");
					}
				}
			}
		}
	}
}
