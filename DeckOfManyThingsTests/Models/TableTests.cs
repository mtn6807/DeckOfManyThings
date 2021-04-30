using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckOfManyThings.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfManyThings.Models.Tests
{
    [TestClass()]
    public class TableTests
    {
        // declares constants
        const string TABLEID = "1";
        const string USERNAME = "user";
        const int NUMBEROFCARDS = 1;
        const int TOP_CARD_VALUE = 14;
        const int CARDSINDECK = 52;
        const Card.Suit TOP_CARD_SUIT = Card.Suit.Club;

        // component under test;
        Table CuT;

        /*
         * Setup method for the Table test, initializes CuT.
         */
        [TestInitialize]
        public void Setup()
        {
            // initialize unit under test.
            CuT = new Table(TABLEID);
        }

        /*
         * Checks that the id field is set correctly
         */
        [TestMethod()]
        public void TableTest()
        {
            // checks the id is set correctly
            Assert.AreEqual(TABLEID, CuT.getID());
        }

        /*
         * Checks if players get accurately added to the dict and the getter 
         * works. As well as removing a player.
         */
        [TestMethod()]
        public void playerMovementTest()
        {
            // initializes new player
            Player testPlayer = new Player(USERNAME);

            // add player to the table
            CuT.addPlayer(testPlayer);

            // checks if player is at the table
            Assert.AreEqual(testPlayer,CuT.getPlayer(USERNAME));

            // remove the player
            CuT.removePlayer(USERNAME);

            // trys to access removed player
            try
            {
                CuT.getPlayer(USERNAME);
                Assert.Fail();
            }
            catch(Exception) { }
        }

        /*
         * deals a number of cards to a player
         */
        [TestMethod()]
        public void dealCardsTest()
        {
            // make a mock player
            Player player = new Player(USERNAME);

            // add player to table
            CuT.addPlayer(player);

            // deal 1 card to the player
            CuT.dealCards(NUMBEROFCARDS, player);

            // check the hand size is equal
            Assert.AreEqual(NUMBEROFCARDS, player.getHand().Count);
        }

        /*
         * Checks if the shuffled deck doesn't return the default top
         */
        [TestMethod()]
        public void shuffleTest()
        {
            // make a mock player
            Player player = new Player(USERNAME);

            // add player to table
            CuT.addPlayer(player);

            // shuffle
            CuT.shuffle();

            // deal 1 card to the player
            CuT.dealCards(NUMBEROFCARDS, player);
            
            // Create expected top card
            Card expectedTopCard = new Card(TOP_CARD_VALUE, TOP_CARD_SUIT);

            // check the top card wouldn't be in the top spot after shuffling
            Assert.AreNotEqual(expectedTopCard, player.getHand()[0]);
        }

        /*
         * checks that the cards left in the deck are accurate.
         */
        [TestMethod()]
        public void cardsLeftTest()
        {
            // checks the deck has 52 cards.
            Assert.AreEqual(CARDSINDECK, CuT.cardsLeft());
            
            // make a mock player
            Player player = new Player(USERNAME);

            // add player to table
            CuT.addPlayer(player);

            // deal 1 card to the player
            CuT.dealCards(NUMBEROFCARDS, player);

            // checks the deck has 51 cards.
            Assert.AreEqual(CARDSINDECK-NUMBEROFCARDS, CuT.cardsLeft());
        }

        /*
         * Checks if the table is empty.
         */
        [TestMethod()]
        public void isEmptyTest()
        {
            // checks an empty table will return true
            Assert.IsTrue(CuT.isEmpty());

            // make a mock player
            Player player = new Player(USERNAME);

            // add player to table
            CuT.addPlayer(player);

            // checks a table with stuff in it is false
            Assert.IsFalse(CuT.isEmpty());
        }
    }
}