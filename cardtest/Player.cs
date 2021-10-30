﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.Models;
namespace cardtest
{
    class Player : Deck
    {
        private Random rnd = new Random();
        protected List<Cards> hand = new List<Cards>();
        private string helper;
        private int dc = 10, tries = 0;
        public int myvalue = 0;
        public void hit()
        {
            hand.Add(deck[rowhelper, columnhelper]);

            if (deck[rowhelper, columnhelper].value == 11 || deck[rowhelper, columnhelper].value == 12 || deck[rowhelper, columnhelper].value == 13)
            {
                myvalue = myvalue + 10;
            }
            else if (deck[rowhelper, columnhelper].value == 1)
            {
                if (myvalue <= 10)
                {
                    myvalue = myvalue + 11;
                }
                else
                    myvalue = myvalue + 1;
            }
            else
            {
                myvalue = myvalue + deck[rowhelper, columnhelper].value;
            }
            deck[rowhelper, columnhelper] = null;
        }
        public int value { get { return myvalue; } }
        public void showhand()
        {
            if (hand.Count() != 0)
            {
                for (int i = 0; i < hand.Count(); i++)
                {
                    Console.Write(hand.ElementAt(i).card + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Hand is empty");
            }
        }
        public void clearhand()
        {
            hand.Clear();
            myvalue = 0;
        }
        public void fold()
        {

        }

        public void hidefirstcard()
        {
            if (hand.Count() != 0)
            {
                helper = hand.ElementAt(0).card;
                hand.ElementAt(0).card = Convert.ToString('\ufffd');
            }
        }
        public void showfirstcard()
        {
            if (hand.Count() != 0 && helper != null)
            {
                hand.ElementAt(0).card = helper;
            }
        }

        public void lookupophand(Player whatever)
        {
            int roll;
            roll = rnd.Next(0,20);

            if(roll >= dc)
            {
                Console.WriteLine("Cheating successful, opponents hand revealed");
                whatever.showfirstcard();
                dc++; 
            }
            else
            {
                if(tries == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hey, you're cheating! Don't do it again");
                    Console.ResetColor();
                    tries++;
                    dc++;
                }
                else
                {
                    Console.WriteLine("You got caught cheating and was disqualified");
                    myvalue = 10000;
                }

            }
        }

        public void lookupnextcard()
        {
            int roll;
            roll = rnd.Next(0, 20);

            if (roll >= dc)
            {
                Console.WriteLine($"Cheating successful, your next card is: {deck[rowhelper,columnhelper].card}" );
                dc++;
            }
            else
            {
                if (tries == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hey, you're cheating! Don't do it again");
                    Console.ResetColor();
                    tries++;
                    dc++;
                }
                else
                {
                    Console.WriteLine("You got caught cheating and was disqualified");
                    myvalue = 10000;
                }

            }
        }
        public void resetcheat()
        {
            tries = 0;dc = 10;
        }
    }
}
