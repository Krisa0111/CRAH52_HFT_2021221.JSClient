using ConsoleTools;
using CRAH52_HFT_2021221.Models;
using System;

namespace CRAH52_HFT_2021221.Client
{
    internal class Menu
    {
        private static void ClubsThatHeldEventsInTheSummer()
        {
            RestService restService = new RestService("http://localhost:30907");
            var result = restService.Get<Clubs>("stat/clubsthatheldeventsinthesummer");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        } // DONE

        private static void CreateClub()
        {
            RestService restService = new RestService("http://localhost:30907/clubs");
            Console.WriteLine("Type in club name: ");
            string clubname = Console.ReadLine();
            Console.WriteLine("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Base ticket price: ");
            int btprice = int.Parse(Console.ReadLine());
            Console.WriteLine("President name: ");
            string president = Console.ReadLine();
            Console.WriteLine("Add a short description: ");
            string shortdesc = Console.ReadLine();
            restService.Post<Clubs>(new Clubs()
            {
                ClubName = clubname,
                Capacity = capacity,
                BaseTicketPrice = btprice,
                President = president,
                ShortDesc = shortdesc
            }, "clubs");
        } // DONE

        private static void CreateEvent()
        {
            RestService restService = new RestService("http://localhost:30907/events");
            Console.WriteLine("Type in event name: ");
            string eventname = Console.ReadLine();
            Console.WriteLine("Add a short description: ");
            string shortdesc = Console.ReadLine();
            Console.WriteLine("Add a date in this format {yyyy mm dd}: ");
            string date = Console.ReadLine();
            Console.WriteLine("Add the id of the club:              (id 6 is free)");
            int id = int.Parse(Console.ReadLine());
            restService.Post<Events>(new Events()
            {
                EventName = eventname,
                EventShortDesc = shortdesc,
                Date = date,
                ClubID = id
            }, "events");
        } // DONE

        private static void CreateGuest()
        {
            RestService restService = new RestService("http://localhost:30907/guests");
            Console.WriteLine("Type in guest name: ");
            string guestname = Console.ReadLine();
            Console.WriteLine("Type in birthyear: ");
            int birthyear = int.Parse(Console.ReadLine());
            Console.WriteLine("Email adress: ");
            string email = Console.ReadLine();
            Console.WriteLine("Type in event id: ");
            int id = int.Parse(Console.ReadLine());
            restService.Post<Guests>(new Guests()
            {
                Name = guestname,
                BirthYear = birthyear,
                Email = email,
                EventID = id
            }, "guests");
        } // DONE
        private static void DeleteClub()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Type in club id that you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            restService.Delete(id, "clubs");
        } // DONE
        private static void DeleteEvent()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Type in event id that you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            restService.Delete(id, "events");

        } // DONE
        private static void DeleteGuest()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Type in guest id that you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            restService.Delete(id, "guests");
        } // DONE
        private static void EventsWithPresident()
        {
            RestService restService = new RestService("http://localhost:30907/events");
            var result = restService.Get<Events>("stat/eventswithpresident");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        } // DONE
        private static void MostExpensiveEvents()
        {
            RestService restService = new RestService("http://localhost:30907");
            var result = restService.Get<Events>("stat/mostexpensiveevents");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        } // DONE
        private static void ReadAllClubs()
        {

            RestService restService = new RestService("http://localhost:30907");
            var clubs = restService.Get<Clubs>("clubs");
            foreach (var item in clubs)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        } // DONE
        private static void ReadAllEvents()
        {

            RestService restService = new RestService("http://localhost:30907");
            var events = restService.Get<Events>("events");
            foreach (var item in events)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        } // DONE
        private static void ReadAllGuests()
        {

            RestService restService = new RestService("http://localhost:30907");
            var guests = restService.Get<Guests>("guests");
            foreach (var item in guests)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        } // DONE
        private static void ReadOneClub()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Give a club Id: ");
            int id = int.Parse(Console.ReadLine());
            var club = restService.Get<Clubs>(id, "clubs");
            Console.WriteLine(club.ToString());
            Console.ReadLine();
        } // DONE
        private static void ReadOneEvent()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Give an event Id: ");
            int id = int.Parse(Console.ReadLine());
            var events = restService.Get<Events>(id, "events");
            Console.WriteLine(events.ToString());
            Console.ReadLine();
        } // DONE
        private static void ReadOneGuest()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Give an ID: ");
            int id = int.Parse(Console.ReadLine());
            var guest = restService.Get<Guests>(id, "guests");
            Console.WriteLine(guest.ToString());
            Console.ReadLine();
        } // DONE

        public static void Showmenu(string[] args)
        {
            var subMenuClubs = new ConsoleMenu(args, level: 1)
                            .Add("Create a club", () => CreateClub())
                            .Add("Read all clubs", () => ReadAllClubs())
                            .Add("Read one club", () => ReadOneClub())
                            .Add("Update a club ", () => UpdateClub())
                            .Add("Delete a club", () => DeleteClub())
                            .Add("Clubs that held event in summer", () => ClubsThatHeldEventsInTheSummer())
                            .Add("Sub_Close", ConsoleMenu.Close)
                            .Configure(config =>
                            {
                                config.Selector = "--> ";
                                config.EnableFilter = true;
                                config.Title = "Submenu of clubs";
                                config.EnableBreadcrumb = true;
                                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                            });
            var subMenuGuests = new ConsoleMenu(args, level: 1)
                .Add("Create a guest", () => CreateGuest())
                .Add("Read all guests", () => ReadAllGuests())
                .Add("Read one guest", () => ReadOneGuest())
                .Add("Update a guest ", () => UpdateGuest())
                .Add("Delete a guest", () => DeleteGuest())
                .Add("Youngest person on coronita event", () => YoungestPersonOnCoronita())
                .Add("Sub_Close", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu of guests";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });
            var subMenuEvents = new ConsoleMenu(args, level: 1)
                .Add("Create an event", () => CreateEvent())
                .Add("Read all events", () => ReadAllEvents())
                .Add("Read one event", () => ReadOneEvent())
                .Add("Update an event", () => UpdateEvent())
                .Add("Delete an event", () => DeleteEvent())
                .Add("The most expensive event", () => MostExpensiveEvents())
                .Add("The most popular event", () => TheMostPopularEvent())
                .Add("Events with president", () => EventsWithPresident())
                .Add("Sub_Close", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu of events";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            var menu = new ConsoleMenu(args, level: 0)

              .Add("Clubs", subMenuClubs.Show)
              .Add("Guests", subMenuGuests.Show)
              .Add("Events", subMenuEvents.Show)
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = true;
                  config.Title = "ClubsDb CRUD";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = true;
              });

            menu.Show();
        }
        private static void TheMostPopularEvent()
        {
            RestService restService = new RestService("http://localhost:30907");
            var result = restService.Get<Events>("stat/themostpopularevent");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        } // DONE
        private static void UpdateClub()
        {
            RestService restService = new RestService("http://localhost:30907");
            Console.WriteLine("Enter a new ClubId: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Club name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the new name of the president or unkown: ");
            string president = Console.ReadLine();
            Console.WriteLine("Enter a new short description: ");
            string shortdesc = Console.ReadLine();
            Console.WriteLine("Enter a new base ticket price: ");
            int ticket = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            restService.Put(new Clubs
            {
                ClubID = id,
                ClubName = name,
                President = president,
                ShortDesc = shortdesc,
                BaseTicketPrice = ticket,
                Capacity = capacity
            }, "clubs");
            Console.WriteLine("updated");

        } //DONE
        private static void UpdateEvent()
        {
            RestService restService = new RestService("http://localhost:30907/events");
            Console.WriteLine("Enter new event Id: ");
            int eventid = int.Parse(Console.ReadLine());
            Console.WriteLine("Type in a new event name: ");
            string eventname = Console.ReadLine();
            Console.WriteLine("Add a new short description: ");
            string shortdesc = Console.ReadLine();
            Console.WriteLine("Add a new date in this format {yyyy mm dd}: ");
            string date = Console.ReadLine();
            Console.WriteLine("Add the new id of the club:              (id 6 is free)");
            int id = int.Parse(Console.ReadLine());
            restService.Put<Events>(new Events()
            {
                EventID = eventid,
                EventName = eventname,
                EventShortDesc = shortdesc,
                Date = date,
                ClubID = id
            }, "events");
            Console.WriteLine("updated");
        }
        private static void UpdateGuest()
        {
            RestService restService = new RestService("http://localhost:30907/guests");
            Console.WriteLine("Enter a new GuestID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Type in a new guest name: ");
            string guestname = Console.ReadLine();
            Console.WriteLine("Type in a new birthyear: ");
            int birthyear = int.Parse(Console.ReadLine());
            Console.WriteLine("New email adress: ");
            string email = Console.ReadLine();
            Console.WriteLine("Type in a new event id: ");
            int eventid = int.Parse(Console.ReadLine());
            restService.Put<Guests>(new Guests()
            {
                GuestID = id,
                Name = guestname,
                BirthYear = birthyear,
                Email = email,
                EventID = eventid
            }, "guests");
            Console.WriteLine("updated");
        }
        private static void YoungestPersonOnCoronita()
        {
            RestService restService = new RestService("http://localhost:30907");
            var result = restService.Get<Guests>("stat/youngestpersononcoronita");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        } // DONE
    }
}