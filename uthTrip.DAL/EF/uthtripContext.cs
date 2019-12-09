namespace UthTrip.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using UthTrip.DAL.Entities;
    /////using Microsoft.EntityFrameworkCore;
    public partial class UthTripContext : DbContext
    {
        private string connectionString;

        public UthTripContext(string conString)
        {
            this.connectionString = conString;
        }

        public UthTripContext()
            : base("name=UthTripContext")
        {
        }

        public virtual DbSet<Blocked_Users> Blocked_Users { get; set; }

        public virtual DbSet<Dates_ranges> Dates_ranges { get; set; }

        public virtual DbSet<Destination> Destinations { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Right> Rights { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Trip> Trips { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<ImageEntity> ImageEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dates_ranges>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.Dates_ranges)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Destination>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.Destination)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Review>()
                .Property(e => e.Review1)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Rights)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.Trip_Title)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.Rights)
                .WithRequired(e => e.Trip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Photo_Url)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Info)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Writer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Rights)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Trips)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Creator_ID)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ImageEntity>()
            //    .HasMany(e => e.users)
            //     .WithRequired(e => e.image)
            //     .HasForeignKey(e => e.User_ID);

        }
    }
}
