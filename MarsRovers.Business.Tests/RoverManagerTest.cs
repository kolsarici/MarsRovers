using System;
using MarsRovers.Business.Concrete.Managers;
using MarsRovers.Entities.Concrete;
using NUnit.Framework;

namespace MarsRovers.Business.Tests
{
    public class RoverManagerTest
    {
        [SetUp]
        public void Setup()
        {
            PlateauManager.plateau = new Plateau();
            PlateauManager.plateau.MinX = 0;
            PlateauManager.plateau.MinY = 0;
            PlateauManager.plateau.MaxX = 5;
            PlateauManager.plateau.MaxY = 5;
        }

        [Test]
        public void Move()
        {
            Rover rover = new Rover();
            rover.Direction = Entities.Enums.Direction.N;
            rover.X = 1;
            rover.Y = 2;
            RoverManager roverManager = new RoverManager();
            roverManager.Move(rover);
            Assert.AreEqual(rover.X, 1);
            Assert.AreEqual(rover.Y, 3);
        }

        [Test]
        public void CalculateDirectionNandL()
        {
            RoverManager roverManager = new RoverManager();
            var direction = roverManager.CalculateDirection(Entities.Enums.Direction.N, Entities.Enums.Path.L);
            Assert.AreEqual(direction, Entities.Enums.Direction.W);
        }

        [Test]
        public void CalculateDirectionNandR()
        {
            RoverManager roverManager = new RoverManager();
            var direction = roverManager.CalculateDirection(Entities.Enums.Direction.N, Entities.Enums.Path.R);
            Assert.AreEqual(direction, Entities.Enums.Direction.E);
        }

        [Test]
        public void CalculateDirectionWandR()
        {
            RoverManager roverManager = new RoverManager();
            var direction = roverManager.CalculateDirection(Entities.Enums.Direction.W, Entities.Enums.Path.R);
            Assert.AreEqual(direction, Entities.Enums.Direction.N);
        }

        [Test]
        public void Calculate()
        {
            RoverManager roverManager = new RoverManager();
            var direction = roverManager.Calculate();
            Assert.AreEqual(direction, Entities.Enums.Direction.N);
        }
    }
}
