using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.PlayerServices;
using core.Domain;
using core;
using Moq;
using core.Service;

namespace ServicesTests
{
    /// <summary>
    /// Summary description for SimplePlayerServiceTest
    /// </summary>
    [TestClass]
    public class SimplePlayerServiceTest
    {
        private SimplePlayerService underTest;
        private CombatService combatService;
        private Statistics statistics;

        public SimplePlayerServiceTest()
        {
            underTest = new SimplePlayerService(combatService, statistics);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testReceiveDamageShouldAliveWhenDamageLessThanHealtPoint()
        {
            //given
            Statistics player = new Statistics();
            player.HealthPoint = 10;
            underTest.Statistics = player;

            //when
            underTest.receiveDamage(2);

            Assert.AreEqual(8, player.HealthPoint);

        }

        [TestMethod]
        public void testReceiveDamageShouldDeadWhenDamageMoreThanHealtPoint()
        {
            //given
            Statistics player = new Statistics();
            player.HealthPoint = 5;
            underTest.Statistics = player;

            //when
            underTest.receiveDamage(7);

            Assert.AreEqual(true, player.IsDead);

        }

        [TestMethod]
        public void testReceiveDamageShouldDeadWhenDamageEqualsHealtPoint()
        {
            //given
            Statistics player = new Statistics();
            player.HealthPoint = 7;
            underTest.Statistics = player;

            //when
            underTest.receiveDamage(7);

            Assert.AreEqual(true, player.IsDead);

        }
    }
}
