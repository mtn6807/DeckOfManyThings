using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfManyThings.Models
{
    /*
     * A class representing a table with players and a deck.
     */
    public class Table
    {
        // dictionary with usernames refrenceng player objects.
        private IDictionary<string,Player> players;

        // deck object for the table.
        private Deck deck;

        // id representing the table.
        private string id;

        /*
         * Constructor for the table class which instantiates the deck and 
         * players dictioanry. As well as sets the id field.
         * 
         * @param newID - an id for the table.
         */
        public Table(string newID)
        {
            players = new Dictionary<string, Player>();
            deck = new Deck();
            id = newID;
        }

        /*
         * Adds a player to the table.
         * 
         * @param newPlayer - a player obj to be added to the table.
         */
        public void addPlayer(Player newPlayer)
        {
            // adds the player into the dictionary.
            players.Add(newPlayer.getName(), newPlayer);
        }

        /*
         * Get the player object via the username in the dictionary.
         * 
         * @param username - the players username
         * @return the player object
         */
        public Player getPlayer(string username)
        {
            // pull the player from dict via username.
            return players[username];
        }

        /*
         * Remove the player from the players dictionary and therfore the table.
         * 
         * @param username - the players username
         */
        public void removePlayer(string username)
        {
            // removes player from dictionary
            players.Remove(username);
        }

        /*
         * deals a number of cards to a specified player.
         * 
         * @param numOfCards - a number of cards to deal
         * @param player - the player to deal cards to
         */
        public void dealCards(int numOfCards, Player player)
        {
            // draws cards from the deck
            var cardsToAdd = deck.drawMultiple(numOfCards);
            // adds every card to the players hand
            foreach(Card card in cardsToAdd) { player.addToHand(card); }
        }

        /*
         * Shuffles the tables deck
         */
        public void shuffle() {
            // shuffle the deck
            deck.shuffle();
        }

        /*
         * returns the number of cards left in the table's deck.
         * @return an int with cards left
         */
        public int cardsLeft()
        {
            return deck.cardsLeft();
        }

        /*
         * checks if the table has any players at it.
         * 
         * @return a boolean representing if there are players left.
         */
        public Boolean isEmpty()
        {
            if (players.Count <= 0)
            {
                return true;
            }
            return false;
        }

        /*
         * getter for the table's id.
         * @return the table's id.
         */
        public string getID()
        {
            return id;
        }
    }
}
