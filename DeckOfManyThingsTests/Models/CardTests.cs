using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeckOfManyThings.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfManyThings.Models.Tests
{
    [TestClass()]
    public class CardTests
    {
        // valid values for a new card
        const int CARD_VALUE = 2;
        const Card.Suit CARD_SUIT = Card.Suit.Club;

        // invalid values
        const int BAD_CARD_VALUE_LOW = 0;
        const int BAD_CARD_VALUE_HIGH = 50;

        // expected tostring
        const string CUT_STRING = "2 of clubs";

        // component under test;
        Card CuT;

        /*
         * Setup method for the Card test, initializes CuT.
         */
        [TestInitialize]
        public void Setup()
        {
            // initialize unit under test.
            CuT = new Card(CARD_VALUE, CARD_SUIT);
        }

        [TestMethod()]
        public void CardTest()
        {
            // makes sure card value too low fails.
            try
            {
                // should always throw exception.
                Card failure = new Card(BAD_CARD_VALUE_LOW, CARD_SUIT);
                Assert.Fail();
            }
            catch (Exception) { }

            // makes sure card value too high fails.
            try
            {
                // should always throw exception.
                Card failure = new Card(BAD_CARD_VALUE_HIGH, CARD_SUIT);
                Assert.Fail();
            }
            catch (Exception) { }
        }

        /*
         * Tests to see if toString method returns expected results.
         */
        [TestMethod()]
        public void toStringTest()
        {
            // Checks that the tostring method is equal to expected string.
            Assert.AreEqual(CUT_STRING, CuT.toString());
        }

        /*
         * Tests to see if overriden equals method works correctly for all cases.
         */
        [TestMethod()]
        public void EqualsTest()
        {
            // create an equal card
            Card equalCard = new Card(CARD_VALUE, CARD_SUIT);
            // check if equal card is equal
            Assert.AreEqual(equalCard, CuT);
            // check if same isntance is equal
            Assert.AreEqual(CuT, CuT);
            // check that null is not equal
            Assert.AreNotEqual(null, CuT);
            // check that different types are not equal
            Assert.AreNotEqual("test", CuT);
        }
    }
}