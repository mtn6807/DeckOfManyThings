using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckOfManyThings.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DeckOfManyThings.Models.Tests
{
    [TestClass()]
    public class PlayerTests
    {

        const string USERNAME = "username";
        const string DIFF_USERNAME = "wrong";
        const int CARD_VALUE = 3;
        const Card.Suit CARD_SUIT = Card.Suit.Club;

        // Cut field
        Player CuT;

        /*
        * Setup method for the Player test, initializes CuT.
        */
        [TestInitialize]
        public void Setup()
        {
            // initialize unit under test.
            CuT = new Player(USERNAME);
        }

        /*
         * Test method for testing player constructor
         */
        [TestMethod()]
        public void PlayerTest()
        {
            // checks name field is set
            Assert.AreEqual(USERNAME, CuT.getName());

            // checks hand is empty 
            Assert.AreEqual(new ArrayList().Count, CuT.getHand().Count);
        }

        /*
         * Checks if the getter for name functions correct.
         */
        [TestMethod()]
        public void getNameTest()
        {
            // Is the getter working correctly
            Assert.AreEqual(USERNAME, CuT.getName());
            // Username is not equal to a different name
            Assert.AreNotEqual(DIFF_USERNAME, CuT.getName());
        }

        /*
         * Checks if cards can accurately be added to the hand
         */
        [TestMethod()]
        public void addToHandTest()
        {
            // makes an empty hand
            ArrayList hand = new ArrayList();
            // checks new player also has empty hand
            Assert.AreEqual(hand.Count, CuT.getHand().Count);
            // add a card to hand
            Card card = new Card(CARD_VALUE, CARD_SUIT);
            hand.Add(card);
            CuT.addToHand(card);
            // assert hands are same size
            Assert.AreEqual(hand.Count, CuT.getHand().Count);
        }

        /*
         * Checks if the getter for hand is accurate.
         */
        [TestMethod()]
        public void getHandTest()
        {
            // makes an empty hand
            ArrayList hand = new ArrayList();
            // checks new player also has empty hand
            Assert.AreEqual(hand.Count, CuT.getHand().Count);
            // add a card to hand
            Card card = new Card(CARD_VALUE, CARD_SUIT);
            hand.Add(card);
            CuT.addToHand(card);
            // assert hands are same size
            Assert.AreEqual(hand.Count, CuT.getHand().Count);
        }
    }
}