using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message(null, commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Name required.", ex.Message);
            }
        }
        [TestMethod]
        public void ConstructorSetsName()
        {
            Message message = new Message("First", commands);
            Assert.AreEqual(message.Name, "First");

        }
        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message message = new Message("First", commands);
            Assert.AreEqual(message.Commands, commands);
        }

    }
}
