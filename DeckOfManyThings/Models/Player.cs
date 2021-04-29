using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace DeckOfManyThings.Models
{
    /*
     * Class representing a player.
     */
    public class Player
    {
        // arraylist representing a players hand.
        private ArrayList hand;
        // a player's username.
        private string name;

        /*
         * A constructor which takes a username assigns to the field and builds 
         * an array list to store as a hand.
         * 
         * @param username - a username for the player
         */
        public Player(string username)
        {
            // sets name field
            name = username;

            // initializes hand variable.
            hand = new ArrayList();
        }

        /*
         * A getter for name
         * 
         * @return the instance name field.
         */
        public string getName() { return name; }

        /*
         * Adds a card to the players hand.
         * 
         * @param card - the card to put in the player's hand
         */
        public void addToHand(Card card)
        {
            // adds card to the player's hand
            hand.Add(card);
        }

        /*
         * A getter for the player's hand
         * @return the player's hand
         */
        public ArrayList getHand()
        {
            return hand;
        }
    }
}
