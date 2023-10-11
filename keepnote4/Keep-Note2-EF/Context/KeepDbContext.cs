using Keep_Note4.Model;
using Microsoft.EntityFrameworkCore;

namespace Keep_Note4.Context
{
    public class KeepDbContext : DbContext
    {
        public KeepDbContext(DbContextOptions<KeepDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(c => c.category)
                .WithMany(p => p.notes)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Note>()
                .HasOne(c => c.reminder)
                .WithMany(p => p.notes)
                .HasForeignKey(c => c.ReminderId);

            modelBuilder.Entity<Note>()
                .HasOne(c => c.user)
                .WithMany(p => p.notes)
                .HasForeignKey(c => c.CreatedBy);

            modelBuilder.Entity<User>()
            .Property(u => u.UserId)
            .ValueGeneratedNever();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }



        public DbSet<Note> notes { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Reminder> reminders { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
