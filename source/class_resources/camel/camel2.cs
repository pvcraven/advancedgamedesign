using System;
using System.Collections;
using System.Collections.Generic;

namespace Camel
{
    class Program
    {
        // Initialize variables for use throughout the entire program
        static int playerPosition;
        static int hadesPosition;
        static int gameLength;
        static bool done;
        static int energy;
        static int maxEnergy = 20;
        static int drachmas;
        static int maxShops = 4;
        static int hadesMovement;
        static int turnCounter;
        static int positionDifference;
        static string distanceStatement;
        static string energyStatement;
        static int[] shops;
        static int movementModifier;
        static int hadesMovementModifier;
        static Dictionary<string, int> shopItems;
        static int speedBoostTurns;
        static int maxSpeedBoost = 5;
        static int roadBlockTurns;
        static int maxRoadBlock = 5;
        static bool purchaseMade;
        static bool moved;
        static bool exitShop;
        static string lineBreak = "-------------------------------------------------------------------------------------";

        static void Main(string[] args)
        {
            // ----------------------------------------- SETUP FUNCTIONS FOR GAME USE -----------------------------------------
            void InitializeGame()
            {
                // Initialize game variables and general setup.
                hadesPosition = 0;
                // Set player position relative to Hades at the beginning of the game.
                playerPosition = SetPlayerPosition(hadesPosition);
                // Randomize the length that the player must travel.
                SetGameLength();
                // Get our list of shop locations.
                shops = DisperseShops();
                energy = maxEnergy;
                turnCounter = 0;
                // This is used to keep our game running until the player wins or is caught by Hades.
                done = false;
                hadesMovementModifier = 0;
                movementModifier = 0;
                shopItems = new Dictionary<string, int>();
                InitializeShop();

                string gameStartTutorial;
                gameStartTutorial = "You are in ancient Greece and have just completed an undercover recon mission for Zeus. Hades has discovered " +
                    "what you have done and is now chasing you while you make your way back to Olympus! Get back to Olympus before Hades makes you pay " +
                    "the price!";

                Console.WriteLine(gameStartTutorial);
                Console.WriteLine(lineBreak);
            }

            // This function will set the Game's length every time it is started up.
            int SetGameLength()
            {
                gameLength = RandomNumber(45, 60);
                return gameLength;
            }

            // Function for generating random numbers within the game.
            int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            // This function sets the players initial starting position with respect to the enemy's position.
            int SetPlayerPosition(int hadesLocation)
            {
                int playerLocation;
                playerLocation = hadesLocation + RandomNumber(1, 6);
                return playerLocation;
            }

            int SetHadesPosition()
            {
                hadesMovement = RandomNumber(2, 5);
                if (hadesMovement - hadesMovementModifier < 0)
                {
                    hadesMovement = 0;
                }
                else
                {
                    hadesMovement = hadesMovement - hadesMovementModifier;
                }
                hadesPosition += hadesMovement;
                return hadesPosition;
            }

            int[] DisperseShops()
            {
                int previousShop;
                int interval;
                int[] shopLocations = new int[maxShops];

                previousShop = 0;

                for (int i = 0; i < maxShops; i++)
                {
                    interval = RandomNumber(4, 10);
                    if (previousShop + 4 < gameLength && (previousShop + interval) < gameLength)
                    {
                        shopLocations[i] = previousShop + interval;
                        previousShop = shopLocations[i];
                    }
                }

                return shopLocations;
            }

            string GetEnergyStatement(int energy)
            {
                if (energy <= 3)
                {
                    return "You are exhausted...";
                }
                else if (energy > 3 && energy <= 10)
                {
                    return "You are starting to get tired...";
                }
                else if (energy > 10 && energy <= 15)
                {
                    return "You still feel moderately energetic.";
                }
                else
                {
                    return "You are pulsing with energy!";
                }
            }

            void CheckForAncientRuins()
            {
                int random;
                int drachmasGained;
                random = RandomNumber(0, 26);
                drachmasGained = RandomNumber(5, 15);
                if (random == 12)
                {
                    Console.WriteLine("You have stumbled upon some ancient ruins. You have found " + drachmasGained + " drachmas and your energy has been restored!");
                    drachmas += drachmasGained;
                    energy = maxEnergy;
                }
            }

            void Purchase(string itemName, int price)
            {
                string shopStatement = "";

                if (itemName.Equals("Energy Drink") && drachmas >= price)
                {
                    energy = maxEnergy;
                    shopStatement = "Your energy has been replenished!";
                    shopItems.Remove("Energy Drink");
                    drachmas -= price;
                    purchaseMade = true;
                }
                else if (itemName.Equals("Speed Boost") && drachmas >= price)
                {
                    movementModifier = RandomNumber(2, 4);
                    speedBoostTurns = maxSpeedBoost;

                    shopStatement = "Your movement speed has been boosted by " + movementModifier +
                        " for " + speedBoostTurns + " turns!";
                    shopItems.Remove("Speed Boost");
                    drachmas -= price;
                    purchaseMade = true;
                }
                else if (itemName.Equals("Road Block") && drachmas >= price)
                {
                    hadesMovementModifier = RandomNumber(1, 3);
                    roadBlockTurns = maxRoadBlock;
                    shopStatement = "You have injured Hades and have restricted his movement by " +
                        hadesMovementModifier + " for " + roadBlockTurns + " turns!";
                    shopItems.Remove("Road Block");
                    drachmas -= price;
                    purchaseMade = true;
                }
                else if (drachmas < price)
                {
                    Console.WriteLine("You cannot afford that!");
                    purchaseMade = false;
                }
                else
                {
                    Console.WriteLine("You have decided to leave.");
                    exitShop = true;
                }
                if (purchaseMade)
                {
                    Console.WriteLine("You have purchased one " + itemName);
                    Console.WriteLine(shopStatement);
                }
            }

            void OpenShop()
            {
                string shopStatement = "You have stumbled upon a traveling merchant!";
                int i = 1;
                Console.WriteLine(shopStatement);
                Dictionary<int, string> itemList = new Dictionary<int, string>();

                foreach (KeyValuePair<string, int> item in shopItems)
                {
                    string displayItem = i + ". " + item.Key + " -------- " + item.Value;
                    Console.WriteLine(displayItem);
                    itemList.Add(i, item.Key);
                    i += 1;
                }

                string leave = i + ". Leave";
                itemList.Add(i, "Leave");
                string playerDrachmas = "Your current held drachmas: " + drachmas;
                string buy = "Would you like to make a purchase?";
                Console.WriteLine(leave);
                Console.WriteLine(playerDrachmas);
                Console.WriteLine(buy);

                purchaseMade = false;
                exitShop = false;

                while (!purchaseMade && !exitShop)
                {
                    string userInput = Console.ReadLine();

                    try
                    {
                        string itemName;
                        int price;

                        itemList.TryGetValue(Convert.ToInt32(userInput), out itemName);
                        shopItems.TryGetValue(itemName, out price);
                        Purchase(itemName, price);
                        exitShop = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
            }

            void InitializeShop()
            {
                shopItems.Add("Energy Drink", 10);
                shopItems.Add("Speed Boost", 25);
                shopItems.Add("Road Block", 15);
            }

            void IncrementItemDuration()
            {
                if (speedBoostTurns > 0)
                {
                    speedBoostTurns -= 1;
                }
                if (roadBlockTurns > 0)
                {
                    roadBlockTurns -= 1;
                }
            }

            void GetUserDecision()
            {
                string slow;
                string medium;
                string fast;
                string rest;
                string input;
                string status;
                string quit;
                bool decided;
                int drachmasGained = 0;

                decided = false;

                slow = "1. Slow and Steady...";
                medium = "2. Keep a moderate pace.";
                fast = "3. Full steam ahead!!!";
                rest = "4. Stop and take a rest...";
                status = "5. Journey Status.";
                quit = "6. Quit Game.";

                if (positionDifference >= 10)
                {
                    Console.WriteLine("Hades is very far away...");
                }
                else if (positionDifference >= 6)
                {
                    Console.WriteLine("Hades is getting closer.");
                }
                else
                {
                    Console.WriteLine("Hades is right on your tail!!!");
                }
                Console.WriteLine();
                Console.WriteLine(slow + "\n" + medium + "\n" + fast + "\n" + rest + "\n" + status + "\n" + quit);
                Console.WriteLine("What would you like to do?");

                while (!decided)
                {
                    // Get user input and set up if statements to evaluate user input.
                    input = Console.ReadLine();

                    int distanceTraveled;
                    int energyUsed;

                    // If player has decided to take it slow...
                    if (input.Equals("1"))
                    {
                        distanceTraveled = (RandomNumber(1, 3) + movementModifier);
                        energyUsed = RandomNumber(-3, -1);
                        playerPosition += distanceTraveled;
                        distanceStatement = "You have decided to play it safe, and have traveled " + distanceTraveled + " miles. ";
                        energyStatement = GetEnergyStatement(energy);
                        drachmasGained = RandomNumber(1, 3);

                        // Make sure we are not surpassing the maximum energy cap.
                        if (energy - energyUsed < maxEnergy - energyUsed)
                        {
                            energy -= energyUsed;
                        }
                        else
                        {
                            energy = maxEnergy;
                        }

                        IncrementItemDuration();

                        decided = true;
                    }
                    // If player has decided on medium travel speed...
                    else if (input.Equals("2") && energy >= 4)
                    {
                        distanceTraveled = (RandomNumber(3, 5) + movementModifier);
                        energyUsed = RandomNumber(2, 4);
                        playerPosition += distanceTraveled;
                        energy -= energyUsed;
                        distanceStatement = "You have decided to move at a steady pace, and have traveled " + distanceTraveled + " miles. ";
                        energyStatement = GetEnergyStatement(energy);
                        drachmasGained = RandomNumber(2, 4);
                        drachmas += drachmasGained;
                        IncrementItemDuration();

                        decided = true;
                    }
                    // If player has decided to go full speed...
                    else if (input.Equals("3") && energy >= 8)
                    {
                        distanceTraveled = (RandomNumber(4, 8) + movementModifier);
                        energyUsed = RandomNumber(6, 8);
                        drachmasGained =
                        playerPosition += distanceTraveled;
                        energy -= energyUsed;
                        distanceStatement = "You have decided to travel at full speed, and have traveled " + distanceTraveled + " miles. ";
                        energyStatement = GetEnergyStatement(energy);
                        drachmasGained = RandomNumber(3, 6);
                        IncrementItemDuration();

                        decided = true;
                    }
                    // If player has decided to rest...
                    else if (input.Equals("4"))
                    {
                        energyUsed = RandomNumber(-10, -6);
                        energy -= energyUsed;
                        distanceStatement = "You have decided to take a rest and recover your energy. ";
                        energyStatement = GetEnergyStatement(energy);
                        IncrementItemDuration();

                        decided = true;
                    }
                    else if (input.Equals("5"))
                    {
                        Console.WriteLine("----------------- STATUS REPORT -----------------\nEnergy: " + GetEnergyStatement(energy) +
                            "\nDrachmas: " + drachmas + "\nHades is " + positionDifference + " miles behind you.");
                        decided = false;
                    }
                    else if (input.Equals("6"))
                    {
                        bool decisionMade = false;
                        Console.WriteLine("Are you sure you would like to quit?\n1. Yes\n2. No");
                        string choice;

                        while (!decisionMade)
                        {
                            choice = Console.ReadLine();

                            if (choice.Equals("1"))
                            {
                                Console.WriteLine("You have exited the game.");
                                done = true;
                                decided = true;
                                decisionMade = true;
                            }
                            else if (choice.Equals("2"))
                            {
                                decisionMade = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter either 1 or 2.");
                            }
                        }
                    }
                    // If player has entered anything that is not above or does not have enough energy...
                    else
                    {
                        if ((input.Equals("2") && energy < 4) || (input.Equals("3") && energy < 8))
                        {
                            Console.WriteLine("You do not have enough energy for that!");
                        }
                        else
                        {
                            Console.WriteLine("That is not an option, please enter a number between 1 and 4.");
                        }
                        // Keep loop running.
                        decided = false;
                    }
                }

                // Update Hades position and print out the game status.
                if (!done)
                {
                    SetHadesPosition();
                    Console.WriteLine(distanceStatement + energyStatement);
                    Console.WriteLine("While traveling you found " + drachmasGained + " drachmas!");
                    drachmas += drachmasGained;
                    turnCounter += 1;
                }

                for (int i = 0; i < shops.Length; i++)
                {
                    if (playerPosition == shops[i])
                    {
                        OpenShop();
                    }
                }
            }
            // -----------------------------------------------------------------------------------------------------------------------

            // ----------------------------------------------------MAIN GAME SETUP----------------------------------------------------
            InitializeGame();

            // Run this loop while the game is not over.
            while (!done)
            {
                string input;
                bool playAgainDecision;
                if (playerPosition < gameLength)
                {
                    if (playerPosition <= hadesPosition)
                    {
                        Console.WriteLine("You were caught! Game Over!");
                        playAgainDecision = false;
                        Console.WriteLine("Would you like to try again?\n1. Yes\n2. No");

                        while (!playAgainDecision)
                        {
                            input = Console.ReadLine();

                            if (input.Equals("1"))
                            {
                                InitializeGame();
                                playAgainDecision = true;
                                done = false;
                            }
                            else if (input.Equals("2"))
                            {
                                playAgainDecision = true;
                                done = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input. Please enter either 1 or 2.");
                                playAgainDecision = false;
                            }
                        }
                    }
                    else
                    {
                        CheckForAncientRuins();
                        GetUserDecision();
                        positionDifference = playerPosition - hadesPosition;
                        Console.WriteLine(lineBreak);
                    }
                }
                else
                {
                    Console.WriteLine("You win!");
                    playAgainDecision = false;
                    while (!playAgainDecision)
                    {
                        input = Console.ReadLine();

                        if (input.Equals("1"))
                        {
                            InitializeGame();
                            playAgainDecision = true;
                            done = false;
                        }
                        else if (input.Equals("2"))
                        {
                            playAgainDecision = true;
                            done = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Please enter either 1 or 2.");
                            playAgainDecision = false;
                        }
                    }
                }
            }
        }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
