using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
//using UniEBoard.Model.Entities;

namespace UniEBoard.Entities.Test
{
    [TestFixture]
    public class ScheduleTests
    {  
        [Test]
        [Category("Positive Tests")]
        [Category("ScheduledFromDay")]
        public void Verify_ScheduledFromDay_When_ScheduledFrom_Has_Value_Pos()
        {
            /*Schedule schedule1 = new Schedule() { ScheduledFrom = new DateTime(2013, 8, 21, 15, 45, 0) };
            Schedule schedule2 = new Schedule() { ScheduledFrom = new DateTime(2012, 2, 28, 13, 15, 0) };
            Assert.AreEqual("Wednesday", schedule1.ScheduledFromDay);
            Assert.AreEqual("Tuesday", schedule2.ScheduledFromDay);*/
        }

        [Test]
        [Category("Positive Tests")]
        [Category("ScheduledToDay")]
        public void Verify_ScheduledToDay_When_ScheduledTo_Has_Value_Pos()
        {
            /*Schedule schedule1 = new Schedule() { ScheduledTo = new DateTime(2013, 8, 22, 15, 45, 0) };
            Schedule schedule2 = new Schedule() { ScheduledTo = new DateTime(2012, 2, 29, 13, 15, 0) };
            Assert.AreEqual("Thursday", schedule1.ScheduledToDay);
            Assert.AreEqual("Wednesday", schedule2.ScheduledToDay);*/
        }
    }
}
