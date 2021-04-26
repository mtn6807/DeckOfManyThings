using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using DeckOfManyThings.Models;

namespace DeckOfManyThings.Application
{
    public class Dealer
    {
        private Deck deck;
        private Hand hand;

        public Dealer()
        {
            deck = new Deck();
            hand = new Hand();
        }

        public void dealOneToHand()
        {
            hand.addToHand(deck.draw());
        }

        public Hand getHand() { return hand; }
        public Deck getDeck() { return deck; }
    }
}
