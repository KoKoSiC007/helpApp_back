using Microsoft.EntityFrameworkCore;
using SupService.Models.Client;
using SupService.Models.Message;
using SupService.Models.Organization;
using SupService.Models.Project;
using SupService.Models.ProjectStaffMan;
using SupService.Models.Stuff;
using SupService.Models.Ticket;

namespace SupService
{
    public class SupServiceContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Stuff> Managers { get; set; }
        public DbSet<ProjectStuffMan> ProjectStuffMans { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Message> Messages { get; set; }
        
        public SupServiceContext(DbContextOptions<SupServiceContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=sup_development;Username=kokos;Password=234492");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasMany(b => b.Clients)
                .WithOne(c => c.Organization);
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Organization)
                .WithMany(org=>org.Clients);
            modelBuilder.Entity<ProjectStuffMan>()
                .HasKey(bc => new { bc.StaffId, bc.ProjectId });  
            modelBuilder.Entity<ProjectStuffMan>()
                .HasOne(bc => bc.Manager)
                .WithMany(b => b.Projects)
                .HasForeignKey(bc => bc.StaffId);  
            modelBuilder.Entity<ProjectStuffMan>()
                .HasOne(bc => bc.Project)
                .WithMany(c => c.Managers)
                .HasForeignKey(bc => bc.ProjectId);
        }
    }
}