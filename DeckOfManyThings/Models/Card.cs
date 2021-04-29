using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DeckOfManyThings.Models
{
    /*
     * A class representing a card.
     */
    public class Card
    {
        /*
         * Enumeration representing the suit of a card.
        */
        public enum Suit
        {
            Club,
            Spade,
            Heart,
            Diamond
        }

        // constants representing card values which are not ints.
        private const int JACK = 11;
        private const int QUEEN = 12;
        private const int KING = 13;
        private const int ACE = 14;

        // constant for lowest card value.
        private const int LOWEST_CARD_VALUE = 1;
        private int cardValue;
        private Suit cardSuit;

        /*
         * Card constructor requires an integer in range 1-14 and a Suit.
        */
        public Card(int value, Suit suit)
        {
            // checks if the value is withing the correct range.
            if(value>=LOWEST_CARD_VALUE && value <= ACE)
            {
                // if it's in the right value it sets the fields
                cardValue = value;
                cardSuit = suit;
            }
            else
            {
                // if it's not throw an exception
                throw new ArgumentException("card value must be between in range 1-14");
            }
        }

        /*
         * to string method for a Card.
         * 
         * @return a string representing a card.
        */
        public string toString()
        {
            // builds a string 
            String temp = "";

            // adds the card value to the string.
            switch (this.cardValue)
            {
                case JACK:
                    temp = temp + "jack of ";
                    break;
                case QUEEN:
                    temp = temp + "queen of ";
                    break;
                case KING:
                    temp = temp + "king of ";
                    break;
                case ACE:
                    temp = temp + "ace of ";
                    break;
                default:
                    temp = temp + this.cardValue.ToString() + " of ";
                    break;
            }

            // adds the suit to the string.
            switch (this.cardSuit)
            {
                case Suit.Spade:
                    temp = temp + "spades";
                    break;
                case Suit.Club:
                    temp = temp + "clubs";
                    break;
                case Suit.Diamond:
                    temp = temp + "diamonds";
                    break;
                case Suit.Heart:
                    temp = temp + "hearts";
                    break;
            }

            return temp;
        }

        /*
         * overriden equals method for the Card object.
         * 
         * @return a boolean checking if two objects are equal.
        */
        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                return false;
            }
            else
            {
                Card compare = (Card)obj;
                return this.toString() == compare.toString();
            }
        }
    }
}
