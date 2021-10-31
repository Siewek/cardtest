﻿using System;
using CardGame.Models;
using cardtest;
using System.Threading;
namespace ConsoleApp4
{
    public enum characters
    {
        basic = 0, cheater = 1, righteous = 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            Player player2 = new Player();
            Game game = new Game();
            int whostarts = deck.whostarts();
            bool foldflag = false, endturnflag = false, opfoldflag = false, backflag=false;
            characters character;
            string command;
            deck.displaytitle();

            while (true)
            {
                if (backflag == true)
                {
                    Console.Clear();
                    deck.displaytitle();
                }
                Console.WriteLine();
                game.menu();
                command = Convert.ToString(Console.ReadLine());
                backflag = false;
                switch (command)
                {
                    case "new":
                        {
                            Console.Clear();
                            while(true)
                            {
                                Console.WriteLine("Choose a character");
                                command = Convert.ToString(Console.ReadLine());
                                switch(command)
                                {
                                    case ("default"):
                                        {
                                            Console.WriteLine("You chose the basic character");
                                            Console.WriteLine();
                                            character = characters.basic;
                                            break;
                                        }
                                    case ("cheater"):
                                        {
                                            Console.WriteLine("You chose the cheater character");
                                            Console.WriteLine();
                                            character = characters.cheater;
                                            break;
                                        }
                                    case ("righteous"):
                                        {
                                            Console.WriteLine("You chose the righteous character");
                                            Console.WriteLine();
                                            character = characters.righteous;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Unknown Character");
                                            Console.WriteLine();
                                            continue;
                                        }                                    
                                }
                                Console.WriteLine("Click enter to continue");
                                Console.ReadLine();                           
                                Console.Clear();
                                break;
                            }
                            while (true)//the entire round
                            {
                                Console.WriteLine();
                                Console.WriteLine("Dealing hands:");
                                Console.WriteLine();
                                deck.builddeck();
                                player.clearhand();
                                player2.clearhand();
                                player.resetcheat();
                                foldflag = false;
                                endturnflag = false;
                                opfoldflag = false;
                                //clean start
                                Console.WriteLine("Starting hands \n");
                                deck.getnextcard();                              
                                player.hit();
                                deck.getnextcard();
                                player2.hit();
                                player2.hidefirstcard();
                                Console.ForegroundColor = ConsoleColor.Red;
                                player2.showhand();
                                Console.ForegroundColor = ConsoleColor.Green;
                                player.showhand();
                                Console.ResetColor();
                                while (true)//showdown
                                {
                                    if (!foldflag)
                                    {
                                        deck.getnextcard();
                                    }
                                    if (whostarts == 2 && backflag ==false)
                                    {
                                        Console.WriteLine("Opponents Move \n");
                                        if (player2.value <= (character == characters.righteous?15:17))
                                        {
                                            Console.WriteLine("Opponent Hit \n");
                                            player2.hit();
                                            whostarts = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opponent folded \n");
                                            opfoldflag = true;
                                            whostarts = 1;
                                        }
                                    }
                                    if (whostarts == 1 && player2.value < 22 && backflag == false)
                                    {
                                        endturnflag = false;                                      
                                        if (foldflag != true)
                                        {
                                            Console.WriteLine("Your Move \n");
                                            Console.WriteLine();
                                            deck.getnextcard();
                                            while (!endturnflag)
                                            {
                                                
                                                command = Console.ReadLine();
                                                switch (command)
                                                {
                                                    case "hit":
                                                        {
                                                            endturnflag = true;
                                                            player.hit();
                                                            Console.WriteLine("You Hit" \n);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            player.showhand();
                                                            Console.ResetColor();
                                                            continue;

                                                        }

                                                    case "fold":
                                                        {
                                                            Console.WriteLine("You Folded \n");
                                                            foldflag = true;
                                                            endturnflag = true;
                                                            continue;
                                                        }
                                                    case "showhands":
                                                        {
                                                            Console.WriteLine("Opponents Hand \n");
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            player2.showhand();
                                                            Console.ResetColor();
                                                            Console.WriteLine("Your Hand \n");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            player.showhand();
                                                            Console.ResetColor();
                                                            continue;
                                                        }
                                                    case "quit":
                                                        {
                                                            return;
                                                        }
                                                    case "help":
                                                        {
                                                            game.help();
                                                            break;
                                                        }
                                                    case "back":
                                                    {
                                                            backflag = true;
                                                            endturnflag = true;
                                                            break;
                                                    }
                                                    case "peek":
                                                        {
                                                            if(character == characters.righteous)
                                                            {
                                                                Console.WriteLine("Righteous character won't cheat \n");
                                                                break;
                                                            }
                                                            player.lookupophand(player2, character);
                                                            if(player.value >21)
                                                            {
                                                                endturnflag = true;
                                                            }
                                                            break;
                                                        }
                                                    case "next":
                                                        {
                                                            if (character == characters.righteous)
                                                            {
                                                                Console.WriteLine("Righteous character won't cheat \n");
                                                                break;
                                                            }
                                                            player.lookupnextcard(character);
                                                            if(player.value>21)
                                                            {
                                                                endturnflag = true;
                                                            }
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("Unknown Command \n");
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine();
                                    whostarts = 2;
                                    //win conditions
                                    if ((opfoldflag == true && foldflag == true && backflag == false) || player.value > 21 || player2.value > 21)
                                    {
                                        player2.showfirstcard();
                                        if (player.value > player2.value && player.value <= 21 || player2.value > 21)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            player2.showhand();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            player.showhand();
                                            Console.ResetColor(); ;
                                            Console.WriteLine("You Win \n");
                                        }
                                        else if (player.value < player2.value && player2.value <= 21 || player.value > 21)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            player2.showhand();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            player.showhand();
                                            Console.ResetColor();
                                            Console.WriteLine("You Lose \n");
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            player2.showhand();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            player.showhand();
                                            Console.ResetColor();
                                            Console.WriteLine("It's a tie \n");
                                        }
                                        Console.WriteLine("Press enter to start next turn \n");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    }
                                    if (backflag == false)
                                        continue;
                                    else
                                        break;
                                }
                                if (backflag == false)
                                {
                                    continue;
                                }
                                else
                                    break;
                            }
                            continue;
                        }
                    case "help":
                        {
                            game.help();
                            break;
                        }
                    case "credits":
                        {
                            game.credits();
                            break;
                        }
                    case "quit":
                        {
                            return;
                        }
                    case "htp":
                        {
                            game.htp();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Unknown Command " + command);
                            Console.WriteLine();
                            break;
                        }
                }
            }
        }
    }
}
