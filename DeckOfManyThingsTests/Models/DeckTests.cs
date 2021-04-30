using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckOfManyThings.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfManyThings.Models.Tests
{
    [TestClass()]
    public class DeckTests
    {
        const int TOP_CARD_VALUE = 14;
        const Card.Suit TOP_CARD_SUIT = Card.Suit.Club;
        const int NUMBER_OF_CARDS = 52;
        const int NUMBER_OF_CARDS_TO_DRAW = 5;
        const int TOO_MANY_CARDS_TO_DRAW = 56;
        const int DRAW_ONE = 1;
        const int RANDOM_CARD_VALUE = 11;
        const Card.Suit RANDOM_CARD_SUIT = Card.Suit.Heart;

        // component under test;
        Deck CuT;

        /*
         * Setup method for the Deck test, initializes CuT.
         */
        [TestInitialize]
        public void Setup()
        {
            // initialize unit under test.
            CuT = new Deck();
        }

        /*
         * Test for deck constructor. Checks for 52 cards in the deck, and that 
         * the top card is the expected card.
         */
        [TestMethod()]
        public void DeckTest()
        {
            // Checks for 52 cards
            Assert.AreEqual(NUMBER_OF_CARDS, CuT.cardsLeft());

            // Checks top card of unshuffled deck is Ace of clubs
            Card expectedTopCard = new Card(TOP_CARD_VALUE, TOP_CARD_SUIT);
            Assert.AreEqual(expectedTopCard, CuT.drawMultiple(1)[0]);
        }

        /*
         * tests a shuffled deck is different from the origional
         * as a shuffled deck only has a 1/52! chance to be the same.
         */
        [TestMethod()]
        public void shuffleTest()
        {
            // stores decks initial state
            String originalState = CuT.toString();
            // shuffle the deck
            CuT.shuffle();
            // checks origional state isn't equal to the shuffled deck
            Assert.AreNotEqual(originalState, CuT.toString());
        }

        /*
         * Test method for drawing multiple cards. Checks the top card is 
         * correctly draw. Checks if the number of cards drawn is correct and
         * tries to draw too many cards.
         */
        [TestMethod()]
        public void drawMultipleTest()
        {
            // Checks top card of unshuffled deck is Ace of clubs
            Card expectedTopCard = new Card(TOP_CARD_VALUE, TOP_CARD_SUIT);
            Assert.AreEqual(expectedTopCard, CuT.drawMultiple(DRAW_ONE)[0]);

            // Checks correct number is drawn
            var hand = CuT.drawMultiple(NUMBER_OF_CARDS_TO_DRAW);
            Assert.AreEqual(NUMBER_OF_CARDS_TO_DRAW, hand.Length);

            // Try to draw too many cards.
            try
            {
                CuT.drawMultiple(TOO_MANY_CARDS_TO_DRAW);
                // fail if exception is not thrown.
                Assert.Fail();
            }
            catch (Exception) { };
        }

        /*
         * Tests the still in deck method to see if cards existed in a deck
         */
        [TestMethod()]
        public void stillInDeckTest()
        {
            // checks for random card which should be in deck
            Card card = new Card(RANDOM_CARD_VALUE, RANDOM_CARD_SUIT);
            Assert.IsTrue(CuT.stillInDeck(card));

            // checks a drawn card is no longer in the deck
            Card missingCard = CuT.drawMultiple(DRAW_ONE)[0];
            Assert.IsFalse(CuT.stillInDeck(missingCard));
        }

        /*
         * Tests the cards left method to see if it accurately reports cards left;
         */
        [TestMethod()]
        public void cardsLeftTest()
        {
            Assert.AreEqual(NUMBER_OF_CARDS, CuT.cardsLeft());

        }

        /*
         * Checks the two string of equal decks are equal.
         */
        [TestMethod()]
        public void toStringTest()
        {
            // makes test deck
            Deck test = new Deck();
            // same deck strings are equal
            Assert.AreEqual(test.toString(), CuT.toString());
            // tostring shouldn't equal empty string
            Assert.AreNotEqual("", CuT.toString());
            // shuffled deck to string shouldn't be equal to unshuffled deck.
            CuT.shuffle();
            Assert.AreNotEqual(test.toString(), CuT.toString());
        }
    }
}