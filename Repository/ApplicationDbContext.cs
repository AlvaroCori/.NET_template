using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Principal;
using template_dotnet.Models;

namespace template_dotnet.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IModel).IsAssignableFrom(t));

            foreach (var type in entityTypes)
            {
                var entity = modelBuilder.Entity(type);

                if (type.GetProperty("Id") != null)
                {
                    entity.Property("Id").HasColumnName("id");
                    entity.HasKey("Id");
                }
            }

            modelBuilder.Entity<SSRExampleModel>(entity =>
            {
                entity.HasOne(e => e.UbicationModel)
                      .WithMany(e => e.Ubications)
                      .HasForeignKey(e => e.StateId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<T> Set<T>() where T : class => base.Set<T>();
    }
}