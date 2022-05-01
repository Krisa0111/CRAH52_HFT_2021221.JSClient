using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRAH52_HFT_2021221.Logic;
using Moq;
using CRAH52_HFT_2021221.Repository;
using CRAH52_HFT_2021221.Models;

namespace CRAH52_HFT_2021221.Test
{
    [TestFixture]
    class ClubsLogicTest
    {
        IClubsLogic clubsLogic;
        Mock<IClubsRepository> mockrepo = new Mock<IClubsRepository>();

        public ClubsLogicTest()
        {
            
            Events onedance = new Events { Date = "2021 07 05" };
            var clubs = new List<Clubs>()
            {
                new Clubs()
                {
                    ClubID =1,
                    ClubName="ötkert",
                    BaseTicketPrice =3000,
                    Events= new Events()
                    {
                        ClubID=1,
                        Date = "2021 06 11",
                        EventName = "onedance"
                    }

                },
                new Clubs()
                {
                    ClubID = 2,
                    ClubName="peaches",
                    BaseTicketPrice=2000,
                    Events = new Events()
                    {
                        ClubID=2,
                        Date = "2021 12 10",
                        EventName= "lljuniornight"
                    }
                },
                new Clubs()
                {
                    ClubID =3,
                    ClubName="cat",
                    BaseTicketPrice = 10000,
                    Events = new Events()
                    {
                        ClubID =3,
                        Date = "2021 07 30",
                        EventName ="coronita"
                    }
                }
            }.AsQueryable();

            mockrepo.Setup(x => x.ReadOne(1)).Returns(new Clubs() { ClubID = 1 });
            mockrepo.Setup(y => y.ReadAll()).Returns(clubs);
            clubsLogic = new ClubsLogic(mockrepo.Object);
        }
        [Test]
        public void CheckReadOne()
        {
            var result = clubsLogic.ReadOne(1);
            Assert.That(result.ClubID, Is.EqualTo(1));
        }


        
        [Test]
        public void CheckClubsThatHeldEventsInTheSummer()
        {
            
            //ACT
            var result = clubsLogic.ClubsThatHeldEventsInTheSummer();
            //ASSERT
            Assert.That(result.FirstOrDefault().ClubID, Is.EqualTo(1));
        }
        [Test]
        public void CheckCreate()
        {
            Assert.That(() => clubsLogic.Create(new Clubs { ClubID = -1 }), Throws.Exception);
        }
    }
}
