using WorkersWages.API.Storage.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace WorkersWages.API.Storage
{
    public class DataContext : IdentityDbContext<User, UserRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Manufactory> Manufactories { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Wage> Wages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("workers_wages");

            modelBuilder.Entity<Profession>().HasIndex(i => new { i.Name }).IsUnique();
            modelBuilder.Entity<Manufactory>().HasIndex(i => new { i.Number }).IsUnique();
            modelBuilder.Entity<Wage>().HasIndex(i => new { i.WorkerLastName }).IsUnique();
            modelBuilder.Entity<Schedule>().HasIndex(i => new { i.ManufactoryId, i.WeekDay }).IsUnique();

            _Seed(modelBuilder);
        }

        private void _Seed(ModelBuilder modelBuilder)
        {
            var now = DateTimeOffset.Now;

            modelBuilder.Entity<Manufactory>().HasData(
                new Manufactory() { Id = 1, Name = "Цех #1", Number = "1", HeadFIO = "Пупкин Арсений Викторович", Created = now, Updated = now }
                );

            modelBuilder.Entity<Profession>().HasData(
                new Profession() { Id = 1, Name = "Слесарь", Created = now, Updated = now },
                new Profession() { Id = 2, Name = "Токарь", Created = now, Updated = now },
                new Profession() { Id = 3, Name = "Сварщик", Created = now, Updated = now }
                );

            modelBuilder.Entity<Salary>().HasData(
                new Salary() { Id = 1, ProfessionId = 1, Rank = 1, Amount = 100, Created = now, Updated = now },
                new Salary() { Id = 2, ProfessionId = 1, Rank = 2, Amount = 200, Created = now, Updated = now },
                new Salary() { Id = 3, ProfessionId = 1, Rank = 3, Amount = 250, Created = now, Updated = now },

                new Salary() { Id = 4, ProfessionId = 2, Rank = 1, Amount = 150, Created = now, Updated = now },
                new Salary() { Id = 5, ProfessionId = 2, Rank = 2, Amount = 200, Created = now, Updated = now },

                new Salary() { Id = 6, ProfessionId = 3, Rank = 1, Amount = 200, Created = now, Updated = now },
                new Salary() { Id = 7, ProfessionId = 3, Rank = 2, Amount = 300, Created = now, Updated = now }
                );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule()
                {
                    Id = 1,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Monday,
                    WorkingStart = new TimeSpan(8, 30, 0),
                    WorkingEnd = new TimeSpan(17, 30, 0),
                    BreakStart = new TimeSpan(12, 0, 0),
                    BreakEnd = new TimeSpan(13, 0, 0),
                    Created = now,
                    Updated = now
                },

                new Schedule()
                {
                    Id = 2,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Tuesday,
                    WorkingStart = new TimeSpan(8, 30, 0),
                    WorkingEnd = new TimeSpan(17, 30, 0),
                    BreakStart = new TimeSpan(12, 0, 0),
                    BreakEnd = new TimeSpan(13, 0, 0),
                    Created = now,
                    Updated = now
                },

                new Schedule()
                {
                    Id = 3,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Wednesday,
                    WorkingStart = new TimeSpan(8, 30, 0),
                    WorkingEnd = new TimeSpan(17, 30, 0),
                    BreakStart = new TimeSpan(12, 0, 0),
                    BreakEnd = new TimeSpan(13, 0, 0),
                    Created = now,
                    Updated = now
                },

                new Schedule()
                {
                    Id = 4,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Thursday,
                    WorkingStart = new TimeSpan(8, 30, 0),
                    WorkingEnd = new TimeSpan(17, 30, 0),
                    BreakStart = new TimeSpan(12, 0, 0),
                    BreakEnd = new TimeSpan(13, 0, 0),
                    Created = now,
                    Updated = now
                },

                new Schedule()
                {
                    Id = 5,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Friday,
                    WorkingStart = new TimeSpan(8, 30, 0),
                    WorkingEnd = new TimeSpan(17, 30, 0),
                    BreakStart = new TimeSpan(12, 0, 0),
                    BreakEnd = new TimeSpan(13, 0, 0),
                    Created = now,
                    Updated = now
                },

                new Schedule()
                {
                    Id = 6,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Saturday,
                    Created = now,
                    Updated = now
                },

                new Schedule()
                {
                    Id = 7,
                    ManufactoryId = 1,
                    WeekDay = WeekDays.Sunday,
                    Created = now,
                    Updated = now
                }
                );
        }
    }
}
