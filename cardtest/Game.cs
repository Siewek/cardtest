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

        public void characterselect()
        {
            Console.WriteLine("Choose your character");
            Console.WriteLine("Available characters: \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("righteous - A truthful and honest character, will never cheat, Opponent is slightly less aggressive \n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("default - has no special benefits, and no handicap, a classic blackjack experience \n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("cheater - a known cheat, more experience with cheating, but will get disqualified imiediatelly after being cought \n" );
            Console.ResetColor();
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
            Console.WriteLine("peek - cheat command, reveals your opponents hidden card, can cause the player to lose if unsuccessful");
            Console.WriteLine("next = cheat command, checks the next drawn card, can cause the player to lose if unsuccessful");
            Console.ResetColor();
            Console.WriteLine("please note that every command is lowercase, any upper case letters won't be supported \n");
            Console.WriteLine();
        }

        public void credits()
        {
             Console.WriteLine();
             Console.Write("Made by ");
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("Siewek");
             Console.ResetColor();
             Console.WriteLine();
             Console.Write("Special Thanks to: ");
             Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine("Hyrriss, Borsuq, QCV, Skranbets, Berh, TheYoungBeast, Spockus, Chromo, AJ and Luneł");
             Console.ResetColor();
             Console.WriteLine("For being incredibly supportive friends");
           /* Console.WriteLine("haha no");
            Console.WriteLine(); */
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
