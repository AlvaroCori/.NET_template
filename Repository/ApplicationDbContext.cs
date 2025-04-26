using Microsoft.EntityFrameworkCore;
using template_dotnet.Models;

namespace template_dotnet.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ExampleModel> ExampleModels { get; set; }
    }
}
