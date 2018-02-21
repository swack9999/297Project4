/*
 * Dealer.cs
 * Authors: Spencer Wack, Matthew London, Monzur Ahmed
 * Creation Date: 2/20/2018
 */
using System;
using System.Collections;

namespace _297Project4
{
    class Dealer
    {
        private static int TOTAL_NUMBER_OF_SUITS_IN_FULL_DECK = 24;     // 4 suits per deck * 6 decks
        private static int SHUFFLE_CONSTANT = 31;
        private ArrayList masterDeck;
        public Dealer()
        {
            // add all cards to initial deck
            masterDeck = new ArrayList();
            for (int index = 0; index < 24; index++)
            {
                masterDeck.Add('2');
                masterDeck.Add('3');
                masterDeck.Add('4');
                masterDeck.Add('5');
                masterDeck.Add('6');
                masterDeck.Add('7');
                masterDeck.Add('8');
                masterDeck.Add('9');
                masterDeck.Add('0');          // can't use 10 because that has two characters
                masterDeck.Add('J');
                masterDeck.Add('Q');
                masterDeck.Add('K');
                masterDeck.Add('A');
            }
        }
        public bool ShuffleCheck() { return (masterDeck.Count <= SHUFFLE_CONSTANT) ? true : false; }
        public void ReshuffleDeck()
        {
            //TODO: Implement reshuffle
        }
        public double CalculateOdds(char cardType)
        {
            //TODO: implement this
            // takes particular card type and calculates probability of drawing one of said type
        }
        public char Deal()
        {
            Random random = new Random();
            return (char) masterDeck[random.Next(0, masterDeck.Count)];
        }
    }
}
