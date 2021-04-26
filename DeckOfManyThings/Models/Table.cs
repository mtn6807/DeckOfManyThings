using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfManyThings.Models
{
    public class Table
    {
        private IDictionary<string,Player> players;
        private Deck deck;
        private string id;

        public Table(string newID)
        {
            players = new Dictionary<string, Player>();
            deck = new Deck();
            id = newID;
        }

        public void addPlayer(Player newPlayer)
        {
            players.Add(newPlayer.getName(), newPlayer);
        }

        public Player getPlayer(string username)
        {
            return players[username];
        }

        public void removePlayer(string username)
        {
            players.Remove(username);
        }

        public void dealCards(int numOfCards, Player player)
        {
            var cardsToAdd = deck.drawMultiple(numOfCards);
            foreach(Card card in cardsToAdd) { player.addToHand(card); }
        }

        public void shuffle() {
            deck.shuffle();
        }

        public int cardsLeft()
        {
            return deck.cardsLeft();
        }

        public Boolean isEmpty()
        {
            if (players.Count <= 0)
            {
                return true;
            }
            return false;
        }

        public string getID()
        {
            return id;
        }
    }
}
