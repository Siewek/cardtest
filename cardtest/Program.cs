using System;
using CardGame.Models;
using cardtest;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            Player player2 = new Player();

            int whostarts = deck.whostarts();
            bool foldflag = false,endturnflag = false, opfoldflag = false;
            string command;
            deck.displaytitle();

            while(true)//the entire round
            {
                Console.WriteLine();
                deck.builddeck();
                player.clearhand();
                player2.clearhand();
                foldflag = false;
                endturnflag = false;
                opfoldflag = false;
                //clean start
                Console.WriteLine("Starting hands");
                player.hit();
                player2.hit();
                player2.hidefirstcard();
                Console.ForegroundColor = ConsoleColor.Red;
                player2.showhand();
                Console.ForegroundColor = ConsoleColor.Green;
                player.showhand();
                Console.ResetColor();
                while (true)//showdown
                {
                    if (whostarts == 2)
                    {
                        Console.WriteLine("Opponents Move");
                        if (player2.value <= 17)
                        {
                            Console.WriteLine("Opponent Hit");
                           player2.hit();                          
                            whostarts = 1;
                        }
                        else
                        {
                            Console.WriteLine("Opponent folded");
                            opfoldflag = true;
                            whostarts = 1;
                        }
                    }
                    if(whostarts == 1 && player2.value <22)
                    {
                        endturnflag = false;
                        Console.WriteLine("Your Move");
                        if (foldflag != true)
                        {
                            while (!endturnflag)
                            {
                                command = Console.ReadLine();
                                switch (command)
                                {
                                    case "hit":
                                        {
                                            endturnflag = true;
                                            player.hit();
                                            Console.WriteLine("You Hit");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            player.showhand();
                                            Console.ResetColor();
                                            continue;

                                        }

                                    case "fold":
                                        {
                                            Console.WriteLine("You Folded");
                                            foldflag = true;
                                            endturnflag = true;
                                            continue;
                                        }
                                    case "showhands":
                                        {
                                            Console.WriteLine("Opponents Hand");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            player2.showhand();
                                            Console.ResetColor();
                                            Console.WriteLine("Your Hand");
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
                                            Console.WriteLine("List of commands: ");
                                            Console.WriteLine("hit - adds a card to your hand");
                                            Console.WriteLine("fold - folds this round");
                                            Console.WriteLine("showhands - shows the cards on the table");
                                            Console.WriteLine("help - displays help (duh)");
                                            Console.WriteLine("quit - quits the program");
                                            break;
                                        }
                                    default: 
                                        {
                                            Console.WriteLine("Unknown Command");
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                    whostarts = 2;
                    //win conditions
                    if ((opfoldflag == true && foldflag == true)||player.value >21 || player2.value >21 )
                    {
                        player2.showfirstcard();
                        if (player.value > player2.value && player.value <=21 || player2.value > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            player2.showhand();
                            Console.ForegroundColor = ConsoleColor.Green;
                            player.showhand();
                            Console.ResetColor(); ;
                            Console.WriteLine("You Win");
                        }
                        else if (player.value < player2.value && player2.value <= 21 || player.value >21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            player2.showhand();
                            Console.ForegroundColor = ConsoleColor.Green;
                            player.showhand();
                            Console.ResetColor();
                            Console.WriteLine("You Lose");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            player2.showhand();
                            Console.ForegroundColor = ConsoleColor.Green;
                            player.showhand();
                            Console.ResetColor();
                            Console.WriteLine("It's a tie");
                        }
                        break;
                    }
                    continue;
                }
               
                continue;
            }
        }
    }
}
