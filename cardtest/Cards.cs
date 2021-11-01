using Figgle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class Cards
    {
        public char suite;

        public string card;

        public int value;

    }

    public class Deck
    {
        public static Cards[,] deck = new Cards[4, 14];

        private char s1 = (char)3, s2 = (char)4, s3 = (char)5, s4 = (char)6;
        protected static int rowhelper, columnhelper;
        private string c1 = "J", c2 = "Q", c3 = "K", c4 = "A";

        Random rnd = new Random();

        public void builddeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck[i, j] = new Cards();

                    deck[i, j].value = j + 1; // adding value

                    if (i == 0) //adding suites and appropriate names
                    {
                        deck[i, j].suite = (char)3;
                        deck[i, j].card = deck[i, j].value.ToString() + s1;
                    }
                    if (i == 1)
                    {
                        deck[i, j].suite = (char)4;
                        deck[i, j].card = deck[i, j].value.ToString() + s2;
                    }
                    if (i == 2)
                    {
                        deck[i, j].suite = (char)5;
                        deck[i, j].card = deck[i, j].value.ToString() + s3;
                    }
                    if (i == 3)
                    {
                        deck[i, j].suite = (char)6;
                        deck[i, j].card = deck[i, j].value.ToString() + s4;
                    }
                    switch (deck[i, j].value) //cases for cards of value higher than 10
                    {
                        case 11:
                            {
                                switch (deck[i, j].suite)
                                {
                                    case (char)3:
                                        {
                                            deck[i, j].card = c1 + s1;
                                            break;
                                        }
                                    case (char)4:
                                        {
                                            deck[i, j].card = c1 + s2;
                                            break;
                                        }
                                    case (char)5:
                                        {
                                            deck[i, j].card = c1 + s3;
                                            break;
                                        }
                                    case (char)6:
                                        {
                                            deck[i, j].card = c1 + s4;
                                            break;
                                        }
                                } //jacks
                                break;
                            }
                        case 12:
                            {
                                switch (deck[i, j].suite)//queens
                                {
                                    case (char)3:
                                        {
                                            deck[i, j].card = c2 + s1;
                                            break;
                                        }
                                    case (char)4:
                                        {
                                            deck[i, j].card = c2+ s2;
                                            break;
                                        }
                                    case (char)5:
                                        {
                                            deck[i, j].card = c2 + s3;
                                            break;
                                        }
                                    case (char)6:
                                        {
                                            deck[i, j].card = c2 + s4;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 13:
                            {
                                switch (deck[i, j].suite)//Kings
                                {
                                    case (char)3:
                                        {
                                            deck[i, j].card = c3 + s1;
                                            break;
                                        }
                                    case (char)4:
                                        {
                                            deck[i, j].card = c3 + s2;
                                            break;
                                        }
                                    case (char)5:
                                        {
                                            deck[i, j].card = c3 + s3;
                                            break;
                                        }
                                    case (char)6:
                                        {
                                            deck[i, j].card = c3 + s4;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 1:
                            {
                                switch (deck[i, j].suite)//Aces
                                {
                                    case (char)3:
                                        {
                                            deck[i, j].card = c4 + s1;
                                            break;
                                        }
                                    case (char)4:
                                        {
                                            deck[i, j].card = c4 + s2;
                                            break;
                                        }
                                    case (char)5:
                                        {
                                            deck[i, j].card = c4 + s3;
                                            break;
                                        }
                                    case (char)6:
                                        {
                                            deck[i, j].card = c4 + s4;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
        }

        public void showdeck()
        {
            for(int i = 0; i < 4;i++)
            {
               for(int j = 0; j<13; j++)
                {
                    if (deck[i, j] != null)
                    {
                        Console.Write(deck[i, j].card + "," + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public int whostarts()
        {
            return rnd.Next(0, 2);
        }
        public void getnextcard()
        {
            rowhelper = rnd.Next(0, 4); columnhelper = rnd.Next(0, 13);
            while (deck[rowhelper, columnhelper] == null)
            {
                rowhelper = rnd.Next(0, 4); columnhelper = rnd.Next(0, 13);
            }
        }
        public void displaytitle()
        {
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine(FiggleFonts.Ogre.Render("Siewek's Card Game"));
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////");
        }
    
    }
}
