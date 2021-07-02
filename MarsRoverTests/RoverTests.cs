using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover rover = new Rover(10);
            Assert.AreEqual(rover.Position, 10);

        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover rover = new Rover(10);
            Assert.AreEqual(rover.Mode, "NORMAL");
        }
        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover rover = new Rover(10);
            Assert.AreEqual(rover.GeneratorWatts, 110);
        }

        
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover rover = new Rover(100);
            Command[] commands = { new Command("MODE_CHANGE", 0,  "LOW_POWER") };
            Message message = new Message("MODE_CHANGE", commands);
            rover.ReceiveMessage(message);
            Assert.AreEqual(rover.Mode, "LOW_POWER");

        }
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Rover rover = new Rover(100);
            Command[] commands = { new Command("MODE_CHANGE", 200, "LOW_POWER") };
            Message message = new Message("MOVE", commands);
            rover.ReceiveMessage(message);
            Assert.AreEqual(100, rover.Position);

        }
        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover rover = new Rover(52634);
            Command[] commands = { new Command("MOVE", 2465) };
            Message message = new Message("MOVE", commands);
            rover.ReceiveMessage(message);
            Assert.AreEqual(2465, rover.Position);
        }
        [TestMethod]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {

            try
            {
                new Command("a",0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Invald input", ex.Message);
            }

        }
    }
}
