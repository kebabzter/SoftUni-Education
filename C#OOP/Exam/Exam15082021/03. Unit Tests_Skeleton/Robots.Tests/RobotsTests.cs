namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;
        [SetUp]
        public void SetUp()
        {
            robot = new Robot("name",100);
        }

        [Test]
        public void CtorRobot()
        { 
            Assert.That(robot.Name, Is.EqualTo("name"));
            Assert.That(robot.MaximumBattery, Is.EqualTo(100));
            Assert.That(robot.Battery, Is.EqualTo(100));
        }


        [Test]
        public void CtorManagerCapacity()
        {
            manager = new RobotManager(200);
            Assert.That(manager.Capacity, Is.EqualTo(200));
        }

        [Test]
        public void CtorException()
        {
            Assert.Throws<ArgumentException>(()=> new RobotManager(-200));
        }

        [Test]
        public void Count()
        {
            manager = new RobotManager(200);
            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddRobot_ThrowException()
        {
            RobotManager rm = new RobotManager(10);
            rm.Add(robot);
            Assert.Throws<InvalidOperationException>(()=>rm.Add(robot));
        }

        [Test]
        public void AddRobot_ExceptionCapacity()
        {
            RobotManager rm = new RobotManager(2);
            rm.Add(robot);
            rm.Add(new Robot("roro", 12));
            Assert.Throws<InvalidOperationException>(() => rm.Add(new Robot("kkk", 11)));
        }

        [Test]
        public void RemoveRobot_ExceptionName()
        {
            RobotManager rm= new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            Robot robotRemove = new Robot("roro", 10);
            Assert.Throws<InvalidOperationException>(()=>rm.Remove("roro"));
        }


        [Test]
        public void RemoveRobot_Ok()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            Robot robotRemove = new Robot("roro", 10);
            rm.Remove("k");
            Assert.That(rm.Count,Is.EqualTo(1));
        }

        [Test]
        public void WorkRobot_ExceptionName()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            Robot robotRemove = new Robot("roro", 10);
            Assert.Throws<InvalidOperationException>(() => rm.Work("roro","job",2));
        }

        [Test]
        public void WorkRobot_Exception()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            Robot robotRemove = new Robot("roro", 10);
            Assert.Throws<InvalidOperationException>(() => rm.Work("name", "job", 280));
        }

        [Test]
        public void WorkRobot_Ok()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            rm.Work("name", "job", 10);
            Assert.That(robot.Battery,Is.EqualTo(90));
        }

        [Test]
        public void ChargeRobot_Exception()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            Robot robotRemove = new Robot("roro", 10);
            Assert.Throws<InvalidOperationException>(() => rm.Charge("roro"));
        }

        [Test]
        public void ChargeRobot_Ok()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Add(new Robot("k", 10));
            rm.Charge("name");
            Assert.That(robot.Battery, Is.EqualTo(100));
        }

        [Test]
        public void ChargeRobotWhitWork_Sccess()
        {
            RobotManager rm = new RobotManager(50);
            rm.Add(robot);
            rm.Work("name", "job", 5);
            rm.Charge("name");
            Assert.AreEqual(robot.Battery, 100);
            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
            Assert.That(robot.Battery, Is.EqualTo(robot.MaximumBattery));
        }
    }
}








