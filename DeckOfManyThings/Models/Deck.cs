using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfManyThings.Models
{
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
         * shuffles the deck.
         * @return void
        */
        public void shuffle()
        {
            Random rng = new Random();
            var toShuffle = deck.ToArray();
            int maxLen = toShuffle.Length;
            for (int deckIndex = 0; deckIndex <= maxLen-1; deckIndex++)
            {
                int randomIndex = rng.Next(0, maxLen-1);
                Card swap = toShuffle[deckIndex];
                toShuffle[deckIndex] = toShuffle[randomIndex];
                toShuffle[randomIndex] = swap;
            }

            deck.Clear();
            foreach (var card in toShuffle)
            {
                deck.Push(card);
            }
        }

        /*
         * draw one card of the top of the deck.
         * @return a drawn card.
        */
        private Card draw()
        {
            if (deck.Count() < 1)
            {
                throw new ArgumentException("there are no more cards to draw.");
            }
            return deck.Pop();
        }

        /*
         * draw a number of cards specified
         * @param numToDraw - a number of cards to draw.
         * @return an array of cards with size of param
        */
        public Card[] drawMultiple(int numToDraw)
        {
            if (deck.Count() < numToDraw)
            {
                throw new ArgumentException("there are not enough cards to draw that many.");
            }
            Card[] hand = new Card[numToDraw];
            for(int i = 0; i<numToDraw; i++)
            {
                hand[i] = this.draw();
            }
            return hand;
        }

        /*
         * checks if a given card is still in the deck.
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
         * returns how many cards are left in the deck
         * @return number of cards left
        */
        public int cardsLeft()
        {
            return deck.Count();
        }

        /*
         * return a string representation of the deck
        */
        public string toString()
        {
            var str = "";
            foreach (var card in deck)
            {
                str = str + card.toString() + " <br />";
            }
            return str;
        }

    }
}
