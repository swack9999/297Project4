/*
 * Player.cs
 * Authors: Spencer Wack, Matthew London, Monzur Ahmed
 * Creation Date: 2/20/2018
 */
using System.Collections;
using System;
namespace _297Project4
{
    public class Player
    {
        // game constants
        public static int FACE_CARD_VALUE = 10;
        public static int SOFT_ACE_VALUE = 11;
        public static int HARD_ACE_VALUE = 1;
        public static int BLACKJACK = 21;

        protected ArrayList playerHand;
        private int money;                                          // in USD
        public int Money { get => money; set => money = value; }

        public Player(char card1, char card2)
        {
            // set hand
            playerHand = new ArrayList();
            playerHand.Add(card1);
            playerHand.Add(card2);

            // set initial amount of money
            money = 100;
        }
        public void HitMe(char card) { playerHand.Add(card); }
        public void Stand() { return; }
        public void Split()
        {
            //TODO: implement split
        }
        public void DoubleDown()
        {
            //TODO: implement this
        }
        public bool BustedCheck(ArrayList hand)
        {
            // sort given hand
            ArrayList tempCards = hand;
            tempCards.Sort();
            // append aces to end in order to determine soft/hard aces
            tempCards = AppendAcesToEndOfArrayList(tempCards);

            // get total for given hand
            int sum = 0;
            foreach (char card in tempCards)
            {
                switch (card)
                {
                    case 'A':                // hard v soft hand determination http://www.countingedge.com/soft-hands-and-hard-hands-in-blackjack/
                        sum += (sum + SOFT_ACE_VALUE > BLACKJACK) ? HARD_ACE_VALUE : SOFT_ACE_VALUE;
                        break;
                    case 'J':
                    case 'Q':
                    case 'K':
                        sum += FACE_CARD_VALUE;
                        break;
                    default:                // all non-face cards are just converted to their corresponding integer values
                        sum += (int)Char.GetNumericValue(card);
                        break;
                }
            }
            return (sum > BLACKJACK) ? true : false;
        }
        private ArrayList AppendAcesToEndOfArrayList(ArrayList cards)
        {
            // assumes cards is already sorted
            ArrayList result = cards;
            int aceNum = 0;
            // count up and remove all initial aces
            for (int index = 0; index < result.Count; index++)
            {
                if ((char) cards[index] == 'A')
                {
                    aceNum++;
                    result.RemoveAt(index);
                    index--;
                }
            }
            // append aces to end as necessary
            for (int index = 0; index < aceNum; index++) { cards.Add('A'); }
            return result;
        }
    }
}