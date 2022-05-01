using CRAH52_HFT_2021221.Logic;
using CRAH52_HFT_2021221.Models;
using CRAH52_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Test
{
    [TestFixture]
    class GuestLogicTest
    {
        IGuestsLogic guestsLogic;
        Mock<IGuestsRepository> mockrepo = new Mock<IGuestsRepository>();
        
        public GuestLogicTest()
        {
            Events coronita = new Events { EventID = 4 ,EventName="Coronita"};
            var guest = new List<Guests>()
            {
                new Guests()
                {
                    GuestID=1,
                    BirthYear=2000,
                    Event = coronita
                },
                new Guests()
                {
                    GuestID=2,
                    BirthYear=1965,
                    Event = coronita
                },
                new Guests()
                {
                    GuestID=3,
                    BirthYear=1967,
                    Event = coronita
                }
            }.AsQueryable();
            mockrepo.Setup(y => y.ReadOne(1)).Returns(new Guests() { GuestID = 1 });
            mockrepo.Setup(x => x.ReadAll()).Returns(guest);
            guestsLogic = new GuestsLogic(mockrepo.Object);
        }
        [Test]
        public void CheckCreate()
        {
            Assert.That(() => guestsLogic.Create(new Guests { GuestID = -1 }), Throws.Exception);
        }
        [Test]
        public void CheckYoungestPersonOnCoronita()
        {
            var result = guestsLogic.YoungestPersonOnCoronita();
            Assert.That(result.FirstOrDefault().GuestID, Is.EqualTo(1));
        }
        [Test]
        public void CheckReadOne()
        {
            var result = guestsLogic.ReadOne(1);
            Assert.That(result.GuestID, Is.EqualTo(1));
        }
    }
}
