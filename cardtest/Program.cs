using System;
using CardGame.Models;
using cardtest;
using System.Threading;
namespace ConsoleApp4
{
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
                                Console.WriteLine("Starting hands");
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
                                    if (whostarts == 1 && player2.value < 22 && backflag == false)
                                    {
                                        endturnflag = false;                                      
                                        if (foldflag != true)
                                        {
                                            Console.WriteLine("Your Move");
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
                                                            player.lookupophand(player2);
                                                            if(player.value >21)
                                                            {
                                                                endturnflag = true;
                                                            }
                                                            break;
                                                        }
                                                    case "next":
                                                        {
                                                            player.lookupnextcard();
                                                            if(player.value>21)
                                                            {
                                                                endturnflag = true;
                                                            }
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
                                            Console.WriteLine("You Win");
                                        }
                                        else if (player.value < player2.value && player2.value <= 21 || player.value > 21)
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
                                        Console.WriteLine("Press enter to start next turn");
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
                            break;
                        }
                }
            }
        }
    }
}
