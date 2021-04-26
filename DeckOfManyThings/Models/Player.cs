using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace DeckOfManyThings.Models
{
    public class Player
    {
        private ArrayList hand;
        private String name;

        public Player(string username)
        {
            name = username;
            hand = new ArrayList();
        }

        public string getName() { return name; }

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
