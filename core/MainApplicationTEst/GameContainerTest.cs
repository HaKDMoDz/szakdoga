using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainApplication.Component;
using core;
using Moq;
using core.Service;

namespace MainApplicationTEst
{
    /// <summary>
    /// Summary description for GameContainer
    /// </summary>
    [TestClass]
    public class GameContainerTest
    {
        private GameContainer underTest;
        private Game game;

        public GameContainerTest()
        {
            game = Mock.Of<Game>();
            underTest = new GameContainer(game);
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
        public void testGetObject()
        {
            //given
            underTest.start();

            //when
            PlayerService actual = underTest.getObject<PlayerService>("playerService");

            //then
            Assert.IsNotNull(actual);
        }
    }
}
