using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using NormasService.Domain.Entities;
using NormasService.Infrastructure.Database.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace NormasService.Infrastructure.Database
{
    [ExcludeFromCodeCoverage]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Norma>(new NormaDbMap().Configure);

            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Norma> Norma { get; set; }
    }
}
