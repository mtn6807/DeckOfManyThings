using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfManyThings.Models
{
    /*
     * Class representing a deck of cards.
     */
    public class Deck
    {
        private const int DECK_SIZE = 52; // const for deck size
        private Stack<Card> deck = new Stack<Card>(); // stack representing a stack

        /*
         * Constructor for the deck object
        */
        public Deck()
        {
            int currentValue = 2; // current value for card
            
            // add 52 cards to the deck and increment the value every 4
            for (int deckIndex=0; deckIndex<=DECK_SIZE-1; deckIndex++)
            {
                if (deckIndex % 4 == 0)
                {
                    deck.Push(new Card(currentValue, Card.Suit.Heart));
                }
                if (deckIndex % 4 == 1)
                {
                    deck.Push(new Card(currentValue, Card.Suit.Spade));
                }
                if (deckIndex % 4 == 2)
                {
                    deck.Push(new Card(currentValue, Card.Suit.Diamond));
                }
                if (deckIndex % 4 == 3)
                {
                    deck.Push(new Card(currentValue, Card.Suit.Club));
                    currentValue++;
                }
            }    
            
        }

        /*
         * shuffles the cards in the stack
        */
        public void shuffle()
        {
            // pulls in a random object.
            Random rng = new Random();

            // turns the stack into an array.
            var toShuffle = deck.ToArray();

            // gets the decks size.
            int maxLen = toShuffle.Length;

            // for loop to iterate through every card.
            for (int deckIndex = 0; deckIndex <= maxLen-1; deckIndex++)
            {
                // grabs a random number in the range or cards in the deck.
                int randomIndex = rng.Next(0, maxLen-1);

                // stores card which will be replaced
                Card swap = toShuffle[deckIndex];
                
                // replaces the card with the random card.
                toShuffle[deckIndex] = toShuffle[randomIndex];
                
                // puts stored card in the random spot.
                toShuffle[randomIndex] = swap;
            }

            // clears the stack and replaces the contents with the new stack.
            deck.Clear();
            foreach (var card in toShuffle)
            {
                deck.Push(card);
            }
        }

        /*
         * draw one card of the top of the deck.
         * 
         * @return a drawn card.
        */
        private Card draw()
        {
            // if the deck is too small throw an exception
            if (deck.Count() < 1)
            {
                throw new ArgumentException("there are no more cards to draw.");
            }

            // pop the top card of the stack and return it.
            return deck.Pop();
        }

        /*
         * draw a number of cards specified
         * @param numToDraw - a number of cards to draw.
         * @return an array of cards with size of param
        */
        public Card[] drawMultiple(int numToDraw)
        {
            // throw an exception if there aren't enough cards left.
            if (deck.Count() < numToDraw)
            {
                throw new ArgumentException("there are not enough cards to draw that many.");
            }

            // creates an array for drawn cards.
            Card[] hand = new Card[numToDraw];

            // draw cards to hand
            for(int i = 0; i<numToDraw; i++)
            {
                hand[i] = this.draw();
            }

            // return drawn cards.
            return hand;
        }

        /*
         * Checks if a given card is still in the deck.
         * 
         * @param card - a card to check if it exists in the deck
         * @return a boolean representing if the given card is in the deck
        */
        public Boolean stillInDeck(Card card)
        {
            foreach(Card currentCard in deck)
            {
                if (currentCard.Equals(card))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Returns how many cards are left in the deck
         * 
         * @return number of cards left
        */
        public int cardsLeft()
        {
            // counts the cards in the deck.
            return deck.Count();
        }

        /*
         * return a string representation of the deck
         * 
         * @return a string representing the deck
        */
        public string toString()
        {
            // makes a str for adding cards to
            var str = "";

            // add every card string to the temp str
            foreach (var card in deck)
            {
                str = str + card.toString() + ", ";
            }

            // return the temp string.
            return str;
        }

    }
}
