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
           
            while(true)//the entire round
            {
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
                player2.showhand();
                player.showhand();
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
                                            player.showhand();
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
                                            player2.showhand();
                                            Console.WriteLine("Your Hand");
                                            player.showhand();
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
                    if ((endturnflag == true && opfoldflag == true && foldflag == true)||player.value >21 || player2.value >21 )
                    {
                        if (player.value > player2.value && player.value <=21)
                        {
                            player2.showhand();
                            player.showhand();
                            Console.WriteLine("You Win");
                        }
                        else if (player.value < player2.value && player2.value <= 21 || player.value >21)
                        {
                            player2.showhand();
                            player.showhand();
                            Console.WriteLine("You Lose");
                        }
                        else
                        {
                            player2.showhand();
                            player.showhand();
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
