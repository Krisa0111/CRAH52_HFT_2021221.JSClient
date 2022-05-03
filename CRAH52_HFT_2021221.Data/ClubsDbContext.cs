using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRAH52_HFT_2021221.Models;

namespace CRAH52_HFT_2021221.Data
{
    public class ClubsDbContext : DbContext
    {
        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public ClubsDbContext()
        {
            
            this.Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ClubsDb.mdf;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clubs>(entity =>
            {
                
                entity.HasOne(x => x.Events)
                .WithOne(y => y.Clubs)
                .HasForeignKey<Events>(x => x.ClubID)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Events>().Property(eventsfk => eventsfk.ClubID).IsRequired(false);
                



            //It may differ from reality
            Clubs Otkert = new Clubs() { ClubID = 1, ClubName = "Ötkert", BaseTicketPrice = 2000, Capacity = 500, President = "unkown", ShortDesc = "Mainly hip-hop rnb music but they play techno in a smaller room" };
            Clubs Peaches = new Clubs { ClubID = 2, ClubName = "Peaches and Cream", BaseTicketPrice = 4000, Capacity = 300, President = "Pap Gergely", ShortDesc = "Unlimited drink consumption is included in the price, mainly rnb music" };
            Clubs Akvarium = new Clubs { ClubID = 3, ClubName = "Akvárium", BaseTicketPrice = 3000, Capacity = 700, President = "unkown", ShortDesc = "This club is a popular host of bigger events like neccparty or bigger techno events" };
            Clubs Heaven = new Clubs { ClubID = 4, ClubName = "Heaven", BaseTicketPrice = 3000, Capacity = 700, President = "unkown", ShortDesc = "Spacious spaces with techno and hip-hop music" ,};
            Clubs Cat = new Clubs { ClubID = 5, ClubName = "Cat Budapest", BaseTicketPrice = 2000, Capacity = 300, President = "unkown", ShortDesc = "Techno music, nice ligh equipment" };
            Clubs Mousoleum = new Clubs { ClubID = 6, ClubName = "Club Mousoleum", BaseTicketPrice = 2000, Capacity = 300, President = "unkown", ShortDesc = "Little place in Vác" };
            
            Events LLJuniorNight = new Events { EventID = 1, Date = "2021 09 13", EventName = "LL Junior in Peaches", EventShortDesc = "LL Junior performed hungarian music" };
            Events Neccparty = new Events { EventID = 2, ClubID = Akvarium.ClubID, Date = "2021 09 24", EventName = "Neccparty by Spanis wax", EventShortDesc = "All kinds of gas music" };
            Events Krubi = new Events { EventID = 3, ClubID = Heaven.ClubID, Date = "2021 08 10", EventName = "Krúbi in Heaven", EventShortDesc = "Krúbi performed in Club Heaven" };
            Events Coronita = new Events { EventID = 4, ClubID = Cat.ClubID, Date = "2021 10 05", EventName = "Coronita", EventShortDesc = "Techno music from 5 am till 13 pm" };
            Events OneDance = new Events { EventID = 5, ClubID = Otkert.ClubID, Date = "2021 10 01", EventName = "OnceDance", EventShortDesc = "OneDance is party series arranged every Thursday" };




            Guests Bela = new Guests { GuestID = 1, Name = "Nagy Béla", BirthYear = 2000, Email = "nagy.bela00@gmail.com",EventID = Coronita.EventID};
            Guests Akos = new Guests { GuestID = 2, Name = "Kis Ákos", BirthYear = 1999, Email = "kis.akos99@gmail.com", EventID = Coronita.EventID};
            Guests Zoltan = new Guests { GuestID = 3, Name = "Csintalan Zoltán", BirthYear = 2001, Email = "zoltan.csintalan01@gmail.com", EventID = Krubi.EventID };
            Guests Bence = new Guests { GuestID = 4, Name = "Pálinkás Bence", BirthYear = 1998, Email = "palinkas.bence98@gmail.com", EventID = LLJuniorNight.EventID };
            Guests Roland = new Guests { GuestID = 5, Name = "Balogh Roland", BirthYear = 1990, Email = "balogh.rolika@gmail.com",EventID = Krubi.EventID };
            Guests Zsolt = new Guests { GuestID = 6, Name = "Alkar Zsolt", BirthYear = 2000, Email = "alkar.zsoltika@freemail.hu", EventID = OneDance.EventID };
            Guests Abraham = new Guests { GuestID = 7, Name = "Lelkes Ábrahám", BirthYear = 1989, Email = "lelkesabraham@freemail.hu", EventID = Neccparty.EventID };
            Guests Jozsef = new Guests { GuestID = 8, Name = "Nagy József", BirthYear = 1985, Email = "nagy.jozsef85@gmail.com",EventID = Coronita.EventID };

            modelBuilder.Entity<Clubs>().HasData(Otkert, Peaches, Akvarium, Heaven, Cat,Mousoleum);
            modelBuilder.Entity<Events>().HasData(Coronita, Neccparty, LLJuniorNight, Krubi, OneDance);
            modelBuilder.Entity<Guests>().HasData(Bela, Akos, Zoltan, Bence, Roland, Zsolt, Abraham, Jozsef);
        }

    }
}
