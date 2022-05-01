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
    class EventsLogicTest
    {
        IEventsLogic eventsLogic;
        Mock<IEventsRepository> mockrepo = new Mock<IEventsRepository>();

        public EventsLogicTest()
        {
            Clubs otkert = new Clubs { BaseTicketPrice = 4000, ClubID = 1, President="unkown" };
            Clubs peaches = new Clubs { BaseTicketPrice = 6000, ClubID = 2, President="Papp Gergely" };
            Clubs heaven = new Clubs { BaseTicketPrice = 10000, ClubID = 3, President="unkown" };
            
            var events = new List<Events>()
            {
                new Events()
                {
                    EventID=1,
                    ClubID=1,
                    Clubs = otkert,
                    Guests = new List<Guests>()
                    {
                        new Guests {GuestID =1},
                        new Guests {GuestID =2},
                        new Guests {GuestID =3}
                    }
                },
                new Events()
                {
                    EventID=2,
                    ClubID=2,
                    Clubs = peaches,
                    Guests = new List<Guests>()
                    {
                        new Guests {GuestID =4},
                        new Guests {GuestID =5}
                    }
                },
                new Events()
                {
                    EventID=3,
                    ClubID=3,
                    Clubs = heaven,
                    Guests = new List<Guests>()
                    {
                        new Guests {GuestID =6},
                        new Guests {GuestID =7},
                        new Guests {GuestID =8},
                        new Guests {GuestID =9},
                    }
                }
            }.AsQueryable();
            mockrepo.Setup(y => y.ReadAll()).Returns(events);
            eventsLogic = new EventsLogic(mockrepo.Object);

        }
        
        [Test]
        public void CheckCreate()
        {
            Assert.That(() => eventsLogic.Create(new Events { EventID = -1 }), Throws.Exception);
        }
        [Test]
        public void CheckTheMostPopularEvent()
        {
            //ACT
            var result = eventsLogic.TheMostPopularEvent();
            //ASSERT
            Assert.That(result.FirstOrDefault().EventID, Is.EqualTo(3));
            
        }
        [Test]
        public void CheckMostExpensiveEvents()
        {
            //ACT
            var result = eventsLogic.MostExpensiveEvents();
            //ASSERT
            Assert.That(result.FirstOrDefault().EventID, Is.EqualTo(3));
        }
        [Test]
        public void CheckEventsWithPresident()
        {
            var result = eventsLogic.EventsWithPresident();
            Assert.That(result.FirstOrDefault().EventID, Is.EqualTo(2));
        }
        
    }
}
