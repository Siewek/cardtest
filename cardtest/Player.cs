using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.Models;
namespace cardtest
{
    class Player : Deck
    {
        protected List<Cards> hand = new List<Cards>();

        public int myvalue = 0;
        public void hit()
        {
            Random rnd = new Random();
            int row = rnd.Next(0, 4), column = rnd.Next(0, 13);
            while (deck[row, column] == null)
            {
                row = rnd.Next(0, 4); column = rnd.Next(0, 13);
            }

            hand.Add(deck[row, column]);

            if (deck[row, column].value == 11 || deck[row, column].value == 12 || deck[row, column].value == 13)
            {
                myvalue = myvalue + 10;
            }
            else if (deck[row, column].value == 1)
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
                myvalue = myvalue + deck[row, column].value;
            }
            deck[row, column] = null;
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
    }
}
