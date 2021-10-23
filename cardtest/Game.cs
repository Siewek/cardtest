using System;
using System.Collections.Generic;
using System.Text;

namespace cardtest
{
    class Game
    {
        public void menu()
        {
            Console.WriteLine("Main Menu");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Available Commands:");
            Console.WriteLine("new - starts new game");
            Console.WriteLine("htp - displays how to play");
            Console.WriteLine("help - displays functions available in game (also available after starting a new game)");
            Console.WriteLine("credits - displays credits");
            Console.WriteLine("quit - quits the game");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void help()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List of commands: ");
            Console.WriteLine("hit - adds a card to your hand");
            Console.WriteLine("fold - folds this round");
            Console.WriteLine("showhands - shows the cards on the table");
            Console.WriteLine("help - displays help (duh)");
            Console.WriteLine("quit - quits the program");
            Console.WriteLine("back - goes back to main menu (only available in game)");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void credits()
        {
            Console.WriteLine();
            Console.Write("Made by");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Michał Olesiewicz");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void htp()
        {
            Console.WriteLine();
            Console.WriteLine("Each player starts with one card unknown to the other player.");
            Console.WriteLine("The goal of the game is to get the sum of your cards as close to 21 as possible");
            Console.WriteLine("with Jack, Queens and Kings counting as 10s and Ace counting as either 1 or 11, depending on what would bring you closer to the desired 21");
            Console.WriteLine("If any player's card sum exceeds 21, they lose automatically");
            Console.WriteLine("Use the help command for more info about available commands");
        }
    }
}
