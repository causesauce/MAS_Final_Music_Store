using MAS_Final_Music_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace MAS_Final_Music_Store.Services
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions options) : base(options)
        {

        }

        // specifying dbsets for db

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ElectricGuitar> ElectricGuitars { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventInstrument> EventInstruments { get; set; }
        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInstrument> OrderInstruments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SamplingPad> SamplingPads { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamEvent> TeamEvents { get; set; }
        public DbSet<Violin> Violins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=mas_final;Integrated Security=True");
        }

        // configuring db rules
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Brand brand1 = new Brand
            {
                BrandId = 1,
                Name = "Yamaha",
                YearEstablished = System.DateTime.Today.AddYears(-100),
                Logo = System.IO.File.ReadAllBytes(@"C:\Users\adria\source\repos\MAS_Final_Music_Store\Images\yamaha-logo.jpg")
            };

            Brand brand2 = new Brand
            {
                BrandId = 2,
                Name = "Fender",
                YearEstablished = System.DateTime.Today.AddYears(-40),
                Logo = System.IO.File.ReadAllBytes(@"C:\Users\adria\source\repos\MAS_Final_Music_Store\Images\fender_logo.jpg")
            };

            // Brand 
            builder.Entity<Brand>(entity =>
            {
                entity.ToTable(nameof(Brand));

                entity.HasKey(e => e.BrandId);
                entity.Property(e => e.BrandId).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.YearEstablished).IsRequired();
                entity.Property(e => e.Logo).HasColumnType("image");


                entity.HasData(brand1, brand2);
            });

            Contract contract1 = new Contract
            {
                ContractId = 1,
                StartDate = DateTime.Today.AddDays(-100),
                EndDate = DateTime.Today.AddYears(5),
                Content = "lorem ipsum",
                BrandId = brand1.BrandId
            };

            Contract contract2 = new Contract
            {
                ContractId = 2,
                StartDate = DateTime.Today.AddDays(-100),
                EndDate = DateTime.Today.AddYears(5),
                Content = "lorem ipsumlorem ipsumlorem ipsumlorem ipsumlorem ipsum",
                BrandId = brand2.BrandId
            };

            // Contract 
            builder.Entity<Contract>(entity =>
            {
                entity.ToTable(nameof(Contract));

                entity.HasKey(e => e.ContractId);
                entity.Property(e => e.ContractId).ValueGeneratedOnAdd();
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.HasOne(e => e.BrandIdNavigation)
                    .WithMany(b => b.Contracts)
                    .HasForeignKey(e => e.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);


            });

            Guitar instrument1 = new Guitar
            {
                InstrumentId = 1,
                Name = "H-40",
                Description = "desc1",
                Photo = null,
                Quantity = 10,
                StringsNum = 6,
                Material = "wood",
                Type = StringType.Steel,
                BrandId = brand1.BrandId
            };

            Guitar instrument2 = new Guitar
            {
                InstrumentId = 2,
                Name = "HQD-45",
                Description = "desc1",
                Photo = null,
                Quantity = 10,
                StringsNum = 6,
                Material = "wood",
                Type = StringType.Steel,
                BrandId = brand1.BrandId
            };

            // Guitar
            builder.Entity<Guitar>(entity => 
            {
                entity.Property(e => e.StringsNum).IsRequired();
                entity.Property(e => e.Material).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired();

                entity.HasData(instrument1, instrument2);
            });

            // Violin
            builder.Entity<Violin>(entity =>
            {
                entity.Property(e => e.StringsNum).IsRequired();
                entity.Property(e => e.Material).IsRequired().HasMaxLength(100);
                entity.Property(e => e.HasReplacementString).IsRequired();
                entity.Property(e => e.ShoulderRest).IsRequired();

            });

            ElectricGuitar instrument3 = new ElectricGuitar
            {
                InstrumentId = 3,
                Name = "Pacifica",
                Description = "desc1",
                Photo = null,
                Quantity = 40,
                StringsNum = 6,
                Material = "wood",
                Voltage = 20,
                Input = "inputdata",
                SinglesNum = 2,
                HumbuckersNum = 2,
                BrandId = brand1.BrandId
            };

            // ElectricGuitar
            builder.Entity<ElectricGuitar>(entity =>
            {
                entity.Property(e => e.StringsNum).IsRequired();
                entity.Property(e => e.Material).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Input).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Voltage).IsRequired();
                entity.Property(e => e.SinglesNum).IsRequired();
                entity.Property(e => e.HumbuckersNum).IsRequired();

                entity.HasData(instrument3);
            });

            // SamplingPad
            builder.Entity<SamplingPad>(entity =>
            {
                entity.Property(e => e.Input).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Voltage).IsRequired();
                entity.Property(e => e.NumberOfSquares).IsRequired();

            });

            Team team1 = new Team
            {
                TeamId = 1,
                Name = "team1"
            };

            Team team2 = new Team
            {
                TeamId = 2,
                Name = "team2"
            };

            // Team
            builder.Entity<Team>(entity => {
                entity.ToTable(nameof(Team));

                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.TeamId).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(e => e.Members)
                    .WithOne(m => m.MemberTeamIdNavigation)
                    .HasForeignKey(m => m.MemberTeamId).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(e => e.Managers)
                    .WithOne(m => m.ManagerTeamIdNavigation)
                    .HasForeignKey(m => m.ManagerTeamId).OnDelete(DeleteBehavior.Restrict);

                entity.HasData(team1, team2);
            });

            // Instruments
            builder.Entity<Instrument>(entity => 
            {
                entity.ToTable(nameof(Instrument));
                entity.HasDiscriminator<int>("InstrumentType")
                    .HasValue<SamplingPad>(1)
                    .HasValue<ElectricGuitar>(2)
                    .HasValue<Violin>(3)
                    .HasValue<Guitar>(4);

                entity.HasKey(e => e.InstrumentId);
                entity.Property(e => e.InstrumentId).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Photo).HasColumnType("image");
                entity.Property(e => e.Quantity).IsRequired();

                entity.HasOne(e => e.BrandIdNavigation)
                    .WithMany(b => b.Instruments)
                    .HasForeignKey(e => e.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            Person person1 = new Person 
            { 
                PersonId = 1, 
                Name = "name1",
                Surname = "surname1",
                Email = "email@email.com",
                PhoneNumber = "+123456789",
                Address = "some address",
                PersonTypes = new HashSet<PersonType> { PersonType.Customer}, 
                Balance = 1000,
                BonusPoints = 20,
                
            };

            Person person2 = new Person
            {
                PersonId = 2,
                Name = "name2",
                Surname = "surname2",
                Email = "email2@email.com",
                PhoneNumber = "+124456789",
                Address = "some address2",
                PersonTypes = new HashSet<PersonType> { PersonType.Worker },
                Salary = 2500,
                WorkerType = WorkerType.Delivery,
                MemberTeamId = team1.TeamId
            };

            Person person3 = new Person
            {
                PersonId = 3,
                Name = "name3",
                Surname = "surname3",
                Email = "email3@email.com",
                PhoneNumber = "+324456789",
                Address = "some address3",
                PersonTypes = new HashSet<PersonType> { PersonType.Worker },
                Salary = 2300,
                WorkerType = WorkerType.Manager,
                MemberTeamId = team1.TeamId,
                ManagerTeamId = team1.TeamId
            };

            // Person
            builder.Entity<Person>(entity => 
            {
                entity.ToTable(nameof(Person));

                entity.HasKey(e => e.PersonId);
                entity.Property(e => e.PersonId).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
                entity.Property(e => e.PersonTypes)
                    .HasConversion(new ValueConverter<HashSet<PersonType>, string>(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<HashSet<PersonType>>(v)
                        ));


                entity.Property(e => e.Balance);
                entity.Property(e => e.BonusPoints);

                entity.Property(e => e.Salary);

                entity.HasData(person1, person2, person3);
            });

            Order order1 = new Order
            {
                OrderId = 1, 
                Description = "order desc",
                Date = DateTime.Today.AddDays(-7),
                DeliveryAddress = "some address",
                OrderIsPaid = true,
                CustomerId = person1.PersonId
            };

            Order order2 = new Order
            {
                OrderId = 2,
                Description = "2order desc",
                Date = DateTime.Today.AddDays(-10),
                DeliveryAddress = "2some address",
                OrderIsPaid = false,
                CustomerId = person2.PersonId
            };

            Order order3 = new Order
            {
                OrderId = 3,
                Description = "3order desc",
                Date = DateTime.Today.AddDays(-6),
                DeliveryAddress = "3some address",
                OrderIsPaid = true,
                CustomerId = person1.PersonId
            };

            // Order
            builder.Entity<Order>(entity => {
                entity.ToTable(nameof(Order));

                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).ValueGeneratedOnAdd();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DeliveryAddress).IsRequired().HasMaxLength(500);
                entity.Property(e => e.OrderIsPaid).IsRequired();

                entity.HasOne(e => e.CustomerIdNavigation)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.CustomerId);

                entity.HasData(order1, order2, order3);
            });

            OrderInstrument orderInstrument1 = new()
            {
                OrderId = order1.OrderId,
                InstrumentId = instrument1.InstrumentId,
                Quantity = 2
            };

            OrderInstrument orderInstrument2 = new()
            {
                OrderId = order2.OrderId,
                InstrumentId = instrument1.InstrumentId,
                Quantity = 2
            };

            OrderInstrument orderInstrument3 = new()
            {
                OrderId = order1.OrderId,
                InstrumentId = instrument2.InstrumentId,
                Quantity = 2
            };

            OrderInstrument orderInstrument4 = new()
            {
                OrderId = order3.OrderId,
                InstrumentId = instrument3.InstrumentId,
                Quantity = 2
            };

            OrderInstrument orderInstrument5 = new()
            {
                OrderId = order3.OrderId,
                InstrumentId = instrument1.InstrumentId,
                Quantity = 2
            };

            // OrderInstrument
            builder.Entity<OrderInstrument>(entity =>
            {
                entity.ToTable(nameof(OrderInstrument));

                entity.HasKey(e => new { e.OrderId, e.InstrumentId });
                entity.Property(e => e.Quantity).IsRequired();

                entity.HasOne(e => e.OrderIdNavigation)
                    .WithMany(o => o.OrderInstruments)
                    .HasForeignKey(e => e.OrderId);

                entity.HasOne(e => e.InstrumentIdNavigation)
                    .WithMany(o => o.OrderInstruments)
                    .HasForeignKey(e => e.InstrumentId);

                entity.HasData(orderInstrument1, orderInstrument2, orderInstrument3, orderInstrument4, orderInstrument5);
            });

            Review review1 = new Review
            {
                ReviewId = 1,
                Content = "very good instrument",
                Image = System.IO.File.ReadAllBytes(@"C:\Users\adria\source\repos\MAS_Final_Music_Store\Images\yamaha-logo.jpg"),
                Date = DateTime.Today.AddDays(-2),
                Rating = 4.8,
                WasEdited = false,
                CustomerId = person1.PersonId,
                InstrumentId = instrument1.InstrumentId
            };

            Review review2 = new Review
            {
                ReviewId = 2,
                Content = "The best instrument",
                Image = null,
                Date = DateTime.Today.AddDays(-2),
                Rating = 4.7,
                WasEdited = false,
                CustomerId = person2.PersonId,
                InstrumentId = instrument1.InstrumentId
            };

            Review review3 = new Review
            {
                ReviewId = 3,
                Content = "very good and good and good instrument",
                Image = null,
                Date = DateTime.Today.AddDays(-1),
                Rating = 4.8,
                WasEdited = false,
                CustomerId = person1.PersonId,
                InstrumentId = instrument1.InstrumentId
            };

            Review review4 = new Review
            {
                ReviewId = 4,
                Content = "very good and good and good instrument",
                Image = null,
                Date = DateTime.Today.AddDays(-5),
                Rating = 4.4,
                WasEdited = false,
                CustomerId = person1.PersonId,
                InstrumentId = instrument3.InstrumentId
            };

            // Review
            builder.Entity<Review>(entity => 
            {
                entity.ToTable(nameof(Review));

                entity.HasKey(e => e.ReviewId);
                entity.Property(e => e.ReviewId).ValueGeneratedOnAdd();
                entity.Property(e => e.Content).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Rating).IsRequired();
                entity.Property(e => e.WasEdited).IsRequired();

                entity.HasOne(e => e.CustomerIdNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(e => e.CustomerId);

                entity.HasOne(e => e.InstrumentIdNavigation)
                    .WithMany(i => i.Reviews)
                    .HasForeignKey(e => e.InstrumentId);

                entity.HasData(review1, review2, review3, review4);
            });

            Event event1 = new Event
            {
                EventId = 1,
                Place = "place1",
                Start = DateTime.Today.AddDays(3),
                Finish = DateTime.Today.AddDays(6),
                Price = 30
            };

            Event event2 = new Event
            {
                EventId = 2,
                Place = "place2",
                Start = DateTime.Today.AddDays(5),
                Finish = DateTime.Today.AddDays(8),
                Price = 30
            };

            // Event
            builder.Entity<Event>(entity =>
            {
                entity.ToTable(nameof(Event));

                entity.HasKey(e => e.EventId);
                entity.Property(e => e.EventId).ValueGeneratedOnAdd();
                entity.Property(e => e.Place).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Start).IsRequired();
                entity.Property(e => e.Finish).IsRequired();
                entity.Property(e => e.Price).IsRequired();

                entity.HasData(event1, event2);
            });

            TeamEvent teamEvent1 = new TeamEvent
            {
                TeamEventId = 1,
                TeamId = 1,
                EventId = 1,
                DutiesDesc = "teamevent 1 1"
            };

            TeamEvent teamEvent2 = new TeamEvent
            {
                TeamEventId = 2,
                TeamId = 2,
                EventId = 2,
                DutiesDesc = "teamevent 2 2"
            };

            TeamEvent teamEvent3 = new TeamEvent
            {
                TeamEventId = 3,
                TeamId = 2,
                EventId = 1,
                DutiesDesc = "teamevent 2 1"
            };

            // TeamEvent
            builder.Entity<TeamEvent>(entity => {
                entity.ToTable(nameof(ITeamEventRepository));

                entity.HasKey(e => e.TeamEventId);
                entity.Property(e => e.TeamEventId).ValueGeneratedOnAdd();
                entity.Property(e => e.DutiesDesc).IsRequired().HasMaxLength(1000);

                entity.HasOne(e => e.TeamIdNavigation)
                    .WithMany(t => t.TeamEvents)
                    .HasForeignKey(e => e.TeamId);


                entity.HasOne(e => e.EventIdNavigation)
                    .WithMany(t => t.TeamEvents)
                    .HasForeignKey(e => e.EventId);

                entity.HasData(teamEvent1, teamEvent2, teamEvent3);
            });

            EventInstrument eventInstrument1 = new EventInstrument
            {
                EventId = 1,
                InstrumentId = 1,
                Quantity = 3
            };

            EventInstrument eventInstrument2 = new EventInstrument
            {
                EventId = 1,
                InstrumentId = 2,
                Quantity = 2
            };

            EventInstrument eventInstrument3 = new EventInstrument
            {
                EventId = 2,
                InstrumentId = 1,
                Quantity = 2
            };

            // EventInstrument
            builder.Entity<EventInstrument>(entity => {
                entity.ToTable(nameof(EventInstrument));

                entity.HasKey(e => new { e.EventId, e.InstrumentId});
                entity.Property(e => e.Quantity).IsRequired();

                entity.HasOne(e => e.InstrumentIdNavigation)
                    .WithMany(i => i.EventInstruments)
                    .HasForeignKey(e => e.InstrumentId);

                entity.HasOne(e => e.EventIdNavigation)
                    .WithMany(ev => ev.EventInstruments)
                    .HasForeignKey(e => e.EventId);

                entity.HasData(eventInstrument1, eventInstrument2, eventInstrument3);
            });

           
        }

    }
}
