using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfManyThings.Models
{
    public class Hand
    {
        private ArrayList hand;
        public Hand()
        {
            hand = new ArrayList();
        }

        public void addToHand(Card card)
        {
            hand.Add(card);
        }

        public ArrayList getHand()
        {
            return hand;
        }
    }
}
